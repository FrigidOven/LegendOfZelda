using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Weapons.Classes.MetalArrow.States;

namespace ZeldaNES.Weapons.Classes.MetalArrow
{
    public class MetalArrow : IWeapon
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
        public MetalArrow(int posX, int posY, GeneralConstants.Orientation orientation, IWeaponUser owner)
        {
            this.body = new WeaponPhysicsObject(posX, posY);

            this.PosX = posX;
            this.PosY = posY;

            state = orientation switch
            {
                GeneralConstants.Orientation.Up => new MetalArrowGoingUpState(this),
                GeneralConstants.Orientation.Down => new MetalArrowGoingDownState(this),
                GeneralConstants.Orientation.Left => new MetalArrowGoingLeftState(this),
                _ => new MetalArrowGoingRightState(this),
            };

            distanceTraveled = 0;

            shouldDelete = false;
            this.owner = owner;
        }
        public void Update()
        {
            state.Update();
            distanceTraveled += WeaponConstants.MetalArrowSpeed;
            if (distanceTraveled >= WeaponConstants.MetalArrowTerminationDistance)
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
