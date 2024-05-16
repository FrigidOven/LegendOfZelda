using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.Items
{
    public interface IMonetaryItem : IItem
    {
        public int Value { get; set; }
    }
}
