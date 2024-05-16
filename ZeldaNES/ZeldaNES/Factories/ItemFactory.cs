using ZeldaNES.Game_Constants;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;
using ZeldaNES.Screens;
using ZeldaNES.Screens.Classes;
using ZeldaNES.Items;
using ZeldaNES.Items.Classes;
using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Physics;

namespace ZeldaNES.Factories
{
    public sealed class ItemFactory
    {
        private IRegion region;
        private static ItemFactory instance = null;
        private static readonly Object padlock = new object();
        private Random rnd = new Random();


        public static ItemFactory Instance { 
            get { 
                return instance; 
            } 
        }

        public static ItemFactory GenInstance()
        {

            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new ItemFactory();
                }
                return instance;
            }

        }

        //        public void setRegion(Region r) {
        //          this.region = r;
        //    }



        public void groupALoot(int posX, int posY, Region region) {     
            //NOTE: we dont have any enemies thatd use this loot table, but if you want to change that go ahead lol
            int random = rnd.Next(0, 11);

            if (random < 5)
            {
                spawnRupee(posX, posY, region);
            }
            else if (random != 10)
            {
                spawnHeart(posX, posY, region);
            }
            else {
                spawnFairy(posX, posY, region);
            }
        }

        public void groupBLoot(int posX, int posY, Region region)
        {
            int random = rnd.Next(0, 4);

            if (random == 0)
            {
                spawnBomb(posX, posY, region);
            }
            else if (random == 1 )
            {
                spawnRupee(posX, posY, region);
            }
            else if (random == 2) {
                spawnHeart(posX, posY, region);
            }
            else
            {
                //spawns nothing, because the clock doesnt have anything it does yet... add in when clock does something
            }
        }

        public void groupCLoot(int posX, int posY, Region region)
        {
            int random = rnd.Next(0, 10);

            if (random == 0 || random == 2 || random == 6 || random == 7 || random == 8)
            {
                spawnRupee(posX, posY, region);
            }
            else if (random == 1 || random == 5 || random == 6 || random == 9)
            {
                spawnHeart(posX, posY, region);
            }
            else if (random == 1 || random == 4)
            {
                spawnBomb(posX, posY, region);
            }
            else {
                //blue ruppee isnt implemented so nothing happens lol. add in here when its implemented
            }
        }

        public void groupDLoot(int posX, int posY, Region region)
        {
            int random = rnd.Next(0, 10);

            if (random == 1 || random == 4)
            {
                spawnFairy(posX, posY, region);
            }
            else if (random == 2 || random == 8)
            {
                spawnRupee(posX, posY, region);
            }
            else
            {
                spawnHeart(posX, posY, region);
            }
        }


        public void spawnBomb(int posX, int posY, Region region)
        {
            IItem item = new BombItem(posX, posY);
            region.Areas[region.AreaIndex].AddItem(item);
            MainPhysicsHandler.AddStaticObject(item, item.Body().Hitbox.Bounds, region.AreaIndex);
        }

        public void spawnRupee(int posX, int posY, Region region)
        {
            IItem item = new RupeeItem(posX, posY);
            region.Areas[region.AreaIndex].AddItem(item);
            MainPhysicsHandler.AddStaticObject(item, item.Body().Hitbox.Bounds, region.AreaIndex);
        }

        public void spawnHalfHeart(int posX, int posY, Region region)
        {
            IItem item = new HalfHeartItem(posX, posY);
            region.Areas[region.AreaIndex].AddItem(item);
            MainPhysicsHandler.AddStaticObject(item, item.Body().Hitbox.Bounds, region.AreaIndex);
        }

        public void spawnHeart(int posX, int posY, Region region)
        {
            IItem item = new HeartItem(posX, posY);
            region.Areas[region.AreaIndex].AddItem(item);
            MainPhysicsHandler.AddStaticObject(item, item.Body().Hitbox.Bounds, region.AreaIndex);
        }

        public void spawnFairy(int posX, int posY, Region region)
        {
            IItem item = new FairyItem(posX, posY);
            region.Areas[region.AreaIndex].AddItem(item);
            MainPhysicsHandler.AddStaticObject(item, item.Body().Hitbox.Bounds, region.AreaIndex);
        }


        public void spawnClock(int posX, int posY, Region region)
        {
            IItem item = new ClockItem(posX, posY);
            region.Areas[region.AreaIndex].AddItem(item);
            MainPhysicsHandler.AddStaticObject(item, item.Body().Hitbox.Bounds, region.AreaIndex);
        }

        //TODO: do this for other items if needed
    }
}
