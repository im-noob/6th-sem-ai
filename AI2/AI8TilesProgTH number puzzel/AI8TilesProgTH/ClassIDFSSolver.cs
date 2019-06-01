using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI8TilesProgTH
{
    class ClassIDFSSolver
    {
        public ClassPuzzle P;
        ClassNode N;
        List<ClassNode> Ns;
        Stack<ClassNode> S = new Stack<ClassNode>();
        SortedList<string, ClassNode> Hist = new SortedList<string, ClassNode>();
        List<ClassNode> Sol = new List<ClassNode>();
        int MaxS = 0;           // Nodes Stored
        int ExpCnt = 0;
        int SolTime = 0;
        DateTime ClkSt = new DateTime();
        DateTime ClkEnd = new DateTime();

        bool LimitNotReached = false;
        bool SgotLarger = false;
        bool KeyInHist = true;
        bool PuzzleSolved = false;

        public ClassIDFSSolver(ClassPuzzle PuzzleToBeSolved)
        {
            P = PuzzleToBeSolved;
        }

        public ClassPuzzle SolveIt()
        {
            ClkSt = DateTime.Now;
            P.IDFSSolved = false;       // Since we need to get out of for loop also, I need to set the solved info to false to avoid undesired break after if statement at the very end 
            MaxS++;      // For the very first push
            for (int limit = 0; limit < 1000; limit++)
            {
                S.Clear();
                N = P.InitNode;
                N.Cost = 0;
                S.Push(N);
                Hist.Clear();                   // Clear Hist for each iteration...
                Hist.Add(_KeyBuild(P.InitNode), P.InitNode);
                while (!P.b_abort && (S.Count > 0))
                {
                    N = S.Pop();
                    ExpCnt++;
                    if (_AreNodesSame(N, P.GoalNode))
                    {
                        P.IDFSSolved = true;
                        break;      // That also breaks from for... 
                    }
                    Ns = N.GetSuccessors();
                    foreach (ClassNode SN in Ns)
                    {
                        string key = _KeyBuild(SN);
                        // For Exeption handling when stopping the puzzle solving
                        try
                        { KeyInHist = Hist.ContainsKey(key); }
                        catch
                        { }
                        if (KeyInHist)
                        {
                            bool CostInHistLarger = false;
                            try
                            { CostInHistLarger = ( Hist[key].Cost > SN.Cost); }
                            catch
                            { }
                            if (CostInHistLarger)
                            {
                                Hist[key].Cost = SN.Cost;
                                S.Push(SN);
                                if (S.Count > MaxS)
                                    MaxS = S.Count;
                            }
                        }
                        else         // Then add only successors that are not opened yet
                        {
                            
                            try { LimitNotReached = SN.Cost <= limit; }
                            catch { }
                            if (LimitNotReached)                   // 0th node is the init node... 
                            {
                                S.Push(SN);         // So that if cost is larger, it is not pushed in to stack...
                                Hist.Add(_KeyBuild(SN), SN);
                            }
                            try { SgotLarger = (S.Count > MaxS); }
                            catch { }
                            if (SgotLarger)
                                MaxS = S.Count;
                        }
                    }
                }
                try { PuzzleSolved = (P.IDFSSolved == true); }
                catch { }
                if ( PuzzleSolved )
                    break;
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
            P.IDFSSolTime = SolTime;     // in milli sec
            P.IDFSNumStoNodes = MaxS;
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
