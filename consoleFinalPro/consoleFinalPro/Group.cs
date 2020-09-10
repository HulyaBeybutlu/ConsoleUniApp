using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleFinalPro
{
    class Group
    {
        public List<Student> StudentList;
        public List<Exam> Exams;

        public Group()
        {
            StudentList = new List<Student>();
            Exams = new List<Exam>();
            Exam html = new Exam("Html", new DateTime(2020, 05, 06));
            Exam css = new Exam("Css", new DateTime(2020, 03, 11));
            Exam js = new Exam("Javascript", new DateTime(2020, 07, 09));
            Exam design = new Exam("Design", new DateTime(2020, 12, 16));
            Exams.Add(html);
            Exams.Add(css);
            Exams.Add(js);
            Exams.Add(design);
        }
        public void AddStudent()
        {
            Console.Write("Please, write student's name:");
            string name = Console.ReadLine();
            Console.Write("Write student's Email: ");
            string email=Console.ReadLine();
            Console.Write("Write phone number: ");
            string phone=Console.ReadLine();
            if (name.Length > 2)
            {
                Student stu = new Student(name, email, phone);
                StudentList.Add(stu);
                Console.WriteLine("\nStudent added succesfully");
                /*if (email.Contains("@"))
                {
                  
                }*/
            }
        }

        public void ShowStudent()
        {
            if (StudentList.Count > 0)
            {
                Student selectedStudent = null;
                foreach (Student stu in StudentList)
                {
                    Console.WriteLine("Id: {0}, Name: {1}, Email: {2}, Phone number: {3}", stu.Id, stu.FullName, stu.Email,stu.Phone);
                }
            Start:
                Console.Write("Please, Select student by Id: ");
                string stuId = Console.ReadLine();
                int id;
                if (int.TryParse(stuId, out id))
                {
                    bool correctId = false;
                    foreach (Student stu in StudentList)
                    {
                        if (stu.Id==id)
                        {
                            correctId = true;
                            selectedStudent = stu;
                            break;
                        }
                    }
                    if (correctId)
                    {
                        Console.WriteLine("Your,selected student's name: {0}\n",selectedStudent.FullName);
                        ShowExams(selectedStudent);
                    }
                    else
                    {
                        Console.WriteLine("\nWarning: This id doesn't exist there. Please, select a valid id...");
                        goto Start;
                    }
                }
                else
                {
                    Console.WriteLine("You can not enter a letter");
                    goto Start;
                }
               
            }
            else
            {
                Console.WriteLine("\nStudent not found");
            }
        }

        public void ShowExams(Student selectedStu)
        {
            Exam SelectedExam = null;
            foreach (Exam ex in Exams)
            {
                Console.WriteLine("Exam name: {0}, Exam date: {1}",ex.ExamName,ex.Date);
            }
        Start:
            Console.Write("Please, select exam by name: ");
            string examName = Console.ReadLine();
            bool correctName = false;
            foreach (Exam ex in Exams)
            {
                if (ex.ExamName==examName)
                {
                    correctName = true;
                    SelectedExam = ex;
                    break;
                }
            }
            if (correctName)
            {
                Console.WriteLine("Exam's name: {0} was added to Student's name: {1}\n",SelectedExam.ExamName,selectedStu.FullName);
                selectedStu.ExamList.Add(SelectedExam);
            }
            else
            {
                Console.WriteLine("\nWarning: This exam doesn't exist there. Please, select a valid name...");
                goto Start;
            }
        }

        public void AddExam()
        {
            Console.WriteLine("*************");
            Console.Write("Please, write exam name: ");
            string exname = Console.ReadLine();
            if (!string.IsNullOrEmpty(exname))
            {
                Exam exm = new Exam(exname, DateTime.Now);
                Exams.Add(exm);
                Console.WriteLine("Exam name was added succesfully");
                foreach (var ex in Exams)
                {
                    Console.WriteLine("Exam name: {0}, Exam date: {1}",ex.ExamName,ex.Date);
                }
            }
            else
            {
                Console.Write("Please, fill exam name: ");
            }
        }
        public void ShowExamsForStudent()
        {
            Exam SelectedExam = null;
            foreach (Exam ex in Exams)
            {
                Console.WriteLine("Exam name: {0}, Exam date: {1}", ex.ExamName, ex.Date);
            }
        Start:
            Console.Write("Please, select exam by name: ");
            string examName = Console.ReadLine();
            bool correctName = false;
            foreach (Exam ex in Exams)
            {
                if(ex.ExamName==examName)
                {
                    correctName = true;
                    SelectedExam = ex;
                    break;
                }
            }
            if (correctName)
            {
                Console.WriteLine("Student's name for exam's name: {0}\n",SelectedExam.ExamName);
                foreach (Student stu in StudentList)
                {
                    if (stu.ExamList.Count==0)
                    {
                        Console.WriteLine("\nWarning: Selected student was not found in any exam...");
                        break;
                    }
                    else if(stu.ExamList.Contains(SelectedExam))
                    {
                        Console.WriteLine("Student id: {0}, Student name: {1}",stu.Id, stu.FullName);
                    }
                }
            }
            else
            {
                Console.WriteLine("\nWarning: Please, select a valid exam name: ");
                goto Start;
            }
        }

    }
}

