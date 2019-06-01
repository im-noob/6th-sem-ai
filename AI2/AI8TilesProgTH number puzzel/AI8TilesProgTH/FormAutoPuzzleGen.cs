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
using System.Security;

namespace AI8TilesProgTH
{
    public partial class FormAutoPuzzleGen : Form
    {
        #region Parameters&Variables

        int NoOfPuzzleMonteCarlo = 100; // N parameter mentioned in the take-home definition sheet. Change it from here. (Do not make GUI cumbersome)
        bool MonteCarlo = false;        // Not to draw buttons when doing a Monte Carlo Data 
        bool FirstWarning = true;       // To give a warning message only at the beginning

        ClassNode MyInitConf;           // Initial condition generated
        int SizeOfPuzzle = 0;           // Initial condition Parameters
        int NoOfStep = 0;
        Button[,] DynBtns;              // Buttons for visual purposes
        int BtnsLeft = 200;             // Buttons' parameters
        int BtnsTop = 10;
        int BtnsClearence = 5;
        int BtnsHeight = 30;
        int BtnsWidth = 40;

        int cBoxBoardSizeIndex;

        private static Random Rand = new Random();

        DialogResult result;        // Just to make sure button is not accidentally pressed, since generating 100 puzzles takes some time.
        SaveFileDialog SavingTool;
        MethodInvoker enableform;
        MethodInvoker showstep;
        Thread generatorthread;
        string stepno;

        #endregion

        public FormAutoPuzzleGen()
        {
            InitializeComponent();
        }

        private void DisableMyGui()         // For not disturbing program operation while doing some calculation
        {
            cBoxBoardSize.Enabled = false;
            nUDTrueStepShuffle.Enabled = false;
            btnGenerateInitialCondition.Enabled = false;
            btnSaveStateAuto.Enabled = false;
            btnGenerateMonteCarloAlgorithmComparison.Enabled = false;
        }

        private void EnableMyGui()      // For not disturbing program operation while doing some calculation and having functions back once done
        {
            cBoxBoardSize.Enabled = true;
            nUDTrueStepShuffle.Enabled = true;
            btnGenerateInitialCondition.Enabled = true;
            btnSaveStateAuto.Enabled = true;
            btnGenerateMonteCarloAlgorithmComparison.Enabled = true;
        }

        private void RemoveDisplayButtons()     // For each initial configuration, first clear previous buttons on the GUI (except for the Monte carlo Data since I do not display states in MonteCarlo data. One can open the .xml file or follow the console)
        {
            for (int i = 0; i < SizeOfPuzzle; i++)                 
            {
                for (int j = 0; j < SizeOfPuzzle; j++)
                {
                    this.Controls.Remove(DynBtns[i, j]);
                }
            }
        }
        
        private void cBoxBoardSize_SelectedIndexChanged(object sender, EventArgs e)     // Automatically generate puzzle when new puzzle size is selected
        {
            cBoxBoardSizeIndex = cBoxBoardSize.SelectedIndex;
            if (FirstWarning == true)
            {
                MessageBox.Show("Generating Puzzle may take some time for large sizes at large steps d. Just be aware of it and please do not rush for the largest setups directly.","Automatic Puzzle Generator");
                FirstWarning = false;
            }

            RemoveDisplayButtons();
            if((cBoxBoardSize.SelectedIndex==0)||(cBoxBoardSize.SelectedIndex==1)||(cBoxBoardSize.SelectedIndex==2)||(cBoxBoardSize.SelectedIndex==3)||(cBoxBoardSize.SelectedIndex==4)||(cBoxBoardSize.SelectedIndex==5)||(cBoxBoardSize.SelectedIndex==6)||(cBoxBoardSize.SelectedIndex==7)||(cBoxBoardSize.SelectedIndex==8)||(cBoxBoardSize.SelectedIndex==9)||(cBoxBoardSize.SelectedIndex==9))
            {
                nUDTrueStepShuffle.Maximum = (cBoxBoardSize.SelectedIndex + 2) * 10 + 10;
            }
            
            DisableMyGui();
            MonteCarlo = false;
            GenerateNewInitialCondition();   
        }

        private void nUDTrueStepShuffle_ValueChanged(object sender, EventArgs e)    // Automatically generate puzzle when puzzle solution step is changed
        {
            RemoveDisplayButtons();
            DisableMyGui();
            MonteCarlo = false;
            GenerateNewInitialCondition();
        }

