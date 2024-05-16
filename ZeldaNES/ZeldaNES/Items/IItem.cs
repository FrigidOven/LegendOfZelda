using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Physics;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Players.Link;
using ZeldaNES.Screens;

namespace ZeldaNES.Items
{
    public interface IItem : IStaticObject
    {
        void Update();
        void Draw();
        void Terminate();
        bool ShouldDelete();
        void SetDeletable(bool deletable);
        public void UseItem(ILink link) {
            return;
        }
        public int PosX {get; set;}
        public int PosY { get; set; }
        public IItemPhysicsObject Body();
    }
}
