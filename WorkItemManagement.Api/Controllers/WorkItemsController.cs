using Microsoft.AspNetCore.Mvc;
using WorkItemManagement.Api.Dtos;
using WorkItemManagement.Api.DTOs;
using WorkItemManagement.Api.Models;
using WorkItemManagement.Api.Services;

namespace WorkItemManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkItemsController : ControllerBase
    {
        private readonly IWorkItemService _service;

        public WorkItemsController(IWorkItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();

            var response = items.Select(x => new WorkItemResponseDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsCompleted = x.IsCompleted,
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if(item  == null)
            {
                return NotFound();
            }

            var resposne = new WorkItemResponseDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
            };

            return Ok(resposne);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWorkItemDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = new WorkItem
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = false
            };

            var created = await _service.CreateAsync(item);

            var response = new WorkItemResponseDto
            {
                Id = created.Id,
                Title = created.Title,
                Description = created.Description,
                IsCompleted = created.IsCompleted
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = response.Id },
                response
            );
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateWorkItemDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = new WorkItem
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted
            };

            var updated = await _service.UpdateAsync(id, item);

            if (!updated)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
