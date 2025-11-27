using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMDCheckSheet.Dtos;
using SMDCheckSheet.Services;
using SMDCheckSheet.Models;


namespace SMDCheckSheet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChangeModelController : ControllerBase
    {
        private readonly ChangeModelService _service;

        public ChangeModelController(ChangeModelService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChangeModelReadDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChangeModelReadDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        //list ChangeModel by status
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<ChangeModelReadDto>>> GetByStatus(string status)
        {
            var result = await _service.GetByStatusAsync(status);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // Update status ChangeModel by Id
        [HttpPut("status/{id}")]
        public async Task<ActionResult<ChangeModel>> UpdateStatus (int id, ChangeModelStatusUpdateDto dto)
        {
            var result = await _service.UpdateStatusAsync(id, dto.Status);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult<ChangeModelReadDto>> Create(ChangeModelCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
