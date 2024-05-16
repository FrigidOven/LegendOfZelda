using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.GameCommands
{
    public class CheatDonothing : ICommand
    {
        private IRegion region;
        public CheatDonothing(IRegion region)
        {
            this.region = region;
        }
        public void Execute()
        {
            return;
        }
    }
}
