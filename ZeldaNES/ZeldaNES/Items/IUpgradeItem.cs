using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.Items
{
    public interface IUpgradeItem : IItem
    {
        public GeneralConstants.UpgradeClasses GetUpgradeClass() {
            return GeneralConstants.UpgradeClasses.None;
        }
        public int GetLevel() {
            return 0;
        }
    }
}
