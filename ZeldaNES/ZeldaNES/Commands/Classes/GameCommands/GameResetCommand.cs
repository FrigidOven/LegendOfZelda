using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.GameStates;
using ZeldaNES.Regions;
using ZeldaNES.Screens;

namespace ZeldaNES.Commands.Classes.GameCommands
{
    public class GameResetCommand : ICommand
    {
        private IRegion region;
        public GameResetCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            GameState.Instance.WinMode = false;
            GameState.Instance.deathMode = false;
            GameState.Instance.gameRef.Reset();
            GameState.Instance.StartMenuMode = true;
            
        }
    }
}
