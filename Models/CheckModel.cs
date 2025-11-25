using System;

namespace SMDCheckSheet.Models
{
    public class CheckModel
    {
        public int Id { get; set; }
        public string? LineChange { get; set; }
        public string? Model { get; set; }
        public string? FCode { get; set; }
        public string? PCBver {  get; set; }
        public string? WorkOrder { get; set; }
        public bool UsedCNcard { get; set; } = false;
        public int? Qty { get; set; }
        public DateTime FeederCheck { get; set; }
        public DateTime OPAccept { get; set; }
        public bool JIG { get; set; } = false;
        public string? CodePCB {  get; set; }
    }
}
