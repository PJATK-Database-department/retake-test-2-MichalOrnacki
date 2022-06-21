using System;
using System.Collections.Generic;

#nullable disable

namespace ApbdTest2.Models
{
    public partial class Action
    {
        public Action()
        {
            FirefighterActions = new HashSet<FirefighterAction>();
            FiretruckActions = new HashSet<FiretruckAction>();
        }

        public int IdAction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool NeedSpecialEquipment { get; set; }

        public virtual ICollection<FirefighterAction> FirefighterActions { get; set; }
        public virtual ICollection<FiretruckAction> FiretruckActions { get; set; }
    }
}
