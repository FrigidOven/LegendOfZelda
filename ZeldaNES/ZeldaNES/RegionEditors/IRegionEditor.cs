using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprint2;

namespace ZeldaNES.RegionEditors
{
    public interface IRegionEditor
    {
        public ISprint2 GetRegionElementMultiplexor();

        public void AddRegionElementMultiplexor();
        public void Draw();
        public void Previous();
        public void Next();
        public void Update();
        public void Initialize();
        public void AddArea();
        public void RemoveArea();
        public void Undo();
        public int DoorDrawLinkingIndex { get; set; }
    }
}
