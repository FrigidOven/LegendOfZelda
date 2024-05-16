using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Weapons.Classes.Fire.States;

namespace ZeldaNES.Weapons.Classes.Fire
{
    public class Fire : IWeapon
    {
        public IWeaponState state;

        private IWeaponUser owner;
        private IWeaponPhysicsObject body;


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

        private int distanceTraveled;

        private bool shouldDelete;

        public Fire(int posX, int posY, GeneralConstants.Orientation orientation, IWeaponUser owner)
        {
            this.body = new WeaponPhysicsObject(posX, posY);

            this.PosX = posX;
            this.PosY = posY;

            state = orientation switch
            {
                GeneralConstants.Orientation.Up => new FireGoingUpState(this),
                GeneralConstants.Orientation.Down => new FireGoingDownState(this),
                GeneralConstants.Orientation.Left => new FireGoingLeftState(this),
                _ => new FireGoingRightState(this),
            };

            distanceTraveled = 0;

            shouldDelete = false;
            this.owner = owner;
        }
        public void Update()
        {
            state.Update();
            distanceTraveled += WeaponConstants.FireSpeed;
            if (distanceTraveled >= WeaponConstants.FireTerminationDistance)
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