        private void btnGenerateInitialCondition_Click(object sender, EventArgs e)  // One can generate new Initial condition with the previously selected Size and distance by just cliking this button
        {
            RemoveDisplayButtons();
            DisableMyGui();
            MonteCarlo = false;
            GenerateNewInitialCondition();
        }

        void GenerateNewInitialCondition()      // Actual d step & specified size puzzle is generated with this function
        {
            if (cBoxBoardSizeIndex == -1)      // To avoid bugs related to comboBox (cBox)
            {
                cBoxBoardSizeIndex = 0;
            }
            SizeOfPuzzle = cBoxBoardSizeIndex + 3;
            MyInitConf = new ClassNode(SizeOfPuzzle);       // Goal state is generated. Puzzle is ready to be shuffled 

            this.Width = BtnsLeft + (SizeOfPuzzle * (BtnsWidth + BtnsClearence)) + 30;      // Enlargen or shrink the GUI depending on the puzzle size
            if (SizeOfPuzzle > 5)
            {
                this.Height = BtnsTop + (SizeOfPuzzle * (BtnsHeight + BtnsClearence)) + 50;
            }
            else
            {
                this.Height = 250;
            }

            int cnt = 0;            // For counting encountered Dead-End nodes
            // SHUFFLING Begins here            
            List<ClassNode> OpenedNodes = new List<ClassNode>();    // To avoid loops store them in OpenedNodes List
            List<ClassNode> DeadNodes = new List<ClassNode>();      // To avoid loops detect DeadNodes. Note that they are updated on the fly, so, most of the time this list is emptied
            OpenedNodes.Add(MyInitConf);          
                     
            List<ClassNode> SuccessorNodes = new List<ClassNode>();
            int NoOfSuccessors;
            NoOfStep = (int)nUDTrueStepShuffle.Value;               // Steps to shuffle

            // Loop avoiding successor opening begind here (main part of shuffling)
            int d = 0;
            while (d < NoOfStep)
            {
                SuccessorNodes = OpenedNodes[OpenedNodes.Count - 1].GetSuccessors();
                NoOfSuccessors = SuccessorNodes.Count;

                // I need to randomize Successor Nodes' order otherwise I will not be able to shuffle well !!!
                List<ClassNode> DummyShuffledSuccessors = new List<ClassNode>();

                for (int i = 0; i < NoOfSuccessors; i++)
                {
                    int RandomWait = Rand.Next(3,7);
                    Thread.Sleep(RandomWait);                       // Random function depends on system clock. So, random waits seems to increase randomness
                    int RandomNumber = Rand.Next(0, (SuccessorNodes.Count));
                    DummyShuffledSuccessors.Add(SuccessorNodes[RandomNumber]);
                    SuccessorNodes.RemoveAt(RandomNumber);
                }
                // Randomizing successors are done
                // Re-use SuccessorNodes array. Its Name is better
                for (int i = 0; i < DummyShuffledSuccessors.Count; i++)
                {
                    SuccessorNodes.Add(DummyShuffledSuccessors[i]);
                }
                
                // TRUE DISTANCE GENERATION... (This may not be optimal distance. For small puzzles it is obviously optimal distance but for long shuffling there may exist shorter path to that initial state)
                bool NewSuccessorFound = false;     // Will be set true if the new successor already exists in the OpenedNodes List
                for (int j = 0; (j < SuccessorNodes.Count) && (NewSuccessorFound == false); j++)        // For all SuccessorNodes
                {
                    bool AlreadyFoundInOpenedFlag = false;      // Successor compared to all Opened Nodes...
                    for (int k = 0; (k < OpenedNodes.Count) && (AlreadyFoundInOpenedFlag == false); k++)           // For All OpenedNodes
                    {
                        bool DifferenceNoticed = false;     // For one Successor node only
                        for (int m = 0; (m < SizeOfPuzzle) && (DifferenceNoticed == false); m++)        // Compare Node in the OpenedList & SuccessorList
                        {
                            for (int n = 0; (n < SizeOfPuzzle) && (DifferenceNoticed == false); n++)
                            {
                                if (OpenedNodes[k].NodeState[m, n] != SuccessorNodes[j].NodeState[m, n])
                                {
                                    DifferenceNoticed = true;           // If Node in the OpenedList & SuccessorList are different Set this flag
                                }
                            }
                        }
                        if (DifferenceNoticed == false)
                        {
                            AlreadyFoundInOpenedFlag = true;
                        }
                    }

                    bool FoundInDeadsFlag = false;
                    for (int k = 0; (k < DeadNodes.Count); k++)             // For all dead nodes (Check whether successor in dead nodes)
                    {
                        bool DifferenceNoticed = false;     // For one Successor node only
                        for (int m = 0; (m < SizeOfPuzzle) && (DifferenceNoticed == false); m++)        // Compare Node in the OpenedList & SuccessorList
                        {
                            for (int n = 0; (n < SizeOfPuzzle) && (DifferenceNoticed == false); n++)
                            {
                                if (DeadNodes[k].NodeState[m, n] != SuccessorNodes[j].NodeState[m, n])
                                {
                                    DifferenceNoticed = true;           // If Node in the OpenedList & SuccessorList are different Set this flag
                                }
                            }
                        }
                        if (DifferenceNoticed == false)
                        {
                            FoundInDeadsFlag = true;
                        }
                    }

                    if ((AlreadyFoundInOpenedFlag == false) && (FoundInDeadsFlag == false))      // New SuccessorNode does not exist in OpenedNodes list & DeadNodes list
                    {
                        OpenedNodes.Add(SuccessorNodes[j]);     // Then add it to the Opened NodesList (i.e. Open that successor)
                        DeadNodes.Clear();
                        NewSuccessorFound = true;
                        d++;
                    }
                }

                // We have a problem if all New Successors are already in the OpenedList. We have to delete the last Node in the OpenedNodeList since it is a DEAD END
                // and request sucessors of the Node before the just deleted one. 
                if (NewSuccessorFound == true)      // One of the successors was new and already added to the OpenedNode list
                {

                }
                else
                {                                   // We are going back at the opened nodes !!! (dead end encountered)
                    DeadNodes.Clear();
                    DeadNodes.Add(OpenedNodes[OpenedNodes.Count - 1]);
                    OpenedNodes.RemoveAt(OpenedNodes.Count - 1);
                    d--;
                    cnt++;
                }
            }
            // SHUFFLING ends here

            if (NoOfStep == (OpenedNodes.Count - 1))        // That was for debug and control. This message box should never be seen !!!
            {
                MyInitConf = OpenedNodes[NoOfStep];
            }
            else
            {
                MessageBox.Show("Generate New");
            }
            
            //Console.WriteLine("Dead-Ends Detected and Recovered:{0}", cnt.ToString()); // COMMENT OUT LATER !!!!!                             

            if (MonteCarlo == false)        // Initial contition is generated. If it was not for Monte Carlo Test, display it
            {
                CreateButtons();
            }
        }

