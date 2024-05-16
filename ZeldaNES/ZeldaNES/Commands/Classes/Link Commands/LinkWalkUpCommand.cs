

using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkWalkUpCommand : ICommand
    {
        private IRegion region;
        public LinkWalkUpCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].WalkUp();
        }
    }
}
