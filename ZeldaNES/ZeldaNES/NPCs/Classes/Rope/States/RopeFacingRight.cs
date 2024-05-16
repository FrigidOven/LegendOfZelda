using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;
using ZeldaNES.Sprites;
using System.Runtime.InteropServices;

namespace ZeldaNES.NPCs.Classes.Rope.States
{
    internal class RopeFacingRight : IRopeState
    {
        RopeEnemy owner;
        ISprite sprite;

        private int yMovement;
        private int xMovement;
        private bool triggered = false;

        private int directionChangeTimer;
        private readonly int direction = 1;
        private int currentspeed = EnemyConstants.RopeMovementSpeed;
        public RopeFacingRight(RopeEnemy owner)
        {
            this.owner = owner;
            this.sprite = new RopeSprite(owner);
            this.yMovement = 0;
            this.xMovement = 1;
            this.directionChangeTimer = 0;
        }

        public void Update()
        {
            this.sprite.Update();
            this.owner.PosX += xMovement * currentspeed;
            this.owner.PosY += yMovement * currentspeed;
            if (!triggered)
            {
                this.directionChangeTimer++;
                if (this.directionChangeTimer == 50)
                {
                    this.yMovement = -1;
                    this.xMovement = 0;
                }
            }
            
            
        }
        public void Chase()
        {
            this.directionChangeTimer = 0;
            this.triggered = true;
            this.currentspeed = EnemyConstants.ChasingSpeed;
            this.yMovement = 0;
            this.xMovement = 1;
        }
        public void Reset()
        {
            this.triggered = false;
            this.currentspeed = EnemyConstants.RopeMovementSpeed;
        }
        public int GetDirection()
        {
            return direction;
        }

        public void Draw()
        {
            this.sprite.Draw();
        }
    }
}
