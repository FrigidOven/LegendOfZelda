using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ZeldaNES.GameStates;
using ZeldaNES.RegionFileGenerators;
using ZeldaNES.Regions;
using ZeldaNES.Screens;

namespace ZeldaNES.Commands.Classes.GameCommands
{
    public class GameEditModeCommand : ICommand
    {
        private IRegion region;
        public GameEditModeCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            if (GameState.Instance.EditorMode)
            {
                GameState.Instance.EditorMode = false;
            }
            else {
                GameState.Instance.EditorMode = true;
            }
        }
    }
}
