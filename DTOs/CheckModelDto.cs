using System;

namespace SMDCheckSheet.Dtos
{
    public class CheckModelCreateDto
    {
        public string? LineChange { get; set; }
        public string? Model { get; set; }
        public string? FCode { get; set; }
        public string? PCBver { get; set; }
        public string? WorkOrder { get; set; }
        public bool? UsedCNcard { get; set; }
        public string RevS15 { get; set; }
        public string RevMounter { get; set; }
        public int? Qty { get; set; }
        public DateTime? FeederCheck { get; set; }
        public DateTime? OPAccept { get; set; }
        public bool? JIG { get; set; }
        public string? CodePCB { get; set; }
    }

   public class CheckModelReadDto
   {
        public int Id { get; set; }
        public string LineChange { get; set; }
        public string Model { get; set; }
        public string FCode { get; set; }
        public string PCBver { get; set; }
        public string WorkOrder { get; set; }
        public bool UsedCNcard { get; set; }
        public string RevS15 { get; set; }
        public string RevMounter { get; set; }
        public int Qty { get; set; }
        public DateTime FeederCheck { get; set; }
        public DateTime OPAccept { get; set; }
        public bool JIG { get; set; }
        public string CodePCB { get; set; }
   }

    public class CheckModelUpdateDto
    {
        public string? LineChange { get; set; }
        public string? Model { get; set; }
        public string? FCode { get; set; }
        public string? PCBver { get; set; }
        public string? WorkOrder { get; set; }
        public bool? UsedCNcard { get; set; }
        public string? RevS15 { get; set; }
        public string? RevMounter { get; set; }
        public int? Qty { get; set; }
        public DateTime? FeederCheck { get; set; }
        public DateTime? OPAccept { get; set; }
        public bool? JIG { get; set; }
        public string? CodePCB { get; set; }
    }


    public class CheckModelMinimalCreateDto
    {
        public string? Status { get; set; }
    }
}