using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Doors1.LockedDoor;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;

namespace ZeldaNES.Doors1
{
    public interface IDoor
    {
        public void Update();
        public void Draw();
        public void DrawDebug();
        public Type GetLinkingType();
        public int GetIndex();
        public IDoorPhysicsObject Body();
        public int PosX { get; set; }
        public int PosY { get; set; }
        public IDoorState GetState();
        public void SetState(IDoorState state);
        public int Index { get; set; }
        public GeneralConstants.CardinalDirection GetCardinalPosition();
        void Open();
        void Close();
    }
}
