using System;

namespace SMDCheckSheet.Dtos
{
    public class TimeChangeModelCreateDto
    {
        public string? QC { get; set; }
        public string? Result { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? CountTime { get; set; }
        public string? History { get; set; }
    }

    public class TimeChangeModelUpdateDto : TimeChangeModelCreateDto { }
    

    public class TimeChangeModelReadDto : TimeChangeModelCreateDto
    {
        public int Id { get; set; }
    }
}
