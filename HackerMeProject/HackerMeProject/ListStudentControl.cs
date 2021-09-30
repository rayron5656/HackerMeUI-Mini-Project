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
    public partial class ListStudentControl : UserControl
    {
        static public List<Student> ListTOdisplay = new List<Student>();

        public ListStudentControl()
        {
            InitializeComponent();
        }

        private void ListStudentControl_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MyDB.studentlist;
        }

        private void Filterbutton_Click(object sender, EventArgs e)
        {
            bool B = true;

            dataGridView1.DataSource = null;
            ListTOdisplay.Clear();

            for (int i = 0; i < 5; i++)
            {
                if (FilterListBox.GetItemChecked(i))
                {
                    foreach (Student stdnt in MyDB.CourseList[i].Studentincourse)
                    {
                        if (!ListTOdisplay.Contains(stdnt))
                        {
                            ListTOdisplay.Add(stdnt);
                        }
                    }
                    B = false;
                }
            }

            if (B)
            {
                dataGridView1.DataSource = MyDB.studentlist;
            }
            else if (ListTOdisplay.Count > 0)
            {
                dataGridView1.DataSource = ListTOdisplay;
                
            }
            else
            {
                dataGridView1.DataSource = null;
            }

           




        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MyDB.DataGridStudent = (Student)dataGridView1.CurrentRow.DataBoundItem;

            var control1 = new StudentControl();
            control1.B = true;

            Form.ActiveForm.ActiveControl.Controls.Clear();
            Form.ActiveForm.ActiveControl.Controls.Add(control1);
            
        }
    }
}
