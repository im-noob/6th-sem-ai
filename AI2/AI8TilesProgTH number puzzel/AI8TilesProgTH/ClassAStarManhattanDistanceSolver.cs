using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI8TilesProgTH
{
    class ClassAStarManhattanDistanceSolver
    {
        public ClassPuzzle P;
        ClassNode N;
        List<ClassNode> Ns;
        SortedList<string,ClassNode> Hist = new SortedList<string,ClassNode>();
        List<ClassNode> Sol = new List<ClassNode>();
        int MaxHist = 0;
        int MaxL = 0;               // Nodes Stored
        int ExpCnt = 0;             // Nodes Processed (expanded)
        int SolTime = 0;
        DateTime ClkSt = new DateTime();
        DateTime ClkEnd = new DateTime();

        bool CostInHistLarger = false;  // For Exeption handling when stopping the puzzle solving
        bool LgotLarger = false;
        bool KeyInHist = true;      

        public ClassAStarManhattanDistanceSolver(ClassPuzzle PuzzleToBeSolved)
        {
            P = PuzzleToBeSolved;        
        }

        public ClassPuzzle SolveIt()
        {
            ClassComparer Comp = new ClassComparer();
            SortedList<int, ClassNode> L = new SortedList<int, ClassNode>(Comp);

            ClkSt = DateTime.Now;
            ExpCnt = 0;

            N = P.InitNode;
            N.Cost = 0;
            N.Heur = _CalcHeurMan(N);
            L.Add(N.Heur + N.Cost, N);
            Hist.Add(_KeyBuild(N), N);

            while (!P.b_abort && L.Count > 0)
            {
                N = L.First().Value;
                L.RemoveAt(0);
                ExpCnt++;           // Node is about to be processed
                if (_AreNodesSame(N, P.GoalNode))
                {
                    P.AStarManSolved = true;
                    break;
                }
                Ns = N.GetSuccessors();
                foreach (ClassNode SN in Ns)
                {
                    SN.Heur = _CalcHeurMan(SN);
                    string key = _KeyBuild(SN);

                    try { KeyInHist = Hist.ContainsKey(key); }      // For Exeption handling when stopping the puzzle solving
                    catch { }
                    if (KeyInHist)
                    {
                        try { CostInHistLarger = (Hist[key].Cost > SN.Cost); }     // For Exeption handling when stopping the puzzle solving
                        catch { }
                        if (CostInHistLarger)
                        {
                            Hist[key].Cost = SN.Cost;
                            L.Add(SN.Heur + SN.Cost, SN);

                            try { LgotLarger = (L.Count > MaxL); }      // For Exeption handling when stopping the puzzle solving
                            catch { }
                            if (LgotLarger)
                                MaxL = L.Count;
                        }
                    }
                    else         // Then add only successors that are not opened yet
                    {
                        L.Add(SN.Heur + SN.Cost, SN);
                        Hist.Add(key, SN);
                        try { LgotLarger = (L.Count > MaxL); }      // For Exeption handling when stopping the puzzle solving
                        catch { }
                        if (LgotLarger)
                            MaxL = L.Count;
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
            P.AStarManSolTime = SolTime;     // in milli sec
            P.AStarManNumStoNodes = MaxL;
            P.AStarManNumExpNodes = ExpCnt;
            P.AStarManSolStep = Sol.Count - 1;          // It is derived from History List
            P.AStarManSolSteps = Sol;

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

        private int _CalcHeurMan(ClassNode Nh)
        {
            int He = 0;
            for (int i = 0; i < P.PuzzleSize; i++)
            {
                for (int j = 0; j < P.PuzzleSize; j++)
                {
                    if (Nh.NodeState[i, j] != 0)
                        He = He + Math.Abs(((Nh.NodeState[i, j] - 1) / N.NodeSize) - i) + Math.Abs(((Nh.NodeState[i, j] - 1) % N.NodeSize) - j);
                    //else                  // If we count blank tile in heuristic... wrong result...
                    //    He = He + (Nh.NodeSize -1 - i) + (N.NodeSize -1 - j);
                }
            }
            return He;
        }

        private string _KeyBuild(ClassNode Nk)
        {
            string s = "";
            for (int i = 0; i < Nk.NodeSize; i++)
            {
                for (int j = 0; j < Nk.NodeSize; j++)
                {
                    s = s + Nk.NodeState[i, j].ToString();
                    if ((i != (N.NodeSize - 1)) || (j != (N.NodeSize - 1)))
                        s = s + ",";
                }
            }
            return s;
        }


    }
}
