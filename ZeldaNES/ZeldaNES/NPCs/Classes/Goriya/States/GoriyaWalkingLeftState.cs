using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs.Classes.Keese.States;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites.Keese;

namespace ZeldaNES.NPCs.Classes.Goriya.States
{
    internal class GoriyaWalkingLeftState: IGoriyaStates
    {
        GoriyaEnemy GoriyaReference;
        private GeneralConstants.Orientation norm = GeneralConstants.Orientation.Left; 
        ISprite sprite;
        public void Update() {
            GoriyaReference.PosX -= EnemyConstants.GoriyaMovementSpeed;
            sprite.Update();    
        }
        public void Draw() { 
            sprite.Draw();
        }
        public GeneralConstants.Orientation GetNormal() {
            return norm;
        }
        public void GoriyaWalkingLeft()
        {
            GoriyaReference.SetState(new GoriyaWalkingLeftState(GoriyaReference));
        }
        public void GoriyaWalkingRight()
        {
            GoriyaReference.SetState(new GoriyaWalkingRightState(GoriyaReference));
        }
        public void GoriyaWalkingUp()
        {
            GoriyaReference.SetState(new GoriyaWalkingUpState(GoriyaReference));
        }
        public void GoriyaWalkingDown()
        {
            GoriyaReference.SetState(new GoriyaWalkingDownState(GoriyaReference));
        }
        public void GoriyaThrowingBoomerang() { }
        public  GoriyaWalkingLeftState(GoriyaEnemy goriya ){
            this.GoriyaReference = goriya;
            this.sprite = new GoriyaWalkingLeftSprite(goriya);
        }

    }
}
