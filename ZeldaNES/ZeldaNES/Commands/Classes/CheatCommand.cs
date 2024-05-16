using ZeldaNES.Regions;
using System.Diagnostics;
using ZeldaNES.NPCs;


namespace ZeldaNES.Commands.Classes.GameCommands
{
	public class CheatCommand : ICommand
	{
		private IRegion region;

		public CheatCommand(IRegion region)
		{
			this.region = region;
		}

		public void Execute(int i)
		{
            switch (i)
			{
                case 1:
					region.players[0].GetInventory().CheatAdd();
                    break;
                case 2:
					int index = region.AreaIndex;
					foreach (var enemy in region.Areas[index].Enemies){
						enemy.Body().Health -= 50;
                    }
                    break;
				case 3:
					region.players[0].Health = 6;
					break;
                case 4:
					region.players[0].IsAbleToDash = true;
                    break;
                default:
                    break;
            }
		}
		public void Execute()
		{
			
        }
	}
}
