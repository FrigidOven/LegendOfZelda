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
    public class AddArea : ICommand
    {
        private IRegion obj;
        public AddArea(IRegion obj)
        {
            this.obj = obj;
        }
        public void Execute()
        {
            if (GameState.Instance.EditorMode)
            {
                obj.GetRegionEditor().AddArea();
            }
        }
    }
}
