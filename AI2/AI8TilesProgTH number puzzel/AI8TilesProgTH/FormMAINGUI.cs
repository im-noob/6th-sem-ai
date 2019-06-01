using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Threading;

namespace AI8TilesProgTH
{
    public partial class FormMAINGUI : Form
    {
        #region Parameters&Variables

        ClassPuzzle PuzzleToSolve;
        List<ClassPuzzle> PL_MC = new List<ClassPuzzle>();      // Puzzle List for Monte Carlo Solution. 
        Form FormPuzzleGenAuto = new FormAutoPuzzleGen();
        Form FormPuzzzleManGen = new FormManuelPuzzleGen();
        ClassBFSSolver S_BFS;
        ClassDFSSolver S_DFS;
        ClassIDFSSolver S_IDFS;
        ClassIDFSSolver_Rec S_IDFS_Rec;     // I guess I will not use it.
        ClassAStarMisplacedTilesSolver S_AMis;
        ClassAStarManhattanDistanceSolver S_AMan;
        List<ClassNode> GUISolSteps = new List<ClassNode>();
        int GUISolStep_indx = 0;

        Button[,] DynBtns;              // Buttons for visual purposes
        int BtnsLeft = 220;             // Buttons' parameters
        int BtnsTop = 120;
        int BtnsClearence = 5;
        int BtnsHeight = 30;
        int BtnsWidth = 40;

        bool play = false;
        bool b_abort_mc = false;

        OpenFileDialog OpeningTool = new OpenFileDialog();
        SaveFileDialog SavingTool = new SaveFileDialog();

        Thread ShowThread;
        Thread solvethread;
        Thread solvemcthread;

        MethodInvoker solutionfound;
        MethodInvoker showsolution;
        MethodInvoker guiinitilize;
        MethodInvoker mcprogress;
        MethodInvoker modifynumbers;

        #endregion

        public FormMAINGUI()
        {
            InitializeComponent();

            EnableCreateAndLoadButtons();
            DisableRadioButsAndSolveButs();
            DisablePlayButs();
            DisableStopSolverBut();
            EnableMonteCarlo();
        }

        #region Enable_Disable_GUI_Objects

        void EnableCreateAndLoadButtons()
        {
            btnCreatePuzzleForMe.Enabled = true;
            btnHavePuzzleYourWay.Enabled = true;
            btnLoadASavedPuzzle.Enabled = true;
        }

        void DisableCreateAndLoadButtons()
        {
            btnCreatePuzzleForMe.Enabled = false;
            btnHavePuzzleYourWay.Enabled = false;
            btnLoadASavedPuzzle.Enabled = false;        
        }

        void EnableRadioButsAndSolveButs()
        {
            btnSolve.Enabled = true;
            btnMonteCarlo.Enabled = true;
            btnStopMonteCarlo.Enabled = true;
            rBtn1Manual.Enabled = true;
            rBtn2BFS.Enabled = true;
            rBtn3DFS.Enabled = true;
            rBtn4IDFS.Enabled = true;
            rBtn5AStarMisplaced.Enabled = true;
            rBtn6AStarManhattan.Enabled = true;
        }

        void DisableRadioButsAndSolveButs()
        {
            btnSolve.Enabled = false;
            btnMonteCarlo.Enabled = false;
            //btnStopMonteCarlo.Enabled = false;
            rBtn1Manual.Enabled = false;
            rBtn2BFS.Enabled = false;
            rBtn3DFS.Enabled = false;
            rBtn4IDFS.Enabled = false;
            rBtn5AStarMisplaced.Enabled = false;
            rBtn6AStarManhattan.Enabled = false;
        }

        void EnableStopSolverBut()
        {
            btnStopSolver.Enabled = true;
        }

        void DisableStopSolverBut()
        {
            btnStopSolver.Enabled = false;
        }

        void EnablePlayButs()
        {
            btnPlay.Enabled = true;
            btnPause.Enabled = true;
            if (GUISolStep_indx > 0)
                btnBackStep.Enabled = true;
            else
                btnBackStep.Enabled = false;

            if (GUISolStep_indx < GUISolSteps.Count - 1)
                btnForwardStep.Enabled = true;
            else
                btnForwardStep.Enabled = false;
        }

        void DisablePlayButs()
        {
            btnPlay.Enabled = false;
            btnPause.Enabled = false;
            btnForwardStep.Enabled = false;
            btnBackStep.Enabled = false;
        }

        void EnableMonteCarlo()
        {
            btnMonteCarlo.Enabled = true;
            btnStopMonteCarlo.Enabled = true;
        }

        void DisableMonteCarlo()
        {
            btnMonteCarlo.Enabled = false;
            btnStopMonteCarlo.Enabled = false;
        }
        
        #endregion

        #region Create&Load_Puzzle

        private void btnCreatePuzzleForMe_Click(object sender, EventArgs e)     // For details see the Auto Puzzle Generator Form
        {
            FormPuzzleGenAuto = new FormAutoPuzzleGen();
            FormPuzzleGenAuto.Show();
        }

        private void btnHavePuzzleYourWay_Click(object sender, EventArgs e)     // For details see the Manual Puzzle Generator Form
        {
            FormPuzzzleManGen = new FormManuelPuzzleGen();
            FormPuzzzleManGen.Show();
        }

        private void btnLoadASavedPuzzle_Click(object sender, EventArgs e)      // Only Read XML File and create the puzzle to be solved by just using XML Node. Puzzle Contructor handles the details.
        {
            OpeningTool.Filter = "Xml File(*.xml)|*.xml";           // Only to see .xml files when opening the SavedPuzzle file
            
            if (OpeningTool.ShowDialog() == DialogResult.OK)
            {
                SavingTool.FileName = OpeningTool.FileName;
                
                XmlDocument xml;
                XmlNode xNode;
                
                xml = new XmlDocument();
                xml.Load(OpeningTool.FileName);
                
                xNode = xml.SelectSingleNode("/AIMehmutluSlidingPuzzleSaveFile/Puzzle.000");  // Select the correct XML Puzzle Node
                PuzzleToSolve = new ClassPuzzle(xNode);                 // Create Puzzle. Its constructor handles the details on XML.                
            }
            if (PuzzleToSolve != null)      // Enable GUI if the puzzle is successfully created
            {
                S_BFS = new ClassBFSSolver(PuzzleToSolve);
                S_DFS = new ClassDFSSolver(PuzzleToSolve);
                S_IDFS_Rec = new ClassIDFSSolver_Rec(PuzzleToSolve);        // Not used
                S_IDFS = new ClassIDFSSolver(PuzzleToSolve);
                S_AMis = new ClassAStarMisplacedTilesSolver(PuzzleToSolve);
                S_AMan = new ClassAStarManhattanDistanceSolver(PuzzleToSolve);

                if (PuzzleToSolve.PuzzleSize > 8)       // Proper sizing of GUI is required for large puzzles
                    this.Height = 460 + (PuzzleToSolve.PuzzleSize - 8) * 35;
                else
                    this.Height = 460;

                _SetGUILabels();

                _GUIButtonsInitial();

                EnableCreateAndLoadButtons();
                EnableRadioButsAndSolveButs();
                EnablePlayButs();
                DisableStopSolverBut();
            }
        }
        
