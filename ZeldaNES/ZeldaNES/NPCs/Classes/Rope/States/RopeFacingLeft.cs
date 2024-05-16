using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;
using ZeldaNES.Game_Constants;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;


namespace ZeldaNES.NPCs.Classes.Rope.States
{
    internal class RopeFacingLeft : IRopeState
    {
        RopeEnemy owner;
        ISprite sprite;
        private int yMovement;
        private int xMovement;
        private int currentspeed = EnemyConstants.RopeMovementSpeed;
        private int directionChangeTimer;
        private bool triggered = false;
        private readonly int direction = -1;
        
        public RopeFacingLeft(RopeEnemy owner) 
        {
            this.owner = owner;
            this.sprite = new RopeSprite(owner);
            this.yMovement = 0;
            this.xMovement = -1;
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
                if (directionChangeTimer == 50)
                {
                    this.yMovement = 1;
                    this.xMovement = 0;
                }
            }
            
            
        }
        public void Chase()
        {
            triggered = true;
            this.directionChangeTimer = 0;
            this.currentspeed = EnemyConstants.ChasingSpeed;
            this.yMovement = 0;
            this.xMovement = -1;
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
