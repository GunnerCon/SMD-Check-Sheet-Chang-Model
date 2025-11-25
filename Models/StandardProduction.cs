using System;

namespace SMDCheckSheet.Models
{
    public class StandardProduction
    {
        public int Id { get; set; }
        public string NumMASK { get; set; }
        public string NumMES { get; set; }
        public int NumScanPrinter { get; set; }
        public int NumScanSignMES { get; set; }
        public string MLS3Closed { get; set; }
        public string UseOnly {  get; set; }
        public string LabelProgram { get; set; }
    }
}
