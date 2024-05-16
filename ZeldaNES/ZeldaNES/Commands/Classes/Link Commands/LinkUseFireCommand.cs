

using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkUseFireCommand : ICommand
    {
        private IRegion region;
        public LinkUseFireCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].UseFire();
        }
    }
}
