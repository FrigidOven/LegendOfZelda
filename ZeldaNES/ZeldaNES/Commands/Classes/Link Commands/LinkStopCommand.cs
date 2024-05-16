
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkStopCommand : ICommand
    {
        private IRegion region;
        public LinkStopCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].Stop();
        }
    }
}
