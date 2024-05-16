using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Sprites.Classes.WeaponSprites.EnergyBall;
using ZeldaNES.Sprites;

namespace ZeldaNES.Weapons.Classes.EnergyBall.States
{
    public class EnergyBallTerminationState : IWeaponState
    {
        private EnergyBall energyBall;
        private ISprite sprite;

        public EnergyBallTerminationState(EnergyBall energyBall)
        {
            this.energyBall = energyBall;
            sprite = new EnergyBallSprite(energyBall);
        }
        public void Update()
        {
            sprite.Update();
            energyBall.ShouldDelete = true;
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void Terminate()
        {

        }
    }
}
