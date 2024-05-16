using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.TextureManager
{


    public sealed class TextureManager
    {
        private static TextureManager instance = null;
        private static readonly Object padlock = new object();
        public SpriteBatch SpriteBatch;

        public Texture2D weaponTexture;
        public Texture2D itemTexture;
        public Texture2D npcTexture;
        public Texture2D tileTexture;
        public Texture2D playerTexture;
        public Texture2D UIPauseMenuTexture;
        public Texture2D UIStartScreenTexture;
        public SpriteFont gameFont;
        private TextureManager(ContentManager Content, SpriteBatch sb) 
        {
            this.SpriteBatch = sb;
            Debug.WriteLine("Spritebatch", sb.ToString());
            gameFont = Content.Load<SpriteFont>("GameFont");
            npcTexture = Content.Load<Texture2D>(GeneralConstants.npcTextureString);
            playerTexture = Content.Load<Texture2D>(GeneralConstants.playerTextureString);
            weaponTexture = Content.Load<Texture2D>(GeneralConstants.weaponTextureString);
            itemTexture = Content.Load<Texture2D>(GeneralConstants.itemTextureString);
            tileTexture = Content.Load<Texture2D>(GeneralConstants.tileTextureString);
            UIPauseMenuTexture = Content.Load<Texture2D>(GeneralConstants.UIPauseMenuTextureString);
            UIStartScreenTexture = Content.Load<Texture2D>(GeneralConstants.UIStartScreenTextureString);
        }
        public static TextureManager Instance
        {
            get
            {
                    return instance;
                
            }
        }
        public static TextureManager GenInstance(ContentManager Content, SpriteBatch SpriteBatch)
        {
          
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new TextureManager(Content, SpriteBatch);
                    }
                    return instance;
                }
            
        }

    }
}
