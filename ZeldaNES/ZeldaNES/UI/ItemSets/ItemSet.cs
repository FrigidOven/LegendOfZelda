using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ZeldaNES.Game_Constants;
using ZeldaNES.Items;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Sprites.Classes.UISprites;
using ZeldaNES.Sprites.UISprites;


namespace ZeldaNES.Tiles.Classes
{
    public class ItemSet
    {
        private List<IItem> itemSet = new List<IItem>();

        public void IncrementPosX(int value) {
            foreach (IItem item in itemSet)
            {
                item.PosX += value;
            }
        }
        public void IncrementPosY(int value)
        {
            foreach (IItem item in itemSet)
            {
                item.PosY += value;
            }
        }
        public void Clear()
        {
            itemSet.Clear();
        }
        public void Add(IItem item) {
            itemSet.Add(item);
        }
        public List<IItem> getList() {
            return itemSet;
        }

        public ItemSet() {
  
        }

        public void Update()
        {
            foreach (IItem item in itemSet) {
                item.Update();
            }
        }
        public void Draw() {
            foreach (IItem item in itemSet)
            {
                item.Draw();
            }
        }

    }
}
