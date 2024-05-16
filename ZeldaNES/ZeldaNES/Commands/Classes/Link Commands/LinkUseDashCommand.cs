

using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkUseDashCommand : ICommand
    {
        private IRegion region;
        public LinkUseDashCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].Dash();
        }
    }
}
