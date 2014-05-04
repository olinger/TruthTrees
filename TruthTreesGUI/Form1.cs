﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using System.Diagnostics; // Process
using System.IO; // StreamWriter


namespace TruthTreesGUI
{
    public partial class Form1 : Form
    {
        public TTNode parent;
        public TextBox focusedTextbox = null;
        public bool clicked = false;
        private bool specialKeyPressed = false;
        public int checkOffCount = 0;
        public List<CheckBox> checkboxes = new List<CheckBox>();
        public Form1()
        {
            InitializeComponent(); 
            foreach(TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.GotFocus += textBox_Enter;
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            focusedTextbox = (TextBox)sender;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (specialKeyPressed)
            {
                e.Handled = true;
                specialKeyPressed = false;
            }
        }

        int c = 0;
        Point location = new Point(0, 0);

        private void levelButton_Click(object sender, EventArgs e)
        {
            if (clicked && focusedTextbox == null)
                return;
            TextBox txtDown = new TextBox();
            txtDown.Name = "txtDown";
            txtDown.Size = new System.Drawing.Size(50, 25);
            txtDown.GotFocus += textBox_Enter;
            txtDown.KeyPress += textBox_KeyPress;
            txtDown.Tag = "C";
            TTNode down = new TTNode(txtDown);
            if (!clicked)
            {
                down.x = 230;
                down.y = 50;
                parent = down;
                clicked = true;
                txtDown.Location = new System.Drawing.Point(parent.x, parent.y);
            }
            if (focusedTextbox != null)
            {
                TTNode p = parent.find(focusedTextbox);

                down.parent = p;
                p.addChild(down);
                parent.reposition();
                txtDown.Location = new System.Drawing.Point(down.x, down.y);
                parent.drawLines();
                drawLines(p);
            }
            this.Controls.Add(txtDown);

            //create corresponding checkbox
            CheckBox chkDown = new CheckBox();
            chkDown.Location = new System.Drawing.Point(down.x + 60, down.y+3);
            chkDown.Tag = down;
            chkDown.Size = new System.Drawing.Size(15, 15);
            this.Controls.Add(chkDown);
            down.cb = chkDown;
            checkboxes.Add(chkDown);
            focusedTextbox = txtDown;
        }

        private void branchButton_Click(object sender, EventArgs e)
        {
            if (focusedTextbox == null)
                return;
            TextBox txtRight = new TextBox();
            TextBox txtLeft = new TextBox();
            txtLeft.Name = "txtLeft";
            txtRight.Name = "txtRight";
            txtRight.Size = new System.Drawing.Size(50, 25);
            txtLeft.Size = new System.Drawing.Size(50, 25);
            txtRight.GotFocus += textBox_Enter;
            txtRight.KeyPress += textBox_KeyPress;
            txtLeft.GotFocus += textBox_Enter;
            txtLeft.KeyPress += textBox_KeyPress;
            txtRight.Tag = "R";
            txtLeft.Tag = "L";
            this.Controls.Add(txtRight);
            this.Controls.Add(txtLeft);

            TTNode left = new TTNode(txtLeft);
            TTNode right = new TTNode(txtRight);

            if (focusedTextbox != null)
            {
                TTNode p = parent.find(focusedTextbox);
                left.parent = p;
                right.parent = p;
                p.addChild(left);
                p.addChild(right);
                p.reposition();
                txtRight.Location = new System.Drawing.Point(right.x, right.y);
                txtLeft.Location = new System.Drawing.Point(left.x, left.y);
                parent.drawLines();
                drawLines(p);
            }

            //create corresponding checkboxes
            CheckBox chkRight = new CheckBox();
            CheckBox chkLeft = new CheckBox();
            chkRight.Location = new System.Drawing.Point(right.x + 60, right.y+3);
            chkLeft.Location = new System.Drawing.Point(left.x + 60, left.y+3);
            chkLeft.Size = new System.Drawing.Size(10, 10);
            chkRight.Tag = right;
            chkLeft.Tag = left;
            chkRight.Size = new System.Drawing.Size(15, 15);
            chkLeft.Size = new System.Drawing.Size(15, 15);
            this.Controls.Add(chkRight);
            this.Controls.Add(chkLeft);
            right.cb = chkRight;
            left.cb = chkLeft;
            checkboxes.Add(chkRight);
            checkboxes.Add(chkLeft);
            focusedTextbox = txtRight;
        }

        private void drawLines(TTNode current)
        {
            ShapeContainer canvas = new ShapeContainer();
            foreach (Line line in current.linesToChildren)
            {
                LineShape theLine = new LineShape();
                // Set the form as the parent of the ShapeContainer.
                canvas.Parent = this;
                // Set the ShapeContainer as the parent of the LineShape.
                theLine.Parent = canvas;
                // Set the starting and ending coordinates for the line.
                theLine.StartPoint = new System.Drawing.Point(line.p1.X, line.p1.Y);
                theLine.EndPoint = new System.Drawing.Point(line.p2.X, line.p2.Y);
            }
            foreach (TTNode child in current.children)
            {
                drawLines(child);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void and_Click(object sender, EventArgs e)
        {
            focusedTextbox.Text += and.Text;
            focusedTextbox.Focus();
            focusedTextbox.Select(focusedTextbox.Text.Length, 0);
        }

        private void or_Click(object sender, EventArgs e)
        {
            focusedTextbox.Text += or.Text;
            focusedTextbox.Focus();
            focusedTextbox.Select(focusedTextbox.Text.Length, 0);
        }

        private void not_Click(object sender, EventArgs e)
        {
            focusedTextbox.Text += not.Text;
            focusedTextbox.Focus();
            focusedTextbox.Select(focusedTextbox.Text.Length, 0);
        }

        private void cond_Click(object sender, EventArgs e)
        {
            focusedTextbox.Text += cond.Text;
            focusedTextbox.Focus();
            focusedTextbox.Select(focusedTextbox.Text.Length, 0);
        }

        private void bicond_Click(object sender, EventArgs e)
        {
            focusedTextbox.Text += bicond.Text;
            focusedTextbox.Focus();
            focusedTextbox.Select(focusedTextbox.Text.Length, 0);
        }

        private void shiftFocus(string direction) //move through tree on keyboard arrow shortcut
        {
            TTNode current = parent.findByText(focusedTextbox.Text);
            TextBox newFocus = focusedTextbox;
            if (direction == "d")
            {
                /*
                TTNode nextSib = current.nextCenterSibling();
                if (nextSib != null)
                {
                    newFocus = nextSib.tb;
                }
                else
                {
                    if (current.hasChild())
                        newFocus = current.children[0].tb;
                }*/
                if (current.hasChild())
                    newFocus = current.children[0].tb;

            }
            else if (direction == "u")
            {
                /* TTNode prevSib = current.previousCenterSibling();
                 if (prevSib != null)
                 {
                     newFocus = prevSib.tb;
                 }
                 else
                 {
                     if(current.parent!=null)
                         newFocus = current.parent.tb;
                 }*/
            }
            else if (direction == "l")
            {
            }
            else if (direction == "r")
            {
            }
            newFocus.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) //all keyboard shorcuts
        {
            //symbol shortcuts
            if (e.KeyCode == Keys.D7 && e.Shift)
            {
                specialKeyPressed = true;
                and_Click(sender, e);
            }
            if (e.KeyCode == Keys.OemPipe && e.Shift)
            {
                specialKeyPressed = true;
                or_Click(sender, e);
            }
            if (e.KeyCode == Keys.Oemtilde && e.Shift)
            {
                specialKeyPressed = true;
                not_Click(sender, e);
            }
            if (e.KeyCode == Keys.D4 && e.Shift)
            {
                specialKeyPressed = true;
                cond_Click(sender, e);
            }
            if (e.KeyCode == Keys.D5 && e.Shift)
            {
                specialKeyPressed = true;
                bicond_Click(sender, e);
            }
            //button function shortcuts
            if (e.KeyCode == Keys.B && e.Control)
            {
                specialKeyPressed = true;
                branchButton_Click(sender, e);
            }
            if (e.KeyCode == Keys.A && e.Control)
            {
                specialKeyPressed = true;
                levelButton_Click(sender, e);
            }
            if (e.KeyCode == Keys.X && e.Control)
            {
                specialKeyPressed = true;
                closedButton_Click(sender, e);
            }
            if (e.KeyCode == Keys.O && e.Control)
            {
                specialKeyPressed = true;
                openButton_Click(sender, e);
            }
            if (e.KeyCode == Keys.V && e.Control)
            {
                specialKeyPressed = true;
                verifyButton_Click(sender, e);
            }
            //navigation shortcuts
            if (e.KeyCode == Keys.Down && e.Control)
            {
                shiftFocus("d");
            }
            if (e.KeyCode == Keys.Up && e.Control)
            {
                shiftFocus("u");
            }
            if (e.KeyCode == Keys.Left && e.Control)
            {
                shiftFocus("l");
            }
            if (e.KeyCode == Keys.Right && e.Control)
            {
                shiftFocus("r");
            }
        }

        private bool verifySentences(List<string> toVerify)
        {
            int ExitCode;
            ProcessStartInfo ProcessInfo;
            Process Process;
            ProcessInfo = new ProcessStartInfo();
            ProcessInfo.FileName = @"C:\Python27\python.exe";
            string args="";
            foreach(string x in toVerify)
            {
                args+=x+" ";
            }
            string path = @"verifyRule.py";
            args=path+ " " + args;
            Console.WriteLine(args);
            ProcessInfo.Arguments=args;
            ProcessInfo.CreateNoWindow=true;
            ProcessInfo.UseShellExecute=true;
            //ProcessInfo.RedirectStandardOutput=false;

            Process=Process.Start(ProcessInfo);
            Process.WaitForExit();
            ExitCode=Process.ExitCode;
            Process.Close();
            Console.WriteLine(ExitCode);
            if (ExitCode == 0)
            {
                Console.WriteLine("verified");
                return true;
            }
            Console.WriteLine("failed to verify");
            return false;
        }

        private string replaceSymbols(string s)
        {
            s = s.Replace('∧', '&');
            s = s.Replace('∨', '|');
            s = s.Replace('¬', '~');
            s = s.Replace('→', '$'); //->
            s = s.Replace('↔', '%'); //<-->
            return s;
        }

        private void verifyButton_Click(object sender, EventArgs e)
        {
            List<string> toVerify = new List<string>();
            List<CheckBox> checkedboxes = new List<CheckBox>();
            int ghettoCount = 0;
            string ruleType = "";
            foreach (CheckBox chk in checkboxes) 
            {
                if (chk.Checked)
                {
                    TTNode t = chk.Tag as TTNode;
                    if (t != null)
                    {
                        toVerify.Add(t.ToString());
                        if (ghettoCount == 1)
                        {
                            string type = t.tb.Tag.ToString();
                            if (type == "C")
                                ruleType = "D";
                            else
                                ruleType = "B";
                        }
                        ghettoCount++;
                    }
                    checkedboxes.Add(chk);
                }
            }
            toVerify.Add(ruleType);
            for(int i=0;i<toVerify.Count;i++)
            {
                toVerify[i] = replaceSymbols(toVerify[i]);
            }
            if (verifySentences(toVerify))
            {
                foreach (Label label in Controls.OfType<Label>())
                {
                    if (label.Text=="failed")
                    {
                        label.Dispose();
                    }
                }
                checkOffCount++;
                Label verifyBranch = new Label();
                verifyBranch.Text = "✓" + checkOffCount;
                verifyBranch.Location = new System.Drawing.Point(checkedboxes[0].Location.X + 15, checkedboxes[0].Location.Y - 3);
                verifyBranch.ForeColor = Color.Green;
                Font font = new Font("Calibri", 10.0f, FontStyle.Bold);
                verifyBranch.Font = font;
                this.Controls.Add(verifyBranch);
            }
            else
            {
                Label incorrect = new Label();
                incorrect.Text = "failed"; incorrect.Location = new System.Drawing.Point(checkedboxes[0].Location.X + 15, checkedboxes[0].Location.Y - 3);
                incorrect.ForeColor = Color.Red;
                Font font = new Font("Calibri", 10.0f, FontStyle.Bold);
                incorrect.Font = font;
                this.Controls.Add(incorrect);
                

            }
           
        }

        private void closedButton_Click(object sender, EventArgs e)
        {
            checkOffCount++;
            Label closedBranch = new Label();
            closedBranch.Text = "X"+checkOffCount;
            closedBranch.Location = new System.Drawing.Point(focusedTextbox.Location.X + 15, focusedTextbox.Location.Y + 25);
            closedBranch.ForeColor = Color.Red;
            Font font = new Font("Calibri", 10.0f, FontStyle.Bold);
            closedBranch.Font = font;
            this.Controls.Add(closedBranch);
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            checkOffCount++;
            Label openBranch = new Label();
            openBranch.Text = "O" + checkOffCount;
            openBranch.Location = new System.Drawing.Point(focusedTextbox.Location.X + 15, focusedTextbox.Location.Y + 25);
            openBranch.ForeColor = Color.Orange;
            Font font = new Font("Calibri", 10.0f, FontStyle.Bold);
            openBranch.Font = font;
            this.Controls.Add(openBranch);
        }

        private void clearSelect_Click(object sender, EventArgs e)
        {
            foreach (CheckBox chk in checkboxes)
            {
                if (chk.Checked)
                    chk.Checked = false;
            }
        }

        private void clearAll_Click(object sender, EventArgs e)
        {

        }

    }
}
