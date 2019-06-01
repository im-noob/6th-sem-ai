namespace Sliding_Puzzle
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lblAutor = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblRevision = new System.Windows.Forms.Label();
            this.lblRights = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.BackColor = System.Drawing.Color.Transparent;
            this.lblAutor.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutor.ForeColor = System.Drawing.Color.Orange;
            this.lblAutor.Location = new System.Drawing.Point(12, 56);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(230, 19);
            this.lblAutor.TabIndex = 5;
            this.lblAutor.Text = "Nombre del autor: Alberto Molero";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.BackColor = System.Drawing.Color.Transparent;
            this.lblCompany.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.Orange;
            this.lblCompany.Location = new System.Drawing.Point(12, 79);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(223, 19);
            this.lblCompany.TabIndex = 7;
            this.lblCompany.Text = "Nombre de la compañía: DX Soft";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.BackColor = System.Drawing.Color.Transparent;
            this.lblCountry.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.ForeColor = System.Drawing.Color.Orange;
            this.lblCountry.Location = new System.Drawing.Point(12, 102);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(120, 19);
            this.lblCountry.TabIndex = 8;
            this.lblCountry.Text = "España (Cataluña)";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Orange;
            this.lblVersion.Location = new System.Drawing.Point(12, 125);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(195, 19);
            this.lblVersion.TabIndex = 9;
            this.lblVersion.Text = "Versión del producto: v.Auto";
            // 
            // lblRevision
            // 
            this.lblRevision.AutoSize = true;
            this.lblRevision.BackColor = System.Drawing.Color.Transparent;
            this.lblRevision.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevision.ForeColor = System.Drawing.Color.Orange;
            this.lblRevision.Location = new System.Drawing.Point(12, 148);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(181, 19);
            this.lblRevision.TabIndex = 10;
            this.lblRevision.Text = "Fecha de la última revisión";
            // 
            // lblRights
            // 
            this.lblRights.AutoSize = true;
            this.lblRights.BackColor = System.Drawing.Color.Transparent;
            this.lblRights.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRights.ForeColor = System.Drawing.Color.Orange;
            this.lblRights.Location = new System.Drawing.Point(12, 171);
            this.lblRights.Name = "lblRights";
            this.lblRights.Size = new System.Drawing.Size(329, 19);
            this.lblRights.TabIndex = 11;
            this.lblRights.Text = "Todos los derechos reservados: Copyright © 2011";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(259, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "support@dxsoft.es";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(390, 256);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRights);
            this.Controls.Add(this.lblRevision);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblAutor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Acerca de Sliding Puzzle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblRevision;
        private System.Windows.Forms.Label lblRights;
        private System.Windows.Forms.Label label6;
    }
}