using GestionDeTareas;
using System.Threading;
using System;
using System.Reflection.Metadata;
using System.ComponentModel;
using Microsoft.VisualBasic.FileIO;

namespace GestionDetareas
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager Tasks = new FileManager("C:\\Users\\Admin\\Desktop\\3rd Semester\\Programacion 1\\Proyectos\\GestionDeTareas\\GestionDeTareas\\Tasks.txt");
            var fuser = new User("sebas", "12345");
            while (true)
            {
                UIs.Title();
                int loginAttempts = 0;
                User cUser; //cUser for Current User*
                do
                {
                    if (loginAttempts > 0)
                    {
                        UIs.WrongLoginMessage();
                    }
                    cUser = UIs.Login();
                    loginAttempts++;
                } while (!User.CheckUser(fuser, cUser));
                int option = UIs.Dashboard();

                switch (option)
                {
                    case 1:
                        TaskM newTask = UIs.NewTaskScreen();
                        Tasks.AddTask(newTask); break;

                }




                Console.ReadKey();
                //         Console.WriteLine(fuser.getId());
            }
        }
    }
}