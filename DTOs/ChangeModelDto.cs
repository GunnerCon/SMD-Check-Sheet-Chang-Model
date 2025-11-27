namespace SMDCheckSheet.Dtos
{
    public class ChangeModelCreateDto
    {
        public int CheckModelId { get; set; }
        public int ProgramCheckId { get; set; }
        public int StandardProductId { get; set; }
        public int StandardVehicleId { get; set; }
        public int TimeChangeModelId { get; set; }
        public int PQCCheckId { get; set; }
        public string Status { get; set; }
    }

    public class ChangeModelReadDto : ChangeModelCreateDto
    {
        public int Id { get; set; }
    }

    public class ChangeModelStatusUpdateDto
    {
        public string Status { get; set; } = "Pending";
    }


}
