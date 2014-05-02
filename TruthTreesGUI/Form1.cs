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

namespace TruthTreesGUI
{
    public partial class Form1 : Form
    {
        public TTNode parent;
        public TextBox focusedTextbox = null;
        public bool clicked = false;
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

        int c = 0;
        Point location = new Point(0, 0);

        private void levelButton_Click(object sender, EventArgs e)
        {
            TextBox txtDown = new TextBox();
            txtDown.Name = "txtDown";
            txtDown.Size = new System.Drawing.Size(50, 25);
            txtDown.GotFocus += textBox_Enter;
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
            txtLeft.GotFocus += textBox_Enter;
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


    }
}
