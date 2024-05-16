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

namespace ZeldaNES.Sprites.Classes.TileSprites

{
    public class IndicatorSprite : ISprite
    {
        static int SpriteIndex = DungeonTileSpriteConstants.WaterSpriteIndex;
        static int SpriteFrameCount = 1;
        static int SpriteStallFrameCount = 1;
        
        Rectangle[] Frames = new Rectangle[SpriteFrameCount];
        Rectangle destination;
        int stallframesCounter;
        int frameIndex;
        ITile owner;
        GraphicsDevice graphDev;
        Texture2D rect;
        public IndicatorSprite(ITile item) {
            
            for (int i = 0; i < SpriteFrameCount; i++)
            {
                Frames[i] = new Rectangle(  0, 
                                            SpriteIndex + i * DungeonTileSpriteConstants.TileSpriteSize, 
                                            DungeonTileSpriteConstants.TileSpriteSize, 
                                            DungeonTileSpriteConstants.TileSpriteSize);
            }
            destination = new Rectangle(    item.PosX - GeneralConstants.ImageScale * (DungeonTileSpriteConstants.TileSpriteSize / 2),
                                            item.PosY - GeneralConstants.ImageScale * (DungeonTileSpriteConstants.TileSpriteSize / 2),
                                            GeneralConstants.ImageScale * DungeonTileSpriteConstants.TileSpriteSize,
                                            GeneralConstants.ImageScale * DungeonTileSpriteConstants.TileSpriteSize);
            stallframesCounter = 0;
            frameIndex = 0;
            stallframesCounter = SpriteStallFrameCount;
            owner = item;
        }
        public void Update() { 
            if(stallframesCounter == SpriteStallFrameCount)
            {
                stallframesCounter = 0;
                frameIndex = (frameIndex + 1) % Frames.Length;
            }
            stallframesCounter++;

        }
        public void Draw()
        {

            if (graphDev == null)
            {
                graphDev = TextureManager.TextureManager.Instance.SpriteBatch.GraphicsDevice;
                rect = new Texture2D(graphDev, GeneralConstants.ImageScale * DungeonTileSpriteConstants.TileSpriteSize, GeneralConstants.ImageScale * DungeonTileSpriteConstants.TileSpriteSize);

                Color[] data = new Color[GeneralConstants.ImageScale * DungeonTileSpriteConstants.TileSpriteSize * GeneralConstants.ImageScale * DungeonTileSpriteConstants.TileSpriteSize];
                for (int i = 0; i < data.Length; ++i)
                {
                    data[i] = Color.Green;
                }
                rect.SetData(data);
            }
            int coordX = owner.PosX - GeneralConstants.ImageScale * (DungeonTileSpriteConstants.TileSpriteSize / 2);
            int coordY = owner.PosY - GeneralConstants.ImageScale * (DungeonTileSpriteConstants.TileSpriteSize / 2);

            Vector2 coord = new Vector2(coordX, coordY);
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(rect, coord, Color.White * .8f);
        }

    }
}
