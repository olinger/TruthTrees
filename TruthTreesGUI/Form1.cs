using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TruthTreesGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        int c = 0;
        private void levelButton_Click(object sender, EventArgs e)
        {
            int cY = 50 + 30 * c;
            TextBox txtRun = new TextBox();
            txtRun.Name = "txtDynamic" + c++;
            txtRun.Location = new System.Drawing.Point(150, cY);
            txtRun.Size = new System.Drawing.Size(50, 25);
            this.Controls.Add(txtRun);

        }
        private void branchButton_Click(object sender, EventArgs e)
        {
            int cY = 50 + 30 * c;
            c++;
            TextBox txtRight = new TextBox();
            TextBox txtLeft = new TextBox();
            txtLeft.Name = "txtLeft" + c;
            txtRight.Name = "txtRight" + c;
            txtRight.Location = new System.Drawing.Point(120, cY);
            txtRight.Size = new System.Drawing.Size(50, 25);
            txtLeft.Location = new System.Drawing.Point(175, cY);
            txtLeft.Size = new System.Drawing.Size(50, 25);
            this.Controls.Add(txtRight);
            this.Controls.Add(txtLeft);
        }
    }
}
