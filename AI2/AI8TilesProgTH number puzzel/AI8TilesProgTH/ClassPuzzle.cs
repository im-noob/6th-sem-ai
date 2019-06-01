using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Xml.Linq;

namespace AI8TilesProgTH
{
    class ClassPuzzle
    {
        public int PuzzleSize;
        public ClassNode InitNode;
        public ClassNode GoalNode;
        public int DesiredStep = -1;           // -1 means that info is not available. It will remain as -1 if the corresponding string is empty in the XML File
        public bool BFSSolved = false;
        public bool DFSSolved = false;
        public bool IDFSSolved = false;
        public bool AStarMisSolved = false;
        public bool AStarManSolved = false;
        public int BFSSolTime = -1;
        public int DFSSolTime = -1;
        public int IDFSSolTime = -1;
        public int AStarMisSolTime = -1;
        public int AStarManSolTime = -1;
        public int BFSNumStoNodes = -1;
        public int DFSNumStoNodes = -1;
        public int IDFSNumStoNodes = -1;
        public int AStarMisNumStoNodes = -1;
        public int AStarManNumStoNodes = -1;
        public int BFSNumExpNodes = -1;
        public int DFSNumExpNodes = -1;
        public int IDFSNumExpNodes = -1;
        public int AStarMisNumExpNodes = -1;
        public int AStarManNumExpNodes = -1;
        public int BFSSolStep = -1;
        public int DFSSolStep = -1;
        public int IDFSSolStep = -1;
        public int AStarMisSolStep = -1;
        public int AStarManSolStep = -1;
        public List<ClassNode> BFSSolSteps = new List<ClassNode>();
        public List<ClassNode> DFSSolSteps = new List<ClassNode>();
        public List<ClassNode> IDFSSolSteps = new List<ClassNode>();
        public List<ClassNode> AStarMisSolSteps = new List<ClassNode>();
        public List<ClassNode> AStarManSolSteps = new List<ClassNode>();
        public bool b_abort = false;

        public int MCPuzNum = 0;
        public int WhichSolver = 0;

