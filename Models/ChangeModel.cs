using System;
using SMDCheckSheet.Models;

namespace SMDCheckSheet.Models
{
    public class ChangeModel
    {
        public int Id { get; set; }

        // Khóa ngoại đến các model khác
        public int CheckModelId { get; set; }
        public int ProgramCheckId { get; set; }
        public int StandardProductId { get; set; }
        public int StandardVehicleId { get; set; }
        public int TimeChangeModelId { get; set; }
        public int PQCCheckId { get; set; }
        public string Status { get; set; } //


        public CheckModel CheckModel { get; set; }
        public ProgramCheck ProgramCheck { get; set; }
        public StandardProduction StandardProduct { get; set; }
        public StandardVehicle StandardVehicle { get; set; }
        public TimeChangeModel TimeChangeModel { get; set; }
        public PQCCheck PQCCheck { get; set; }
    }
}
