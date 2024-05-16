using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ZeldaNES.GameStates;
using ZeldaNES.Items;
using ZeldaNES.Regions;
using ZeldaNES.Screens;
using ZeldaNES.Sprint2;
namespace ZeldaNES.Commands.Classes.GameCommands
{
    public class NextArea : ICommand
    {
        private IRegion obj;
        public NextArea(IRegion obj)
        {
            this.obj = obj;
        }
        public void Execute()
        {
            if (GameState.Instance.EditorMode)
            {
                obj.Next();
            }
        }
    }
}
