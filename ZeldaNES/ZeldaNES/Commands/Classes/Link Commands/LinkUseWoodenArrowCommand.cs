

using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkUseWoodenArrowCommand : ICommand
    {
        private IRegion region;
        public LinkUseWoodenArrowCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].UseWoodenArrow();
        }   
    }
}
