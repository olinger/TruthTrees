namespace TruthTreesGUI
{
    partial class Form1
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
            this.levelButton = new System.Windows.Forms.Button();
            this.branchButton = new System.Windows.Forms.Button();
            this.verifyButton = new System.Windows.Forms.Button();
            this.premiseButton = new System.Windows.Forms.Button();
            this.goalButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // levelButton
            // 
            this.levelButton.Location = new System.Drawing.Point(546, 34);
            this.levelButton.Name = "levelButton";
            this.levelButton.Size = new System.Drawing.Size(68, 25);
            this.levelButton.TabIndex = 1;
            this.levelButton.Text = "Level";
            this.levelButton.UseVisualStyleBackColor = true;
            this.levelButton.Click += new System.EventHandler(this.levelButton_Click);
            // 
            // branchButton
            // 
            this.branchButton.Location = new System.Drawing.Point(546, 65);
            this.branchButton.Name = "branchButton";
            this.branchButton.Size = new System.Drawing.Size(68, 25);
            this.branchButton.TabIndex = 2;
            this.branchButton.Text = "Branch";
            this.branchButton.UseVisualStyleBackColor = true;
            this.branchButton.Click += new System.EventHandler(this.branchButton_Click);
            // 
            // verifyButton
            // 
            this.verifyButton.Location = new System.Drawing.Point(546, 96);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(68, 25);
            this.verifyButton.TabIndex = 3;
            this.verifyButton.Text = "Verify";
            this.verifyButton.UseVisualStyleBackColor = true;
            // 
            // premiseButton
            // 
            this.premiseButton.Location = new System.Drawing.Point(546, 127);
            this.premiseButton.Name = "premiseButton";
            this.premiseButton.Size = new System.Drawing.Size(90, 25);
            this.premiseButton.TabIndex = 4;
            this.premiseButton.Text = "Add Premise";
            this.premiseButton.UseVisualStyleBackColor = true;
            // 
            // goalButton
            // 
            this.goalButton.Location = new System.Drawing.Point(546, 158);
            this.goalButton.Name = "goalButton";
            this.goalButton.Size = new System.Drawing.Size(90, 25);
            this.goalButton.TabIndex = 5;
            this.goalButton.Text = "Add Goal";
            this.goalButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(674, 507);
            this.Controls.Add(this.goalButton);
            this.Controls.Add(this.premiseButton);
            this.Controls.Add(this.verifyButton);
            this.Controls.Add(this.branchButton);
            this.Controls.Add(this.levelButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button levelButton;
        private System.Windows.Forms.Button branchButton;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.Button premiseButton;
        private System.Windows.Forms.Button goalButton;
    }
}

