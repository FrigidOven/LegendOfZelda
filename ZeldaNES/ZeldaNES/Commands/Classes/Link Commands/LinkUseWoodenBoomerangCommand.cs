

using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkUseWoodenBoomerangCommand : ICommand
    {
        private IRegion region;
        public LinkUseWoodenBoomerangCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].UseWoodenBoomerang();
        }
    }
}
