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
        public int StandardProductionId { get; set; }
        public int StandardVehicleId { get; set; }
        public int TimeChangeModelId { get; set; }
        public int PQCCheckId { get; set; }
        public string Status { get; set; } // {PQCDone, ENGDone, SupervisorDone, ManagerDone, ManagerKoreaDone}


        public CheckModel CheckModel { get; set; }
        public ProgramCheck ProgramCheck { get; set; }
        public StandardProduction StandardProduction { get; set; }
        public StandardVehicle StandardVehicle { get; set; }
        public TimeChangeModel TimeChangeModel { get; set; }
        public PQCCheck PQCCheck { get; set; }
    }
}