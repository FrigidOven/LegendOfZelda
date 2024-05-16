using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Sprites.UISprites;


namespace ZeldaNES.Tiles.Classes
{
    public class DigitTile : ITile
    {
        private bool isSolid;
        private ISprite sprite;
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

        public DigitTile(int posX, int posY)
        {
            body = new TilePhysicsObject(posX, posY, this.isSolid);

            PosX = posX;
            PosY = posY;
            sprite = new ZeroSprite(this);
        }
        public DigitTile() {
            this.isSolid = false;
            body = new TilePhysicsObject(0, 0, this.isSolid);
            sprite = new ZeroSprite(this);
        }
        public void SetValue(int num) {
            switch (num)
            {
                case 0:
                    sprite = new ZeroSprite(this);
                    break;
                case 1:
                    sprite = new OneSprite(this);
                    break;
                case 2:
                    sprite = new TwoSprite(this);
                    break;
                case 3:
                    sprite = new ThreeSprite(this);
                    break;
                case 4:
                    sprite = new FourSprite(this);
                    break;
                case 5:
                    sprite = new FiveSprite(this);
                    break;
                case 6:
                    sprite = new SixSprite(this);
                    break;
                case 7:
                    sprite = new SevenSprite(this);
                    break;
                case 8:
                    sprite = new EightSprite(this);
                    break;
                case 9:
                    sprite = new NineSprite(this);
                    break;
            }
        }
        public ITilePhysicsObject Body()
        {
            return body;
        }
        public void Update() {
            sprite.Update();
        }

        public void Draw() {
            sprite.Draw();
        }

        public bool IsSolid()
        {
            return isSolid;
        }
    }
}
