using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Tiles;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.UISprites;
using ZeldaNES.Tiles.Classes;
using ZeldaNES.UI.PauseMenus;

namespace ZeldaNES.Sprites.Classes.TileSprites

{
    public class PauseMenuBackgroundSprite : ISprite
    {
        static int SpriteIndex = DungeonTileSpriteConstants.BlackSpriteIndex;
        static int SpriteFrameCount = 1;
        static int SpriteStallFrameCount = 1;
        
        Rectangle[] Frames = new Rectangle[SpriteFrameCount];
        Rectangle destination;
        int stallframesCounter;
        int frameIndex;
        PauseMenu owner;
        public PauseMenuBackgroundSprite(PauseMenu owner) {
            
            for (int i = 0; i < SpriteFrameCount; i++)
            {
                Frames[i] = new Rectangle(  UISpriteConstants.PauseScreenX, UISpriteConstants.PauseScreenY,  UISpriteConstants.PauseScreenWidth,UISpriteConstants.PauseScreenHeight);
            }
            destination = new Rectangle(    owner.PosX - GeneralConstants.ImageScale * (DungeonTileSpriteConstants.TileSpriteSize / 2),
                                            owner.PosY - GeneralConstants.ImageScale * (DungeonTileSpriteConstants.TileSpriteSize / 2),
                                            GeneralConstants.ImageScale * DungeonTileSpriteConstants.TileSpriteSize,
                                            GeneralConstants.ImageScale * DungeonTileSpriteConstants.TileSpriteSize);
            stallframesCounter = 0;
            frameIndex = 0;
            stallframesCounter = SpriteStallFrameCount;
            this.owner = owner;
        }
        public void Update() { 
            if(stallframesCounter == SpriteStallFrameCount)
            {
                stallframesCounter = 0;
                frameIndex = (frameIndex + 1) % Frames.Length;
            }
            stallframesCounter++;

        }
        public void Draw() {
            destination = new Rectangle(owner.PosX, owner.PosY, 16 * 16 * GeneralConstants.ImageScale, 16 * 15 * GeneralConstants.ImageScale);

            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.UIPauseMenuTexture, destination, Frames[frameIndex], Color.White);
        }

    }
}