        public ClassPuzzle(XmlNode PuzzleInXML)
        {
            XmlNodeList xList;
            XmlNodeList xListAlgs;              // Just makes simpler
            string DummyStr;

            xList = PuzzleInXML.ChildNodes;
            DummyStr = xList[0].InnerText;
            PuzzleSize = Convert.ToInt32(DummyStr);     // Puzzle size is set

            DummyStr = xList[1].InnerText;
            string[] StatesArray = DummyStr.Split(',');
            int[,] StatesVals = new int[PuzzleSize, PuzzleSize];
            for (int i = 0; i < PuzzleSize; i++)
            {
                for (int j = 0; j < PuzzleSize; j++)
                {
                    StatesVals[i, j] = Convert.ToInt32(StatesArray[(i * PuzzleSize) + j]);
                }
            }
            InitNode = new ClassNode(StatesVals);       // InitNode and GoalNode are created.   
            GoalNode = new ClassNode(PuzzleSize);       // Having 2 different contructors, useful

            DummyStr = xList[2].InnerText;
            if (DummyStr == "N/A")
            { }
            else
            {
                DesiredStep = Convert.ToInt32(DummyStr);
            }

            xList = PuzzleInXML.LastChild.ChildNodes;       // BFS, DFS, IDFE A*Mis, A*Man. I will call their childs to xListAlgs
            xListAlgs = xList[0].ChildNodes;                // Child Nodes of BFS Nodes

            // SAME FOR ALL 5 ALGORITHMS
            DummyStr = xListAlgs[0].InnerText;              // Get Whwthwe Puzzle Solved With BFS
            if (DummyStr == "F")
            {
                BFSSolved = false;
            }
            else if (DummyStr == "T")
            {
                BFSSolved = true;
            }

            DummyStr = xListAlgs[1].InnerText;              // Get solution Time in Seconds
            if (DummyStr != "")
            {
                BFSSolTime = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[2].InnerText;              // Get Number of Stored Nodes
            if (DummyStr != "")
            {
                BFSNumStoNodes = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[3].InnerText;              // Get Number of Expanded Nodes
            if (DummyStr != "")
            {
                BFSNumExpNodes = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[4].InnerText;              // Get Number of Solution Step
            if (DummyStr != "")
            {
                BFSSolStep = Convert.ToInt32(DummyStr);
            }

            xListAlgs = xListAlgs[5].ChildNodes;            // Construct Solution Steps 
            foreach (XmlNode xmlN in xListAlgs)
            {
                DummyStr = xmlN.InnerText;
                StatesArray = DummyStr.Split(',');
                StatesVals = new int[PuzzleSize, PuzzleSize];
                for (int i = 0; i < PuzzleSize; i++)
                {
                    for (int j = 0; j < PuzzleSize; j++)
                    {
                        StatesVals[i, j] = Convert.ToInt32(StatesArray[(i * PuzzleSize) + j]);
                    }
                }
                BFSSolSteps.Add(new ClassNode(StatesVals));
            }

            xListAlgs = xList[1].ChildNodes;                // Child Nodes of DFS Nodes
            // SAME FOR ALL 5 ALGORITHMS
            DummyStr = xListAlgs[0].InnerText;              // Get Whwthwe Puzzle Solved With BFS
            if (DummyStr == "F")
            {
                DFSSolved = false;
            }
            else if (DummyStr == "T")
            {
                DFSSolved = true;
            }

            DummyStr = xListAlgs[1].InnerText;              // Get solution Time in Seconds
            if (DummyStr != "")
            {
                DFSSolTime = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[2].InnerText;              // Get Number of Stored Nodes
            if (DummyStr != "")
            {
                DFSNumStoNodes = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[3].InnerText;              // Get Number of Expanded Nodes
            if (DummyStr != "")
            {
                DFSNumExpNodes = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[4].InnerText;              // Get Number of Solution Step
            if (DummyStr != "")
            {
                DFSSolStep = Convert.ToInt32(DummyStr);
            }

            xListAlgs = xListAlgs[5].ChildNodes;            // Construct Solution Steps 
            foreach (XmlNode xmlN in xListAlgs)
            {
                DummyStr = xmlN.InnerText;
                StatesArray = DummyStr.Split(',');
                StatesVals = new int[PuzzleSize, PuzzleSize];
                for (int i = 0; i < PuzzleSize; i++)
                {
                    for (int j = 0; j < PuzzleSize; j++)
                    {
                        StatesVals[i, j] = Convert.ToInt32(StatesArray[(i * PuzzleSize) + j]);
                    }
                }
                DFSSolSteps.Add(new ClassNode(StatesVals));
            }


            xListAlgs = xList[2].ChildNodes;                // Child Nodes of IDFS Nodes
            // SAME FOR ALL 5 ALGORITHMS
            DummyStr = xListAlgs[0].InnerText;              // Get Whwthwe Puzzle Solved With BFS
            if (DummyStr == "F")
            {
                IDFSSolved = false;
            }
            else if (DummyStr == "T")
            {
                IDFSSolved = true;
            }

            DummyStr = xListAlgs[1].InnerText;              // Get solution Time in Seconds
            if (DummyStr != "")
            {
                IDFSSolTime = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[2].InnerText;              // Get Number of Stored Nodes
            if (DummyStr != "")
            {
                IDFSNumStoNodes = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[3].InnerText;              // Get Number of Expanded Nodes
            if (DummyStr != "")
            {
                IDFSNumExpNodes = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[4].InnerText;              // Get Number of Solution Step
            if (DummyStr != "")
            {
                IDFSSolStep = Convert.ToInt32(DummyStr);
            }

            xListAlgs = xListAlgs[5].ChildNodes;            // Construct Solution Steps 
            foreach (XmlNode xmlN in xListAlgs)
            {
                DummyStr = xmlN.InnerText;
                StatesArray = DummyStr.Split(',');
                StatesVals = new int[PuzzleSize, PuzzleSize];
                for (int i = 0; i < PuzzleSize; i++)
                {
                    for (int j = 0; j < PuzzleSize; j++)
                    {
                        StatesVals[i, j] = Convert.ToInt32(StatesArray[(i * PuzzleSize) + j]);
                    }
                }
                IDFSSolSteps.Add(new ClassNode(StatesVals));
            }


            xListAlgs = xList[3].ChildNodes;                // Child Nodes of AStarMis Nodes
            // SAME FOR ALL 5 ALGORITHMS
            DummyStr = xListAlgs[0].InnerText;              // Get Whwthwe Puzzle Solved With BFS
            if (DummyStr == "F")
            {
                AStarMisSolved = false;
            }
            else if (DummyStr == "T")
            {
                AStarMisSolved = true;
            }

            DummyStr = xListAlgs[1].InnerText;              // Get solution Time in Seconds
            if (DummyStr != "")
            {
                AStarMisSolTime = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[2].InnerText;              // Get Number of Stored Nodes
            if (DummyStr != "")
            {
                AStarMisNumStoNodes = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[3].InnerText;              // Get Number of Expanded Nodes
            if (DummyStr != "")
            {
                AStarMisNumExpNodes = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[4].InnerText;              // Get Number of Solution Step
            if (DummyStr != "")
            {
                AStarMisSolStep = Convert.ToInt32(DummyStr);
            }

            xListAlgs = xListAlgs[5].ChildNodes;            // Construct Solution Steps 
            foreach (XmlNode xmlN in xListAlgs)
            {
                DummyStr = xmlN.InnerText;
                StatesArray = DummyStr.Split(',');
                StatesVals = new int[PuzzleSize, PuzzleSize];
                for (int i = 0; i < PuzzleSize; i++)
                {
                    for (int j = 0; j < PuzzleSize; j++)
                    {
                        StatesVals[i, j] = Convert.ToInt32(StatesArray[(i * PuzzleSize) + j]);
                    }
                }
                AStarMisSolSteps.Add(new ClassNode(StatesVals));
            }


            xListAlgs = xList[4].ChildNodes;                // Child Nodes of AStarMan Nodes
            // SAME FOR ALL 5 ALGORITHMS
            DummyStr = xListAlgs[0].InnerText;              // Get Whwthwe Puzzle Solved With BFS
            if (DummyStr == "F")
            {
                AStarManSolved = false;
            }
            else if (DummyStr == "T")
            {
                AStarManSolved = true;
            }

            DummyStr = xListAlgs[1].InnerText;              // Get solution Time in Seconds
            if (DummyStr != "")
            {
                AStarManSolTime = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[2].InnerText;              // Get Number of Stored Nodes
            if (DummyStr != "")
            {
                AStarManNumStoNodes = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[3].InnerText;              // Get Number of Expanded Nodes
            if (DummyStr != "")
            {
                AStarManNumExpNodes = Convert.ToInt32(DummyStr);
            }

            DummyStr = xListAlgs[4].InnerText;              // Get Number of Solution Step
            if (DummyStr != "")
            {
                AStarManSolStep = Convert.ToInt32(DummyStr);
            }

            xListAlgs = xListAlgs[5].ChildNodes;            // Construct Solution Steps 
            foreach (XmlNode xmlN in xListAlgs)
            {
                DummyStr = xmlN.InnerText;
                StatesArray = DummyStr.Split(',');
                StatesVals = new int[PuzzleSize, PuzzleSize];
                for (int i = 0; i < PuzzleSize; i++)
                {
                    for (int j = 0; j < PuzzleSize; j++)
                    {
                        StatesVals[i, j] = Convert.ToInt32(StatesArray[(i * PuzzleSize) + j]);
                    }
                }
                AStarManSolSteps.Add(new ClassNode(StatesVals));
            }

        }


    }
}
