using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.Hitboxes;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.NPCs.Classes.OldMan.States;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;
using ZeldaNES.Weapons;
using ZeldaNES.Weapons.Classes.EnergyBall;
using ZeldaNES.Factories;
using ZeldaNES.Game_Constants;
using ZeldaNES.Regions;
using ZeldaNES.Players.Link;
using System.Numerics;

namespace ZeldaNES.NPCs.Classes.OldMan
{
    public class OldManNPC : INPC, IWeaponUser
    {
        private IEnemyPhysicsObject body;

        private IOldManState state;

        WeaponFactory weaponFactory;
        private int weaponTimer;
        private int directionTimer;

        public bool IsFriendly { get; set; }

        public bool frozen = false;

        public int PosX
        {
            get => body.PosX;
            set
            {
                body.PosX = value;
            }
        }
        public int PosY
        {
            get => body.PosY;
            set
            {
                body.PosY = value;
            }
        }

        
        private ISprite sprite;
        public OldManNPC(int posX, int posY)
        {
            body = new EnemyPhysicsObject(posX, posY, 5);
            sprite = new OldManSprite(this);
            state = new OldManPeacefulMode(this);
            directionTimer = 15;
            weaponTimer = 0;
            this.IsFriendly = true;
        }
        public OldManNPC()
        {
            body = new EnemyPhysicsObject(0, 0, 5);
            sprite = new OldManSprite(this);
            state = new OldManPeacefulMode(this);
            directionTimer = 15;
            weaponTimer = 0;
            this.IsFriendly = true;
        }
        public IEnemyPhysicsObject Body()
        {
            return body;
        }
        public void SetWeaponFactory(WeaponFactory weaponfactory)
        {
            this.weaponFactory = weaponfactory;
        }
        public void Draw()
        {
            sprite.Draw();
        }

        public void Update()
        {
            if (body.IsTakingDamage && this.IsFriendly)
            {
                this.state = new OldManBossMode(this);
                this.IsFriendly = false;
            }

            if (!this.IsFriendly && !frozen)
            {
                directionTimer++;
                weaponTimer++;

                // Movement
                if (directionTimer < 60)
                {
                    PosX = PosX + 1;

                }
                else if (directionTimer < 120)
                {
                    PosY = PosY + 1;
                }
                else if (directionTimer < 180)
                {
                    PosX = PosX - 1;
                }
                else if (directionTimer < 240)
                {
                    PosY = PosY - 1;
                }
                else
                {
                    directionTimer = 0;
                }

                // Attacking
                if (weaponTimer > 260)
                {
                    weaponFactory.MakeNewFire(PosX, PosY, GeneralConstants.Orientation.Up, this);
                    weaponFactory.MakeNewFire(PosX, PosY, GeneralConstants.Orientation.Down, this);
                    weaponFactory.MakeNewFire(PosX, PosY, GeneralConstants.Orientation.Left, this);
                    weaponFactory.MakeNewFire(PosX, PosY, GeneralConstants.Orientation.Right, this);
                    weaponFactory.MakeNewEnergyBall(PosX, PosY, GeneralConstants.Orientation.UpLeft, this);
                    weaponFactory.MakeNewEnergyBall(PosX, PosY, GeneralConstants.Orientation.DownRight, this);
                    weaponFactory.MakeNewEnergyBall(PosX, PosY, GeneralConstants.Orientation.DownLeft, this);
                    weaponFactory.MakeNewEnergyBall(PosX, PosY, GeneralConstants.Orientation.UpRight, this);
                    weaponTimer = 0;
                }
            }

            this.weaponTimer++;
            this.state.Update();
        }

        public void dropLoot(Region region)
        {
            //when/if boss fight implemented, you can un-comment out the line below so he drops loot on death (gave him same loot table as aquamentus)
            ItemFactory.Instance.spawnClock(PosX, PosY, region);
        }

        public void freeze()
        {
            frozen = true;
        }

        public void unfreeze()
        {
            frozen = false;
        }

        public void AIMovement(ILink link)
        {
            Vector2 direction = new Vector2(link.Body().PosX - body.PosX, link.Body().PosY - body.PosY);
            direction = Vector2.Normalize(direction);
            body.PosX += (int)(direction.X * EnemyConstants.ChasingSpeed);
            body.PosY += (int)(direction.Y * EnemyConstants.ChasingSpeed);
        }
    }
}
