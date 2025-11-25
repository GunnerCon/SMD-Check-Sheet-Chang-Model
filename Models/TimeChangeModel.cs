using System;

namespace SMDCheckSheet.Models
{
    public class TimeChangeModel
    {
        public int Id { get; set; }
        public string? QC { get; set; }
        public string? Result { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int? CountTime { get; set; }
        public string? History { get; set; }
    }
}
