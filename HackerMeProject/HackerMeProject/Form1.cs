using HackerMe.DB;
using HackerMe.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackerMeProject
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            
        }

        private void actionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control1 = new StudentControl();
            Welcomepanel.Controls.Clear();
            Welcomepanel.Controls.Add(control1);
            control1.Dock = DockStyle.Fill;
        }

        private void actionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var control2 = new LecturersControl();
            Welcomepanel.Controls.Clear();
            Welcomepanel.Controls.Add(control2);
            control2.Dock = DockStyle.Fill;
        }

        private void listsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control3 = new ListStudentControl();
            Welcomepanel.Controls.Clear();
            Welcomepanel.Controls.Add(control3);
            control3.Dock = DockStyle.Fill;
        }
    }
}
