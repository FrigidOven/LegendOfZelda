using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;

namespace ZeldaNES.NPCs
{
    public interface INPC
    {
        void Update();
        IEnemyPhysicsObject Body();
        void Draw();
        int PosX { get; set; }
        int PosY {  get; set; }
        void drawDebug() {
            IEnemyPhysicsObject body = this.Body();
        }

        void dropLoot(Region region);

        void AIMovement(ILink link);

        void freeze();
        void unfreeze();
    }
}
