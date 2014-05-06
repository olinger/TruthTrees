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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.clearSelect = new System.Windows.Forms.Button();
            this.clearAll = new System.Windows.Forms.Button();
            this.deleteNode = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.premiseButton = new System.Windows.Forms.Button();
            this.verifyTreeButton = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // levelButton
            // 
            this.levelButton.Location = new System.Drawing.Point(194, 35);
            this.levelButton.Name = "levelButton";
            this.levelButton.Size = new System.Drawing.Size(68, 25);
            this.levelButton.TabIndex = 1;
            this.levelButton.Text = "Level";
            this.levelButton.UseVisualStyleBackColor = true;
            this.levelButton.Click += new System.EventHandler(this.levelButton_Click);
            // 
            // branchButton
            // 
            this.branchButton.Location = new System.Drawing.Point(268, 35);
            this.branchButton.Name = "branchButton";
            this.branchButton.Size = new System.Drawing.Size(68, 25);
            this.branchButton.TabIndex = 2;
            this.branchButton.Text = "Branch";
            this.branchButton.UseVisualStyleBackColor = true;
            this.branchButton.Click += new System.EventHandler(this.branchButton_Click);
            // 
            // verifyButton
            // 
            this.verifyButton.Location = new System.Drawing.Point(342, 35);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(68, 25);
            this.verifyButton.TabIndex = 3;
            this.verifyButton.Text = "Verify";
            this.verifyButton.UseVisualStyleBackColor = true;
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            // 
            // and
            // 
            this.and.Location = new System.Drawing.Point(589, 28);
            this.and.Name = "and";
            this.and.Size = new System.Drawing.Size(32, 32);
            this.and.TabIndex = 4;
            this.and.Text = "∧";
            this.and.UseVisualStyleBackColor = true;
            this.and.Click += new System.EventHandler(this.and_Click);
            // 
            // or
            // 
            this.or.Location = new System.Drawing.Point(627, 28);
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
            this.not.Location = new System.Drawing.Point(665, 28);
            this.not.Name = "not";
            this.not.Size = new System.Drawing.Size(32, 32);
            this.not.TabIndex = 6;
            this.not.Text = "¬";
            this.not.UseVisualStyleBackColor = true;
            this.not.Click += new System.EventHandler(this.not_Click);
            // 
            // cond
            // 
            this.cond.Location = new System.Drawing.Point(611, 66);
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
            this.bicond.Location = new System.Drawing.Point(649, 66);
            this.bicond.Name = "bicond";
            this.bicond.Size = new System.Drawing.Size(32, 32);
            this.bicond.TabIndex = 8;
            this.bicond.Text = "↔";
            this.bicond.UseVisualStyleBackColor = true;
            this.bicond.Click += new System.EventHandler(this.bicond_Click);
            // 
            // closedButton
            // 
            this.closedButton.Location = new System.Drawing.Point(416, 35);
            this.closedButton.Name = "closedButton";
            this.closedButton.Size = new System.Drawing.Size(68, 25);
            this.closedButton.TabIndex = 9;
            this.closedButton.Text = "Closed";
            this.closedButton.UseVisualStyleBackColor = true;
            this.closedButton.Click += new System.EventHandler(this.closedButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(490, 35);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(68, 25);
            this.openButton.TabIndex = 10;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // clearSelect
            // 
            this.clearSelect.Location = new System.Drawing.Point(130, 66);
            this.clearSelect.Name = "clearSelect";
            this.clearSelect.Size = new System.Drawing.Size(100, 25);
            this.clearSelect.TabIndex = 11;
            this.clearSelect.Text = "Clear Selection";
            this.clearSelect.UseVisualStyleBackColor = true;
            this.clearSelect.Click += new System.EventHandler(this.clearSelect_Click);
            // 
            // clearAll
            // 
            this.clearAll.Location = new System.Drawing.Point(342, 66);
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(100, 25);
            this.clearAll.TabIndex = 12;
            this.clearAll.Text = "Clear All";
            this.clearAll.UseVisualStyleBackColor = true;
            this.clearAll.Click += new System.EventHandler(this.clearAll_Click);
            // 
            // deleteNode
            // 
            this.deleteNode.Location = new System.Drawing.Point(236, 66);
            this.deleteNode.Name = "deleteNode";
            this.deleteNode.Size = new System.Drawing.Size(100, 25);
            this.deleteNode.TabIndex = 13;
            this.deleteNode.Text = "Delete";
            this.deleteNode.UseVisualStyleBackColor = true;
            this.deleteNode.Click += new System.EventHandler(this.deleteNode_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(900, 25);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(22, 104);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel1.Size = new System.Drawing.Size(856, 593);
            this.panel1.TabIndex = 15;
            // 
            // premiseButton
            // 
            this.premiseButton.Location = new System.Drawing.Point(120, 35);
            this.premiseButton.Name = "premiseButton";
            this.premiseButton.Size = new System.Drawing.Size(68, 25);
            this.premiseButton.TabIndex = 16;
            this.premiseButton.Text = "Premise";
            this.premiseButton.UseVisualStyleBackColor = true;
            this.premiseButton.Click += new System.EventHandler(this.premiseButton_Click);
            this.premiseButton.MouseHover += new System.EventHandler(this.premiseButton_MouseHover);
            // 
            // verifyTreeButton
            // 
            this.verifyTreeButton.Location = new System.Drawing.Point(448, 66);
            this.verifyTreeButton.Name = "verifyTreeButton";
            this.verifyTreeButton.Size = new System.Drawing.Size(100, 25);
            this.verifyTreeButton.TabIndex = 17;
            this.verifyTreeButton.Text = "Verify Tree";
            this.verifyTreeButton.UseVisualStyleBackColor = true;
            this.verifyTreeButton.Click += new System.EventHandler(this.verifyTreeButton_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(900, 723);
            this.Controls.Add(this.verifyTreeButton);
            this.Controls.Add(this.premiseButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.deleteNode);
            this.Controls.Add(this.clearAll);
            this.Controls.Add(this.clearSelect);
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
            this.Text = "Truth Trees";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button clearSelect;
        private System.Windows.Forms.Button clearAll;
        private System.Windows.Forms.Button deleteNode;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button premiseButton;
        private System.Windows.Forms.Button verifyTreeButton;
    }
}

