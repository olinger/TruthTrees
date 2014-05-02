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
            this.and = new System.Windows.Forms.Button();
            this.or = new System.Windows.Forms.Button();
            this.not = new System.Windows.Forms.Button();
            this.cond = new System.Windows.Forms.Button();
            this.bicond = new System.Windows.Forms.Button();
            this.closedButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
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
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            // 
            // and
            // 
            this.and.Location = new System.Drawing.Point(525, 192);
            this.and.Name = "and";
            this.and.Size = new System.Drawing.Size(32, 32);
            this.and.TabIndex = 4;
            this.and.Text = "∧";
            this.and.UseVisualStyleBackColor = true;
            this.and.Click += new System.EventHandler(this.and_Click);
            // 
            // or
            // 
            this.or.Location = new System.Drawing.Point(563, 192);
            this.or.Name = "or";
            this.or.Size = new System.Drawing.Size(32, 32);
            this.or.TabIndex = 5;
            this.or.Text = "∨";
            this.or.UseVisualStyleBackColor = true;
            this.or.Click += new System.EventHandler(this.or_Click);
            // 
            // not
            // 
            this.not.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.not.Location = new System.Drawing.Point(601, 192);
            this.not.Name = "not";
            this.not.Size = new System.Drawing.Size(32, 32);
            this.not.TabIndex = 6;
            this.not.Text = "¬";
            this.not.UseVisualStyleBackColor = true;
            this.not.Click += new System.EventHandler(this.not_Click);
            // 
            // cond
            // 
            this.cond.Location = new System.Drawing.Point(547, 230);
            this.cond.Name = "cond";
            this.cond.Size = new System.Drawing.Size(32, 32);
            this.cond.TabIndex = 7;
            this.cond.Text = "→";
            this.cond.UseVisualStyleBackColor = true;
            this.cond.Click += new System.EventHandler(this.cond_Click);
            // 
            // bicond
            // 
            this.bicond.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bicond.Location = new System.Drawing.Point(585, 230);
            this.bicond.Name = "bicond";
            this.bicond.Size = new System.Drawing.Size(32, 32);
            this.bicond.TabIndex = 8;
            this.bicond.Text = "↔";
            this.bicond.UseVisualStyleBackColor = true;
            this.bicond.Click += new System.EventHandler(this.bicond_Click);
            // 
            // closedButton
            // 
            this.closedButton.Location = new System.Drawing.Point(546, 127);
            this.closedButton.Name = "closedButton";
            this.closedButton.Size = new System.Drawing.Size(68, 25);
            this.closedButton.TabIndex = 9;
            this.closedButton.Text = "Closed";
            this.closedButton.UseVisualStyleBackColor = true;
            this.closedButton.Click += new System.EventHandler(this.closedButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(546, 158);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(68, 25);
            this.openButton.TabIndex = 10;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(674, 507);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.closedButton);
            this.Controls.Add(this.bicond);
            this.Controls.Add(this.cond);
            this.Controls.Add(this.not);
            this.Controls.Add(this.or);
            this.Controls.Add(this.and);
            this.Controls.Add(this.verifyButton);
            this.Controls.Add(this.branchButton);
            this.Controls.Add(this.levelButton);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button levelButton;
        private System.Windows.Forms.Button branchButton;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.Button and;
        private System.Windows.Forms.Button or;
        private System.Windows.Forms.Button not;
        private System.Windows.Forms.Button cond;
        private System.Windows.Forms.Button bicond;
        private System.Windows.Forms.Button closedButton;
        private System.Windows.Forms.Button openButton;
    }
}

