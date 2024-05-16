

using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkUseClockCommand : ICommand
    {
        private IRegion region;
        public LinkUseClockCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].useClock();
        }
    }
}
