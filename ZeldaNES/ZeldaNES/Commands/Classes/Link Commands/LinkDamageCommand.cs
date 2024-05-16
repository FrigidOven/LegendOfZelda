
using ZeldaNES.Regions;


namespace ZeldaNES.Commands.Classes.Link_Commands
{
    public class LinkDamageCommand : ICommand
    {
        private IRegion region;
        public LinkDamageCommand(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            region.players[0].Health = region.players[0].Health - 1;
            region.players[0].IsTakingDamage = true;
        }
    }
}
