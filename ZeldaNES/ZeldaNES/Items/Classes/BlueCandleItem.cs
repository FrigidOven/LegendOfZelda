using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.ItemSprites;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using System.Reflection;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.Items.Classes
{   
    public class BlueCandleItem: IEquippableItem, IUpgradeItem
    { 
        private IItemPhysicsObject body;
        private bool deletable = false;
        ISprite spriteRef;
        public int PosX
        {
            get => body.PosX;
            set
            {
                body.PosX = value;
            }
        }
        public GeneralConstants.UpgradeClasses GetUpgradeClass()
        {
            return GeneralConstants.UpgradeClasses.Candle;
        }
        public int GetLevel()
        {
            return 0;
        }
        public int PosY
        {
            get => body.PosY;
            set
            {
                body.PosY = value;
            }
        }



        public BlueCandleItem() {
            body = new ItemPhysicsObject(0, 0);
            spriteRef = new BlueCandleSprite(this);
        }
        public BlueCandleItem(int x , int y)
        {
            body = new ItemPhysicsObject(x, y);
            this.PosX = x;
            this.PosY = y;
            spriteRef = new BlueCandleSprite(this);
        }
        public void Update() {
            spriteRef.Update();
        }
        public void Draw() {
            spriteRef.Draw();
        }
        public int GetPosX() { 
            return PosX; 
        }
        public int GetPosY() { 
            return PosY;
        }
        public void SetPosX(int x) { 
            PosX = x;
        }
        public void SetPosY(int y) { 
            PosY = y;
        }
        public void Terminate() { 
        }
        public bool ShouldDelete()
        {
            return this.deletable;
        }
        public void SetDeletable(bool deletable)
        {
            this.deletable = deletable;
        }
        public IItemPhysicsObject Body()
        {
            return body;
        }
    }
}
