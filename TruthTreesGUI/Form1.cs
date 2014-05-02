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

namespace TruthTreesGUI
{
    public partial class Form1 : Form
    {
        public TTNode parent;
        public TextBox focusedTextbox = null;
        public bool clicked = false;
        private bool specialKeyPressed = false;

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
            TextBox txtDown = new TextBox();
            txtDown.Name = "txtDown";
            txtDown.Size = new System.Drawing.Size(50, 25);
            txtDown.GotFocus += textBox_Enter;
            txtDown.KeyPress += textBox_KeyPress;
            txtDown.Tag = "C";
            TTNode down = new TTNode(txtDown);
            if (!clicked)
            {
                down.x = 220;
                down.y = 70;
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
            chkDown.Location = new System.Drawing.Point(down.x + 60, down.y);
            chkDown.Tag = down;
            this.Controls.Add(chkDown);
            down.cb = chkDown;
        }

        private void branchButton_Click(object sender, EventArgs e)
        {
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
            chkRight.Location = new System.Drawing.Point(right.x + 60, right.y);
            chkLeft.Location = new System.Drawing.Point(left.x + 60, left.y);
            chkRight.Tag = right;
            chkLeft.Tag = left;
            this.Controls.Add(chkRight);
            this.Controls.Add(chkLeft);
            left.cb = chkLeft;
            right.cb = chkRight;
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
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
            if (e.KeyCode == Keys.B && e.Control)
            {
                specialKeyPressed = true;
                branchButton_Click(sender, e);
            }
            if (e.KeyCode == Keys.L && e.Control)
            {
                specialKeyPressed = true;
                levelButton_Click(sender, e);
            }
        }

    }
}