        #endregion

        #region SolveFunctions

        private void btnSolve_Click(object sender, EventArgs e)
        {
            DisableCreateAndLoadButtons();      // GUI Restrictions
            DisablePlayButs();
            DisableRadioButsAndSolveButs();
            btnStopMonteCarlo.Enabled = false;
            EnableStopSolverBut();

            solutionfound = SolutionFound;      // Thread for saving function...
            if (rBtn1Manual.Checked)            // I will do the solutions in a new thread so that GUI is not affected
            {
                solvethread = new Thread(new ThreadStart(_SolveManual));
                solvethread.Start();
            }
            else if (rBtn2BFS.Checked)
            {
                solvethread = new Thread(new ThreadStart(_SolveBFS));
                solvethread.Start();
            }
            else if (rBtn3DFS.Checked)
            {
                solvethread = new Thread(new ThreadStart(_SolveDFS));
                solvethread.Start();
            }
            else if (rBtn4IDFS.Checked)
            {
                solvethread = new Thread(new ThreadStart(_SolveIDFS));
                solvethread.Start();
            }
            else if (rBtn5AStarMisplaced.Checked)
            {
                solvethread = new Thread(new ThreadStart(_SolveAStarMis));
                solvethread.Start();
            }
            else if (rBtn6AStarManhattan.Checked)
            {
                solvethread = new Thread(new ThreadStart(_SolveAStarMan));
                solvethread.Start();
            }
            
        }

        private void SolutionFound()
        { 
            if (rBtn1Manual.Checked )
	        {
                //lblMsg.Text = "Puzzle will be solved by you. Not implemented yet. (See Manual Puzzle Creator)";
	        }
            else if (rBtn2BFS.Checked)
            {
                lblMsg.Text = "Puzzle Solved with BFS.";
            }
            else if (rBtn3DFS.Checked)
            {
                lblMsg.Text = "Puzzle Solved with DFS.";
            }
            else if (rBtn4IDFS.Checked)
            {
                lblMsg.Text = "Puzzle Solved with IDFS.";
            }
            else if (rBtn5AStarMisplaced.Checked)
            {
                lblMsg.Text = "Puzzle Solved with A*Mis.";
            }
            else if (rBtn6AStarManhattan.Checked)
            {
                lblMsg.Text = "Puzzle Solved with A*Man.";
            }
            EnablePlayButs();           // They should be done in the opend thread
            DisableStopSolverBut();
            EnableCreateAndLoadButtons();
            EnableRadioButsAndSolveButs();
            if (!rBtn1Manual.Checked)
                _SaveSolvedPuzzle();
            _SetGUILabels();
            _GUIButtonsInitial();
        }

        private void _SolveManual()     // Not implemented... User can solve the puzzle by cliking on the puzzle tiles... (Like in the creating own puzzle mode)
        {
            Invoke(solutionfound);

            solvethread.Abort();    // Adina thread cagrilan fonksiyonlarin sonunda olmali
            solvethread.Join();
        }

        private void _SolveBFS()
        {
            S_BFS = new ClassBFSSolver(PuzzleToSolve);      // Create new so that all data especially hist is renewed
            DialogResult result;
            if (PuzzleToSolve.BFSSolved == true)
            {
                result = MessageBox.Show("This puzzle is already solved with BFS algorithm. Would you like to solve it again?", "BFS Solver", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    Invoke(solutionfound);
                }
                else if (result == DialogResult.Yes)
                {
                    PuzzleToSolve = S_BFS.SolveIt();
                    Invoke(solutionfound);
                    
                }
            }
            else
            {
                PuzzleToSolve = S_BFS.SolveIt();
                Invoke(solutionfound);
                
            }

            solvethread.Abort();        // Release the thread once it is finished
            solvethread.Join();
        }

        private void _SolveDFS()
        {
            S_DFS = new ClassDFSSolver(PuzzleToSolve);
            DialogResult result;
            if (PuzzleToSolve.DFSSolved == true)
            {
                result = MessageBox.Show("This puzzle is already solved with DFS algorithm. Would you like to solve it again?", "DFS Solver", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    Invoke(solutionfound);
                }
                else if (result == DialogResult.Yes)
                {
                    PuzzleToSolve = S_DFS.SolveIt();
                    Invoke(solutionfound);
                }
            }
            else
            {
                PuzzleToSolve = S_DFS.SolveIt();
                Invoke(solutionfound);
            }

            solvethread.Abort();        // Release the thread once it is finished
            solvethread.Join();
        }

        private void _SolveIDFS()       // Non-Recursive one is used.
        {
            S_IDFS = new ClassIDFSSolver(PuzzleToSolve);
            DialogResult result;
            if (PuzzleToSolve.IDFSSolved == true)
            {
                result = MessageBox.Show("This puzzle is already solved with IDFS algorithm. Would you like to solve it again?", "IDFS Solver", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    Invoke(solutionfound);
                }
                else if (result == DialogResult.Yes)
                {
                    PuzzleToSolve = S_IDFS.SolveIt();
                    Invoke(solutionfound);
                }
            }
            else
            {
                PuzzleToSolve = S_IDFS.SolveIt();
                Invoke(solutionfound);
            }

            solvethread.Abort();        // Release the thread once it is finished
            solvethread.Join();
        }

        private void _SolveAStarMis()
        {
            S_AMis = new ClassAStarMisplacedTilesSolver(PuzzleToSolve);
            DialogResult result;
            if (PuzzleToSolve.AStarMisSolved == true)
            {
                result = MessageBox.Show("This puzzle is already solved with A* algorithm with misplaced tiles heuristic. Would you like to solve it again?", "A* Solver (Misplaced)", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    Invoke(solutionfound);
                }
                else if (result == DialogResult.Yes)
                {
                    PuzzleToSolve = S_AMis.SolveIt();
                    Invoke(solutionfound);
                }
            }
            else
            {
                PuzzleToSolve = S_AMis.SolveIt();
                Invoke(solutionfound);
            }

            solvethread.Abort();        // Release the thread once it is finished
            solvethread.Join();
        }

        private void _SolveAStarMan()
        {
            S_AMan = new ClassAStarManhattanDistanceSolver(PuzzleToSolve);
            DialogResult result;
            if (PuzzleToSolve.AStarManSolved == true)
            {
                result = MessageBox.Show("This puzzle is already solved with A* algorithm with Manhattan distance heuristic. Would you like to solve it again?", "A* Solver (Manhattan)", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    Invoke(solutionfound);
                }
                else if (result == DialogResult.Yes)
                {
                    PuzzleToSolve = S_AMan.SolveIt();
                    Invoke(solutionfound);
                }
            }
            else
            {
                PuzzleToSolve = S_AMan.SolveIt();
                Invoke(solutionfound);
            }

            solvethread.Abort();        // Release the thread once it is finished
            solvethread.Join();
        }

