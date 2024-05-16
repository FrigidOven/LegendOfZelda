
using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkWalkLeftCommand : ICommand
    {
        private IRegion region;
        public LinkWalkLeftCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].WalkLeft();
        }
    }
}
