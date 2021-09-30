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
    public partial class StudentControl : UserControl
    {
         public bool B;

        public StudentControl()
        {
            InitializeComponent();
            toolStripButton2.Enabled = false;
            toolStripButton4.Enabled = false;
            
        }

        

        private void toolStripButton3_Click(string ID) // searchById Method
        {
            MyDB.SelectedStudent = null;
            SearchByIDtoolStripTextBox.Text = ID;
            toolStripButton2.Enabled = false;
            toolStripButton4.Enabled = false;


            if (SearchByIDtoolStripTextBox.Text != "" || SearchByIDtoolStripTextBox.Text != null)
            {
                if (MyDB.checkforstudentByID(SearchByIDtoolStripTextBox.Text))
                {

                    Student StudentSearched = MyDB.GetstudentById(SearchByIDtoolStripTextBox.Text);
                    IDtextBox.Text = StudentSearched.ID;
                    FirstNametextBox.Text = StudentSearched.Firstname;
                    LastNametextBox.Text = StudentSearched.Lastname;
                    PhonetextBox.Text = StudentSearched.PhoneNumber;
                    EmailtextBox.Text = StudentSearched.Email;
                    CitycomboBox.SelectedIndex = StudentSearched.City;
                    DOBdateTimePicker.Value = StudentSearched.DOB;

                    for (int i = 0; i < 5; i++)
                    {
                        if (MyDB.CourseList[i].Studentincourse.Contains(StudentSearched))
                        {
                            CoursecheckedListBox.SetItemChecked(i, true);
                        }
                    }

                    MyDB.SelectedStudent = StudentSearched;
                    toolStripButton2.Enabled = true;
                    toolStripButton4.Enabled = true;

                    StatusLabel.ForeColor = Color.Green;
                    StatusLabel.Text = "Done";

                }
                else
                {
                    StatusLabel.ForeColor = Color.Red;
                    StatusLabel.Text = "No Student Found";
                }

            }
            else
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "No Student Found";
            }
       
    }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e) //add student
        {
            Student studentOadd = new Student(IDtextBox.Text, FirstNametextBox.Text, LastNametextBox.Text, PhonetextBox.Text, EmailtextBox.Text, CitycomboBox.SelectedIndex, DOBdateTimePicker.Value);
            if (MyDB.IsValidStudent(studentOadd))
            {
                if (MyDB.checkforstudentByID(IDtextBox.Text))
                {
                    IDErrorLabel.Text = "Student is already in the system";
                }
                else
                {
                    
                    MyDB.studentlist.Add(studentOadd);

                    for (int i = 0; i < 5; i++)
                    {
                        if (CoursecheckedListBox.GetItemChecked(i))
                        {
                            MyDB.CourseList[i].Studentincourse.Add(studentOadd);
                        }
                    }
                    IDErrorLabel.Text = "";
                    FirstNameErrorLabel.Text = "";
                    LastNameErrorLabel.Text = "";
                    PhoneErrorLabel.Text = "";
                    EmailErrorLabel.Text = "";

                    IDtextBox.Text = "";
                    FirstNametextBox.Text = "";
                    LastNametextBox.Text = "";
                    PhonetextBox.Text = "";
                    EmailtextBox.Text = "";

                    for (int i = 0; i < 5; i++)
                    {
                        CoursecheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
                    }

                    CitycomboBox.SelectedIndex = -1;
                    DOBdateTimePicker.Value = DateTime.Now;

                    
                    StatusLabel.ForeColor = Color.Green;
                    StatusLabel.Text = "Student Added";
                }
            }
            else
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "Add Failed";
                if (!MyDB.IsValidIsraeliId(studentOadd.ID))
                {
                    IDErrorLabel.Text = "invalid ID";
                }
                else
                {
                    IDErrorLabel.Text = "";
                }
                if (!MyDB.IsRealName(studentOadd.Firstname))
                {
                    FirstNameErrorLabel.Text = "Invalid First Name";

                }
                else
                {
                    FirstNameErrorLabel.Text = "";
                }
                if (!MyDB.IsRealName(studentOadd.Lastname))
                {
                    LastNameErrorLabel.Text = "invalid Last Name";
                }
                else
                {
                    LastNameErrorLabel.Text = "";
                }
                if (!MyDB.IsValidPhoneNumber(studentOadd.PhoneNumber))
                {
                    PhoneErrorLabel.Text = "invalid Phone Number";
                }
                else
                {
                    PhoneErrorLabel.Text = "";
                }
                if (!MyDB.IsValidEmail(studentOadd.Email))
                {
                    EmailErrorLabel.Text = "Invalid Email";
                }
                else
                {
                    EmailErrorLabel.Text = "";
                }
            }

        }

        private void IDtextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e) // search by id
        {
            MyDB.SelectedStudent = null;
            toolStripButton2.Enabled = false;
            toolStripButton4.Enabled = false;


            if (SearchByIDtoolStripTextBox.Text != "" || SearchByIDtoolStripTextBox.Text != null)
            {
                if (MyDB.checkforstudentByID(SearchByIDtoolStripTextBox.Text))
                {

                Student StudentSearched = MyDB.GetstudentById(SearchByIDtoolStripTextBox.Text);
                IDtextBox.Text = StudentSearched.ID;
                FirstNametextBox.Text = StudentSearched.Firstname;
                LastNametextBox.Text = StudentSearched.Lastname;
                PhonetextBox.Text = StudentSearched.PhoneNumber;
                EmailtextBox.Text = StudentSearched.Email;
                CitycomboBox.SelectedIndex = StudentSearched.City;
                DOBdateTimePicker.Value = StudentSearched.DOB;

                    for (int i = 0; i < 5; i++)
                    {
                        if (MyDB.CourseList[i].Studentincourse.Contains(StudentSearched))
                        {
                            CoursecheckedListBox.SetItemChecked(i, true);
                        }
                    }

                MyDB.SelectedStudent = StudentSearched;
                    toolStripButton2.Enabled = true;
                    toolStripButton4.Enabled = true;

                    StatusLabel.ForeColor = Color.Green;
                    StatusLabel.Text = "Done";

                }
                else
                {
                    StatusLabel.ForeColor = Color.Red;
                    StatusLabel.Text = "No Student Found";
                }

            }
            else
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "No Student Found";
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e) // Delete
        {

            if (MyDB.SelectedStudent != null)
            {
                Areyousureform areyou = new Areyousureform();

                DialogResult dialogresult = areyou.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                
                        MyDB.studentlist.Remove(MyDB.SelectedStudent);
                        for (int i = 0; i < 5; i++)
                        {
                            if (MyDB.CourseList[i].Studentincourse.Contains(MyDB.SelectedStudent))
                            {
                                MyDB.CourseList[i].Studentincourse.Remove(MyDB.SelectedStudent);
                            }
                        }

                        IDtextBox.Text = "";
                        FirstNametextBox.Text = "";
                        LastNametextBox.Text = "";
                        PhonetextBox.Text = "";
                        EmailtextBox.Text = "";
                        CitycomboBox.SelectedIndex = -1;
                        DOBdateTimePicker.Value = DateTime.Now;
                        for (int i = 0; i < 5; i++)
                        {
                            CoursecheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
                        }

                    StatusLabel.ForeColor = Color.Green;
                    StatusLabel.Text = "Student Deleted";

                    MyDB.SelectedStudent = null;
                    toolStripButton2.Enabled = false;
                    toolStripButton4.Enabled = false;



                }
                else if (dialogresult == DialogResult.Cancel)
                {
                
                }
                areyou.Dispose();
            }
            else
            {

            }



        }

        private void toolStripButton4_Click(object sender, EventArgs e) // save changes
        {
            if (MyDB.SelectedStudent != null)
            {
                StatusLabel.Text = "";
                if (MyDB.IsRealName(FirstNametextBox.Text))
                {
                    MyDB.SelectedStudent.Firstname = FirstNametextBox.Text;
                    FirstNameErrorLabel.Text = "";
                }
                else
                {
                    FirstNameErrorLabel.Text = "Invalid First Name";
                }
                if (MyDB.IsRealName(LastNametextBox.Text))
                {
                    MyDB.SelectedStudent.Lastname = LastNametextBox.Text;
                    LastNameErrorLabel.Text = "";
                }
                else
                {
                    LastNameErrorLabel.Text = "Invalid Last Name";
                }
                if (MyDB.IsValidEmail(EmailtextBox.Text))
                {
                    MyDB.SelectedStudent.Email = EmailtextBox.Text;
                    EmailErrorLabel.Text = "";
                }
                else
                {
                    EmailErrorLabel.Text = "Invalid Email";
                }
                if (CitycomboBox.SelectedIndex != -1)
                {
                    MyDB.SelectedStudent.City = CitycomboBox.SelectedIndex;
                    CityErrorLabel.Text = "";
                }
                else
                {
                    CityErrorLabel.Text = "Please Choose a city";
                }
                for (int i = 0; i < 5; i++)
                {
                    if (CoursecheckedListBox.GetItemChecked(i))
                    {
                        if (!MyDB.CourseList[i].Studentincourse.Contains(MyDB.SelectedStudent))
                        {
                            MyDB.CourseList[i].Studentincourse.Add(MyDB.SelectedStudent);
                        }
                    }
                }
                StatusLabel.ForeColor = Color.Green;
                StatusLabel.Text = "student updated";

                IDtextBox.Text = "";
                FirstNametextBox.Text = "";
                LastNametextBox.Text = "";
                PhonetextBox.Text = "";
                EmailtextBox.Text = "";
                CitycomboBox.SelectedIndex = -1;
                DOBdateTimePicker.Value = DateTime.Now;
                for (int i = 0; i < 5; i++)
                {
                    CoursecheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
                }

                

                MyDB.SelectedStudent = null;
                toolStripButton2.Enabled = false;
                toolStripButton4.Enabled = false;


            }
            else
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "No student selected";
            }
        }

        private void StudentControl_Load(object sender, EventArgs e)
        {
            if (B)
            {
                toolStripButton3_Click(MyDB.DataGridStudent.ID);
                B = false;
            }
        }
    }
}
