using ZeldaNES.Regions;

namespace ZeldaNES.Commands.Classes.GameCommands;
public class EnemyAICommand : ICommand
{
    private IRegion region;

    public EnemyAICommand(IRegion region)
    {
        this.region = region;
    }

    public void Execute()
    {
        var playerArea = region.Areas[region.AreaIndex];

        foreach (var player in region.players)
        { 
            foreach (var enemy in playerArea.Enemies)
            {
                enemy.AIMovement(player);
            }
        }
    }
}