        void CreateButtons()            // Create Buttons on the GUI. They will be disabled and just for visual purposes
        {
            Button b;
            DynBtns = new Button[SizeOfPuzzle, SizeOfPuzzle];
            for (int i = 0; i < SizeOfPuzzle; i++)
            {
                for (int j = 0; j < SizeOfPuzzle; j++)
                {
                    b = new Button();
                    b.Width = BtnsWidth;
                    b.Height = BtnsHeight;
                    b.BackColor = Color.SkyBlue;
                    b.Visible = true;
                    b.Left = BtnsLeft + j * (b.Width + BtnsClearence);
                    b.Top = BtnsTop + i * (b.Height + BtnsClearence);
                    b.Text = MyInitConf.NodeState[i, j].ToString();
                    b.Enabled = false;
                    DynBtns[i, j] = b;
                    if (MyInitConf.NodeState[i, j] != 0)
                    {
                        this.Controls.Add(b);
                    }
                }
            }

            EnableMyGui();
        }

        // You can generate, control and save only 1 puzzle at a time with this GUI... If you want uncontrolled samples, just use MONTE CARLO... or write your own .xml file manually...
        private void btnSaveStateAuto_Click(object sender, EventArgs e)     
        {
            if (MyInitConf != null)
            {
                SaveFileDialog SavingTool = new SaveFileDialog();
                SavingTool.AddExtension = true;
                SavingTool.Filter = "Xml File(*.xml)|*.xml";
                if (SavingTool.ShowDialog() == DialogResult.OK)
                {
                    XDocument inventoryDoc = new XDocument();

                    string Size = "";
                    string State = "";
                    string DesiredOpStep = "";
                    string Dtxt = "";
                    string Dtxt2 = "F";

                    Size = SizeOfPuzzle.ToString();
                    DesiredOpStep = NoOfStep.ToString();

                    for (int i = 0; i < SizeOfPuzzle; i++)
                    {
                        for (int j = 0; j < SizeOfPuzzle; j++)
                        {
                            State = State + MyInitConf.NodeState[i, j];
                            if (j != SizeOfPuzzle - 1 || i != SizeOfPuzzle - 1)
                            {
                                State = State + ",";
                            }
                        }
                    }
                    //Console.WriteLine("State: {0}", State);
                    XElement newElement = new XElement("AIMehmutluSlidingPuzzleSaveFile",
                                new XElement("Puzzle.000",
                                    new XElement("Size", Size),
                                    new XElement("State", State),
                                    new XElement("DesiredOptimalSolutionStep", DesiredOpStep),
                                    new XElement("SolvedAlgorithms",
                                        new XElement("BFS",
                                            new XElement("Solved", Dtxt2),
                                            new XElement("SolutionTime", Dtxt),
                                            new XElement("NoOfStoredNodes", Dtxt),
                                            new XElement("NoOfNodeExpansion", Dtxt),
                                            new XElement("SolutionStep", Dtxt),
                                            new XElement("SolutionNodes",
                                                new XElement("Node0", State))),
                                        new XElement("DFS",
                                            new XElement("Solved", Dtxt2),
                                            new XElement("SolutionTime", Dtxt),
                                            new XElement("NoOfStoredNodes", Dtxt),
                                            new XElement("NoOfNodeExpansion", Dtxt),
                                            new XElement("SolutionStep", Dtxt),
                                            new XElement("SolutionNodes",
                                                new XElement("Node0", State))),
                                        new XElement("IDFS",
                                            new XElement("Solved", Dtxt2),
                                            new XElement("SolutionTime", Dtxt),
                                            new XElement("NoOfStoredNodes", Dtxt),
                                            new XElement("NoOfNodeExpansion", Dtxt),
                                            new XElement("SolutionStep", Dtxt),
                                            new XElement("SolutionNodes",
                                                new XElement("Node0", State))),
                                        new XElement("AStarMisplacedTiles",
                                            new XElement("Solved", Dtxt2),
                                            new XElement("SolutionTime", Dtxt),
                                            new XElement("NoOfStoredNodes", Dtxt),
                                            new XElement("NoOfNodeExpansion", Dtxt),
                                            new XElement("SolutionStep", Dtxt),
                                            new XElement("SolutionNodes",
                                                new XElement("Node0", State))),
                                        new XElement("AStarManhattan",
                                            new XElement("Solved", Dtxt2),
                                            new XElement("SolutionTime", Dtxt),
                                            new XElement("NoOfStoredNodes", Dtxt),
                                            new XElement("NoOfNodeExpansion", Dtxt),
                                            new XElement("SolutionStep", Dtxt),
                                            new XElement("SolutionNodes",
                                                new XElement("Node0", State))))));
                    // Add to in-memory object.
                    inventoryDoc.AddFirst(newElement);
                    inventoryDoc.Save(SavingTool.FileName);
                }
            }
        }
             
