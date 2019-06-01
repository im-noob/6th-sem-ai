using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI8TilesProgTH
{
    class ClassDFSSolver
    {
        public ClassPuzzle P;
        ClassNode N;
        List<ClassNode> Ns;
        Stack<ClassNode> S = new Stack<ClassNode>();
        SortedList<string,ClassNode> Hist = new SortedList<string,ClassNode>();
        List<ClassNode> Sol = new List<ClassNode>();
        int MaxS = 0;           // Nodes Stored
        int ExpCnt = 0;
        int SolTime = 0;
        DateTime ClkSt = new DateTime();
        DateTime ClkEnd = new DateTime();

        public ClassDFSSolver(ClassPuzzle PuzzleToBeSolved)
        {
            P = PuzzleToBeSolved;
        }

        public ClassPuzzle SolveIt()
        {
            ClkSt = DateTime.Now;
            P.InitNode.Cost = 0;
            S.Push(P.InitNode);
            MaxS++;
            Hist.Add(_KeyBuild(P.InitNode),P.InitNode);

            while (!P.b_abort && S.Count > 0)
            {
                N = S.Pop();                
                ExpCnt++;
                if (_AreNodesSame(N, P.GoalNode))
                {
                    P.DFSSolved = true;
                    break;
                }
                Ns = N.GetSuccessors();
                foreach (ClassNode SN in Ns)
                {
                    string key = _KeyBuild(SN);
                    bool KeyInHist = true;      // For Exeption handling when stopping the puzzle solving
                    try
                    { KeyInHist = Hist.ContainsKey(key); }
                    catch
                    { }

                    if (KeyInHist)      // I wonder whether it works or not
                    {
                    //    if (Hist[key].Cost > SN.Cost)
                    //    {
                    //        Hist[key].Cost = SN.Cost;
                    //        S.Push(SN);
                    //        if (S.Count > MaxS)
                    //            MaxS = S.Count;
                    //    }
                    }
                    else         // Then add only successors that are not opened yet
                    {
                        S.Push(SN);
                        Hist.Add(_KeyBuild(SN),SN);
                        if (S.Count > MaxS)
                            MaxS = S.Count;
                    }
                }
            }

            if (P.b_abort)
            { return P; }
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
            P.DFSSolTime = SolTime;     // in milli sec
            P.DFSNumStoNodes = MaxS;
            P.DFSNumExpNodes = ExpCnt;
            P.DFSSolStep = Sol.Count - 1;          // It is derived from History List
            P.DFSSolSteps = Sol;

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
