using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMDCheckSheet.Dtos;
using SMDCheckSheet.Models;
using SMDCheckSheet.Services;

namespace SMDCheckSheet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TimeChangeModelController : ControllerBase
    {
        private readonly TimeChangeModelService _service;

        public TimeChangeModelController(TimeChangeModelService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeChangeModelReadDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeChangeModelReadDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TimeChangeModelReadDto>> Create(TimeChangeModelCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TimeChangeModelUpdateDto>> Update(int id , TimeChangeModelUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id,dto);
            if (result == null) return NotFound();
            return Ok(result);
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
