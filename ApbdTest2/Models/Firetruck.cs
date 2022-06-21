using System;
using System.Collections.Generic;

#nullable disable

namespace ApbdTest2.Models
{
    public partial class Firetruck
    {
        public Firetruck()
        {
            FiretruckActions = new HashSet<FiretruckAction>();
        }

        public int IdFireTruck { get; set; }
        public string OperationalNumber { get; set; }
        public bool SpecialEquipment { get; set; }

        public virtual ICollection<FiretruckAction> FiretruckActions { get; set; }
    }
}
