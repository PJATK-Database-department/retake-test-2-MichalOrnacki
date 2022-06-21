using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApbdTest2.Dtos
{
    public class GetFiretruckResponse
    {
        public Truck truck { get; set; }
        public List<FireAction> actionsList { get; set; }
    }

    public class Truck
    {
        public int IdFireTruck { get; set; }
        public string OperationalNumber { get; set; }
        public bool SpecialEquipment { get; set; }

    }

    public class FireAction
    {
        public int IdAction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool NeedSpecialEquipment { get; set; }
        public int Firefighters { get; set; }
        public DateTime FiretruckAssignedDate { get; set; }
    }
}
