namespace AI8TilesProgTH
{
    partial class FormMAINGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreatePuzzleForMe = new System.Windows.Forms.Button();
            this.btnHavePuzzleYourWay = new System.Windows.Forms.Button();
            this.btnLoadASavedPuzzle = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.rBtn1Manual = new System.Windows.Forms.RadioButton();
            this.rBtn2BFS = new System.Windows.Forms.RadioButton();
            this.rBtn3DFS = new System.Windows.Forms.RadioButton();
            this.rBtn4IDFS = new System.Windows.Forms.RadioButton();
            this.rBtn5AStarMisplaced = new System.Windows.Forms.RadioButton();
            this.rBtn6AStarManhattan = new System.Windows.Forms.RadioButton();
            this.btnMonteCarlo = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblSolTime = new System.Windows.Forms.Label();
            this.lblSolStep = new System.Windows.Forms.Label();
            this.lblExpNode = new System.Windows.Forms.Label();
            this.lblStoNode = new System.Windows.Forms.Label();
            this.btnBackStep = new System.Windows.Forms.Button();
            this.btnForwardStep = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStopSolver = new System.Windows.Forms.Button();
            this.btnStopMonteCarlo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreatePuzzleForMe
            // 
            this.btnCreatePuzzleForMe.Location = new System.Drawing.Point(9, 10);
            this.btnCreatePuzzleForMe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreatePuzzleForMe.Name = "btnCreatePuzzleForMe";
            this.btnCreatePuzzleForMe.Size = new System.Drawing.Size(141, 27);
            this.btnCreatePuzzleForMe.TabIndex = 4;
            this.btnCreatePuzzleForMe.Text = "Create Puzzle For Me";
            this.btnCreatePuzzleForMe.UseVisualStyleBackColor = true;
            this.btnCreatePuzzleForMe.Visible = false;
            this.btnCreatePuzzleForMe.Click += new System.EventHandler(this.btnCreatePuzzleForMe_Click);
            // 
            // btnHavePuzzleYourWay
            // 
            this.btnHavePuzzleYourWay.Location = new System.Drawing.Point(9, 41);
            this.btnHavePuzzleYourWay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHavePuzzleYourWay.Name = "btnHavePuzzleYourWay";
            this.btnHavePuzzleYourWay.Size = new System.Drawing.Size(141, 27);
            this.btnHavePuzzleYourWay.TabIndex = 5;
            this.btnHavePuzzleYourWay.Text = "Have Puzzle Your Way";
            this.btnHavePuzzleYourWay.UseVisualStyleBackColor = true;
            this.btnHavePuzzleYourWay.Click += new System.EventHandler(this.btnHavePuzzleYourWay_Click);
            // 
            // btnLoadASavedPuzzle
            // 
            this.btnLoadASavedPuzzle.Location = new System.Drawing.Point(9, 73);
            this.btnLoadASavedPuzzle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadASavedPuzzle.Name = "btnLoadASavedPuzzle";
            this.btnLoadASavedPuzzle.Size = new System.Drawing.Size(141, 27);
            this.btnLoadASavedPuzzle.TabIndex = 6;
            this.btnLoadASavedPuzzle.Text = "Load A Saved Puzzle";
            this.btnLoadASavedPuzzle.UseVisualStyleBackColor = true;
            this.btnLoadASavedPuzzle.Click += new System.EventHandler(this.btnLoadASavedPuzzle_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(9, 236);
            this.btnSolve.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(141, 27);
            this.btnSolve.TabIndex = 7;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // rBtn1Manual
            // 
            this.rBtn1Manual.AutoSize = true;
            this.rBtn1Manual.Checked = true;
            this.rBtn1Manual.Location = new System.Drawing.Point(14, 105);
            this.rBtn1Manual.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rBtn1Manual.Name = "rBtn1Manual";
            this.rBtn1Manual.Size = new System.Drawing.Size(81, 17);
            this.rBtn1Manual.TabIndex = 8;
            this.rBtn1Manual.TabStop = true;
            this.rBtn1Manual.Text = "I will solve it";
            this.rBtn1Manual.UseVisualStyleBackColor = true;
            this.rBtn1Manual.CheckedChanged += new System.EventHandler(this.rBtn1Manual_CheckedChanged);
            // 
            // rBtn2BFS
            // 
            this.rBtn2BFS.AutoSize = true;
            this.rBtn2BFS.Location = new System.Drawing.Point(14, 127);
            this.rBtn2BFS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rBtn2BFS.Name = "rBtn2BFS";
            this.rBtn2BFS.Size = new System.Drawing.Size(115, 17);
            this.rBtn2BFS.TabIndex = 9;
            this.rBtn2BFS.Text = "Breath First Search";
            this.rBtn2BFS.UseVisualStyleBackColor = true;
            this.rBtn2BFS.CheckedChanged += new System.EventHandler(this.rBtn2BFS_CheckedChanged);
            // 
            // rBtn3DFS
            // 
            this.rBtn3DFS.AutoSize = true;
            this.rBtn3DFS.Location = new System.Drawing.Point(14, 149);
            this.rBtn3DFS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rBtn3DFS.Name = "rBtn3DFS";
            this.rBtn3DFS.Size = new System.Drawing.Size(113, 17);
            this.rBtn3DFS.TabIndex = 10;
            this.rBtn3DFS.Text = "Depth First Search";
            this.rBtn3DFS.UseVisualStyleBackColor = true;
            this.rBtn3DFS.CheckedChanged += new System.EventHandler(this.rBtn3DFS_CheckedChanged);
            // 
            // rBtn4IDFS
            // 
            this.rBtn4IDFS.AutoSize = true;
            this.rBtn4IDFS.Location = new System.Drawing.Point(14, 171);
            this.rBtn4IDFS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rBtn4IDFS.Name = "rBtn4IDFS";
            this.rBtn4IDFS.Size = new System.Drawing.Size(87, 17);
            this.rBtn4IDFS.TabIndex = 11;
            this.rBtn4IDFS.Text = "Iterative DFS";
            this.rBtn4IDFS.UseVisualStyleBackColor = true;
            this.rBtn4IDFS.CheckedChanged += new System.EventHandler(this.rBtn4IDFS_CheckedChanged);
            // 
            // rBtn5AStarMisplaced
            // 
            this.rBtn5AStarMisplaced.AutoSize = true;
            this.rBtn5AStarMisplaced.Location = new System.Drawing.Point(14, 193);
            this.rBtn5AStarMisplaced.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rBtn5AStarMisplaced.Name = "rBtn5AStarMisplaced";
            this.rBtn5AStarMisplaced.Size = new System.Drawing.Size(134, 17);
            this.rBtn5AStarMisplaced.TabIndex = 12;
            this.rBtn5AStarMisplaced.Text = "A* Heuristic: Misplaced";
            this.rBtn5AStarMisplaced.UseVisualStyleBackColor = true;
            this.rBtn5AStarMisplaced.CheckedChanged += new System.EventHandler(this.rBtn5AStarMisplaced_CheckedChanged);
            // 
            // rBtn6AStarManhattan
            // 
            this.rBtn6AStarManhattan.AutoSize = true;
            this.rBtn6AStarManhattan.Location = new System.Drawing.Point(14, 214);
            this.rBtn6AStarManhattan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rBtn6AStarManhattan.Name = "rBtn6AStarManhattan";
            this.rBtn6AStarManhattan.Size = new System.Drawing.Size(137, 17);
            this.rBtn6AStarManhattan.TabIndex = 13;
            this.rBtn6AStarManhattan.Text = "A* Heuristic: Manhattan";
            this.rBtn6AStarManhattan.UseVisualStyleBackColor = true;
            this.rBtn6AStarManhattan.CheckedChanged += new System.EventHandler(this.rBtn6AStarManhattan_CheckedChanged);
            // 
            // btnMonteCarlo
            // 
            this.btnMonteCarlo.Location = new System.Drawing.Point(9, 268);
            this.btnMonteCarlo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMonteCarlo.Name = "btnMonteCarlo";
            this.btnMonteCarlo.Size = new System.Drawing.Size(141, 27);
            this.btnMonteCarlo.TabIndex = 14;
            this.btnMonteCarlo.Text = "Monte Carlo";
            this.btnMonteCarlo.UseVisualStyleBackColor = true;
            this.btnMonteCarlo.Visible = false;
            this.btnMonteCarlo.Click += new System.EventHandler(this.btnMonteCarlo_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(154, 10);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(149, 13);
            this.lblMsg.TabIndex = 15;
            this.lblMsg.Text = "Create or Load a Slider Puzzle";
            // 
            // lblSolTime
            // 
            this.lblSolTime.AutoSize = true;
            this.lblSolTime.Location = new System.Drawing.Point(154, 24);
            this.lblSolTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSolTime.Name = "lblSolTime";
            this.lblSolTime.Size = new System.Drawing.Size(96, 13);
            this.lblSolTime.TabIndex = 16;
            this.lblSolTime.Text = "Solution Time (ms):";
            // 
            // lblSolStep
            // 
            this.lblSolStep.AutoSize = true;
            this.lblSolStep.Location = new System.Drawing.Point(154, 37);
            this.lblSolStep.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSolStep.Name = "lblSolStep";
            this.lblSolStep.Size = new System.Drawing.Size(73, 13);
            this.lblSolStep.TabIndex = 17;
            this.lblSolStep.Text = "Solution Step:";
            // 
            // lblExpNode
            // 
            this.lblExpNode.AutoSize = true;
            this.lblExpNode.Location = new System.Drawing.Point(321, 37);
            this.lblExpNode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExpNode.Name = "lblExpNode";
            this.lblExpNode.Size = new System.Drawing.Size(92, 13);
            this.lblExpNode.TabIndex = 18;
            this.lblExpNode.Text = "Expanded Nodes:";
            // 
            // lblStoNode
            // 
            this.lblStoNode.AutoSize = true;
            this.lblStoNode.Location = new System.Drawing.Point(321, 24);
            this.lblStoNode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStoNode.Name = "lblStoNode";
            this.lblStoNode.Size = new System.Drawing.Size(75, 13);
            this.lblStoNode.TabIndex = 19;
            this.lblStoNode.Text = "Stored Nodes:";
            // 
            // btnBackStep
            // 
            this.btnBackStep.Enabled = false;
            this.btnBackStep.Location = new System.Drawing.Point(260, 54);
            this.btnBackStep.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBackStep.Name = "btnBackStep";
            this.btnBackStep.Size = new System.Drawing.Size(54, 28);
            this.btnBackStep.TabIndex = 20;
            this.btnBackStep.Text = "<===";
            this.btnBackStep.UseVisualStyleBackColor = true;
            this.btnBackStep.Click += new System.EventHandler(this.btnBackStep_Click);
            // 
            // btnForwardStep
            // 
            this.btnForwardStep.Enabled = false;
            this.btnForwardStep.Location = new System.Drawing.Point(319, 54);
            this.btnForwardStep.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnForwardStep.Name = "btnForwardStep";
            this.btnForwardStep.Size = new System.Drawing.Size(54, 28);
            this.btnForwardStep.TabIndex = 21;
            this.btnForwardStep.Text = "===>";
            this.btnForwardStep.UseVisualStyleBackColor = true;
            this.btnForwardStep.Click += new System.EventHandler(this.btnForwardStep_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(392, 54);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(54, 28);
            this.btnPlay.TabIndex = 22;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(450, 54);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(54, 28);
            this.btnPause.TabIndex = 22;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStopSolver
            // 
            this.btnStopSolver.Location = new System.Drawing.Point(158, 54);
            this.btnStopSolver.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStopSolver.Name = "btnStopSolver";
            this.btnStopSolver.Size = new System.Drawing.Size(86, 28);
            this.btnStopSolver.TabIndex = 22;
            this.btnStopSolver.Text = "Stop Solver";
            this.btnStopSolver.UseVisualStyleBackColor = true;
            this.btnStopSolver.Click += new System.EventHandler(this.btnStopSolver_Click);
            // 
            // btnStopMonteCarlo
            // 
            this.btnStopMonteCarlo.Location = new System.Drawing.Point(9, 300);
            this.btnStopMonteCarlo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStopMonteCarlo.Name = "btnStopMonteCarlo";
            this.btnStopMonteCarlo.Size = new System.Drawing.Size(141, 27);
            this.btnStopMonteCarlo.TabIndex = 23;
            this.btnStopMonteCarlo.Text = "Stop Monte Carlo";
            this.btnStopMonteCarlo.UseVisualStyleBackColor = true;
            this.btnStopMonteCarlo.Visible = false;
            this.btnStopMonteCarlo.Click += new System.EventHandler(this.btnStopMonteCarlo_Click);
            // 
            // FormMAINGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 336);
            this.Controls.Add(this.btnStopMonteCarlo);
            this.Controls.Add(this.btnStopSolver);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnForwardStep);
            this.Controls.Add(this.btnBackStep);
            this.Controls.Add(this.lblStoNode);
            this.Controls.Add(this.lblExpNode);
            this.Controls.Add(this.lblSolStep);
            this.Controls.Add(this.lblSolTime);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnMonteCarlo);
            this.Controls.Add(this.rBtn6AStarManhattan);
            this.Controls.Add(this.rBtn5AStarMisplaced);
            this.Controls.Add(this.rBtn4IDFS);
            this.Controls.Add(this.rBtn3DFS);
            this.Controls.Add(this.rBtn2BFS);
            this.Controls.Add(this.rBtn1Manual);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.btnLoadASavedPuzzle);
            this.Controls.Add(this.btnHavePuzzleYourWay);
            this.Controls.Add(this.btnCreatePuzzleForMe);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMAINGUI";
            this.Text = "Slider Puzzle Solution Analysis by MehMuTlu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMAINGUI_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreatePuzzleForMe;
        private System.Windows.Forms.Button btnHavePuzzleYourWay;
        private System.Windows.Forms.Button btnLoadASavedPuzzle;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.RadioButton rBtn1Manual;
        private System.Windows.Forms.RadioButton rBtn2BFS;
        private System.Windows.Forms.RadioButton rBtn3DFS;
        private System.Windows.Forms.RadioButton rBtn4IDFS;
        private System.Windows.Forms.RadioButton rBtn5AStarMisplaced;
        private System.Windows.Forms.RadioButton rBtn6AStarManhattan;
        private System.Windows.Forms.Button btnMonteCarlo;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblSolTime;
        private System.Windows.Forms.Label lblSolStep;
        private System.Windows.Forms.Label lblExpNode;
        private System.Windows.Forms.Label lblStoNode;
        private System.Windows.Forms.Button btnBackStep;
        private System.Windows.Forms.Button btnForwardStep;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStopSolver;
        private System.Windows.Forms.Button btnStopMonteCarlo;
    }
}

