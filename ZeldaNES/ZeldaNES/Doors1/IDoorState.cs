using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.Doors1
{
    public interface IDoorState
    {
        public void Update();
        public void Draw();
        public void DrawDebug();
        public Type GetLinkingType();
        public IDoor Door { get; set; }
        public GeneralConstants.CardinalDirection GetCardinalPosition();
        public int PosX { get; set; }
        public int PosY { get; set; }
        public bool Passable { get; set; }
        void Open();
        void Close();
    }
}
