using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Sprites.Classes.WeaponSprites.EnergyBall;
using ZeldaNES.Sprites;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.Weapons.Classes.EnergyBall.States
{
    public class EnergyBallGoingLeftState : IWeaponState
    {
        private EnergyBall energyBall;
        private ISprite sprite;

        public EnergyBallGoingLeftState(EnergyBall energyBall)
        {
            this.energyBall = energyBall;
            sprite = new EnergyBallSprite(energyBall);
        }

        public void Update()
        {
            energyBall.PosX = energyBall.PosX - WeaponConstants.EnergyBallSpeed;
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw();
        }

        public void Terminate()
        {
            energyBall.state = new EnergyBallTerminationState(energyBall);
        }
    }
}
