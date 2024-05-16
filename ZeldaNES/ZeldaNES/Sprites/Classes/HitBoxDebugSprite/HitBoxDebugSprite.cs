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
using ZeldaNES.Physics.Hitboxes;

namespace ZeldaNES.Sprites.Classes.TileSprites

{
    public class HitBoxDebugSprite : ISprite
    {
        static int SpriteIndex = DungeonTileSpriteConstants.WaterSpriteIndex;
        static int SpriteFrameCount = 1;
        static int SpriteStallFrameCount = 1;
        
        Rectangle[] Frames = new Rectangle[SpriteFrameCount];
        Rectangle destination;
        int stallframesCounter;
        int frameIndex;
        IHitbox owner;
        GraphicsDevice graphDev;
        Texture2D rect;
        public HitBoxDebugSprite(IHitbox hitbox) {
           
            destination = new Rectangle(    hitbox.PosX - GeneralConstants.ImageScale * (DungeonTileSpriteConstants.TileSpriteSize / 2),
                                            hitbox.PosY - GeneralConstants.ImageScale * (DungeonTileSpriteConstants.TileSpriteSize / 2),
                                            GeneralConstants.ImageScale * DungeonTileSpriteConstants.TileSpriteSize,
                                            GeneralConstants.ImageScale * DungeonTileSpriteConstants.TileSpriteSize);
            stallframesCounter = 0;
            frameIndex = 0;
            stallframesCounter = SpriteStallFrameCount;
            owner = hitbox;
        }
        public void Update() { 
      

        }
        public void Draw()
        {

            if (graphDev == null)
            {
                graphDev = TextureManager.TextureManager.Instance.SpriteBatch.GraphicsDevice;
                rect = new Texture2D(graphDev, owner.Bounds.Width, owner.Bounds.Height);

                Color[] data = new Color[owner.Bounds.Width* owner.Bounds.Height];
                for (int i = 0; i < data.Length; ++i)
                {
                    data[i] = Color.Yellow;
                }
                rect.SetData(data);
            }
            int coordX = owner.PosX - owner.Bounds.Width /2;
            int coordY = owner.PosY - owner.Bounds.Height /2;

            Vector2 coord = new Vector2(coordX, coordY);
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(rect, coord, Color.White * .8f);
        }

    }
}
