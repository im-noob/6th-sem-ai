using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AI8TilesProgTH
{
    public enum ActionType 
    {
        L,
        R,
        U,
        D
    }

    class ClassNode
    {
        public int NodeSize;        // Simplifies works
        public int[,] NodeState;    // Node steta is a 2 dimentional array
        public Point LoB;           // Location of Blank Tile (Empty Location)
        public ClassNode ParentNode;

        public int Cost = -1;
        public int Heur = -1;
        
        public ClassNode(int PSize) // Constructor for generating a goal node. Remember that all initial configurationa are SHUFFED from Goal node to avoid unsolvable problems.
        {
            NodeSize = PSize;
            NodeState = new int[PSize,PSize];
            for (int i = 0; i < NodeSize; i++)
            {
                for (int j = 0; j < NodeSize; j++)
                {
                    NodeState[i, j] = (i * NodeSize) + j + 1;
                }
            }
            NodeState[NodeSize - 1, NodeSize - 1] = 0;
            LoB = new Point(NodeSize - 1, NodeSize - 1);
            ParentNode = null;
        }
        
        public ClassNode(int[,] StatesAtCreation)   // Constroctor when initial state is known (when loaded from an XML file)
        {
            NodeSize = Math.Abs((int)Math.Sqrt(StatesAtCreation.Length));
            NodeState = StatesAtCreation;            
            for (int i = 0; i < NodeSize; i++)
            {
                for (int j = 0; j < NodeSize; j++)
                {
                    if (NodeState[i, j] == 0)
                    {
                        LoB = new Point(i, j);
                    }
                }
            }
            ParentNode = null;
        }

        public ClassNode(ClassNode NodeToBeCopied, ActionType type)      // Copy Constructor for Successors
        {
            NodeSize = NodeToBeCopied.NodeSize;
            switch (type)
            { 
                case ActionType.U:
                    LoB = new Point(NodeToBeCopied.LoB.X - 1, NodeToBeCopied.LoB.Y);
                    break;
                case ActionType.R:
                    LoB = new Point(NodeToBeCopied.LoB.X, NodeToBeCopied.LoB.Y + 1);
                    break;
                case ActionType.L:
                    LoB = new Point(NodeToBeCopied.LoB.X, NodeToBeCopied.LoB.Y - 1);
                    break;
                case ActionType.D:
                    LoB = new Point(NodeToBeCopied.LoB.X + 1, NodeToBeCopied.LoB.Y);
                    break;
            }
            Cost = NodeToBeCopied.Cost + 1;
            NodeState = (int[,]) NodeToBeCopied.NodeState.Clone();
            NodeState[NodeToBeCopied.LoB.X, NodeToBeCopied.LoB.Y] = NodeToBeCopied.NodeState[LoB.X, LoB.Y];             // PROBLEM
            NodeState[LoB.X, LoB.Y] = 0;
            ParentNode = NodeToBeCopied;
        }

        public List<ClassNode> GetSuccessors()
        {
            List<ClassNode> result = new List<ClassNode>();
            if (LoB.X < NodeSize - 1)
                result.Add(new ClassNode(this, ActionType.D));
            if (LoB.Y > 0)
                result.Add(new ClassNode(this, ActionType.L));
            if (LoB.Y < NodeSize - 1)
                result.Add(new ClassNode(this, ActionType.R));
            if (LoB.X > 0)
                result.Add(new ClassNode(this, ActionType.U));
            return result;
        }

        public ClassNode GetParent()
        {
            //List<int[,]> result = new List<int[,]>();
            if (ParentNode != null)
            {
                //result.a
                //result.AddRange(ParentNode.GetPath());
                //result.Add(NodeState);
                return ParentNode;
            }
            else
                return null;
        }
        

    }
}
