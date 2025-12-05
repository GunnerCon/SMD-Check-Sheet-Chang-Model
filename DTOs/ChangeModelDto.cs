using System.ComponentModel.DataAnnotations;
using SMDCheckSheet.Models;

namespace SMDCheckSheet.Dtos
{
    public class ChangeModelCreateDto
    {
        public int CheckModelId { get; set; }
        public int ProgramCheckId { get; set; }
        public int StandardProductionId { get; set; }
        public int StandardVehicleId { get; set; }
        public int TimeChangeModelId { get; set; }
        public int PQCCheckId { get; set; }
        public string Status { get; set; }
        public string? ExcelFileUrl { get; set; }
        public string? PdfFileUrl { get; set; }
        public int AccountId { get; set; }
        public DateTime CreateAt { get; set; }
    }

    public class ChangeModelReadDto : ChangeModelCreateDto
    {
        public int Id { get; set; }
    }

    public class ChangeModelReadObjectDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string ExcelFileUrl { get; set; }
        public string PdfFileUrl { get; set; }
        public DateTime CreateAt { get; set; }

        public CheckModel CheckModel { get; set; }
        public ProgramCheck ProgramCheck { get; set; }
        public StandardProduction StandardProduction { get; set; }
        public StandardVehicle StandardVehicle { get; set; }
        public TimeChangeModel TimeChangeModel { get; set; }
        public PQCCheck PQCCheck { get; set; }
        public Account Account { get; set; }
    }

    public class ChangeModelUploadDto
    {
        public int Id { get; set; }
        public IFormFile? PdfFile { get; set; }
        public IFormFile? ExcelFile { get; set; }
    }

    public class ChangeModelStatusUpdateDto
    {
        public string Status { get; set; } = "Pending";
    }

    public class ChangeModelFilterDto
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }

}
