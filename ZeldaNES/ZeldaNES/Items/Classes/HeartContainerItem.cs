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
    public class HeartContainerItem: IUpgradeItem
    {
        public int PosX
        {
            get => body.PosX;
            set
            {
                body.PosX = value;
            }
        }
        public void UseItem(ILink link)
        {
            link.HealthCapacity += 2;
            link.Health = link.HealthCapacity;
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
      
        public HeartContainerItem() {
            body = new ItemPhysicsObject(0, 0);

            spriteRef = new HeartContainerSprite(this);
        }
        public HeartContainerItem(int x, int y)
        {
            body = new ItemPhysicsObject(x, y);

            this.PosX = x;
            this.PosY = y;
            spriteRef = new HeartContainerSprite(this);
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
