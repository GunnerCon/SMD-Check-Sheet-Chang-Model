using System;

namespace SMDCheckSheet.Models
{
    public class PQCCheck
    {
        public int Id { get; set; }
        public string ICPlan { get; set; }
        public string ChecksumReal { get; set; }
        public string ChecksumConfirm { get; set; }
        public string Turner { get; set; }
        public TimeSpan StartLCR { get; set; }
        public TimeSpan EndLCR { get; set; }
        public string NameCheck { get; set; }
        public bool ResultLCR { get; set; }
    }
}
