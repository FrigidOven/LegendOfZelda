using System.Collections.Generic;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites.Classes.UISprites;



namespace ZeldaNES.Tiles.Classes
{
    public class HealthBarTile : ITile
    {
        private bool isSolid;
        private List<HealthTile> hearts = new List<HealthTile>();
        private ITilePhysicsObject body;
       
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

        public HealthBarTile(int posX, int posY)
        {
            body = new TilePhysicsObject(posX, posY, this.isSolid);

            PosX = posX;
            PosY = posY;
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < 8; i++)
                {
                    hearts.Add(new HealthTile(
                        posX + i * UISpriteConstants.HeartSpriteSize * GeneralConstants.ImageScale,
                        posY + k * GeneralConstants.ImageScale * UISpriteConstants.HeartSpriteSize));
                   
                }
            }

            
        }
        public HealthBarTile() {
            this.isSolid = false;
            body = new TilePhysicsObject(0, 0, this.isSolid);
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < 8; i++)
                {
                    hearts.Add(new HealthTile(
                        0 + i * UISpriteConstants.HeartSpriteSize * GeneralConstants.ImageScale,
                        0 + k * GeneralConstants.ImageScale * UISpriteConstants.HeartSpriteSize));
                }
            }
        }
        public void SetValue(int num, int capacity) 
        {
            capacity /= 2;
            //check if num is odd
            int odd = num % 2;
            int totalHearts = 0;
            if (num < 0) {
                return;
            }
            if (odd != 0)
            {
                totalHearts++;
                int counter = 0;
                num -= 1;
                while (num != 0)
                {
                    hearts[counter].SetValue(2);
                    counter++;
                    num -= 2;
                };
                hearts[counter].SetValue(1);
                counter++;
                for (int i = counter; i < capacity; i++)
                {
                    hearts[i].SetValue(0);
                }
                for (int i = capacity; i < 16; i++)
                {
                    hearts[i].SetValue(3);
                }

            }
            else 
            {
                int counter = 0;
                while (num != 0)
                {
                    hearts[counter].SetValue(2);
                    counter++;
                    num -= 2;
                };
                for (int i = counter; i < capacity; i++)
                {
                    hearts[i].SetValue(0);
                }
                for (int i = capacity; i < 16; i++)
                {
                    hearts[i].SetValue(3);
                }

            }
        }
        public ITilePhysicsObject Body()
        {
            return body;
        }
        public void Update()
        {
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < 8; i++)
                {
                    hearts[i + (k * 8)].Update();
                    hearts[i + (k * 8)].PosX = this.PosX + i * UISpriteConstants.HeartSpriteSize * GeneralConstants.ImageScale;
                    hearts[i + (k * 8)].PosY = this.PosY + k * GeneralConstants.ImageScale * UISpriteConstants.HeartSpriteSize;



                }
            }
        }
        public void Draw() {
            for (int i = 0; i < 16; i++)
            {
                hearts[i].Draw();


            }
        }

        public bool IsSolid()
        {
            return isSolid;
        }
    }
}
