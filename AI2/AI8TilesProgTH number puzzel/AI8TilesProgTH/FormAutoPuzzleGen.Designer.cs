namespace AI8TilesProgTH
{
    partial class FormAutoPuzzleGen
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
            this.cBoxBoardSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDTrueStepShuffle = new System.Windows.Forms.NumericUpDown();
            this.btnSaveStateAuto = new System.Windows.Forms.Button();
            this.btnGenerateInitialCondition = new System.Windows.Forms.Button();
            this.btnGenerateMonteCarloAlgorithmComparison = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrueStepShuffle)).BeginInit();
            this.SuspendLayout();
            // 
            // cBoxBoardSize
            // 
            this.cBoxBoardSize.FormattingEnabled = true;
            this.cBoxBoardSize.Items.AddRange(new object[] {
            "Board Size 3x3",
            "Board Size 4x4",
            "Board Size 5x5",
            "Board Size 6x6",
            "Board Size 7x7",
            "Board Size 8x8",
            "Board Size 9x9",
            "Board Size 10x10"});
            this.cBoxBoardSize.Location = new System.Drawing.Point(12, 12);
            this.cBoxBoardSize.Name = "cBoxBoardSize";
            this.cBoxBoardSize.Size = new System.Drawing.Size(172, 24);
            this.cBoxBoardSize.TabIndex = 6;
            this.cBoxBoardSize.TabStop = false;
            this.cBoxBoardSize.Text = "Choose Board Size";
            this.cBoxBoardSize.SelectedIndexChanged += new System.EventHandler(this.cBoxBoardSize_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Step d (Shuffle):";
            // 
            // nUDTrueStepShuffle
            // 
            this.nUDTrueStepShuffle.Enabled = false;
            this.nUDTrueStepShuffle.Location = new System.Drawing.Point(129, 42);
            this.nUDTrueStepShuffle.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDTrueStepShuffle.Name = "nUDTrueStepShuffle";
            this.nUDTrueStepShuffle.Size = new System.Drawing.Size(55, 22);
            this.nUDTrueStepShuffle.TabIndex = 4;
            this.nUDTrueStepShuffle.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDTrueStepShuffle.ValueChanged += new System.EventHandler(this.nUDTrueStepShuffle_ValueChanged);
            // 
            // btnSaveStateAuto
            // 
            this.btnSaveStateAuto.Enabled = false;
            this.btnSaveStateAuto.Location = new System.Drawing.Point(12, 111);
            this.btnSaveStateAuto.Name = "btnSaveStateAuto";
            this.btnSaveStateAuto.Size = new System.Drawing.Size(172, 35);
            this.btnSaveStateAuto.TabIndex = 8;
            this.btnSaveStateAuto.Text = "I Like It, Save Puzzle";
            this.btnSaveStateAuto.UseVisualStyleBackColor = true;
            this.btnSaveStateAuto.Click += new System.EventHandler(this.btnSaveStateAuto_Click);
            // 
            // btnGenerateInitialCondition
            // 
            this.btnGenerateInitialCondition.Enabled = false;
            this.btnGenerateInitialCondition.Location = new System.Drawing.Point(12, 70);
            this.btnGenerateInitialCondition.Name = "btnGenerateInitialCondition";
            this.btnGenerateInitialCondition.Size = new System.Drawing.Size(172, 35);
            this.btnGenerateInitialCondition.TabIndex = 9;
            this.btnGenerateInitialCondition.Text = "Generate New Puzzle";
            this.btnGenerateInitialCondition.UseVisualStyleBackColor = true;
            this.btnGenerateInitialCondition.Click += new System.EventHandler(this.btnGenerateInitialCondition_Click);
            // 
            // btnGenerateMonteCarloAlgorithmComparison
            // 
            this.btnGenerateMonteCarloAlgorithmComparison.Enabled = false;
            this.btnGenerateMonteCarloAlgorithmComparison.Location = new System.Drawing.Point(12, 152);
            this.btnGenerateMonteCarloAlgorithmComparison.Name = "btnGenerateMonteCarloAlgorithmComparison";
            this.btnGenerateMonteCarloAlgorithmComparison.Size = new System.Drawing.Size(172, 35);
            this.btnGenerateMonteCarloAlgorithmComparison.TabIndex = 10;
            this.btnGenerateMonteCarloAlgorithmComparison.Text = "Monte Carlo Generation";
            this.btnGenerateMonteCarloAlgorithmComparison.UseVisualStyleBackColor = true;
            this.btnGenerateMonteCarloAlgorithmComparison.Click += new System.EventHandler(this.btnGenerateMonteCarloAlgorithmComparison_Click);
            // 
            // FormAutoPuzzleGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 203);
            this.Controls.Add(this.btnGenerateMonteCarloAlgorithmComparison);
            this.Controls.Add(this.btnGenerateInitialCondition);
            this.Controls.Add(this.btnSaveStateAuto);
            this.Controls.Add(this.cBoxBoardSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nUDTrueStepShuffle);
            this.Name = "FormAutoPuzzleGen";
            this.Text = "Automatic Puzzle Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAutoPuzzleGen_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrueStepShuffle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxBoardSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDTrueStepShuffle;
        private System.Windows.Forms.Button btnSaveStateAuto;
        private System.Windows.Forms.Button btnGenerateInitialCondition;
        private System.Windows.Forms.Button btnGenerateMonteCarloAlgorithmComparison;
    }
}