using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI8TilesProgTH
{
    class ClassAStarMisplacedTilesSolver
    {
        public ClassPuzzle P;
        ClassNode N;
        List<ClassNode> Ns;
        SortedList<string, ClassNode> Hist = new SortedList<string, ClassNode>();
        List<ClassNode> Sol = new List<ClassNode>();
        int MaxHist = 0;            // Nodes Stored
        int MaxL = 0;
        int ExpCnt = 0;             // Nodes Processed (expanded)
        int SolTime = 0;
        DateTime ClkSt = new DateTime();
        DateTime ClkEnd = new DateTime();

        bool KeyInHist = true;      // For Exeption handling when stopping the puzzle solving
        bool CostInHistLarger = false;
        bool LgotLarger = false;

        public ClassAStarMisplacedTilesSolver(ClassPuzzle PuzzleToBeSolved)
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
            N.Heur = _CalcHeurMis(N);
            L.Add(N.Heur + N.Cost, N);
            Hist.Add(_KeyBuild(N), N);

            while (!P.b_abort && L.Count > 0)
            {
                N = L.First().Value;
                L.RemoveAt(0);
                ExpCnt++;           // Node is about to be processed
                if (_AreNodesSame(N, P.GoalNode))
                {
                    P.AStarMisSolved = true;
                    break;
                }
                Ns = N.GetSuccessors();
                foreach (ClassNode SN in Ns)
                {
                    SN.Heur = _CalcHeurMis(SN);
                    string key = _KeyBuild(SN);
                    try { KeyInHist = Hist.ContainsKey(key); }
                    catch { }
                    if (KeyInHist)
                    {
                        try { CostInHistLarger = ( Hist[key].Cost > SN.Cost); }
                        catch { }
                        if (CostInHistLarger)
                        {
                            Hist[key].Cost = SN.Cost;
                            L.Add(SN.Heur + SN.Cost, SN);
                            try { LgotLarger = (L.Count > MaxL); }
                            catch { }
                            if (LgotLarger)
                                MaxL = L.Count;
                        }
                    }
                    else         // Then add only successors that are not opened yet
                    {
                        L.Add(SN.Heur + SN.Cost, SN);
                        Hist.Add(key, SN);
                        try { LgotLarger = (L.Count > MaxL); }
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
            P.AStarMisSolTime = SolTime;     // in milli sec
            P.AStarMisNumStoNodes = MaxL;        // Although the History is not used....
            P.AStarMisNumExpNodes = ExpCnt;
            P.AStarMisSolStep = Sol.Count - 1;          // It is derived from History List
            P.AStarMisSolSteps = Sol;

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

        private int _CalcHeurMis(ClassNode Nh)
        {
            int He = 0;
            for (int i = 0; i < P.PuzzleSize; i++)
            {
                for (int j = 0; j < P.PuzzleSize; j++)
                {
                    if ((Nh.NodeState[i, j] != 0) && ((Math.Abs(((Nh.NodeState[i, j] - 1) / N.NodeSize) - i) != 0) || (Math.Abs(((Nh.NodeState[i, j] - 1) % N.NodeSize) - j) != 0)))
                        He++;           // Do not count blank tile !! since it is not actually a tile.
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
