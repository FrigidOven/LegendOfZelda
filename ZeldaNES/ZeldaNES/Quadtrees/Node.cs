using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.Quadtrees
{
    public class Node
    {
        public bool IsLeaf
        {
            get => count != -1;
        }

        public int count;
        public int firstChild;
        public Rectangle bounds;

        public Node(Rectangle bounds)
        {
            count = 0;
            firstChild = -1;
            this.bounds = bounds;
        }
    }
}
