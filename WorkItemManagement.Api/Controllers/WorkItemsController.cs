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
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWorkItemDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = new WorkItem
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = false
            };

            var created = await _service.CreateAsync(item);

            return CreatedAtAction(nameof(GetById), new {id = created.Id},created);
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
