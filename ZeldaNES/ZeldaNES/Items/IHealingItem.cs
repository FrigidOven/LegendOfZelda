using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZeldaNES.Players.Link;

namespace ZeldaNES.Items
{
    public interface IHealingItem : IItem
    {
        int HealAmount { get; set; }
        public void UseItem(ILink link) {
            link.Health += HealAmount;
            if (link.Health > link.HealthCapacity) {
                link.Health = link.HealthCapacity;
            }
        }
    }
}