        private void btnStopSolver_Click(object sender, EventArgs e)
        {
            try
            {
                S_BFS.P.b_abort = true;
                S_DFS.P.b_abort = true;
                S_IDFS.P.b_abort = true;
                S_AMan.P.b_abort = true;
                S_AMis.P.b_abort = true;
                solvethread.Abort();
                solvethread.Join();

                EnablePlayButs();          // Once solution is aboreted update GUI
                DisableStopSolverBut();
                EnableCreateAndLoadButtons();
                EnableRadioButsAndSolveButs();
                if (!rBtn1Manual.Checked)
                    _SaveSolvedPuzzle();
                _SetGUILabels();
                _GUIButtonsInitial();

                S_BFS.P.b_abort = false;
                S_DFS.P.b_abort = false;
                S_IDFS.P.b_abort = false;
                S_AMan.P.b_abort = false;
                S_AMis.P.b_abort = false;
            }
            catch { }
        }

        #endregion

        #region SaveFunctions
        
        private void _SaveSolvedPuzzle()
        {
            XDocument inventoryDoc = new XDocument();

            string Size = "";
            string State = "";
            string DesiredOpStep = "";

            if (PuzzleToSolve.DesiredStep == -1)
                DesiredOpStep = "N/A";
            else
                DesiredOpStep = PuzzleToSolve.DesiredStep.ToString();

            Size = PuzzleToSolve.PuzzleSize.ToString();
            DesiredOpStep = PuzzleToSolve.DesiredStep.ToString();

            for (int i = 0; i < PuzzleToSolve.PuzzleSize; i++)
            {
                for (int j = 0; j < PuzzleToSolve.PuzzleSize; j++)
                {
                    State = State + PuzzleToSolve.InitNode.NodeState[i, j];
                    if (j != PuzzleToSolve.PuzzleSize - 1 || i != PuzzleToSolve.PuzzleSize - 1)
                    {
                        State = State + ",";
                    }
                }
            }

            string BFSSolved = "";
            string BFSSolTime = "";
            string BFSStoNode = "";
            string BFSExpNode = "";
            string BFSSolStep = "";
            string BFSSolNode = "";             // Will be added Later On

            if (PuzzleToSolve.BFSSolved == true)
            {
                BFSSolved = "T";
                BFSSolTime = PuzzleToSolve.BFSSolTime.ToString();
                BFSStoNode = PuzzleToSolve.BFSNumStoNodes.ToString();
                BFSExpNode = PuzzleToSolve.BFSNumExpNodes.ToString();
                BFSSolStep = PuzzleToSolve.BFSSolStep.ToString();
            }
            else
            {
                BFSSolved = "F";
            }

            string DFSSolved = "";
            string DFSSolTime = "";
            string DFSStoNode = "";
            string DFSExpNode = "";
            string DFSSolStep = "";
            string DFSSolNode = "";                 // Will be added Later On

            if (PuzzleToSolve.DFSSolved == true)
            {
                DFSSolved = "T";
                DFSSolTime = PuzzleToSolve.DFSSolTime.ToString();
                DFSStoNode = PuzzleToSolve.DFSNumStoNodes.ToString();
                DFSExpNode = PuzzleToSolve.DFSNumExpNodes.ToString();
                DFSSolStep = PuzzleToSolve.DFSSolStep.ToString();
            }
            else
            {
                DFSSolved = "F";
            }

            string IDFSSolved = "";
            string IDFSSolTime = "";
            string IDFSStoNode = "";
            string IDFSExpNode = "";
            string IDFSSolStep = "";
            string IDFSSolNode = "";                // Will be added Later On

            if (PuzzleToSolve.IDFSSolved == true)
            {
                IDFSSolved = "T";
                IDFSSolTime = PuzzleToSolve.IDFSSolTime.ToString();
                IDFSStoNode = PuzzleToSolve.IDFSNumStoNodes.ToString();
                IDFSExpNode = PuzzleToSolve.IDFSNumExpNodes.ToString();
                IDFSSolStep = PuzzleToSolve.IDFSSolStep.ToString();
            }
            else
            {
                IDFSSolved = "F";
            }

            string AMisSolved = "";
            string AMisSolTime = "";
            string AMisStoNode = "";
            string AMisExpNode = "";
            string AMisSolStep = "";
            string AMisSolNode = "";                // Will be added Later On

            if (PuzzleToSolve.AStarMisSolved == true)
            {
                AMisSolved = "T";
                AMisSolTime = PuzzleToSolve.AStarMisSolTime.ToString();
                AMisStoNode = PuzzleToSolve.AStarMisNumStoNodes.ToString();
                AMisExpNode = PuzzleToSolve.AStarMisNumExpNodes.ToString();
                AMisSolStep = PuzzleToSolve.AStarMisSolStep.ToString();
            }
            else
            {
                AMisSolved = "F";
            }

            string AManSolved = "";
            string AManSolTime = "";
            string AManStoNode = "";
            string AManExpNode = "";
            string AManSolStep = "";
            string AManSolNode = "";                // Will be added Later On

            if (PuzzleToSolve.AStarManSolved == true)
            {
                AManSolved = "T";
                AManSolTime = PuzzleToSolve.AStarManSolTime.ToString();
                AManStoNode = PuzzleToSolve.AStarManNumStoNodes.ToString();
                AManExpNode = PuzzleToSolve.AStarManNumExpNodes.ToString();
                AManSolStep = PuzzleToSolve.AStarManSolStep.ToString();
            }
            else
            {
                AManSolved = "F";
            }


            //Console.WriteLine("State: {0}", State);
            XElement newElement = new XElement("AIMehmutluSlidingPuzzleSaveFile",
                        new XElement("Puzzle.000",
                            new XElement("Size", Size),
                            new XElement("State", State),
                            new XElement("DesiredOptimalSolutionStep", DesiredOpStep),
                            new XElement("SolvedAlgorithms",
                                new XElement("BFS",
                                    new XElement("Solved", BFSSolved),
                                    new XElement("SolutionTime", BFSSolTime),
                                    new XElement("NoOfStoredNodes", BFSStoNode),
                                    new XElement("NoOfNodeExpansion", BFSExpNode),
                                    new XElement("SolutionStep", BFSSolStep),
                                    new XElement("SolutionNodes",
                                        new XElement("Node0", State))),
                                new XElement("DFS",
                                    new XElement("Solved", DFSSolved),
                                    new XElement("SolutionTime", DFSSolTime),
                                    new XElement("NoOfStoredNodes", DFSStoNode),
                                    new XElement("NoOfNodeExpansion", DFSExpNode),
                                    new XElement("SolutionStep", DFSSolStep),
                                    new XElement("SolutionNodes",
                                        new XElement("Node0", State))),
                                new XElement("IDFS",
                                    new XElement("Solved", IDFSSolved),
                                    new XElement("SolutionTime", IDFSSolTime),
                                    new XElement("NoOfStoredNodes", IDFSStoNode),
                                    new XElement("NoOfNodeExpansion", IDFSExpNode),
                                    new XElement("SolutionStep", IDFSSolStep),
                                    new XElement("SolutionNodes",
                                        new XElement("Node0", State))),
                                new XElement("AStarMisplacedTiles",
                                    new XElement("Solved", AMisSolved),
                                    new XElement("SolutionTime", AMisSolTime),
                                    new XElement("NoOfStoredNodes", AMisStoNode),
                                    new XElement("NoOfNodeExpansion", AMisExpNode),
                                    new XElement("SolutionStep", AMisSolStep),
                                    new XElement("SolutionNodes",
                                        new XElement("Node0", State))),
                                new XElement("AStarManhattan",
                                    new XElement("Solved", AManSolved),
                                    new XElement("SolutionTime", AManSolTime),
                                    new XElement("NoOfStoredNodes", AManStoNode),
                                    new XElement("NoOfNodeExpansion", AManExpNode),
                                    new XElement("SolutionStep", AManSolStep),
                                    new XElement("SolutionNodes",
                                        new XElement("Node0", State))))));
            // Add to in-memory object
            inventoryDoc.AddFirst(newElement);          // First Burst is ready
            // Now Add Solution Steps So that I can display them
            int cnt = 0;
            foreach (ClassNode Cn in PuzzleToSolve.BFSSolSteps)
            {
                if (Cn != PuzzleToSolve.BFSSolSteps[0])
                {
                    string st = "Node" + cnt.ToString();
                    inventoryDoc.Root.Element("Puzzle.000").Element("SolvedAlgorithms").Element("BFS").Element("SolutionNodes").Add(new XElement(st, _StateInString(Cn)));
                
                }
                cnt++;
            }

            cnt = 0;
            foreach (ClassNode Cn in PuzzleToSolve.DFSSolSteps)
            {
                if (Cn != PuzzleToSolve.DFSSolSteps[0])
                {
                    string st = "Node" + cnt.ToString();
                    inventoryDoc.Root.Element("Puzzle.000").Element("SolvedAlgorithms").Element("DFS").Element("SolutionNodes").Add(new XElement(st, _StateInString(Cn)));

                }
                cnt++;
            }

            cnt = 0;
            foreach (ClassNode Cn in PuzzleToSolve.IDFSSolSteps)
            {
                if (Cn != PuzzleToSolve.IDFSSolSteps[0])
                {
                    string st = "Node" + cnt.ToString();
                    inventoryDoc.Root.Element("Puzzle.000").Element("SolvedAlgorithms").Element("IDFS").Element("SolutionNodes").Add(new XElement(st, _StateInString(Cn)));

                }
                cnt++;
            }

            cnt = 0;
            foreach (ClassNode Cn in PuzzleToSolve.AStarMisSolSteps)
            {
                if (Cn != PuzzleToSolve.AStarMisSolSteps[0])
                {
                    string st = "Node" + cnt.ToString();
                    inventoryDoc.Root.Element("Puzzle.000").Element("SolvedAlgorithms").Element("AStarMisplacedTiles").Element("SolutionNodes").Add(new XElement(st, _StateInString(Cn)));

                }
                cnt++;
            }

            cnt = 0;
            foreach (ClassNode Cn in PuzzleToSolve.AStarManSolSteps)
            {
                if (Cn != PuzzleToSolve.AStarManSolSteps[0])
                {
                    string st = "Node" + cnt.ToString();
                    inventoryDoc.Root.Element("Puzzle.000").Element("SolvedAlgorithms").Element("AStarManhattan").Element("SolutionNodes").Add(new XElement(st, _StateInString(Cn)));

                }
                cnt++;
            }

            inventoryDoc.Save(SavingTool.FileName);     // Filename was set when chosen while loading file!!!

            lblMsg.Text = "Solved Puzzle is saved over its initial file";

            solvethread.Abort();
            solvethread.Join();
        }

