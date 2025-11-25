namespace SMDCheckSheet.Dtos
{
    public class ProgramCheckCreateDto
    {
        public string? PrinterProgram { get; set; }
        public string? SPIProgram { get; set; }
        public string? MounterProgram { get; set; }
        public int? PointMounter { get; set; }
        public string? MOAIProgram { get; set; }
        public string? SOAIProgram { get; set; }
        public int? PointSOAI { get; set; }
        public string? ReflowProgram { get; set; }
        public int? ReflowSpeed { get; set; }
    }

    public class ProgramCheckReadDto
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

    public class ProgramCheckUpdateDto
    {
        public string? PrinterProgram { get; set; }
        public string? SPIProgram { get; set; }
        public string? MounterProgram { get; set; }
        public int? PointMounter { get; set; }
        public string? MOAIProgram { get; set; }
        public string? SOAIProgram { get; set; }
        public int? PointSOAI { get; set; }
        public string? ReflowProgram { get; set; }
        public int? ReflowSpeed { get; set; }
    }
}
