using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Factories;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites.BossSprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;
using ZeldaNES.Weapons;
using ZeldaNES.Weapons.Classes.EnergyBall;

namespace ZeldaNES.NPCs.Classes.Aquamentus
{
    public class AquamentusEnemy : INPC, IWeaponUser
    {
        ISprite sprite;

        public bool frozen = false;


        private IEnemyPhysicsObject body;
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

        private WeaponFactory weaponfactory;
        private int shootTimer = 0;
        private int damageTimer = 0;
        public bool IsFriendly { get; set; }

        public AquamentusEnemy(int posX, int posY)
        {
            body = new EnemyPhysicsObject(posX, posY, 6);

            sprite = new AquamentusSprite(this);
        }
        public AquamentusEnemy()
        {
            body = new EnemyPhysicsObject(300, 300, 6);

            sprite = new AquamentusSprite(this);
        }
        public IEnemyPhysicsObject Body()
        {
            return body;
        }
        public void SetWeaponFactory(WeaponFactory weaponfactory) {
            this.weaponfactory = weaponfactory;
        }
        public void Update()
        {
            if (!frozen)
            {
                if (shootTimer >= 90)
                {
                    shootTimer = 0;
                    // Change boss animation to attacking
                    weaponfactory.MakeNewEnergyBall(PosX, PosY, GeneralConstants.Orientation.UpLeft, this);
                    weaponfactory.MakeNewEnergyBall(PosX, PosY, GeneralConstants.Orientation.Left, this);
                    weaponfactory.MakeNewEnergyBall(PosX, PosY, GeneralConstants.Orientation.DownLeft, this);

                }
                shootTimer++;
                sprite.Update();
            }
            ManageDamage();

        }
        private void ManageDamage()
        {
            if(!body.IsTakingDamage)
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
            sprite.Draw();
        }

        public void dropLoot(Region region)
        {
            //ItemFactory.Instance.spawnHeart(PosX, PosY, region);
            ItemFactory.Instance.groupDLoot(PosX, PosY, region);
        }

        public void AIMovement(ILink link)
        {
            //
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
