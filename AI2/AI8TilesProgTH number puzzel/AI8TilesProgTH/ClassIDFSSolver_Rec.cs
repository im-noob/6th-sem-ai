using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI8TilesProgTH
{
    class ClassIDFSSolver_Rec
    {
        public ClassPuzzle P;
        ClassNode N;
        List<ClassNode> Ns;
        Stack<ClassNode> S = new Stack<ClassNode>();
        SortedList<string,ClassNode> Hist = new SortedList<string,ClassNode>();
        List<ClassNode> Sol = new List<ClassNode>();
        int MaxHist = 0;           // Nodes Stored
        int ExpCnt = 0;
        int SolTime = 0;
        DateTime ClkSt = new DateTime();
        DateTime ClkEnd = new DateTime();



        public ClassIDFSSolver_Rec(ClassPuzzle PuzzleToBeSolved)
        {
            P = PuzzleToBeSolved;
        }

        public ClassPuzzle SolveIt()
        {
            ClkSt = DateTime.Now;
            ExpCnt = 0;

            N = P.InitNode;
            ClassNode DNd;

            for (int i = 1; i < 250000; i++)
            {
                Hist.Clear();
                Hist.Add(_KeyBuild(P.InitNode), P.InitNode);
                //Console.WriteLine("Iteration: {0}", i.ToString());
                DNd = DepthLimitedDFS(P.InitNode, i);                
                if (DNd != null)
                {
                    N = DNd;
                    break;
                }
            }

            ClassNode DN = N;
            while (DN != null)
            {
                Sol.Add(DN);
                DN = DN.GetParent();
            }

            Sol.Reverse();

            // THEY NEED TO BE CHECKED...
            ClkEnd = DateTime.Now;
            SolTime = (ClkEnd.Millisecond - ClkSt.Millisecond) + (ClkEnd.Second - ClkSt.Second) * 1000 + (ClkEnd.Minute - ClkSt.Minute) * 60 * 1000 + (ClkEnd.Hour - ClkSt.Hour) * 60 * 60 * 1000 + (ClkEnd.DayOfYear - ClkSt.DayOfYear) * 24 * 60 * 60 * 1000; // DO NOT USE THIS PROGRAM AT NEW YEAR PARTY!!!
            P.IDFSSolTime = SolTime;     // in milli sec
            P.IDFSNumStoNodes = MaxHist;        // Although the History is not used....
            P.IDFSNumExpNodes = ExpCnt;
            P.IDFSSolStep = Sol.Count - 1;          // It is derived from History List
            P.IDFSSolSteps = Sol;

            return P;
        }


        private bool _AreNodesSame(ClassNode N1, ClassNode N2)      // Checks whether sent 2 nodes have the same state or not
        {
            bool Same = true;
            for (int i = 0; (i < P.PuzzleSize) && (Same == true); i++)
            {
                for (int j = 0; (j < P.PuzzleSize) && (Same == true); j++)
                {
                    if (N1.NodeState[i, j] != N2.NodeState[i, j])
                    {
                        Same = false;
                    }
                }
            }
            return Same;
        }

        ClassNode DepthLimitedDFS(ClassNode Nd, int limit)      // Hist olmadan bakınca hızlı bakıyor ama stateler inanılmaz fazla oluyor...
        {                                                       
            ExpCnt++;
            int lim = limit;
            if (_AreNodesSame(Nd, P.GoalNode))
            {
                P.IDFSSolved = true;
                return Nd;
            }
            else if (lim == 0)
            {
                return null;            
            }
            lim--;

            List<ClassNode> Nsuc = Nd.GetSuccessors();
            foreach (ClassNode CNd in Nsuc)
            {
                ClassNode DumN = DepthLimitedDFS(CNd, lim);

                if (DumN != null)
                {
                    return DumN;
                }
                
            }
            return null;        // Should not reach here ???
        }

        private string _KeyBuild(ClassNode Nk)
        {
            string s = "";
            for (int i = 0; i < Nk.NodeSize; i++)
            {
                for (int j = 0; j < Nk.NodeSize; j++)
                {
                    s = s + Nk.NodeState[i, j].ToString();
                    if ((i != (Nk.NodeSize - 1)) || (j != (Nk.NodeSize - 1)))
                        s = s + ",";
                }
            }
            return s;
        }


    }
}
