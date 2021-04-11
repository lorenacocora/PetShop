using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain
{
    public class Vet : Entity<int>
    {
        public string Name { get; set; }
        public String Schedule { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Vet vet &&
                   ID == vet.ID &&
                   Name == vet.Name &&
                   Schedule == vet.Schedule;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Name, Schedule);
        }

        public override string ToString()
        {
            return Name+","+Schedule;
        }

        public string getStartingHour()
        {
            string[] fieldsHoursMinutes = Schedule.Split("-");
            string[] hour = fieldsHoursMinutes[0].Split(":");
            return hour[0];
        }

        public string getEndingHour()
        {
            string[] fieldsHoursMinutes = Schedule.Split("-");
            string[] hour = fieldsHoursMinutes[1].Split(":");
            return hour[0];
        }

        public string getStartingMinute()
        {
            string[] fieldsHoursMinutes = Schedule.Split("-");
            string[] minutes = fieldsHoursMinutes[0].Split(":");
            return minutes[1];
        }
    }
}
