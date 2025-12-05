using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMDCheckSheet.Dtos;
using SMDCheckSheet.Services;
using SMDCheckSheet.Models;
using Microsoft.AspNetCore.Authorization;


namespace SMDCheckSheet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ChangeModelController : ControllerBase
    {
        private readonly ChangeModelService _service;
        private readonly AccountService _accountService;

        public ChangeModelController(ChangeModelService service, AccountService accountService)
        {
            _service = service;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChangeModelReadDto>>> GetAll()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi GetAll: " + ex.Message);
                return StatusCode(500, "Lỗi server khi lấy danh sách.");
            }
        }

        [HttpGet("object/{id}")]
        public async Task<ActionResult<ChangeModelReadObjectDto>> GetAllWithObject(int id)
        {
            var result = await _service.GetAllWithObjectAsync(id);
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

        [Authorize(Roles = "ENG")]
        [HttpPost()]
        public async Task<ActionResult<ChangeModelReadDto>> Create(ChangeModelCreateDto dto)
        {
            var accountId = int.Parse(User.FindFirst("uid")?.Value);

            var account = await _accountService.GetByIdAsync(accountId);
            if (account == null) return BadRequest("Tài khoản không tồn tại");

            var result = await _service.CreateAsync(dto, accountId);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("upload-files")]
        public async Task<IActionResult> UploadFiles(IFormFile file, int changeModelId)
        {
            var fileUrl = await _service.UploadFileAsync(file, changeModelId);
            return Ok(new { url = fileUrl });
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<ChangeModelReadDto>>> Filter([FromQuery]ChangeModelFilterDto filter)
        {
            var result = await _service.FilterByDateAsync(filter.FromDate, filter.ToDate);
            return Ok(result);
        }

        [HttpGet("workorder/{workOrder}")]
        public async Task<ActionResult<IEnumerable<ChangeModelReadDto>>> GetByWorkOrder(string workOrder)
        {
            var result = await _service.GetByWorkOrderAsync(workOrder);
            return Ok(result);
        }

    }
}
