using System;
using System.Collections.Generic;
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
    public class GameQuitCommand : ICommand
    {
        private IRegion region;
        public GameQuitCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            GameState.Instance.gameRef.Exit();
        }
    }
}
