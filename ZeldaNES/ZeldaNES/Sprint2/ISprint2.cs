using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Items;

namespace ZeldaNES.Sprint2
{
    public interface ISprint2: ICycleable
    {
        public GeneralConstants.Entities GetEntity();
        public GeneralConstants.EntitiesType GetEntityType();

        public void UpdateIndicator(int x, int y);
        int GetPosX();
        int GetPosY();
        void SetPosX(int x);
        void SetPosY(int y);
        void Draw();
        public int PosX { set; get; }
        public int PosY { set; get; }

    }
}
