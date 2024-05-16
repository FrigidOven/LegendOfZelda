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
    public class OpenPauseMenuCommand : ICommand
    {
        private IRegion region;
        public OpenPauseMenuCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            if (GameState.Instance.PauseScreenMode)
            {
                GameState.Instance.PauseScreenMode = false;

            }
            else {
                GameState.Instance.PauseScreenMode = true;

            }
        }
    }
}
