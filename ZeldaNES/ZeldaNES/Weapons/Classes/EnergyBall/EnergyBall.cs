using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Weapons.Classes.EnergyBall.States;

namespace ZeldaNES.Weapons.Classes.EnergyBall
{
    public class EnergyBall : IWeapon
    {
        public IWeaponState state;
        private IWeaponPhysicsObject body;
        private GeneralConstants.Orientation orientation;
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
        public EnergyBall(int posX, int posY, GeneralConstants.Orientation orientation)
        {
            this.body = new WeaponPhysicsObject(posX, posY);

            this.PosX = posX;
            this.PosY = posY;

            state = orientation switch
            {
                GeneralConstants.Orientation.Up => new EnergyBallGoingUpState(this),
                GeneralConstants.Orientation.Down => new EnergyBallGoingDownState(this),
                GeneralConstants.Orientation.Left => new EnergyBallGoingLeftState(this),
                GeneralConstants.Orientation.Right => new EnergyBallGoingRightState(this),
                GeneralConstants.Orientation.UpLeft => new EnergyBallGoingUpLeftState(this),
                GeneralConstants.Orientation.UpRight => new EnergyBallGoingUpRightState(this),
                GeneralConstants.Orientation.DownLeft => new EnergyBallGoingDownLeftState(this),
                _ => new EnergyBallGoingDownRightState(this),
            };

            distanceTraveled = 0;

            shouldDelete = false;
        }
        public void Update()
        {
            state.Update();
            distanceTraveled += WeaponConstants.EnergyBallSpeed;
            if (distanceTraveled >= WeaponConstants.EnergyBallTerminationDistance)
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
