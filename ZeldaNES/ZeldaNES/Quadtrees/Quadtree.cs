using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ZeldaNES.Quadtrees
{
    public class Quadtree<T>
        where T : class
    {
        private static int MAX_COUNT = 1;
        private static int MAX_DEPTH = 7;

        private Rectangle rootBounds;

        private ListWithGaps<Node> nodes;
        private ListWithGaps<ElmNode> elmNodes;
        private ListWithGaps<T> elms;

        private int leafCount;

        public Quadtree(Rectangle rootBounds)
        {
            this.rootBounds = rootBounds;

            nodes = new ListWithGaps<Node>();
            elmNodes = new ListWithGaps<ElmNode>();
            elms = new ListWithGaps<T>();

            nodes.Add(new Node(rootBounds));

            leafCount = 1;
        }
        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            // red square on link sprite
            Rectangle sourceRect = new Rectangle(16, 352, 1, 1);


            for(int i = 0; i < nodes.Count; i++)
            {
                Rectangle leftEdge = new Rectangle(nodes.ValueAt(i).bounds.Left, nodes.ValueAt(i).bounds.Y, 1, nodes.ValueAt(i).bounds.Height);
                Rectangle rightEdge = new Rectangle(nodes.ValueAt(i).bounds.Right, nodes.ValueAt(i).bounds.Y, 1, nodes.ValueAt(i).bounds.Height);
                Rectangle topEdge = new Rectangle(nodes.ValueAt(i).bounds.X, nodes.ValueAt(i).bounds.Top, nodes.ValueAt(i).bounds.Width, 1);
                Rectangle bottomEdge = new Rectangle(nodes.ValueAt(i).bounds.X, nodes.ValueAt(i).bounds.Bottom, nodes.ValueAt(i).bounds.Width, 1);

                spriteBatch.Draw(texture, leftEdge, sourceRect, Color.White);
                spriteBatch.Draw(texture, topEdge, sourceRect, Color.White);
                spriteBatch.Draw(texture, rightEdge, sourceRect, Color.White);
                spriteBatch.Draw(texture, bottomEdge, sourceRect, Color.White);
            }
        }
        public void Add(T elm, Rectangle elmBounds)
        {
            if (!nodes.ValueAt(0).bounds.Intersects(elmBounds))
            {
                return;
            }
            int elmIndex = elmIndex = elms.Add(elm);

            Stack<(int, int)> leaves = new Stack<(int, int)>();
            leaves.Push((0, 1));

            while (leaves.Count > 0)
            {
                (int, int) leaf = leaves.Pop();

                if (!nodes.ValueAt(leaf.Item1).IsLeaf)
                {
                    int northwest = nodes.ValueAt(leaf.Item1).firstChild;
                    for (int i = 0; i < 4; i++)
                    {
                        if (nodes.ValueAt(northwest + i).bounds.Intersects(elmBounds))
                        {
                            leaves.Push((northwest + i, leaf.Item2 + 1));
                        }
                    }
                    continue;
                }

                if (nodes.ValueAt(leaf.Item1).count == MAX_COUNT && leaf.Item2 < MAX_DEPTH)
                {
                    Divide(leaf.Item1);
                    // push each quadrant of the branch onto the stack of leaves to add to if the element
                    // fits into that leaf
                    int northwest = nodes.ValueAt(leaf.Item1).firstChild;
                    for (int i = 0; i < 4; i++)
                    {
                        if (nodes.ValueAt(northwest + i).bounds.Intersects(elmBounds))
                        {
                            leaves.Push((northwest + i, leaf.Item2 + 1));
                        }
                    }
                    continue;
                }

                // create the element node and add it to the head of the list,
                // then change the head to point to the new element node.
                ElmNode elmNode = new ElmNode(elmIndex, elmBounds);
                elmNode.next = nodes.ValueAt(leaf.Item1).firstChild;
                int elmId = elmNodes.Add(elmNode);
                nodes.ValueAt(leaf.Item1).firstChild = elmId;
                nodes.ValueAt(leaf.Item1).count++;
            }
        }
        private void Divide(int leaf)
        {
            // mark the leaf as a branch
            nodes.ValueAt(leaf).count = -1;

            // get the head of the list of elm nodes
            int elmChain = nodes.ValueAt(leaf).firstChild;

            // alot the 4 quadrants
            int northwest = nodes.Add(new Node(NorthwestBoundingBox(nodes.ValueAt(leaf).bounds)));
            nodes.Add(new Node(NortheastBoundingBox(nodes.ValueAt(leaf).bounds)));
            nodes.Add(new Node(SouthwestBoundingBox(nodes.ValueAt(leaf).bounds)));
            nodes.Add(new Node(SoutheastBoundingBox(nodes.ValueAt(leaf).bounds)));

            // make branch point to northwest quadrant
            nodes.ValueAt(leaf).firstChild = northwest;

            // the leaf will only be here if it had MAX_COUNT element nodes, so we know
            // the number of elements is just MAX_COUNT.
            // we will re-add the element nodes to the the new children of the leaf since
            // branches cannot contain leaves
            // we re-add since there will be more than one copy of the node if it fits into
            // more than one child
            for (int i = 0; i < MAX_COUNT; i++)
            {
                int next = elmNodes.ValueAt(elmChain).next;
                for (int j = 0; j < 4; j++)
                {
                    if (nodes.ValueAt(northwest + j).bounds.Intersects(elmNodes.ValueAt(elmChain).bounds))
                    {
                        ElmNode elm = new ElmNode(elmNodes.ValueAt(elmChain).elmIndex, elmNodes.ValueAt(elmChain).bounds);
                        elm.next = nodes.ValueAt(northwest + j).firstChild;
                        int elmNode = elmNodes.Add(elm);
                        nodes.ValueAt(northwest + j).firstChild = elmNode;
                        nodes.ValueAt(northwest + j).count++;
                    }
                }
                // discard the old nodes
                elmNodes.Remove(elmChain);
                elmChain = next;
            }
            leafCount += 3;
        }
        public void Remove(T elm, Rectangle elmBounds)
        {
            Stack<int> leaves = new Stack<int>();
            int elmIndex = -1;
            leaves.Push(0);

            while (leaves.Count > 0)
            {
                int leaf = leaves.Pop();
                if (!nodes.ValueAt(leaf).IsLeaf)
                {
                    int northwest = nodes.ValueAt(leaf).firstChild;
                    for (int i = 0; i < 4; i++)
                    {
                        if (nodes.ValueAt(northwest + i).bounds.Intersects(elmBounds))
                        {
                            leaves.Push(northwest + i);
                        }
                    }
                    continue;
                }
                if (elms.ValueAt(elmNodes.ValueAt(nodes.ValueAt(leaf).firstChild).elmIndex).Equals(elm))
                {
                    elmIndex = elmNodes.ValueAt(nodes.ValueAt(leaf).firstChild).elmIndex;

                    int oldHead = nodes.ValueAt(leaf).firstChild;

                    nodes.ValueAt(leaf).firstChild = elmNodes.ValueAt(oldHead).next;
                    nodes.ValueAt(leaf).count--;

                    elmNodes.Remove(oldHead);
                    continue;
                }

                int curElm = nodes.ValueAt(leaf).firstChild;
                int preElm = curElm;

                while (curElm != -1)
                {
                    if (elms.ValueAt(elmNodes.ValueAt(curElm).elmIndex).Equals(elm))
                    {
                        elmIndex = elmNodes.ValueAt(curElm).elmIndex;

                        elmNodes.ValueAt(preElm).next = elmNodes.ValueAt(curElm).next;
                        nodes.ValueAt(leaf).count--;

                        elmNodes.Remove(curElm);
                        break;
                    }
                    preElm = curElm;
                    curElm = elmNodes.ValueAt(curElm).next;
                }
            }
            elms.Remove(elmIndex);
        }
        public void Relocate(T elm, Rectangle oldElmBounds, Rectangle newElmBounds)
        {
            Stack<int> branches = new Stack<int>();
            Stack<int> leaves = new Stack<int>();
            branches.Push(0);
            int elmIndex = -1;

            while (branches.Count > 0)
            {
                int branch = branches.Pop();

                if (!nodes.ValueAt(branch).IsLeaf)
                {
                    int northwest = nodes.ValueAt(branch).firstChild;
                    for (int i = 0; i < 4; i++)
                    {
                        if (nodes.ValueAt(northwest + i).bounds.Intersects(oldElmBounds) ||
                           nodes.ValueAt(northwest + i).bounds.Intersects(newElmBounds))
                        {
                            branches.Push(northwest + i);
                        }
                    }
                    continue;
                }
                if (elmIndex == -1 && nodes.ValueAt(branch).bounds.Intersects(oldElmBounds))
                {
                    int head = nodes.ValueAt(branch).firstChild;
                    while (head != -1)
                    {
                        if (elms.ValueAt(elmNodes.ValueAt(head).elmIndex).Equals(elm))
                        {
                            elmIndex = head;
                            break;
                        }

                        head = elmNodes.ValueAt(head).next;
                    }
                }
                leaves.Push(branch);
            }
            while (leaves.Count > 0)
            {
                int leaf = leaves.Pop();
                if (!nodes.ValueAt(leaf).bounds.Intersects(newElmBounds))
                {
                    if (elms.ValueAt(elmNodes.ValueAt(nodes.ValueAt(leaf).firstChild).elmIndex).Equals(elm))
                    {
                        int oldHead = nodes.ValueAt(leaf).firstChild;

                        nodes.ValueAt(leaf).firstChild = elmNodes.ValueAt(oldHead).next;
                        nodes.ValueAt(leaf).count--;

                        elmNodes.Remove(oldHead);
                        continue;
                    }

                    int curElm = nodes.ValueAt(leaf).firstChild;
                    int preElm = curElm;

                    while (curElm != -1)
                    {
                        if (elms.ValueAt(elmNodes.ValueAt(curElm).elmIndex).Equals(elm))
                        {
                            elmNodes.ValueAt(preElm).next = elmNodes.ValueAt(curElm).next;
                            nodes.ValueAt(leaf).count--;

                            elmNodes.Remove(curElm);
                            break;
                        }
                        preElm = curElm;
                        curElm = elmNodes.ValueAt(curElm).next;
                    }
                    continue;
                }
                if (!nodes.ValueAt(leaf).bounds.Intersects(oldElmBounds))
                {
                    // TODO: should check depth
                    if (nodes.ValueAt(leaf).count == MAX_COUNT)
                    {
                        Divide(leaf);
                        int northwest = nodes.ValueAt(leaf).firstChild;
                        for (int i = 0; i < 4; i++)
                        {
                            if (nodes.ValueAt(northwest + i).bounds.Intersects(newElmBounds))
                            {
                                leaves.Push(northwest + i);
                            }
                        }
                        continue;
                    }
                    ElmNode elmNode = new ElmNode(elmIndex, newElmBounds);
                    elmNode.next = nodes.ValueAt(leaf).firstChild;
                    int elmId = elmNodes.Add(elmNode);
                    nodes.ValueAt(leaf).firstChild = elmId;
                    nodes.ValueAt(leaf).count++;
                    continue;
                }
            }
        }
        public void Trim()
        {
            Stack<int> branches = new Stack<int>();
            branches.Push(0);
            while (branches.Count > 0)
            {
                int branch = branches.Pop();

                // a leaf cannot be trimmed, only branches can
                if (nodes.ValueAt(branch).IsLeaf)
                {
                    continue;
                }

                int emptyLeaves = 0;
                int northwest = nodes.ValueAt(branch).firstChild;

                // check the quadrants
                for (int i = 0; i < 4; i++)
                {
                    // add any extra branches to be procced
                    if (!nodes.ValueAt(northwest + i).IsLeaf)
                    {
                        branches.Push(northwest + i);
                    }
                    // otherwise, if its a leaf, check if its empty
                    else if (nodes.ValueAt(northwest + i).count == 0)
                    {
                        emptyLeaves++;
                    }
                }

                if (emptyLeaves == 4)
                {
                    // make it a leaf if its leaves are all empty
                    nodes.ValueAt(branch).count = 0;
                    nodes.ValueAt(branch).firstChild = -1;

                    nodes.Remove(northwest);
                    nodes.Remove(northwest + 1);
                    nodes.Remove(northwest + 2);
                    nodes.Remove(northwest + 3);

                    leafCount -= 3;
                }
            }
        }
        public HashSet<T> QueryAll()
        {
            return QueryArea(rootBounds);
        }
        public HashSet<T> QueryArea(Rectangle area)
        {
            Stack<int> branches = new Stack<int>();
            HashSet<T> entries = new HashSet<T>();

            if (rootBounds.Intersects(area))
            {
                branches.Push(0);
            }

            while (branches.Count > 0)
            {
                int branch = branches.Pop();

                if(nodes.ValueAt(branch).IsLeaf)
                {
                    int elementChain = nodes.ValueAt(branch).firstChild;
                    for (int i = 0; elementChain != -1; i++)
                    {
                        if (elmNodes.ValueAt(elementChain).bounds.Intersects(area))
                        {
                            entries.Add(elms.ValueAt(elmNodes.ValueAt(elementChain).elmIndex));
                        }
                        elementChain = elmNodes.ValueAt(elementChain).next;
                    }
                    continue;
                }
                int northwest = nodes.ValueAt(branch).firstChild;
                for (int i = 0; i < 4; i++)
                {
                    if (nodes.ValueAt(northwest + i).bounds.Intersects(area))
                    {
                        branches.Push(northwest + i);
                    }
                }
            }

            return entries;
        }
        private Rectangle NorthwestBoundingBox(Rectangle bounds)
        {
            int width = bounds.Width / 2;
            int height = bounds.Height / 2;
            int x = bounds.X;
            int y = bounds.Y;

            return new Rectangle(x, y, width, height);
        }
        private Rectangle NortheastBoundingBox(Rectangle bounds)
        {
            int width = bounds.Width / 2;
            width += bounds.Width % 2 == 0 ? 0 : 1;
            int height = bounds.Height / 2;
            int x = (bounds.X + bounds.Width) - width;
            int y = bounds.Y;

            return new Rectangle(x, y, width, height);
        }
        private Rectangle SouthwestBoundingBox(Rectangle bounds)
        {
            int width = bounds.Width / 2;
            int height = bounds.Height / 2;
            height += bounds.Height % 2 == 0 ? 0 : 1;
            int x = bounds.X;
            int y = (bounds.Y + bounds.Height) - height;

            return new Rectangle(x, y, width, height);
        }
        private Rectangle SoutheastBoundingBox(Rectangle bounds)
        {
            int width = bounds.Width / 2;
            width += bounds.Width % 2 == 0 ? 0 : 1;
            int height = bounds.Height / 2;
            height += bounds.Height % 2 == 0 ? 0 : 1;
            int x = (bounds.X + bounds.Width) - width;
            int y = (bounds.Y + bounds.Height) - height;

            return new Rectangle(x, y, width, height);
        }
    }
}
