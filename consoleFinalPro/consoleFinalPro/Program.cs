using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleFinalPro
{
    class Program
    {
        static void Main(string[] args)
        {
            Group group = new Group();
            string userInput;
            int input;
            do
            {
                Console.WriteLine("Please, select one of the followings\n");
                Console.WriteLine("1.Add New Student");
                Console.WriteLine("2.Show Students and Add Exam");
                Console.WriteLine("3.Add New Exam");
                Console.WriteLine("4.Show Exams for Student");
                Console.WriteLine("5.Show Teachers");
                Console.WriteLine("6.Exit");
                Console.WriteLine(">>>>>>");
                userInput = Console.ReadLine();
                if (int.TryParse(userInput,out input))
                {
                    switch (input)
                    {
                        case 1:
                            group.AddStudent();
                            break;
                        case 2:
                            group.ShowStudent();
                            break;
                        case 3:
                            group.AddExam();
                            break;
                        case 4:
                            group.ShowExamsForStudent();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Warning: You can not enter a letter\n");
                }
            } while (userInput!="6");
        }
    }
}
