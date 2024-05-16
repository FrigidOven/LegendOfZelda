using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core.Tokens;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.ItemSprites;

namespace ZeldaNES.Items.Classes
{   
    public class RedPotionItem : IItem, IEquippableItem, IUpgradeItem
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
        public GeneralConstants.UpgradeClasses GetUpgradeClass()
        {
            return GeneralConstants.UpgradeClasses.Potion;
        }
        public int GetLevel()
        {
            return 1;
        }
        ISprite spriteRef;
        private IItemPhysicsObject body;
        private bool deletable = false;
        private int healAmount;
        public int HealAmount { get { return healAmount; } set { healAmount = value; } }
        public RedPotionItem() {
            body = new ItemPhysicsObject(0, 0);

            spriteRef = new RedPotionSprite(this);
        }
        public RedPotionItem(int x, int y)
        {
            body = new ItemPhysicsObject(x, y);

            this.PosX = x;
            this.PosY = y;
            spriteRef = new RedPotionSprite(this);
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
