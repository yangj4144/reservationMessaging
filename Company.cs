using System;
using System.Collections.Generic;
using System.Text;

namespace hotel
{
    public class Company
    {
        public int Id { get; set; }

        public string company { get; set; }

        public string City { get; set; }

        public string Timezone { get; set; }

        public Company()
        {
            
        }

        public override string ToString()
        {
            return Id + " " + company + " , " + City + " , " + Timezone;
        }

    }
    
}
