namespace SMDCheckSheet.Dtos
{
    public class StandardVehicleCreateDto
    {
        public int? PrinterSpecGTAL { get; set; }
        public int? PrinterSpecTDQ { get; set; }
        public int? PrinterSpecTDKC { get; set; }
        public int? PrinterSpecDSL { get; set; }
        public int? PrinterRealTDQ { get; set; }
        public int? PrinterRealTDKC { get; set; }
        public int? PrinterRealDSL { get; set; }
        public bool? PrinterQ1 { get; set; }
        public bool? SPIQ1 { get; set; }
        public bool? MountQ1 { get; set; }
        public bool? MountQ2 { get; set; }
        public bool? ReflowQ1 { get; set; }
        public int? ReFlowSettingRail { get; set; }
        public int? ReFlowRealRail { get; set; }
        public bool? AOIQ1 { get; set; }
        public string? AOICheck { get; set; }
        public bool? OutputCheck { get; set; }
        public string? ModelValue { get; set; }
        public string? PitchValue { get; set; }
        public string? PitchReal { get; set; }
        public string? NameOP { get; set; }
        public string? NameAOI { get; set; }
    }

    public class StandardVehicleUpdateDto : StandardVehicleCreateDto { }

     public class StandardVehicleReadDto : StandardVehicleCreateDto
    {
        public int Id { get; set; }
    }
}