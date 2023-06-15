using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
    internal class Program
    {
        static List<Student> Students = new List<Student>(); //tüm metotlar tek listeyle çalışmalı
        static void Main(string[] args)
        {
            InputFakeData();
            Application();
        }
        static void Application()
        {

            Menu();
            while (true) // creating a while true loop to make an infinite loop 
            {
                string choice = GetChoice();
                switch (choice)
                {
                    case "1":
                    case "E":
                        AddStudent(); break;
                    case "2":
                    case "L":
                        ListStudent(); break;
                    case "3":
                    case "S":
                        DeleteStudent(); break;
                    case "4":
                    case "X":
                        Exit();
                        //or you can use Environment.Exit(0) as well.                      
                        break;
                }
            }
        }
        static string GetChoice()
        {

          

            string input;
            string characters = "1234ELSX";
            int counter = 0;
            while (true)
            {
                counter++;
                Console.Write("Your choice: ");
                input = Console.ReadLine().ToUpper();
                if (characters.IndexOf(input) > -1 && input.Length == 1)
                {
                    return input;
                }
                else if (counter == 10)
                {
                    Console.WriteLine("Sorry, I cannot understand you. Program is terminated.");
                    Environment.Exit(0);
                }
                Console.WriteLine("Your input is incorrect, please try again.");
            }

        }
        static void Menu()
        {
            Console.WriteLine("Student Management System");
            Console.WriteLine();
            Console.WriteLine("1 - Add Student(E)       ");
            Console.WriteLine("2 - List Student(L)    ");
            Console.WriteLine("3 - Delete Student(S)        ");
            Console.WriteLine("4 - Exit(X)              ");
            Console.WriteLine();
        }
        static void InputFakeData()
        {
            Student o1 = new Student();
            o1.Name = "Elif";
            o1.Surname = "Acar";
            o1.Branch = "A";
            o1.No = 125;

            Student o2 = new Student();
            o2.Name = "Gamze";
            o2.Surname = "Başarır";
            o2.Branch = "B";
            o2.No = 225;

            Student o3 = new Student();
            o3.Name = "Cansu";
            o3.Surname = "Kaftan";
            o3.Branch = "C";
            o3.No = 325;

            Students.Add(o1);
            Students.Add(o2);
            Students.Add(o3);

        }
        static void ListStudent()
        {
            Console.WriteLine("2 - List Student---------- ");
            Console.WriteLine();

            if (Students.Count == 0)
            {
                Console.WriteLine("There are no students to be displayed.");
            }
            else
            {
                Console.WriteLine("Branch    No        Name       Surname   ");
                Console.WriteLine("----------------------------------");

                foreach (Student o in Students)
                {

                    Console.WriteLine(o.Branch.PadRight(8) + +o.No + o.Name.PadLeft(10) + o.Surname.PadLeft(11));
                }
            }
        }
        static void AddStudent()
        {

            Student o = new Student();
            Console.WriteLine("1 - Add Student----------  ");
            Console.WriteLine((Students.Count + 1) + ". Student ");



            Console.Write("Name: ");
            o.Name = Console.ReadLine().ToLower().Trim();
            o.Name = o.Name.Substring(0, 1).ToUpper() + o.Name.Substring(1);

            Console.Write("Surname: ");
            o.Surname = Console.ReadLine().ToLower().Trim();
            o.Surname = o.Surname.Substring(0, 1).ToUpper() + o.Surname.Substring(1);

            Console.Write("Branch: ");
            o.Branch = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Are you sure that you want to save the data? (Y / N) ");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                Students.Add(o);
                Console.WriteLine("Student has been saved. ");
            }
            else if (input == "n")
            {
                Console.WriteLine("Student has not been saved.");
            }
            else
            {
                Console.WriteLine("Please enter a valid input.");


            }
        }
        static void DeleteStudent()
        {
            Console.WriteLine("3 - Delete Student----------                                                   ");
            Console.WriteLine("Information of the student that you want to delete                             ");
            Console.Write("No: ");
            int no = Convert.ToInt32(Console.ReadLine());



            if (Students.Count == 0)
            {
                Console.WriteLine("There are no students to delete from the list");
            }
            else
            {
                Student o = null;
                //Write foreach to find the student whose number is equal to no

                foreach (Student item in Students)
                {
                    if (item.No == no)
                    {
                        o = item;
                        break;
                    }

                }
                if (o != null)
                {
                    Console.WriteLine("Name: " + o.Name);
                    Console.WriteLine("Surname: " + o.Surname);
                    Console.WriteLine("Branch: " + o.Branch);
                    Console.WriteLine();
                    Console.Write("Are you sure to delete the student? (Y / N) ");
                    string giris = Console.ReadLine().ToUpper();
                    if (giris == "y")
                    {
                        Students.Remove(o);
                        Console.WriteLine("Student has been deleted. ");
                    }
                    else
                    {
                        Console.WriteLine("Student has not been deleted. ");
                    }
                }
                else
                {
                    Console.WriteLine("There is no such student in the list.");
                }

            }
        }
        static void Exit()
        {
            Console.WriteLine("The program has been terminated.");
            Environment.Exit(0);
        }



    }
}
