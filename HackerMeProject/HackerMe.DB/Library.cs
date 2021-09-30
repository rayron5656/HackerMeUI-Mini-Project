using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HackerMe.DB
{
    static public class MyDB
    {
        static public List<Student> studentlist = new List<Student>();
        static public Course[] CourseList = new Course[5];
        static public Student SelectedStudent;
        static public Student DataGridStudent;

        static MyDB()
        {
            Course netcore = new Course(".NET Core", new Lecturer());
            CourseList[0] = netcore;
            Course OOP = new Course("OOP", new Lecturer());
            CourseList[1] = OOP;
            Course Core = new Course("Core", new Lecturer());
            CourseList[2] = Core;
            Course HTML = new Course("HTML", new Lecturer());
            CourseList[3] = HTML;
            Course CSS = new Course("CSS", new Lecturer());
            CourseList[4] = CSS;
        }

        static public bool IsValidIsraeliId(this string s)
        {
            int LastNumber = 0;
            int counter = 1;
            int FinallNumber = 0;
            int I10AndUp = 0;
            int Tens = 0;
            int Ones = 0;

            if (s.Length != 9)
            {
                
                return false;
            }
            else
            {
                foreach (var Ch in s)
                {
                    if (counter != 9)
                    {
                        if (counter % 2 == 1)
                        {

                            FinallNumber += int.Parse(Ch.ToString());

                        }
                        else
                        {
                            if (2 * int.Parse(Ch.ToString()) >= 10)
                            {
                                I10AndUp = 2 * int.Parse(Ch.ToString());
                                Ones = I10AndUp % 10;
                                Tens = (I10AndUp - Ones) / 10;

                                FinallNumber += Ones + Tens;

                            }
                            else
                            {
                                FinallNumber += 2 * int.Parse(Ch.ToString());
                            }
                        }
                        counter++;

                    }
                    else
                    {
                        LastNumber = int.Parse(Ch.ToString());
                    }
                }
                if ((LastNumber + FinallNumber) % 10 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        static public bool checkforstudentByID(string recID)
        {
            foreach (Student item in MyDB.studentlist)
            {
                if (recID == item.ID)
                {
                    return true;
                }
            }
            return false;
        }

        static public Student GetstudentById(string recID)
        {
            foreach (Student item in MyDB.studentlist)
            {
                if (recID == item.ID)
                {
                    return item;
                }
            }
            return null;
        }

        static public bool IsRealName(string Name)
        {
            var regex1 = new Regex(@"^(?<firstchar>[A-Z])((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-][A-Za-z])|(?<spaces> [A-Za-z]))*$");
            return regex1.IsMatch(Name);
        }

        static public bool IsValidEmail(string Email)
        {
            var regex10 = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex10.IsMatch(Email);
        }
        
        static public bool IsValidPhoneNumber(string Number)
        {
            var regex = new Regex(@"^\d{10}$");
            return regex.IsMatch(Number);

        }

        static public bool IsValidStudent(Student Stdnt2Check)
        {
            if (MyDB.IsRealName(Stdnt2Check.Firstname)&& MyDB.IsRealName(Stdnt2Check.Lastname) && MyDB.IsValidEmail(Stdnt2Check.Email) && MyDB.IsValidPhoneNumber(Stdnt2Check.PhoneNumber) && MyDB.IsValidIsraeliId(Stdnt2Check.ID))
            {
                return true;
            }
            return false;
        }

        

    }

    public class Student
    {
        public string ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int City { get; set; }
        public DateTime DOB { get; set; }

        public Student(string iD, string firstname, string lastname, string phoneNumber,string email , int city, DateTime dOB)
        {
            ID = iD;
            Firstname = firstname;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            City = city;
            DOB = dOB;
            Email = email;
        }
    }

    public class Lecturer
    {
        public string ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public int City { get; set; }
        public DateTime DOB { get; set; }
    }

    public class Course
    {
        public string name;
        public List<Student> Studentincourse = new List<Student>();
        public Lecturer Lecturer;
        public DateTime StartingDate { get; set; }
        public int NumberOfSessions { get; set; }

        public Course(string name, Lecturer lecturer)
        {
            this.name = name;
            
            Lecturer = lecturer;
        }




    }


}
