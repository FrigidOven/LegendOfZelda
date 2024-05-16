using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Weapons.Classes.WoodenBoomerang.States;

namespace ZeldaNES.Weapons.Classes.WoodenBoomerang
{
    public class WoodenBoomerang : IWeapon
    {
        public IWeaponState state;
        private IWeaponUser owner;
        private IWeaponPhysicsObject body;

        private int distanceTraveled;

        private bool shouldDelete;
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

        public WoodenBoomerang(int posX, int posY, GeneralConstants.Orientation orientation, IWeaponUser owner)
        {
            this.body = new WeaponPhysicsObject(posX, posY);

            this.PosX = posX;
            this.PosY = posY;
            this.owner = owner;

            state = orientation switch
            {
                GeneralConstants.Orientation.Up => new WoodenBoomerangGoingUpState(this, owner),
                GeneralConstants.Orientation.Down => new WoodenBoomerangGoingDownState(this, owner),
                GeneralConstants.Orientation.Left => new WoodenBoomerangGoingLeftState(this, owner),
                _ => new WoodenBoomerangGoingRightState(this, owner),
            };

            distanceTraveled = 0;

            shouldDelete = false;
            this.owner = owner;
        }
        public void Update()
        {
            state.Update();
            distanceTraveled += WeaponConstants.WoodenBoomerangSpeed;
            if (distanceTraveled >= WeaponConstants.WoodenBoomerangTerminationDistance)
            {
                Terminate();
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
