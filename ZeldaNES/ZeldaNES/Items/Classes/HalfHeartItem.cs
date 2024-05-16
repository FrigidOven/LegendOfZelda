using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Players.Link;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.ItemSprites;

namespace ZeldaNES.Items.Classes
{   
    public class HalfHeartItem: IHealingItem
    {
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
      
        ISprite spriteRef;
        private IItemPhysicsObject body;
        private bool deletable = false;
        private int healAmount = 1;
        public int HealAmount { get { return healAmount; } set { healAmount = value; } }
        public HalfHeartItem() {
            body = new ItemPhysicsObject(0, 0);
            HealAmount = 1;
            spriteRef = new HalfHeartSprite(this);
        }
        public HalfHeartItem(int x, int y)
        {
            body = new ItemPhysicsObject(x, y);
            HealAmount = 1;
            this.PosX = x;
            this.PosY = y;
            spriteRef = new HalfHeartSprite(this);
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
