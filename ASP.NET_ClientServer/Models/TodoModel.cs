using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_ClientServer.Models
{
    public struct Timespent
    {
        public int Duration { get; set; }
        public System.DateTime Date { get; set; }
        public String Desc { get; set; }
    }
    public class TodoModel
    {
        public String ID { get; set; }
        [Display(Name = " Todo title")]
        public String Title { get; set; }
        [Display(Name = "Todo Description")]
        public String Desc { get; set; }
        public System.DateTime TimeCreated { get; set; }
        public System.DateTime Date { get; set; }
        [Display(Name = "Estimation (Minutes)")]
        public int Estimate { get; set; }
        public int TotalTimeSpent { get; set; }
        public Timespent[] Timespent { get; set; }
    }
}
