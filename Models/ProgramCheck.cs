using System;

namespace SMDCheckSheet.Models
{
    public class ProgramCheck // ← phải có từ khóa public
    {
        public int Id { get; set; }
        public string PrinterProgram { get; set; }
        public string SPIProgram { get; set; }
        public string MounterProgram { get; set; }
        public int PointMounter { get; set; }
        public string MOAIProgram { get; set; }
        public string SOAIProgram { get; set; }
        public int PointSOAI { get; set; }
        public string ReflowProgram { get; set; }
        public int ReflowSpeed { get; set; }
    }
}