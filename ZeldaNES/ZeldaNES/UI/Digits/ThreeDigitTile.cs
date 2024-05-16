using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Sprites.Classes.UISprites;
using ZeldaNES.Sprites.UISprites;


namespace ZeldaNES.Tiles.Classes
{
    public class ThreeDigitTile : ITile
    {
        private bool isSolid;
        private List<DigitTile> digits = new List<DigitTile>();
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

        public ThreeDigitTile(int posX, int posY)
        {
            body = new TilePhysicsObject(posX, posY, this.isSolid);

            PosX = posX;
            PosY = posY;
            int counter = 0;
            for (int i = 0; i < 3; i++) {
                digits.Add( new DigitTile());
            }
            foreach (DigitTile digi in digits)
            {
                
                digi.PosX = posX  + counter * (3 * UISpriteConstants.TextSpriteSize) / 4 * GeneralConstants.ImageScale;
                digi.PosY = posY;
                counter++;
            }
        }
        public ThreeDigitTile() {
            this.isSolid = false;
            body = new TilePhysicsObject(0, 0, this.isSolid);
        }
        public void SetValue(int num) {
            int Hundreds = num / 100;
            num %= 100;
            int Tens = num / 10;
            int Ones = num % 10;
            digits[0].SetValue(Hundreds);
            digits[1].SetValue(Tens);
            digits[2].SetValue(Ones);


        }
        public ITilePhysicsObject Body()
        {
            return body;
        }
        public void Update() {
            int counter = 0;
           
            foreach (DigitTile digi in digits)
            {
                digi.PosX = PosX + counter * (3 * UISpriteConstants.TextSpriteSize) / 4 * GeneralConstants.ImageScale;
                digi.PosY = this.PosY;
                digi.Update();
                counter++;
            }
        }

        public void Draw() {
            foreach (DigitTile digi in digits)
            {
                digi.Draw();

            }
        }

        public bool IsSolid()
        {
            return isSolid;
        }
    }
}
