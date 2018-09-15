using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NavigatorDiaries.Views
{
    public class TripPlannerItems
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Place { get; set; }
        public string TripDate { get; set; }
        public string Transport { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }

    public class JournaEntrylItems
    {
        [PrimaryKey, AutoIncrement]
        public int EntryId { get; set; }
        public string City { get; set; }
        public string Weather { get; set; }
        public string Emotion { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string EntryDescription { get; set; }
        public byte[] Multimedia { get; set; }
        
    }


    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }
        public string Country { get; set; }
        public string Interests { get; set; }
        public string Bio { get; set; }
    }

}


