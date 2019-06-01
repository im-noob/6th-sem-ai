using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI8TilesProgTH
{
    class ClassBFSSolver
    {
        public ClassPuzzle P;
        ClassNode N;
        List<ClassNode> Ns;
        Queue<ClassNode> Q = new Queue<ClassNode>();
        SortedList<string, ClassNode> Hist = new SortedList<string, ClassNode>();
        List<ClassNode> Sol = new List<ClassNode>();
        int MaxQ = 0;           // Nodes Stored
        int ExpCnt = 0;
        int SolTime = 0;
        DateTime ClkSt = new DateTime();
        DateTime ClkEnd = new DateTime();
        

        public ClassBFSSolver(ClassPuzzle PuzzleToBeSolved)
        {
            P = PuzzleToBeSolved;
        }

        public ClassPuzzle SolveIt()
        {
            ClkSt = DateTime.Now;
            Q.Enqueue(P.InitNode);
            MaxQ = 1;
            Hist.Add(_KeyBuild(P.InitNode),P.InitNode);

            while (!P.b_abort && Q.Count > 0)
            {
                N = Q.Dequeue();
                ExpCnt++;
                if (_AreNodesSame(N, P.GoalNode))
                {
                    P.BFSSolved = true;
                    // N is Solution... Search in Hist for it parents till the very beginnig
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

                    if (KeyInHist)  // If state already found in hist list, do not do anything 
                    { }
                    else         // if SN not in Hist List add only successors that are not opened yet
                    {
                        Q.Enqueue(SN);
                        Hist.Add(key, SN);
                        if (Q.Count > MaxQ)
                            MaxQ = Q.Count;
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

            ClkEnd = DateTime.Now;
            SolTime = (ClkEnd.Millisecond - ClkSt.Millisecond) + (ClkEnd.Second - ClkSt.Second) * 1000 + (ClkEnd.Minute - ClkSt.Minute) * 60 * 1000 + (ClkEnd.Hour - ClkSt.Hour) * 60 * 60 * 1000 + (ClkEnd.DayOfYear - ClkSt.DayOfYear) * 24 * 60 * 60 * 1000; // DO NOT USE THIS PROGRAM AT NEW YEAR PARTY!!!
            P.BFSSolTime = SolTime;     // in milli sec
            P.BFSNumStoNodes = MaxQ;
            P.BFSNumExpNodes = ExpCnt;
            P.BFSSolStep = Sol.Count-1;          // It is derived from History List
            P.BFSSolSteps = Sol;

            

            return P;
        }

        private bool _AreNodesSame(ClassNode N1, ClassNode N2)
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
