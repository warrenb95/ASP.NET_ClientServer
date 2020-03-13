using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public struct Timespent
    {
        public int Duration { get; set; }
        public System.DateTime Date { get; set; }
        public String Desc { get; set; }
    }

    class TodoModel
    {
        public String ID { get; set; }
        public String Title { get; set; }
        public String Desc { get; set; }
        public System.DateTime TimeCreated { get; set; }
        public int Estimate { get; set; }

        public int TotalTimeSpent { get; set; }

        public Timespent[] Timespent { get; set; }
    }

}
