using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.Quadtrees
{
    public class ElmNode
    {
        public int elmIndex;
        public Rectangle bounds;
        public int next;

        public ElmNode(int elmIndex, Rectangle bounds)
        {
            this.elmIndex = elmIndex;
            this.bounds = bounds;
            next = -1;
        }
    }
}