        private string _StateInString(ClassNode Nstr)       // Complementary function for _SaveSolvedPuzzle, ie. saving
        {
            string s = "";
            for (int i = 0; i < Nstr.NodeSize; i++)
            {
                for (int j = 0; j < Nstr.NodeSize; j++)
                {
                    s = s + Nstr.NodeState[i, j].ToString();
                    if ((i != (Nstr.NodeSize - 1)) || (j != (Nstr.NodeSize - 1)))
                        s = s + ",";
                }
            }
            return s;
        }
        
        #endregion

        #region RadioButtons
        
        private void rBtn1Manual_CheckedChanged(object sender, EventArgs e)
        {
            _SetGUILabels();
            _GUIButtonsInitial();
        }

        private void rBtn2BFS_CheckedChanged(object sender, EventArgs e)
        {
            _SetGUILabels();
            _GUIButtonsInitial();
        }

        private void rBtn3DFS_CheckedChanged(object sender, EventArgs e)
        {
            _SetGUILabels();
            _GUIButtonsInitial();
        }

        private void rBtn4IDFS_CheckedChanged(object sender, EventArgs e)
        {
            _SetGUILabels();
            _GUIButtonsInitial();
        }

        private void rBtn5AStarMisplaced_CheckedChanged(object sender, EventArgs e)
        {
            _SetGUILabels();
            _GUIButtonsInitial();
        }

        private void rBtn6AStarManhattan_CheckedChanged(object sender, EventArgs e)
        {
            _SetGUILabels();
            _GUIButtonsInitial();
        }
        
        #endregion

        #region GUI_Labels&DisplayButtons

