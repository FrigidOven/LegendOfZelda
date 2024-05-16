using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Weapons.Classes.Bomb.States;
using ZeldaNES.Weapons.Classes.Clock.States;

namespace ZeldaNES.Weapons.Classes.Clock
{
    public class Clock : IWeapon
    {
        public IWeaponState state;

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

        public Clock(int posX, int posY)
        {
            this.body = new WeaponPhysicsObject(posX, posY, WeaponConstants.BombHitboxSize, false);

            this.PosX = posX;
            this.PosY = posY;

            state = new ClockTickingState(this);
            ticks = 0;

            shouldDelete = false;
        }
        public void Update()
        {
            state.Update();
            ticks++;
            if (ticks >= WeaponConstants.ClockTickCount)
            {
                Terminate();
                shouldDelete = true;
            }
        }
        public IWeaponPhysicsObject Body()
        {
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
    }
}
