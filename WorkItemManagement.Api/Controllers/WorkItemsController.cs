using Microsoft.AspNetCore.Mvc;
using WorkItemManagement.Api.Services;
using WorkItemManagement.Api.Models;
using WorkItemManagement.Api.DTOs;

namespace WorkItemManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkItemsController : ControllerBase
    {
        private readonly IWorkItemService _workItemService;

        public WorkItemsController(IWorkItemService workItemService)
        {
            _workItemService = workItemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _workItemService.GetAllWorkItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _workItemService.GetWorkItemById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateWorkItemDto dto)
        {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var createditem = _workItemService.CreateWorkItem(dto.Title, dto.Description);
            return Ok(createditem);
        }

        [HttpPost("{id}/complete")]
        public IActionResult MarkComplete(int id)
        {
            _workItemService.MarkAsCompleted(id);
            return NoContent();
        }
    }
}
