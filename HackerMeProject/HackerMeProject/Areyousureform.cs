using HackerMe.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackerMe.UI
{
    public partial class Areyousureform : Form
    {
        public Areyousureform()
        {
            InitializeComponent();
            
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            
        }

        private void Areyousureform_Load(object sender, EventArgs e)
        {
            IDlabelAreyou.Text = MyDB.SelectedStudent.ID;
            NamelabelAreyou.Text = MyDB.SelectedStudent.Firstname + " " + MyDB.SelectedStudent.Lastname;
           
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