        // Monte Carlo Requires an Automated data generating sequence. # of data is written in a global paramater at the beginnig of the program (NoOfPuzzleMonteCarlo)
        private void btnGenerateMonteCarloAlgorithmComparison_Click(object sender, EventArgs e)
        {
            DisableMyGui();
            result = MessageBox.Show("You are about to generate a Monte Carlo Data. It Consists of 100 puzzles at chosen size and d distance. It takes some time (from a half min, up to more mins) depending on size and d due to Randomness fact. Are you sure you want to start?", "Monte Carlo Data Generation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            { }
            else if (result == DialogResult.Yes)
            {

                MonteCarlo = true;      // To avoid GUI buttons

                SavingTool = new SaveFileDialog();       // Saving options
                SavingTool.AddExtension = true;
                SavingTool.Filter = "Xml File(*.xml)|*.xml";
                if (SavingTool.ShowDialog() == DialogResult.OK)         // Saving window opens
                {
                    generatorthread = new Thread(new ThreadStart(GenerateMonteCarloAlgorithmComparison));
                    generatorthread.Start();
                }
            }
            
            
        }       // End of Monte Carlo data generation
        
        private void ShowMCStep() 
        {
            this.Text = stepno;
        }

        private void GenerateMonteCarloAlgorithmComparison()
        {
            showstep = ShowMCStep;
            XDocument inventoryDoc = new XDocument();           // New xml file is created

            XElement firstElement = new XElement("AIMehmutluSlidingPuzzleSaveFile");
            inventoryDoc.AddFirst(firstElement);

            string Size = "";
            string State = "";
            string DesiredOpStep = "";
            string Dtxt = "";
            string Dtxt2 = "F";

            Size = SizeOfPuzzle.ToString();
            DesiredOpStep = NoOfStep.ToString();

            for (int m = 0; m < NoOfPuzzleMonteCarlo; m++)      // for N puzzle, generate all and add to xml file.
            {
                string DummyPuzNum = "";
                DummyPuzNum = m.ToString();
                if (m < 10)
                {
                    DummyPuzNum = "00" + DummyPuzNum;
                }
                else if (m < 100)
                {
                    DummyPuzNum = "0" + DummyPuzNum;
                }
                DummyPuzNum = "Puzzle." + DummyPuzNum;

                stepno = m.ToString() + "th Puzzle Generated, out of: " + NoOfPuzzleMonteCarlo.ToString();       // To display the progress
                Invoke(showstep);
                //Thread.Sleep(277);          // Just to bring randomness wait some time (I think random fumction works with system clock)

                GenerateNewInitialCondition();                  // Generate Puzzle initial condition and then construct the XML node... and add it to XML file....
                State = "";
                for (int i = 0; i < SizeOfPuzzle; i++)          // convert the initial condition to a string
                {
                    for (int j = 0; j < SizeOfPuzzle; j++)
                    {
                        State = State + MyInitConf.NodeState[i, j];
                        if (j != SizeOfPuzzle - 1 || i != SizeOfPuzzle - 1)
                        {
                            State = State + ",";
                        }
                    }
                }
                //Console.WriteLine("State: {0}", State);         // For debug. One can check efficiency of ramdomness from lines written on the console (on debug mode)
                XElement newElement = new XElement(DummyPuzNum,    // Construct the puzzle SAVE XML NODE
                                new XElement("Size", Size),
                                new XElement("State", State),
                                new XElement("DesiredOptimalSolutionStep", DesiredOpStep),
                                new XElement("SolvedAlgorithms",
                                    new XElement("BFS",
                                        new XElement("Solved", Dtxt2),
                                        new XElement("SolutionTime", Dtxt),
                                        new XElement("NoOfStoredNodes", Dtxt),
                                        new XElement("NoOfNodeExpansion", Dtxt),
                                        new XElement("SolutionStep", Dtxt),
                                        new XElement("SolutionNodes",
                                            new XElement("Node0", State))),
                                    new XElement("DFS",
                                        new XElement("Solved", Dtxt2),
                                        new XElement("SolutionTime", Dtxt),
                                        new XElement("NoOfStoredNodes", Dtxt),
                                        new XElement("NoOfNodeExpansion", Dtxt),
                                        new XElement("SolutionStep", Dtxt),
                                        new XElement("SolutionNodes",
                                            new XElement("Node0", State))),
                                    new XElement("IDFS",
                                        new XElement("Solved", Dtxt2),
                                        new XElement("SolutionTime", Dtxt),
                                        new XElement("NoOfStoredNodes", Dtxt),
                                        new XElement("NoOfNodeExpansion", Dtxt),
                                        new XElement("SolutionStep", Dtxt),
                                        new XElement("SolutionNodes",
                                            new XElement("Node0", State))),
                                    new XElement("AStarMisplacedTiles",
                                        new XElement("Solved", Dtxt2),
                                        new XElement("SolutionTime", Dtxt),
                                        new XElement("NoOfStoredNodes", Dtxt),
                                        new XElement("NoOfNodeExpansion", Dtxt),
                                        new XElement("SolutionStep", Dtxt),
                                        new XElement("SolutionNodes",
                                            new XElement("Node0", State))),
                                    new XElement("AStarManhattan",
                                        new XElement("Solved", Dtxt2),
                                        new XElement("SolutionTime", Dtxt),
                                        new XElement("NoOfStoredNodes", Dtxt),
                                        new XElement("NoOfNodeExpansion", Dtxt),
                                        new XElement("SolutionStep", Dtxt),
                                        new XElement("SolutionNodes",
                                            new XElement("Node0", State)))));
                // Add xml node to in-memory object.
                inventoryDoc.Descendants("AIMehmutluSlidingPuzzleSaveFile").First().Add(newElement);
            }
            stepno = "Automatic Puzzle Generator";
            Invoke(showstep);
            // Save the XML file at the very end. To the destination chosen by the user (by save window)
            inventoryDoc.Save(SavingTool.FileName);

            enableform = EnableMyGui;
            Invoke(enableform);
        }

        private void FormAutoPuzzleGen_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                generatorthread.Abort();
                generatorthread.Join();
            }
            catch { }
        }

    }
}
