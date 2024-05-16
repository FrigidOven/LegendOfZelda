

using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkUseBombCommand : ICommand
    {
        private IRegion region;
        public LinkUseBombCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].UseBomb();
        }
    }
}
