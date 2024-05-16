

using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkWalkRightCommand : ICommand
    {
        private IRegion region;
        public LinkWalkRightCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].WalkRight();
        }
    }
}
