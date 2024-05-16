

using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkUseMetalArrowCommand : ICommand
    {
        private IRegion region;
        public LinkUseMetalArrowCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].UseMetalArrow();
        }
    }
}
