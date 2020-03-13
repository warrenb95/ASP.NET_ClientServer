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
        [Required(ErrorMessage = " You need to enter a title.")]
        public String Title { get; set; }

        [Display(Name = "Todo description")]
        [Required(ErrorMessage = " You need to enter a description.")]
        public String Desc { get; set; }
        public System.DateTime TimeCreated { get; set; }

        [Display(Name = "Estimation (Minutes)")]
        [Required(ErrorMessage = " You need to enter an estimation.")]
        public int Estimate { get; set; }

        public int TotalTimeSpent { get; set; }

        public Timespent[] Timespent { get; set; }
    }
}
