using System;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Factories;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs.Classes.WallMaster.States;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;

namespace ZeldaNES.NPCs.Classes.WallMaster
{
    public class WallMasterEnemy : INPC
    {
        private ISprite sprite;

        private IEnemyPhysicsObject body;

        private IWallMasterState state;

        public WallMasterEnemy(int posX, int posY)
        {
            body = new EnemyPhysicsObject(posX, posY, 3);

            sprite = new WallMasterSprite(this);

            state = new WallMasterNormalState(this);
        }
        public WallMasterEnemy()
        {
            body = new EnemyPhysicsObject(0, 0, 3);

            sprite = new WallMasterSprite(this);

            state = new WallMasterNormalState(this);

        }

        public IEnemyPhysicsObject Body()
        {
            return body;
        }
        public void Update()
        {
            //sprite.Update();
            state.Update();
        }

        public void Draw()
        {
            sprite.Draw();
        }
        public int PosX
        {
            get => body.PosX;
            set => body.PosX = value;
        }
        public int PosY
        {
            get => body.PosY;
            set => body.PosY = value;
        }

        public void dropLoot(Region region)
        {
            ItemFactory.Instance.groupCLoot(PosX, PosY, region);
        }

        public void freeze()
        {
            state = new WallMasterFrozenState(this);
        }

        public void unfreeze()
        {
            state = new WallMasterNormalState(this);
        }

        public void AIMovement(ILink link)
        {
            // WallMaster is a stationary enemy
        }
    }
}
