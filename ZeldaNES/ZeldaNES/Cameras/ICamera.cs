using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.Cameras
{
    public interface ICamera
    {
        public static ICamera Instance { get; }
        public Matrix Transform { get; }
        public Matrix UpScreen { get; }
        public Matrix DownScreen { get; }
        public Matrix LeftScreen { get; }
        public Matrix RightScreen { get; }
        public float Speed { set; }
        public float Scale { set; }
        public void Update();
        public void SetDestination(int posX, int posY);
        public void PanUp();
        public void PanDown();
        public void PanLeft();
        public void PanRight();
        public void Shift(int posX, int posY);
        public void SnapTo(int posX, int posY);
        public void Reset();

    }
}
