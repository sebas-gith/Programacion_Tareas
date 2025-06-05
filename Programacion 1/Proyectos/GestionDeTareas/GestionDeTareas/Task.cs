using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeTareas
{ 
    public class TaskM
    {
        private string Id;
        private string Title;
        private string Description;
        private string Date;
        private string Time;

        public TaskM()
        {
            Date = DateTime.Now.ToShortDateString();
            Time = DateTime.Now.ToShortTimeString();
        }

        public TaskM(string title, string description)
        {
            Title = title;
            Description = description;
            Date = DateTime.Now.ToShortDateString();
            Time = DateTime.Now.ToShortTimeString();
        }

        public TaskM(string title, string description, string date, string time)
        {
            Title = title;
            Description = description;
            Date = date;
            Time = time;
        }

        public void setTitle(string title)
        {
            this.Title = title;
        }

        public void setDescription(string description)
        {
            this.Description = description;
        }

        public override string ToString()
        {
            return $"{Title},{Description},{Date},{Time}";
        }

        public static TaskM StringToTask(string task)
        {
            string[] data = task.Split(',');
            return new TaskM(data[0], data[1], data[2], data[3]);
        }

    }
}
