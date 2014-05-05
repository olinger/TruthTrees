using System;
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
        public TTNode focusNode;
        public TextBox focusedTextbox = null;
        public bool clicked = false;
        private bool specialKeyPressed = false;
        public int checkOffCount = 0;
        public List<CheckBox> checkboxes = new List<CheckBox>();
        public Form1()
        {
            InitializeComponent(); 
            foreach(TextBox tb in this.panel1.Controls.OfType<TextBox>())
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
            txtDown.Size = new System.Drawing.Size(80, 25);
            txtDown.GotFocus += textBox_Enter;
            txtDown.KeyPress += textBox_KeyPress;
            txtDown.Tag = "C";
            TTNode down = new TTNode(txtDown);
            if (!clicked)
            {
                down.x = 260;
                down.y = 50;
                parent = down;
                clicked = true;
                txtDown.Location = new System.Drawing.Point(parent.x, parent.y);
            }
            else if (focusedTextbox != null)
            {
                TTNode p = parent.find(focusedTextbox);

                down.parent = p;
                p.addChild(down);
                parent.reposition();
                txtDown.Location = new System.Drawing.Point(down.x, down.y);
                parent.drawLines();
                drawLines(p);
            }
            panel1.Controls.Add(txtDown);

            //create corresponding checkbox
            CheckBox chkDown = new CheckBox();
            chkDown.Location = new System.Drawing.Point(down.x + 87, down.y + 3);
            chkDown.Tag = down;
            chkDown.Size = new System.Drawing.Size(15, 15);
            // panel1.Controls.Add(chkDown);
            panel1.Controls.Add(txtDown);
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
            txtRight.Size = new System.Drawing.Size(80, 25);
            txtLeft.Size = new System.Drawing.Size(80, 25);
            txtRight.GotFocus += textBox_Enter;
            txtRight.KeyPress += textBox_KeyPress;
            txtLeft.GotFocus += textBox_Enter;
            txtLeft.KeyPress += textBox_KeyPress;
            txtRight.Tag = "R";
            txtLeft.Tag = "L";
            panel1.Controls.Add(txtRight);
            panel1.Controls.Add(txtLeft);

            TTNode left = new TTNode(txtLeft);
            TTNode right = new TTNode(txtRight);
            left.sibling = right;
            right.sibling = left;
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
            chkRight.Location = new System.Drawing.Point(right.x + 87, right.y + 3);
            chkLeft.Location = new System.Drawing.Point(left.x + 87, left.y + 3);
            chkLeft.Size = new System.Drawing.Size(10, 10);
            chkRight.Tag = right;
            chkLeft.Tag = left;
            chkRight.Size = new System.Drawing.Size(15, 15);
            chkLeft.Size = new System.Drawing.Size(15, 15);
            panel1.Controls.Add(chkRight);
            panel1.Controls.Add(chkLeft);

            right.cb = chkRight;
            left.cb = chkLeft;
            checkboxes.Add(chkRight);
            checkboxes.Add(chkLeft);
            focusedTextbox = txtRight;
        }


        private void drawLines(TTNode current)
        {
            ShapeContainer canvas = new ShapeContainer();
            foreach (LineShape line in current.linesToChildren)
            {
                canvas.Parent = panel1;
                line.Parent = canvas;
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
            if (e.KeyCode == Keys.D && e.Control)
            {
                specialKeyPressed = true;
                deleteNode_Click(sender, e);
            }
            if (e.KeyCode == Keys.D && e.Control && e.Shift)
            {
                specialKeyPressed = true;
                clearAll_Click(sender, e);
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
            ProcessInfo.UseShellExecute=false;
            ProcessInfo.RedirectStandardOutput=true;

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
            s = s.Replace("→", "->"); //->
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
                foreach (Label label in panel1.Controls.OfType<Label>())
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
                panel1.Controls.Add(verifyBranch);
            }
            else
            {
                Label incorrect = new Label();
                incorrect.Text = "failed"; 
                incorrect.Location = new System.Drawing.Point(checkedboxes[0].Location.X + 15, checkedboxes[0].Location.Y - 3);
                incorrect.ForeColor = Color.Red;
                Font font = new Font("Calibri", 10.0f, FontStyle.Bold);
                incorrect.Font = font;
                panel1.Controls.Add(incorrect);
            }
            foreach (CheckBox chk in panel1.Controls.OfType<CheckBox>())
            {
                chk.Checked = false;
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
            panel1.Controls.Add(closedBranch);
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
            panel1.Controls.Add(openBranch);
        }

        private void clearSelect_Click(object sender, EventArgs e)
        {
            foreach (CheckBox chk in checkboxes)
            {
                if (chk.Checked)
                    chk.Checked = false;
            }
        }

        private void delete(TTNode current)
        {
            if (current != null)
            {
                foreach (LineShape line in current.linesToChildren)
                {
                    line.Dispose();
                }
                current.linesToChildren.Clear();
                if(current.parent!=null)
                    current.parent.children.Clear();
                current.delete();
            }
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            if (parent != null)
            {
                parent.delete();
                parent = null;
            }
            checkboxes.Clear();
            foreach (LineShape line in this.panel1.Controls.OfType<LineShape>())
            {
                line.Parent.Dispose();
                line.Dispose();
            }
            clicked = false;
            foreach (Label lbl in this.panel1.Controls.OfType<Label>())
            {
                lbl.Dispose();
            }
        }

        private void deleteNode_Click(object sender, EventArgs e)
        {
            TTNode current = parent.find(focusedTextbox);
            
            if (current != null)
            {
                TTNode p = current.parent;
                current.delete();
                if (p != null)
                {
                    p.linesToChildren.Clear();
                    p.children.Clear();
                    p.drawLines();
                    drawLines(p);
                }
            }
            foreach (LineShape line in this.panel1.Controls.OfType<LineShape>())
            {
                line.Parent.Dispose();
                line.Dispose();
            }
            foreach (ShapeContainer shp in this.panel1.Controls.OfType<ShapeContainer>())
            {
                shp.Dispose();
            }
            checkboxes.Clear();

            foreach (CheckBox chk in this.panel1.Controls.OfType<CheckBox>())
            {
                checkboxes.Add(chk);
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

    }
}
