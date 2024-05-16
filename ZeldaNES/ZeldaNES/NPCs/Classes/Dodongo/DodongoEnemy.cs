using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Factories;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs.Classes.Dodongo.States;
using ZeldaNES.Physics.Hitboxes;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;

namespace ZeldaNES.NPCs.Classes.Dodongo
{
    public class DodongoEnemy : INPC
    {
        private IEnemyPhysicsObject body;
        private int XOriginal;
        private int YOriginal;

        public bool frozen = false;

        public int PosX
        {
            get => body.PosX;
            set {
                body.PosX = value; }
        }
        public int PosY
        {
            get => body.PosY;
            set
            {
                body.PosY = value;
            }
        }

        private IDodongoState state;

        private int turnWalkDistance;
        private int walkDistanceTraveled;

        private int stunDuration;
        private int stunDurationCounter;
        private int damageTimer;

        public DodongoEnemy(int posX, int posY)
        {
            body = new EnemyPhysicsObject(posX, posY, 6);

            state = new DodongoWalkingUpState(this);

            walkDistanceTraveled = 0;
            turnWalkDistance = 40;

            stunDuration = 20;
            stunDurationCounter = 0;
        }
        public DodongoEnemy()
        {
            body = new EnemyPhysicsObject(XOriginal, YOriginal, 6);

            state = new DodongoWalkingUpState(this);

            walkDistanceTraveled = 0;
            turnWalkDistance = 40;

            stunDuration = 20;
            stunDurationCounter = 0;
        }
        public void SetDodongoState(IDodongoState state) {
            this.state = state;
        }
        public IEnemyPhysicsObject Body()
        {
            return body;
        }
        public void Update()
        {
            if (!frozen)
            {
                state.Update();
                if (walkDistanceTraveled >= turnWalkDistance)
                {
                    state.TurnLeft();
                    walkDistanceTraveled = 0;
                    return;
                }
                if (stunDurationCounter > 0)
                {
                    state.EatBomb();
                    stunDurationCounter--;
                    return;
                }
                if (walkDistanceTraveled == turnWalkDistance / 2)
                {
                    stunDurationCounter = stunDuration;
                }
                state.WalkForwards();
                walkDistanceTraveled++;
            }
            ManageDamage();
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
        public void Draw()
        {
            state.Draw();
        }

        public void dropLoot(Region region)
        {
            ItemFactory.Instance.groupDLoot(PosX,PosY,region);
        }

        public void AIMovement(ILink link)
        {
            Vector2 direction = new Vector2(link.Body().PosX - body.PosX, link.Body().PosY - body.PosY);
            direction = Vector2.Normalize(direction);
            body.PosX += (int)(direction.X * EnemyConstants.ChasingSpeed);
            body.PosY += (int)(direction.Y * EnemyConstants.ChasingSpeed);

            // Determine the state based on the direction
            if (Math.Abs(direction.X) > Math.Abs(direction.Y))
            {
                // Moving more horizontally
                if (direction.X > 0)
                {
                    state = new DodongoWalkingRightState(this);
                }
                else
                {
                    state = new DodongoWalkingLeftState(this);
                }
            }
            else
            {
                // Moving more vertically
                if (direction.Y > 0)
                {
                    state = new DodongoWalkingDownState(this);
                }
                else
                {
                    state = new DodongoWalkingUpState(this);
                }
            }
        }

        public void freeze()
        {
            frozen = true;
        }

        public void unfreeze()
        {
            frozen = false;
        }
    }
}
