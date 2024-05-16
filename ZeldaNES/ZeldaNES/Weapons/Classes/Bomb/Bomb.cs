using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Players.Link.Classes;
using ZeldaNES.Screens;
using ZeldaNES.Weapons.Classes.Bomb.States;

namespace ZeldaNES.Weapons.Classes.Bomb
{
    public class Bomb : IWeapon
    {
        public IWeaponState state;

        //private IWeaponUser owner;
        private bool isFriendly;

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

        private int ticks;

        private bool shouldDelete;
        private IWeaponPhysicsObject body;

        public Bomb(int posX, int posY)
        {
            this.body = new WeaponPhysicsObject(posX, posY, WeaponConstants.BombHitboxSize, false);

            this.PosX = posX;
            this.PosY = posY;

            state = new BombTickingState(this);
            ticks = 0;

            shouldDelete = false;

            isFriendly = false;
        }

        public Bomb(int posX, int posY, IWeaponUser user)
        {
            this.body = new WeaponPhysicsObject(posX, posY, WeaponConstants.BombHitboxSize, false);

            this.PosX = posX;
            this.PosY = posY;

            state = new BombTickingState(this);
            ticks = 0;

            shouldDelete = false;


            if (user is Link)
            {
                isFriendly = true;
            }
            else {
                isFriendly = false;
            }
        }


        public void Update()
        {
            state.Update();
            ticks++;
            if (ticks >= WeaponConstants.BombTickCount)
            {
                Terminate();
            }
        }
        public IWeaponPhysicsObject Body() {
            return body;
        }
        public void Draw()
        {
            state.Draw();
        }
   
        public bool ShouldDelete
        {
            get => shouldDelete;
            set => shouldDelete = value;
        }
        public void Terminate()
        {
            state.Terminate();
        }

        public bool IsFriendly() {
            return isFriendly;
        } 
    }
}
