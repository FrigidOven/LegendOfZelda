using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Regions;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;
using ZeldaNES.Game_Constants;
using ZeldaNES.Players.Link.Classes;
using ZeldaNES.Players.Link;
//namespace ZeldaNES.NPCs.Classes
using ZeldaNES.NPCs.Classes.Trap.States;
namespace ZeldaNES.NPCs.Classes.Trap
{
    public class TrapEnemy : INPC
    {
        private ISprite sprite;
        public bool triggerup = false;
        public bool triggerdown = false;
        public bool triggerleft = false;
        public bool triggerright = false;
        public bool triggered = false;
        public int changingroomcounter = 0;// when changing room, the trap will keeping moving

        private ITrapStates state;

        private IEnemyPhysicsObject body;

        public void Triggerup()
        {

            triggerup = true;

        }
        public void Triggerdown()
        {

            triggerdown = true;
        }
        public void Triggerleft()
        {

            triggerleft = true;
        }
        public void Triggerright()
        {

            triggerright = true;
        }
        public bool hasTriggered()
        {

            return triggerup || triggerdown || triggerleft || triggerright;

        }
        public void reset()
        {
            if (sprite is TrapSprite trapSprite)
            {
                triggerup = false;
                triggerdown = false;
                triggerleft = false;
                triggerright = false;
                changingroomcounter = 0;
            }
        }
        public TrapEnemy(int posX, int posY)
        {
            body = new EnemyPhysicsObject(posX, posY, 100);

            sprite = new TrapSprite(this);

            state = new TrapNormalState(this);
        }
        public TrapEnemy()
        {
            sprite = new TrapSprite(this);
            body = new EnemyPhysicsObject(0, 0, 100);
            state = new TrapNormalState(this);


        }
        public IEnemyPhysicsObject Body()
        {
            return body;
        }
        public void Update()
        {
            state.Update();
            sprite.Update();
            /*
            sprite.Update();
            if (triggerup)
            {
                PosY += EnemyConstants.ChasingSpeed;
                changingroomcounter++;
            }
            else if (triggerdown)
            {
                PosY -= EnemyConstants.ChasingSpeed;
                changingroomcounter++;
            }
            else if (triggerleft)
            {
                PosX -= EnemyConstants.ChasingSpeed;
                changingroomcounter++;
            }
            else if (triggerright)
            {
                PosX += EnemyConstants.ChasingSpeed;
                changingroomcounter++;
            }
            if (changingroomcounter > 16 * 3 * 12)
            {
                triggerup = false;
                triggerdown = false;
                triggerleft = false;
                triggerright = false;
                changingroomcounter = 0;
            }
            */
        }

        public void Draw()
        {
            sprite.Draw();
            //state.Draw();
        }
        public int PosX
        {
            get => body.PosX;
            set => body.PosX = value;
        }
        public int PosY
        {
            get => body.PosY;
            set => body.PosY = value;
        }

        public void dropLoot(Region region)
        {
            //
        }

        public void AIMovement(ILink link)
        {
            // Already gets triggered by player
        }

        public void freeze()
        {
            this.state = new TrapFrozenState(this);
        }

        public void unfreeze()
        {
            this.state = new TrapNormalState(this);
        }
    }
}