        private void _SetGUILabels()        // GUI Labels are written for visual debugging and satiasfaction
        {
            if (rBtn1Manual.Checked)
            {
                lblMsg.Text = "Size " + PuzzleToSolve.PuzzleSize.ToString() + ", Step " + PuzzleToSolve.DesiredStep.ToString() + " (?)" + " slider puzzle is loaded. Have Fun.";
                lblSolTime.Text = "Solution Time (ms): ";
                lblSolStep.Text = "Expanded Nodes: ";
                lblStoNode.Text = "Solution Step: ";
                lblExpNode.Text = "Stored Nodes: ";
            }
            else if (rBtn2BFS.Checked)
            {
                if (PuzzleToSolve.BFSSolved == true)
                {
                    lblMsg.Text = "Size " + PuzzleToSolve.PuzzleSize.ToString() + ", Step " + PuzzleToSolve.DesiredStep.ToString() + " (?)" + " slider puzzle is loaded. Already solved with BFS";
                    lblSolTime.Text = "Solution Time (ms): " + PuzzleToSolve.BFSSolTime.ToString();
                    lblSolStep.Text = "Expanded Nodes: " + PuzzleToSolve.BFSNumExpNodes.ToString();
                    lblStoNode.Text = "Solution Step: " + PuzzleToSolve.BFSSolStep.ToString();
                    lblExpNode.Text = "Stored Nodes: " + PuzzleToSolve.BFSNumStoNodes.ToString();
                }
                else
                {
                    lblMsg.Text = "Size " + PuzzleToSolve.PuzzleSize.ToString() + ", Step " + PuzzleToSolve.DesiredStep.ToString() + " (?)" + " slider puzzle is loaded. Not solved with BFS yet.";
                    lblSolTime.Text = "Solution Time (ms): ";
                    lblSolStep.Text = "Expanded Nodes: ";
                    lblStoNode.Text = "Solution Step: ";
                    lblExpNode.Text = "Stored Nodes: ";
                }
            }
            else if (rBtn3DFS.Checked)
            {
                if (PuzzleToSolve.DFSSolved == true)
                {
                    lblMsg.Text = "Size " + PuzzleToSolve.PuzzleSize.ToString() + ", Step " + PuzzleToSolve.DesiredStep.ToString() + " (?)" + " slider puzzle is loaded. Already solved with DFS.";
                    lblSolTime.Text = "Solution Time (ms): " + PuzzleToSolve.DFSSolTime.ToString();
                    lblSolStep.Text = "Expanded Nodes: " + PuzzleToSolve.DFSNumExpNodes.ToString();
                    lblStoNode.Text = "Solution Step: " + PuzzleToSolve.DFSSolStep.ToString();
                    lblExpNode.Text = "Stored Nodes: " + PuzzleToSolve.DFSNumStoNodes.ToString();
                }
                else
                {
                    lblMsg.Text = "Size " + PuzzleToSolve.PuzzleSize.ToString() + ", Step " + PuzzleToSolve.DesiredStep.ToString() + " (?)" + " slider puzzle is loaded. Not solved with DFS yet.";
                    lblSolTime.Text = "Solution Time (ms): ";
                    lblSolStep.Text = "Expanded Nodes: ";
                    lblStoNode.Text = "Solution Step: ";
                    lblExpNode.Text = "Stored Nodes: ";
                }
            }
            else if (rBtn4IDFS.Checked)
            {
                if (PuzzleToSolve.IDFSSolved == true)
                {
                    lblMsg.Text = "Size " + PuzzleToSolve.PuzzleSize.ToString() + ", Step " + PuzzleToSolve.DesiredStep.ToString() + " (?)" + " slider puzzle is loaded. Already solved with IDFS.";
                    lblSolTime.Text = "Solution Time (ms): " + PuzzleToSolve.IDFSSolTime.ToString();
                    lblSolStep.Text = "Expanded Nodes: " + PuzzleToSolve.IDFSNumExpNodes.ToString();
                    lblStoNode.Text = "Solution Step: " + PuzzleToSolve.IDFSSolStep.ToString();
                    lblExpNode.Text = "Stored Nodes: " + PuzzleToSolve.IDFSNumStoNodes.ToString();
                }
                else
                {
                    lblMsg.Text = "Size " + PuzzleToSolve.PuzzleSize.ToString() + ", Step " + PuzzleToSolve.DesiredStep.ToString() + " (?)" + " slider puzzle is loaded. Not solved with IDFS yet.";
                    lblSolTime.Text = "Solution Time (ms): ";
                    lblSolStep.Text = "Expanded Nodes: ";
                    lblStoNode.Text = "Solution Step: ";
                    lblExpNode.Text = "Stored Nodes: ";
                }
            }
            else if (rBtn5AStarMisplaced.Checked)
            {
                if (PuzzleToSolve.AStarMisSolved == true)
                {
                    lblMsg.Text = "Size " + PuzzleToSolve.PuzzleSize.ToString() + ", Step " + PuzzleToSolve.DesiredStep.ToString() + " (?)" + " slider puzzle is loaded. Already solved with A* (Mis).";
                    lblSolTime.Text = "Solution Time (ms): " + PuzzleToSolve.AStarMisSolTime.ToString();
                    lblSolStep.Text = "Expanded Nodes: " + PuzzleToSolve.AStarMisNumExpNodes.ToString();
                    lblStoNode.Text = "Solution Step: " + PuzzleToSolve.AStarMisSolStep.ToString();
                    lblExpNode.Text = "Stored Nodes: " + PuzzleToSolve.AStarMisNumStoNodes.ToString();
                }
                else
                {
                    lblMsg.Text = "Size " + PuzzleToSolve.PuzzleSize.ToString() + ", Step " + PuzzleToSolve.DesiredStep.ToString() + " (?)" + " slider puzzle is loaded. Not solved with A* (Mis).";
                    lblSolTime.Text = "Solution Time (ms): ";
                    lblSolStep.Text = "Expanded Nodes: ";
                    lblStoNode.Text = "Solution Step: ";
                    lblExpNode.Text = "Stored Nodes: ";
                }
            }
            else if (rBtn6AStarManhattan.Checked)
            {
                if (PuzzleToSolve.AStarManSolved == true)
                {
                    lblMsg.Text = "Size " + PuzzleToSolve.PuzzleSize.ToString() + ", Step " + PuzzleToSolve.DesiredStep.ToString() + " (?)" + " slider puzzle is loaded. Already solved with A* (Man).";
                    lblSolTime.Text = "Solution Time (ms): " + PuzzleToSolve.AStarManSolTime.ToString();
                    lblSolStep.Text = "Expanded Nodes: " + PuzzleToSolve.AStarManNumExpNodes.ToString();
                    lblStoNode.Text = "Solution Step: " + PuzzleToSolve.AStarManSolStep.ToString();
                    lblExpNode.Text = "Stored Nodes: " + PuzzleToSolve.AStarManNumStoNodes.ToString();
                }
                else
                {
                    lblMsg.Text = "Size " + PuzzleToSolve.PuzzleSize.ToString() + ", Step " + PuzzleToSolve.DesiredStep.ToString() + " (?)" + " slider puzzle is loaded. Not solved with A* (Man).";
                    lblSolTime.Text = "Solution Time (ms): ";
                    lblSolStep.Text = "Expanded Nodes: ";
                    lblStoNode.Text = "Solution Step: ";
                    lblExpNode.Text = "Stored Nodes: ";
                }
            }

        }

        private void _GUIButtonsInitial()       // Display State on the GUI with buttons, initilization
        {
            GUISolSteps.Clear();
            if (rBtn1Manual.Checked)
            {
                GUISolSteps.Add(PuzzleToSolve.InitNode);
            }
            else if (rBtn2BFS.Checked)
            {
                GUISolSteps = new List<ClassNode>(PuzzleToSolve.BFSSolSteps);
            }
            else if (rBtn3DFS.Checked)
            {
                GUISolSteps = new List<ClassNode>(PuzzleToSolve.DFSSolSteps);
            }
            else if (rBtn4IDFS.Checked)
            {
                GUISolSteps = new List<ClassNode>(PuzzleToSolve.IDFSSolSteps);
            }
            else if (rBtn5AStarMisplaced.Checked)
            {
                GUISolSteps = new List<ClassNode>(PuzzleToSolve.AStarMisSolSteps);
            }
            else if (rBtn6AStarManhattan.Checked)
            {
                GUISolSteps = new List<ClassNode>(PuzzleToSolve.AStarManSolSteps);
            }

            GUISolStep_indx = 0;
            if (GUISolStep_indx == 0)
                btnBackStep.Enabled = false;        // Cross thread problem...
            else
                btnBackStep.Enabled = true;
            if (GUISolStep_indx == (GUISolSteps.Count - 1))
                btnForwardStep.Enabled = false;
            else
                btnForwardStep.Enabled = true;

            if (rBtn1Manual.Checked)        // If manual... No solution available... 
            {
                btnBackStep.Enabled = false;
                btnForwardStep.Enabled = false;
            }

            _GUIDisplayButtons();

        }

