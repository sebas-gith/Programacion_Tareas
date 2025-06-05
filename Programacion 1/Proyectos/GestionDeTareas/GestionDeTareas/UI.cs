using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using GestionDeTareas;

namespace GestionDeTareas
{
    class UIs
    {
        public static void Title()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 2);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("TasK Manager");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static User Login()
        {
            int height = Console.WindowHeight;
            int width = Console.WindowWidth;
            //fcposition is for First Cursor Position
            int fcpositionheight = height / 2;
            int fcpositionwidth = width / 2;

            Console.SetCursorPosition(fcpositionwidth-3, fcpositionheight-10);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Login: \n");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.SetCursorPosition(fcpositionwidth - 12, fcpositionheight-8);
            Console.Write("Name: ");
            Console.ForegroundColor = ConsoleColor.White;
            string name = Console.ReadLine();
            Console.SetCursorPosition(fcpositionwidth - 12, fcpositionheight - 6);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Password: ");
            Console.ForegroundColor = ConsoleColor.White;
            string pass = Console.ReadLine();

            Console.Clear();

            return new User(name, pass);
        }

        public static int Dashboard()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Choose an option: ");
            Console.SetCursorPosition(Console.WindowWidth/2-25, Console.WindowHeight/2);
            Console.WriteLine("1. Add\t\t 2. View All\t\t 3.Modify One\t\t 4.Delete One\t\t");
            Console.CursorVisible = false;
            int option = (int)Console.ReadKey().KeyChar-48;
            Console.WriteLine(option);
            Console.Clear();
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.White;

            return option;
        }
        
        public static void WrongLoginMessage()
        {
            Console.WriteLine("Wrong Login!");
            Console.WriteLine("Try again");
        }

        public static TaskM NewTaskScreen()
        {
            TaskM newTask = new TaskM();
            Console.Write("Title: ");
            newTask.setTitle(Console.ReadLine());
            Console.Write("Description: ");
            newTask.setDescription(Console.ReadLine());

            return newTask;
        }

        public static void ModifyTaskScreen()
        {

        }

        public static void DeleteTaskScreen() { 
        
        }

        public static void ViewTaskScreen() {
            {



            }
        }
    }

}


