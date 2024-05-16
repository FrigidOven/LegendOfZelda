using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.WeaponSprites.EnergyBall;

namespace ZeldaNES.Weapons.Classes.EnergyBall.States
{
    public class EnergyBallGoingDownRightState : IWeaponState
    {
        private EnergyBall energyBall;
        private ISprite sprite;

        public EnergyBallGoingDownRightState(EnergyBall energyBall)
        {
            this.energyBall = energyBall;
            sprite = new EnergyBallSprite(energyBall);
        }

        public void Update()
        {
            energyBall.PosX = energyBall.PosX + WeaponConstants.EnergyBallSpeed;
            energyBall.PosY = energyBall.PosY + WeaponConstants.EnergyBallSpeed;
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
