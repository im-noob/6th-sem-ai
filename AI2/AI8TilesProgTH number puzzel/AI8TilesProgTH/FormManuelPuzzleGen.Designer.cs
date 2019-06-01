namespace AI8TilesProgTH
{
    partial class FormManuelPuzzleGen
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
            this.cBoxBoardSizeMan = new System.Windows.Forms.ComboBox();
            this.btnSaveIt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cBoxBoardSizeMan
            // 
            this.cBoxBoardSizeMan.FormattingEnabled = true;
            this.cBoxBoardSizeMan.Items.AddRange(new object[] {
            "Board Size 3x3",
            "Board Size 4x4",
            "Board Size 5x5",
            "Board Size 6x6",
            "Board Size 7x7",
            "Board Size 8x8",
            "Board Size 9x9",
            "Board Size 10x10"});
            this.cBoxBoardSizeMan.Location = new System.Drawing.Point(12, 12);
            this.cBoxBoardSizeMan.Name = "cBoxBoardSizeMan";
            this.cBoxBoardSizeMan.Size = new System.Drawing.Size(172, 24);
            this.cBoxBoardSizeMan.TabIndex = 10;
            this.cBoxBoardSizeMan.TabStop = false;
            this.cBoxBoardSizeMan.Text = "Choose Board Size";
            this.cBoxBoardSizeMan.SelectedIndexChanged += new System.EventHandler(this.cBoxBoardSizeMan_SelectedIndexChanged);
            // 
            // btnSaveIt
            // 
            this.btnSaveIt.Location = new System.Drawing.Point(12, 42);
            this.btnSaveIt.Name = "btnSaveIt";
            this.btnSaveIt.Size = new System.Drawing.Size(172, 30);
            this.btnSaveIt.TabIndex = 12;
            this.btnSaveIt.Text = "I am Done, Save It";
            this.btnSaveIt.UseVisualStyleBackColor = true;
            this.btnSaveIt.Click += new System.EventHandler(this.btnSaveIt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "First, Chose Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Then, Press # Buttons :)";
            // 
            // FormManuelPuzzleGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 118);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveIt);
            this.Controls.Add(this.cBoxBoardSizeMan);
            this.Name = "FormManuelPuzzleGen";
            this.Text = "Manuel Puzzle Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxBoardSizeMan;
        private System.Windows.Forms.Button btnSaveIt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}