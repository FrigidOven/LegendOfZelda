using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.NPCs.Classes.BigJelly.States;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.Hitboxes;
using ZeldaNES.NPCs.Classes.BigJelly;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Game_Constants;
using ZeldaNES.Regions;
using ZeldaNES.Players.Link;
using System.Numerics;



namespace ZeldaNES.NPCs.Classes.BigJelly
{
    public class BigJellyEnemy : INPC
    {
        private IEnemyPhysicsObject body;

        public bool frozen = false;

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


        private IBigJellyStates state;

        private int curState;
        private int durationUntilNextState;
        private int maxDuration = 5;

        private Random rnd = new Random();
        private int damageTimer;

        public BigJellyEnemy(int posX, int posY)
        {
            body = new EnemyPhysicsObject(posX, posY, EnemyConstants.BigJellyHealth);

            curState = 0;
            curState = rnd.Next(0, 3);

            chooseNextState(curState);
            durationUntilNextState = rnd.Next() % maxDuration;
        }
        public BigJellyEnemy()
        {
            body = new EnemyPhysicsObject(300, 300, EnemyConstants.BigJellyHealth);

            curState = 0;
            curState = rnd.Next(0, 3);

            chooseNextState(curState);
            durationUntilNextState = rnd.Next() % maxDuration;
        }
        public IEnemyPhysicsObject Body()
        {
            return body;
        }
        public IBigJellyStates GetBigJellyState() {
            return state;
        }
        public void SetBigJellyState(IBigJellyStates state) {
            this.state = state;
        }
        private void chooseNextState(int nextState)
        {
            switch (nextState)
            {
                case 0:
                    {
                        state = new BigJellyMovingDownState(this);
                        break;
                    }
                case 1:
                    {
                        state = new BigJellyMovingUpState(this);
                        break;
                    }
                case 2:
                    {
                        state = new BigJellyMovingLeftState(this);
                        break;
                    }
                case 3:
                    {
                        state = new BigJellyMovingRightState(this);
                        break;
                    }

            }

        }
        public void Update()
        {
            if (!frozen)
            {
                state.Update();
                if (durationUntilNextState == 0)
                {
                    durationUntilNextState = 40;
                    curState = rnd.Next() % 9;
                    chooseNextState(curState);
                }
                durationUntilNextState--;
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
            //
        }

        public void AIMovement(ILink link)
        {
            Vector2 direction = new Vector2(link.Body().PosX - body.PosX, link.Body().PosY - body.PosY);
            direction = Vector2.Normalize(direction);
            body.PosX += (int)(direction.X * EnemyConstants.ChasingSpeed);
            body.PosY += (int)(direction.Y * EnemyConstants.ChasingSpeed);
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
