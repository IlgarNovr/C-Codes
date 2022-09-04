using System;
namespace Person
{
    public class PersonInfo
    {
        public int ID { get; set; }

        public string username { get; set; }

        public string email { get; set; }
        private string pass;
        public string password
        {
            get => pass;
            set
            {
                if (value.Length < 8)
                    throw new Exception("Password is too short");
                pass = value;
            }
        }

        public string name { get; set; }

        public string surname { get; set; }

        public PersonInfo(string username, string email, string password, string name, string surname)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.name = name;
            this.surname = surname;
        }

        public PersonInfo(){}
    }
}