        private void _GUIDisplayButtons()           // For creating state display buttons
        {
            Button[,] Dbs = new Button[PuzzleToSolve.PuzzleSize, PuzzleToSolve.PuzzleSize];     // Dummy Buttons to avoid flickering of buttons when removing and adding new ones.
            Button Db;
            for (int i = 0; i < PuzzleToSolve.PuzzleSize; i++)
            {
                for (int j = 0; j < PuzzleToSolve.PuzzleSize; j++)
                {
                    Db = new Button();
                    Db.Width = BtnsWidth;
                    Db.Height = BtnsHeight;
                    if (rBtn1Manual.Checked)
                        Db.BackColor = Color.SkyBlue;
                    else if (rBtn2BFS.Checked)
                        Db.BackColor = Color.Goldenrod;     // misty rose 
                    else if (rBtn3DFS.Checked)
                        Db.BackColor = Color.Peru;
                    else if (rBtn4IDFS.Checked)
                        Db.BackColor = Color.YellowGreen;
                    else if (rBtn5AStarMisplaced.Checked)
                        Db.BackColor = Color.Tomato;            // Coral
                    else if (rBtn6AStarManhattan.Checked)
                        Db.BackColor = Color.Plum;
                    Db.Left = BtnsLeft + j * (Db.Width + BtnsClearence);
                    Db.Top = BtnsTop + i * (Db.Height + BtnsClearence);
                    Db.Text = GUISolSteps[GUISolStep_indx].NodeState[i, j].ToString();
                    Db.Enabled = false;
                    Dbs[i, j] = Db;
                    if (GUISolSteps[GUISolStep_indx].NodeState[i, j] != 0)
                        Dbs[i, j].Visible = true;
                    else
                        Dbs[i, j].Visible = false;
                    this.Controls.Add(Dbs[i, j]);           // First add new buttons to Controls... Then remove previous buttons to avoid flickering on the buttons.
                }
            }

            _GUIClearButtons();     // Removing previous buttons from the GUI is important... Otherwise everything will be on top of each other...
            DynBtns = new Button[PuzzleToSolve.PuzzleSize, PuzzleToSolve.PuzzleSize];
            for (int i = 0; i < PuzzleToSolve.PuzzleSize; i++)
            {
                for (int j = 0; j < PuzzleToSolve.PuzzleSize; j++)
                {
                    DynBtns[i, j] = Dbs[i, j];
                }
            }

            if (GUISolStep_indx == 0)
                btnBackStep.Enabled = false;
            else
                btnBackStep.Enabled = true;
            if (GUISolStep_indx == (GUISolSteps.Count - 1))
                btnForwardStep.Enabled = false;
            else
                btnForwardStep.Enabled = true;

            this.Refresh();
        }

        private void _GUIClearButtons()         // I need to remove old display buttons from controls
        {
            if (DynBtns != null)
            {
                for (int i = 0; i < DynBtns.GetLength(1); i++)
                {
                    for (int j = 0; j < DynBtns.GetLength(1); j++)
                    {
                        this.Controls.Remove(DynBtns[i, j]);
                    }
                }
            }
        }

        #endregion

        #region DisplaySolution
        private void btnBackStep_Click(object sender, EventArgs e)      // Step Back in the solution steps
        {
            GUISolStep_indx--;

            _GUIDisplayButtons();
        }

        private void btnForwardStep_Click(object sender, EventArgs e)   // Step Forward in the solution steps
        {
            GUISolStep_indx++;

            _GUIDisplayButtons();
        }

        private void PlaySolution()             // For automatically displaying the solution
        {
            showsolution = _GUIDisplayButtons;  // That is done in different thread because I need to sleep thread between transitions
            guiinitilize = _GUIButtonsInitial;
            while (play && GUISolStep_indx < GUISolSteps.Count)
            {
                Invoke(showsolution);
                Thread.Sleep(300);              // trick that causes delay between playing steps
                GUISolStep_indx++;
            }
            if (play == true)       // By cliking the PLAY button we had set play bit... now we need to stop playing by restting it
            {
                Thread.Sleep(2000);         // After finishing just wait a little then go to the initial configuretion again
                play = false;
                GUISolStep_indx = 0;        // when play is finished index is sent back..
                Invoke(guiinitilize);       // Should I add it all!! ok.. no problem.. 
            }
            ShowThread.Abort();
            ShowThread.Join();
        }

        private void btnPlay_Click(object sender, EventArgs e)      // Create new thread and start it
        {
            ShowThread = new Thread(new ThreadStart(PlaySolution));
            play = true;
            ShowThread.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)     // for pausing just reset play bit
        {
            play = false;
        }
        #endregion

        #region MonteCarlo

        private void btnMonteCarlo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Monte Carlo test will take some time. You should load the Monte Carlo data generated with Automatic Puzzle Generator. It contains 100 puzzle samples for a true (?) D step Puzzle. Some Puzzles especialy with high D step ones may be solved in less step, that is due to the fact that they are created in Depth-First fashion. But, they will be examined in the true D steps statistics. Some puzzles may be the same, but since OS is not a Real Time OS they will still contribute to the diversity. All 100 Puzzles will be solved with all 5 algorithms and will be saved on the same XML file after all solutions are complete. If you stop Monte Carlo Run before it finished nothing will be saved. Do you want to continue?","Monte Carlo Solver.", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            { }
            else if (result == DialogResult.Yes)
            {
                bool cont = _LoadMonteCarlo();
                if (cont)
                {
                    b_abort_mc = false;
                    mcprogress = _DisplayProgressOfMonteCarlo;     // Method invoker is initilized...
                    solvemcthread = new Thread(new ThreadStart(_SolveMonteCarlo));
                    solvemcthread.Start();
                }
                
                //_SolveMonteCarlo();

                //_SaveMonteCarlo();
            }
        }

        private bool _LoadMonteCarlo()
        { 
            OpeningTool.Filter = "Xml File(*.xml)|*.xml";           // Only to see .xml files when opening the SavedPuzzle file

            if (OpeningTool.ShowDialog() == DialogResult.OK)
            {
                SavingTool.FileName = OpeningTool.FileName;     // For saving on the same file

                XmlDocument xml;
                XmlNode xNode;
                XmlNodeList xList;

                xml = new XmlDocument();
                xml.Load(OpeningTool.FileName);

                xNode = xml.SelectSingleNode("/AIMehmutluSlidingPuzzleSaveFile");  // Select the correct XML Puzzle Node
                xList = xNode.ChildNodes;
                PL_MC.Clear();
                foreach (XmlNode Nx in xList)
                {
                    PL_MC.Add(new ClassPuzzle(Nx));                 // Create Puzzle. Its constructor handles the details on XML.
                }
                int cnt = 0;
                for (int i = 0; i < PL_MC.Count; i++)          // Required fo monte carlo...
                {
                    PL_MC[i].MCPuzNum = i;
                    cnt++;
                }
            }
            else
                return false;

            if (PL_MC != null)      // Continue if the puzzles are successfully created
            {
                S_BFS = new ClassBFSSolver(PuzzleToSolve);
                S_DFS = new ClassDFSSolver(PuzzleToSolve);
                S_IDFS_Rec = new ClassIDFSSolver_Rec(PuzzleToSolve);        // Not used
                S_IDFS = new ClassIDFSSolver(PuzzleToSolve);
                S_AMis = new ClassAStarMisplacedTilesSolver(PuzzleToSolve);
                S_AMan = new ClassAStarManhattanDistanceSolver(PuzzleToSolve);

                DisableCreateAndLoadButtons();      // GUI Disabled before starting the MONTE CARLO.
                DisableRadioButsAndSolveButs();
                DisablePlayButs();
                DisableStopSolverBut();
                return true;
            }
            return false;
        }

