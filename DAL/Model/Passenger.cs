using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Passenger
    {
        public int PassengerID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public int FerryID { get; set; }
        public int? CarID { get; set; }

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


