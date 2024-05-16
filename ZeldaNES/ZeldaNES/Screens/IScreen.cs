using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Items;
using ZeldaNES.NPCs;
using ZeldaNES.Players.Link;
using ZeldaNES.Sprint2;
using ZeldaNES.Tiles;
using ZeldaNES.Weapons;

namespace ZeldaNES.Screens
{
    public interface IScreen
    {
        void Quit();
        void Initialize();
        void Update();
        void Draw();
        string[] ContentToLoad();
        void LoadContent(Texture2D[] content);
        SpriteBatch GetSpriteBatch();
        Texture2D GetPlayerTexture();
        Texture2D GetWeaponTexture();
        ISprint2 GetSprint2Item();
        ISprint2 GetSprint2Tile();
        ISprint2 GetSprint2NPC();
        void AddFriendlyWeapon(IWeapon weapon);
        void AddHostileWeapon(IWeapon weapon);
    }
}
