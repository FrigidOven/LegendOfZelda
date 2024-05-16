using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs.Classes.Keese.States;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites.Keese;

namespace ZeldaNES.NPCs.Classes.Goriya.States
{
    internal class GoriyaWalkingUpState: IGoriyaStates
    {
        GoriyaEnemy GoriyaReference;
        ISprite sprite;
        private GeneralConstants.Orientation norm = GeneralConstants.Orientation.Up;
        public void Update() {
            GoriyaReference.PosY -=  EnemyConstants.GoriyaMovementSpeed;
            sprite.Update();    
        }
        public void Draw() { 
            sprite.Draw();
        }
        public void GoriyaWalkingLeft() {
            GoriyaReference.SetState(new GoriyaWalkingLeftState(GoriyaReference));
        }
        public void GoriyaWalkingRight() {
            GoriyaReference.SetState(new GoriyaWalkingRightState(GoriyaReference));
        }
        public void GoriyaWalkingUp() {
            GoriyaReference.SetState(new GoriyaWalkingUpState(GoriyaReference));
        }
        public void GoriyaWalkingDown() {
            GoriyaReference.SetState(new GoriyaWalkingDownState(GoriyaReference));
        }
        public void GoriyaThrowingBoomerang() { }

        public GeneralConstants.Orientation GetNormal()
        {
            return norm;
        }
        public  GoriyaWalkingUpState(GoriyaEnemy goriya ){
            this.GoriyaReference = goriya;
            this.sprite = new GoriyaWalkingUpSprite(goriya);
        }

    }
}
