

using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkWalkDownCommand : ICommand
    {
        private IRegion region;
        public LinkWalkDownCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].WalkDown();
        }
    }
}
