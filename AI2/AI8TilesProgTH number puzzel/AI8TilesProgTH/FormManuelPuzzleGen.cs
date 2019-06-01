using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AI8TilesProgTH
{
    public partial class FormManuelPuzzleGen : Form
    {
        static ClassNode MyInitConf;    // Generated Initial configuration will be in this parameter
        int SizeOfPuzzle=0;
        Button[,] DynBtns;              // Buttons' parameters for GUI
        int BtnsLeft = 200;
        int BtnsTop = 10;
        int BtnsClearence = 5;
        int BtnsHeight = 30;
        int BtnsWidth = 40;

        public FormManuelPuzzleGen()
        {
            InitializeComponent();
        }

        void CreateButtons()        // Creating Buttons on the GUI. They will be clikable !!!
        {
            for (int i = 0; i < SizeOfPuzzle; i++)                 //Removing Buttons. Clearing previously drawn buttons (if exists)
            {
                for (int j = 0; j < SizeOfPuzzle; j++)
                {
                    this.Controls.Remove(DynBtns[i, j]);
                }
            }

            if (cBoxBoardSizeMan.SelectedIndex == -1)           // to prevent any bug from cBox object
            {
                cBoxBoardSizeMan.SelectedIndex = 0;
            }
            SizeOfPuzzle = cBoxBoardSizeMan.SelectedIndex + 3;
            MyInitConf = new ClassNode(SizeOfPuzzle);           // Initialy, Initial State equals to the goal state

            this.Width = BtnsLeft + (SizeOfPuzzle * (BtnsWidth + BtnsClearence)) + 30;      // GUI Size
            this.Height = BtnsTop + (SizeOfPuzzle * (BtnsHeight + BtnsClearence)) + 50;


            Button b;               // Create and display GUI buttons
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
                    b.Tag = i.ToString() + "," + j.ToString();
                    b.Click += new EventHandler(btnArray_Click);
                    DynBtns[i, j] = b;
                    if (MyInitConf.NodeState[i, j] != 0)
                    {
                        this.Controls.Add(b);
                    }
                }
            }
        }

        private void cBoxBoardSizeMan_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateButtons();
        }

        private void btnArray_Click(object sender, EventArgs e)     // After clicked to any button on GUI this event is raised
        {
            Button b = (Button)sender;          // clicked button is b

            int i_of_clicked = 0, j_of_clicked = 0;
            string[] Subtext = b.Tag.ToString().Split(',');     // Identify the clicked button from its tag
            i_of_clicked = Convert.ToInt16(Subtext[0]);         // Parsing is simple with C# like many other things
            j_of_clicked = Convert.ToInt16(Subtext[1]);
           
            // Compare the position of the clicked button with BLANK tile. If they are neinghbors, swap those 2 buttons (Blank Button and clicked button). It will seem like they have swapped on the GUI.
            if ((i_of_clicked == MyInitConf.LoB.X - 1) && (j_of_clicked == MyInitConf.LoB.Y))       // Top Of B Ced (clicked)
            {
                MyInitConf.LoB.X = i_of_clicked;
                MyInitConf.NodeState[i_of_clicked + 1, j_of_clicked] = MyInitConf.NodeState[i_of_clicked, j_of_clicked];
                MyInitConf.NodeState[i_of_clicked, j_of_clicked] = 0;
                DynBtns[i_of_clicked, j_of_clicked].Text = "0";
                DynBtns[i_of_clicked + 1, j_of_clicked].Text = MyInitConf.NodeState[i_of_clicked + 1, j_of_clicked].ToString();
                this.Controls.Add(DynBtns[i_of_clicked + 1, j_of_clicked]);
                this.Controls.Remove(DynBtns[i_of_clicked,j_of_clicked]);
            }
            else if ((i_of_clicked == MyInitConf.LoB.X + 1) && (j_of_clicked == MyInitConf.LoB.Y))  // Down Of B Ced
            {
                MyInitConf.LoB.X = i_of_clicked;
                MyInitConf.NodeState[i_of_clicked - 1, j_of_clicked] = MyInitConf.NodeState[i_of_clicked, j_of_clicked];
                MyInitConf.NodeState[i_of_clicked, j_of_clicked] = 0;
                DynBtns[i_of_clicked, j_of_clicked].Text = "0";
                DynBtns[i_of_clicked - 1, j_of_clicked].Text = MyInitConf.NodeState[i_of_clicked - 1, j_of_clicked].ToString();
                this.Controls.Add(DynBtns[i_of_clicked - 1, j_of_clicked]);
                this.Controls.Remove(DynBtns[i_of_clicked, j_of_clicked]);
            }
            else if ((i_of_clicked == MyInitConf.LoB.X) && (j_of_clicked == MyInitConf.LoB.Y + 1))  // Right Of B Ced
            {
                MyInitConf.LoB.Y = j_of_clicked;
                MyInitConf.NodeState[i_of_clicked, j_of_clicked - 1] = MyInitConf.NodeState[i_of_clicked, j_of_clicked];
                MyInitConf.NodeState[i_of_clicked, j_of_clicked] = 0;
                DynBtns[i_of_clicked, j_of_clicked].Text = "0";
                DynBtns[i_of_clicked, j_of_clicked - 1].Text = MyInitConf.NodeState[i_of_clicked, j_of_clicked - 1].ToString();
                this.Controls.Add(DynBtns[i_of_clicked, j_of_clicked - 1]);
                this.Controls.Remove(DynBtns[i_of_clicked, j_of_clicked]);
            }
            else if ((i_of_clicked == MyInitConf.LoB.X) && (j_of_clicked == MyInitConf.LoB.Y - 1))  // Left Of B Ced
            {
                MyInitConf.LoB.Y = j_of_clicked;
                MyInitConf.NodeState[i_of_clicked, j_of_clicked + 1] = MyInitConf.NodeState[i_of_clicked, j_of_clicked];
                MyInitConf.NodeState[i_of_clicked, j_of_clicked] = 0;
                DynBtns[i_of_clicked, j_of_clicked].Text = "0";
                DynBtns[i_of_clicked, j_of_clicked + 1].Text = MyInitConf.NodeState[i_of_clicked, j_of_clicked + 1].ToString();
                this.Controls.Add(DynBtns[i_of_clicked, j_of_clicked + 1]);
                this.Controls.Remove(DynBtns[i_of_clicked, j_of_clicked]);
            }
        }

        private void btnSaveIt_Click(object sender, EventArgs e)        // Save the generated Initial Configuration
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
                    string DesiredOpStep = "N/A";           // Since we can generate any custom condition with many loops, we can not know probable optimal path
                    string Dtxt = "";
                    string Dtxt2 = "F";

                    Size = SizeOfPuzzle.ToString();

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
                    //Console.WriteLine("State: {0}",State);          // For debug (only debug mode)
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
                    // Finally save the XML file to the folder user specified
                    inventoryDoc.Save(SavingTool.FileName);
                }
            }
        }





    }
}
