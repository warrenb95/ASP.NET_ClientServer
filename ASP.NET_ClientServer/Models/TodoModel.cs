using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_ClientServer.Models
{
    public class Timespent
    {
        public String ID { get; set; }

        [Display(Name = "Time spent (Minutes)")]
        [Required(ErrorMessage = " You need to enter a value for time spent.")]
        public int timespent { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = " You need to enter a description.")]
        public string desc { get; set; }
    }
    public class TodoModel
    {
        public String ID { get; set; }

        [Display(Name = "Todo title")]
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