        private void _SolveMonteCarlo()
        {
            for (int i = 0; i < PL_MC.Count && !b_abort_mc; i++)
            {
                PuzzleToSolve = PL_MC[i];                       // For parameter transfer between threads
                //Console.WriteLine("Puzzle: {0}", i);
                S_BFS = new ClassBFSSolver(PL_MC[i]);
                PL_MC[i] = S_BFS.SolveIt();
                PuzzleToSolve.WhichSolver = 0;
                //_DisplayProgressOfMonteCarlo();
                Invoke(mcprogress);

                S_DFS = new ClassDFSSolver(PL_MC[i]);
                PL_MC[i] = S_DFS.SolveIt();
                PuzzleToSolve.WhichSolver = 1;
                //_DisplayProgressOfMonteCarlo();
                Invoke(mcprogress);

                S_IDFS = new ClassIDFSSolver(PL_MC[i]);
                PL_MC[i] = S_IDFS.SolveIt();
                PuzzleToSolve.WhichSolver = 2;
                //_DisplayProgressOfMonteCarlo();
                Invoke(mcprogress);

                S_AMis = new ClassAStarMisplacedTilesSolver(PL_MC[i]);
                PL_MC[i] = S_AMis.SolveIt();
                PuzzleToSolve.WhichSolver = 3;
                //_DisplayProgressOfMonteCarlo();
                Invoke(mcprogress);

                S_AMan = new ClassAStarManhattanDistanceSolver(PL_MC[i]);
                PL_MC[i] = S_AMan.SolveIt();
                PuzzleToSolve.WhichSolver = 4;
                //_DisplayProgressOfMonteCarlo();
                Invoke(mcprogress);
            }
            if (b_abort_mc)
                _SaveMonteCarlo();
            else
            {
                Invoke(mcaftersave);
                solvemcthread.Abort();        // Release the thread once it is finished
                solvemcthread.Join();
            }
        }

