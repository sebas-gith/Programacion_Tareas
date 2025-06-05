using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GestionDeTareas
{
    class FileManager
    {
        private string Path;

        public FileManager(string path) {
            Path = path;
        }

        public void AddTask(TaskM task) {
            string newTask = task.ToString();
            using (StreamWriter writer = new StreamWriter(this.Path, append: true)) { 
                writer.WriteLine(newTask);
            }

        }


        public List<TaskM> GetAllTask() {
            List<TaskM> list = new List<TaskM>(); 
            
            using (StreamReader reader = new StreamReader(this.Path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                   list.Add(TaskM.StringToTask(line));
                }

            }

            return list;
        
        }
    }
}
