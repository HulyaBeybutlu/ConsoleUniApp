using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleFinalPro
{
    class Student
    {
        public int Id { get; private set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Exam> ExamList { get; set; }
        private static int stuId = 1;

        public Student(string FullName,string Email,string Phone)
        {
            this.FullName = FullName;
            this.Email = Email;
            this.Phone = Phone;
            Id = stuId;
            stuId++;
            ExamList = new List<Exam>();
        }
        
    }
}
