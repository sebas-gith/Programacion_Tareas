using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography;

namespace GestionDeTareas
{
    public class User
    {
        private string id;
        private string name;
        private string password;

        public User(string name, string password) {
            this.GenerateAnId();
            this.name = name;
            //FormatPassword(password);
            this.password = password;
        }

        private void GenerateAnId()
        {
            string localId = "";
            for (int i = 0; i < 5; ++i)
            {
                Random rand = new Random();
                for (int j = 0; j < 3; ++j)
                {
                    char letter = (char)(rand.Next(0, 25)+97);
                    localId += letter;
                }
                if(i != 4)
                {
                    localId += '-';
                }
            }

            id = localId;
        }
        public string getId()
        {
            return id;
        }

        //private void FormatPassword(string pw)
        //{
        //    string pass = Convert.ToBase64String(pw);
        //    this.password = Convert.FromBase64String(pw);
        //}
        public string FormatCSV()
        {
            
            return "";
        }

        public static bool CheckUser(User s1, User s2)
        {
            return (s1.name == s2.name) && (s1.password == s2.password);
        }
    }
}
