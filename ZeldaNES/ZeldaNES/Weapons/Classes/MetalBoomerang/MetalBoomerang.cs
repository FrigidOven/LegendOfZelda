using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Game_Constants;
using ZeldaNES.Weapons.Classes.MetalBoomerang.States;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;

namespace ZeldaNES.Weapons.Classes.MetalBoomerang
{
    public class MetalBoomerang : IWeapon
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
        public MetalBoomerang(int posX, int posY, GeneralConstants.Orientation orientation, IWeaponUser owner)
        {
            this.body = new WeaponPhysicsObject(posX, posY);


            this.PosX = posX;
            this.PosY = posY;
            state = orientation switch
            {
                GeneralConstants.Orientation.Up => new MetalBoomerangGoingUpState(this, owner),
                GeneralConstants.Orientation.Down => new MetalBoomerangGoingDownState(this, owner),
                GeneralConstants.Orientation.Left => new MetalBoomerangGoingLeftState(this, owner),
                _ => new MetalBoomerangGoingRightState(this, owner),
            };

            distanceTraveled = 0;

            shouldDelete = false;
            this.owner = owner;
        }
        public void Update()
        {
            state.Update();
            distanceTraveled += WeaponConstants.MetalBoomerangSpeed;
            if (distanceTraveled >= WeaponConstants.MetalBoomerangTerminationDistance)
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
