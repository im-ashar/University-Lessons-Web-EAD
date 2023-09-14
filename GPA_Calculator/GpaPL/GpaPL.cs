using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class GpaPL
    {
        List<GpaDTO> studentsList = new List<GpaDTO>();
        public int MainMenu()
        {
            Console.WriteLine("\n1---- Enter Student Data\n");
            Console.WriteLine("2---- Output Student Data\n");
            Console.WriteLine("3---- Exit\n");
            Console.Write("Please Select One Of The Above Options: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int sel = int.Parse(Console.ReadLine());
            Console.ResetColor();
            while (sel <= 0 || sel >= 4)
            {
                Console.WriteLine("***Wrong Input***\n");
                Console.WriteLine("*****Please Select Again*****");
                Console.ForegroundColor = ConsoleColor.Green;
                sel = int.Parse(Console.ReadLine());
                Console.ResetColor();
            }
            return sel;
        }

        public void EnterStudent()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n***Adding Student***\n");
            Console.ResetColor();
            Console.WriteLine("Enter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Roll Number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string rollNo = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Subject Title: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string subject = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("Marks: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int marks = 0;
            try
            {
                marks = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + "***Wrong Input***");
                Console.ResetColor();
            }
            Console.ResetColor();

            GpaDTO dto = new GpaDTO();

            dto.Name = name;
            dto.Marks = marks;
            dto.Subject = subject;
            dto.RollNo = rollNo;


            studentsList.Add(dto);
            GpaBLL bll = new GpaBLL();
            bll.MarksToGrade(studentsList);
        }


        public void DisplayStudent()
        {
            GpaBLL bll = new GpaBLL();
            List<GpaDTO> newList = bll.GradeToGpa();
            foreach (GpaDTO dto in newList)
            {
                Console.Write("Name: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{dto.Name}");
                Console.ResetColor();

                Console.Write("Roll Number: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{dto.RollNo}");
                Console.ResetColor();

                Console.Write("Subject: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{dto.Subject}");
                Console.ResetColor();

                Console.Write("GPA: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{dto.Gpa}");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("--------------------------------");
                Console.ResetColor();

            }
        }
    }
}
