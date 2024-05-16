

using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkSwingSwordCommand : ICommand
    {
        private IRegion region;
        public LinkSwingSwordCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].SwingSword();
        }
    }
}
