
using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkUseMetalBoomerangCommand : ICommand
    {
        private IRegion region;
        public LinkUseMetalBoomerangCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].UseMetalBoomerang();
        }
    }
}
