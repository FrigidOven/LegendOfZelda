using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Factories;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs.Classes.Rope.States;
using ZeldaNES.NPCs.Classes.Stalfo;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Regions;
using ZeldaNES.Game_Constants;
using ZeldaNES.Players.Link;
using System.Numerics;

namespace ZeldaNES.NPCs.Classes.Rope
{
    public class RopeEnemy : INPC
    {
        private IEnemyPhysicsObject body;
        private IRopeState state;

        private int stateTimer;
        public int leftOrRight;
        private int damageTimer;
        public bool triggerbool = false;
        private bool right = false;
        private bool left = false;
        private bool firstTrigger = false;

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
        public void triggerleft()
        {
            this.triggerbool = true;
            this.left = true;
            this.right = false;
            this.firstTrigger = true;
        }
        public void triggerright()
        {
            this.triggerbool = true;
            this.right = true;
            this.left = false;
            this.firstTrigger = true;
        }
        public void reset()
        {
            this.triggerbool = false;
            this.right = false;
            this.left = false;
            this.state.Reset();
            this.firstTrigger = false;
        }
        public RopeEnemy(int posX, int posY)
        {
            this.body = new EnemyPhysicsObject(posX, posY, 1);
            this.leftOrRight = 0;
            this.state = new RopeFacingLeft(this);
        }
        public RopeEnemy()
        {
            this.body = new EnemyPhysicsObject(0, 0, 1);
            this.leftOrRight = 0;
            this.state = new RopeFacingLeft(this);
        }

        public IEnemyPhysicsObject Body()
        {
            return body;
        }
        public void Draw()
        {
            this.state.Draw();
        }

        //public void ChangeState(IRopeState state)
        //{
         //a   this.state = state;
        //}

        public void Update()
        {
            if (!this.triggerbool)
            {
                this.state.Update();
                stateTimer++;
                if (stateTimer == 100)
                {
                    if (leftOrRight == 0)
                    {
                        this.state = new RopeFacingLeft(this);
                        leftOrRight++;
                    }
                    else
                    {
                        this.state = new RopeFacingRight(this);
                        leftOrRight--;
                    }
                    stateTimer = 0;
                }
                ManageDamage();
            }
            else//if the rope is triggered
            {   
               if (firstTrigger)//first frame the rope is triggered (change the facing direction)
               {
                    if (right)
                    {
                        leftOrRight = 1;
                        this.state = new RopeFacingRight(this);
                        this.state.Chase();
                        this.state.Update();
                        this.firstTrigger = false;
                    }
                    if (left)
                    {
                        leftOrRight = 0;
                        this.state = new RopeFacingLeft(this);
                        this.state.Chase();
                        this.state.Update();
                        this.firstTrigger = false;
                    }
               }
               this.state.Chase();
               this.state.Update();
               ManageDamage();
            }
        }
        private void ManageDamage()
        {
            if (!body.IsTakingDamage)
            {
                return;
            }
            if (damageTimer < EnemyConstants.DamageGracePeriod)
            {
                damageTimer++;
            }
            else
            {
                damageTimer = 0;
                body.IsTakingDamage = false;
            }
        }

        public void dropLoot(Region region)
        {
            ItemFactory.Instance.groupCLoot(PosX, PosY, region);
        }

        public void AIMovement(ILink link)
        {
            Vector2 direction = new Vector2(link.Body().PosX - body.PosX, link.Body().PosY - body.PosY);
            direction = Vector2.Normalize(direction);
            body.PosX += (int)(direction.X * EnemyConstants.ChasingSpeed);
            body.PosY += (int)(direction.Y * EnemyConstants.ChasingSpeed);

            // Determine the state based on the direction
            if (direction.X > 0)
            {
                // Moving right
                state = new RopeFacingRight(this);
            }
            else
            {
                // Moving left
                state = new RopeFacingLeft(this);
            }

        }

        public void freeze()
        {
            this.state = new RopeFrozen(this);
        }

        public void unfreeze()
        {
            Update();   //TODO: i doubt thisll work
        }
    }
}
