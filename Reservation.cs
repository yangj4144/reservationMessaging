using System;
using System.Collections.Generic;
using System.Text;

namespace hotel
{
    public class Reservation
    {
        public int RoomNumber { get; set; }

        public int StartTimestamp { get; set; }

        public int EndTimeStamp { get; set; }

        public Reservation(int roomNumber, int startTimeStamp, int endTimeStamp)
        {
            this.RoomNumber = roomNumber;
            this.StartTimestamp = startTimeStamp;
            this.EndTimeStamp = endTimeStamp;
        }

        public override string ToString()
        {
            return " , " + RoomNumber + " , " + StartTimestamp + " , " + EndTimeStamp;
        }
    }
}