        private void _SaveMonteCarlo()
        {
            XDocument inventoryDoc = new XDocument();

            for (int m = 0; m < PL_MC.Count; m++)
            {

                PuzzleToSolve = PL_MC[m];       // So that I can use my old code directly...

                string Size = "";
                string State = "";
                string DesiredOpStep = "";
                string PuzNum = "";
                string PrevPuzNum = "";
                if (m < 10)
                {
                    PuzNum = "Puzzle.00" + m.ToString();
                    PrevPuzNum = "Puzzle.00" + (m-1).ToString();
                }
                else if (m < 100)
                {
                    PuzNum = "Puzzle.0" + m.ToString();
                    PrevPuzNum = "Puzzle.0" + (m - 1).ToString();
                }
                else
                {
                    PuzNum = "Puzzle." + m.ToString();
                    PrevPuzNum = "Puzzle." + (m - 1).ToString();
                }
                
                if (PuzzleToSolve.DesiredStep == -1)
                    DesiredOpStep = "N/A";
                else
                    DesiredOpStep = PuzzleToSolve.DesiredStep.ToString();

                Size = PuzzleToSolve.PuzzleSize.ToString();
                DesiredOpStep = PuzzleToSolve.DesiredStep.ToString();

                for (int i = 0; i < PuzzleToSolve.PuzzleSize; i++)
                {
                    for (int j = 0; j < PuzzleToSolve.PuzzleSize; j++)
                    {
                        State = State + PuzzleToSolve.InitNode.NodeState[i, j];
                        if (j != PuzzleToSolve.PuzzleSize - 1 || i != PuzzleToSolve.PuzzleSize - 1)
                        {
                            State = State + ",";
                        }
                    }
                }

                string BFSSolved = "";
                string BFSSolTime = "";
                string BFSStoNode = "";
                string BFSExpNode = "";
                string BFSSolStep = "";
                string BFSSolNode = "";             // Will be added Later On

                if (PuzzleToSolve.BFSSolved == true)
                {
                    BFSSolved = "T";
                    BFSSolTime = PuzzleToSolve.BFSSolTime.ToString();
                    BFSStoNode = PuzzleToSolve.BFSNumStoNodes.ToString();
                    BFSExpNode = PuzzleToSolve.BFSNumExpNodes.ToString();
                    BFSSolStep = PuzzleToSolve.BFSSolStep.ToString();
                }
                else
                {
                    BFSSolved = "F";
                }

                string DFSSolved = "";
                string DFSSolTime = "";
                string DFSStoNode = "";
                string DFSExpNode = "";
                string DFSSolStep = "";
                string DFSSolNode = "";                 // Will be added Later On

                if (PuzzleToSolve.DFSSolved == true)
                {
                    DFSSolved = "T";
                    DFSSolTime = PuzzleToSolve.DFSSolTime.ToString();
                    DFSStoNode = PuzzleToSolve.DFSNumStoNodes.ToString();
                    DFSExpNode = PuzzleToSolve.DFSNumExpNodes.ToString();
                    DFSSolStep = PuzzleToSolve.DFSSolStep.ToString();
                }
                else
                {
                    DFSSolved = "F";
                }

                string IDFSSolved = "";
                string IDFSSolTime = "";
                string IDFSStoNode = "";
                string IDFSExpNode = "";
                string IDFSSolStep = "";
                string IDFSSolNode = "";                // Will be added Later On

                if (PuzzleToSolve.IDFSSolved == true)
                {
                    IDFSSolved = "T";
                    IDFSSolTime = PuzzleToSolve.IDFSSolTime.ToString();
                    IDFSStoNode = PuzzleToSolve.IDFSNumStoNodes.ToString();
                    IDFSExpNode = PuzzleToSolve.IDFSNumExpNodes.ToString();
                    IDFSSolStep = PuzzleToSolve.IDFSSolStep.ToString();
                }
                else
                {
                    IDFSSolved = "F";
                }

                string AMisSolved = "";
                string AMisSolTime = "";
                string AMisStoNode = "";
                string AMisExpNode = "";
                string AMisSolStep = "";
                string AMisSolNode = "";                // Will be added Later On

                if (PuzzleToSolve.AStarMisSolved == true)
                {
                    AMisSolved = "T";
                    AMisSolTime = PuzzleToSolve.AStarMisSolTime.ToString();
                    AMisStoNode = PuzzleToSolve.AStarMisNumStoNodes.ToString();
                    AMisExpNode = PuzzleToSolve.AStarMisNumExpNodes.ToString();
                    AMisSolStep = PuzzleToSolve.AStarMisSolStep.ToString();
                }
                else
                {
                    AMisSolved = "F";
                }

                string AManSolved = "";
                string AManSolTime = "";
                string AManStoNode = "";
                string AManExpNode = "";
                string AManSolStep = "";
                string AManSolNode = "";                // Will be added Later On

                if (PuzzleToSolve.AStarManSolved == true)
                {
                    AManSolved = "T";
                    AManSolTime = PuzzleToSolve.AStarManSolTime.ToString();
                    AManStoNode = PuzzleToSolve.AStarManNumStoNodes.ToString();
                    AManExpNode = PuzzleToSolve.AStarManNumExpNodes.ToString();
                    AManSolStep = PuzzleToSolve.AStarManSolStep.ToString();
                }
                else
                {
                    AManSolved = "F";
                }

                //Console.WriteLine("State: {0}", State);
                XElement newElement = new XElement("AIMehmutluSlidingPuzzleSaveFile",
                            new XElement(PuzNum,
                                new XElement("Size", Size),
                                new XElement("State", State),
                                new XElement("DesiredOptimalSolutionStep", DesiredOpStep),
                                new XElement("SolvedAlgorithms",
                                    new XElement("BFS",
                                        new XElement("Solved", BFSSolved),
                                        new XElement("SolutionTime", BFSSolTime),
                                        new XElement("NoOfStoredNodes", BFSStoNode),
                                        new XElement("NoOfNodeExpansion", BFSExpNode),
                                        new XElement("SolutionStep", BFSSolStep),
                                        new XElement("SolutionNodes",
                                            new XElement("Node0", State))),
                                    new XElement("DFS",
                                        new XElement("Solved", DFSSolved),
                                        new XElement("SolutionTime", DFSSolTime),
                                        new XElement("NoOfStoredNodes", DFSStoNode),
                                        new XElement("NoOfNodeExpansion", DFSExpNode),
                                        new XElement("SolutionStep", DFSSolStep),
                                        new XElement("SolutionNodes",
                                            new XElement("Node0", State))),
                                    new XElement("IDFS",
                                        new XElement("Solved", IDFSSolved),
                                        new XElement("SolutionTime", IDFSSolTime),
                                        new XElement("NoOfStoredNodes", IDFSStoNode),
                                        new XElement("NoOfNodeExpansion", IDFSExpNode),
                                        new XElement("SolutionStep", IDFSSolStep),
                                        new XElement("SolutionNodes",
                                            new XElement("Node0", State))),
                                    new XElement("AStarMisplacedTiles",
                                        new XElement("Solved", AMisSolved),
                                        new XElement("SolutionTime", AMisSolTime),
                                        new XElement("NoOfStoredNodes", AMisStoNode),
                                        new XElement("NoOfNodeExpansion", AMisExpNode),
                                        new XElement("SolutionStep", AMisSolStep),
                                        new XElement("SolutionNodes",
                                            new XElement("Node0", State))),
                                    new XElement("AStarManhattan",
                                        new XElement("Solved", AManSolved),
                                        new XElement("SolutionTime", AManSolTime),
                                        new XElement("NoOfStoredNodes", AManStoNode),
                                        new XElement("NoOfNodeExpansion", AManExpNode),
                                        new XElement("SolutionStep", AManSolStep),
                                        new XElement("SolutionNodes",
                                            new XElement("Node0", State))))));
                // Add to in-memory object
                if (m == 0)
                    inventoryDoc.AddFirst(newElement);          // First Burst is ready               
                else
                    inventoryDoc.Root.Add(newElement.FirstNode);
                // Now Add Solution Steps So that I can display them
                int cnt = 0;
                foreach (ClassNode Cn in PuzzleToSolve.BFSSolSteps)
                {
                    if (Cn != PuzzleToSolve.BFSSolSteps[0])
                    {
                        string st = "Node" + cnt.ToString();
                        inventoryDoc.Root.Element(PuzNum).Element("SolvedAlgorithms").Element("BFS").Element("SolutionNodes").Add(new XElement(st, _StateInString(Cn)));

                    }
                    cnt++;
                }
                // Saving DFS Steps in MONTE Carlo run makes the save file ridicuolsly large (100-250mb for size 3)
                /*
                cnt = 0;
                foreach (ClassNode Cn in PuzzleToSolve.DFSSolSteps)
                {
                    if (Cn != PuzzleToSolve.DFSSolSteps[0])
                    {
                        string st = "Node" + cnt.ToString();
                        inventoryDoc.Root.Element(PuzNum).Element("SolvedAlgorithms").Element("DFS").Element("SolutionNodes").Add(new XElement(st, _StateInString(Cn)));

                    }
                    cnt++;
                }
                */
                cnt = 0;
                foreach (ClassNode Cn in PuzzleToSolve.IDFSSolSteps)
                {
                    if (Cn != PuzzleToSolve.IDFSSolSteps[0])
                    {
                        string st = "Node" + cnt.ToString();
                        inventoryDoc.Root.Element(PuzNum).Element("SolvedAlgorithms").Element("IDFS").Element("SolutionNodes").Add(new XElement(st, _StateInString(Cn)));

                    }
                    cnt++;
                }

                cnt = 0;
                foreach (ClassNode Cn in PuzzleToSolve.AStarMisSolSteps)
                {
                    if (Cn != PuzzleToSolve.AStarMisSolSteps[0])
                    {
                        string st = "Node" + cnt.ToString();
                        inventoryDoc.Root.Element(PuzNum).Element("SolvedAlgorithms").Element("AStarMisplacedTiles").Element("SolutionNodes").Add(new XElement(st, _StateInString(Cn)));

                    }
                    cnt++;
                }

                cnt = 0;
                foreach (ClassNode Cn in PuzzleToSolve.AStarManSolSteps)
                {
                    if (Cn != PuzzleToSolve.AStarManSolSteps[0])
                    {
                        string st = "Node" + cnt.ToString();
                        inventoryDoc.Root.Element(PuzNum).Element("SolvedAlgorithms").Element("AStarManhattan").Element("SolutionNodes").Add(new XElement(st, _StateInString(Cn)));

                    }
                    cnt++;
                }


            }

            inventoryDoc.Save(SavingTool.FileName);     // Filename was set when chosen while loading file!!!

            mcaftersave = EnableGUIAfterMCSave;
            Invoke(mcaftersave);

            solvemcthread.Abort();        // Release the thread once it is finished
            solvemcthread.Join();
        }

        private void _DisplayProgressOfMonteCarlo()
        {
            string Alg = "";
            string Puz =  PuzzleToSolve.MCPuzNum.ToString();
            if (PuzzleToSolve.WhichSolver == 0)
                Alg = "BFS";
            else if (PuzzleToSolve.WhichSolver == 1)
                Alg = "DFS";
            else if (PuzzleToSolve.WhichSolver == 2)
                Alg = "IDFS";
            else if (PuzzleToSolve.WhichSolver == 3)
                Alg = "A* Mis";
            else if (PuzzleToSolve.WhichSolver == 4)
                Alg = "A* Man";
            lblMsg.Text = "Monte Carlo Progress: Puzzle " + Puz + " is solved with Algorithm " + Alg;
            lblMsg.Refresh();
        }

        MethodInvoker mcaftersave;

        private void EnableGUIAfterMCSave() 
        {
            lblMsg.Text = "MONTE CARLO run is saved over its initial file";

            _GUIButtonsInitial();
            DisablePlayButs();
            DisableRadioButsAndSolveButs();
            EnableCreateAndLoadButtons();
            EnableMonteCarlo();
        }

        private void btnStopMonteCarlo_Click(object sender, EventArgs e)
        {
            b_abort_mc = true;
            for (int i = 0; i < PL_MC.Count; i++)
            {
                PL_MC[i].b_abort = true;
            }
        }

        #endregion

        #region FormClosing

        private void FormMAINGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                solvethread.Abort();
                solvethread.Join();
            }
            catch { }

            try
            {
                ShowThread.Abort();
                ShowThread.Join();
            }
            catch { }

            try
            {
                solvemcthread.Abort();
                solvemcthread.Join();
            }
            catch { }
        }

        #endregion

    }
}
