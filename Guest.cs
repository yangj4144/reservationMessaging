using System;
using System.Collections.Generic;
using System.Text;

namespace hotel
{
    public class Guest
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Reservation Reservation { get; set; }

        public Guest()
        {

        }

        public Guest(int id, string firstName, string lastName, Reservation reservation)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Reservation = reservation;


        }


        public override string ToString()
        {
            return "ID: " + Id + ", " + FirstName + " " + LastName +  Reservation;
        }

    }
}
