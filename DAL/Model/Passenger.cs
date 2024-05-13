using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Passenger
    {
        public int PassengerID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }

        public Passenger() { }

        public Passenger(string name, string gender, int age, DateTime birthday)
        {
            this.Name = name;
            this.Gender = gender;
            this.Age = age;
            this.Birthday = birthday;
        }

        public Passenger(int id, string name, string gender, int age, DateTime birthday)
        {
            this.PassengerID = id;
            this.Name = name;
            this.Gender = gender;
            this.Age = age;
            this.Birthday = birthday;
        }
    }
}


