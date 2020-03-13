using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TodoDataLibrary
{
    public struct Timespent
    {
        public int timespent { get; set; }
        public DateTime timecreated { get; set; }
        public string desc { get; set; }
    }

    public class TodoModel
    {
        public string _id { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public DateTime timecreated { get; set; }
        public DateTime deadline { get; set; }
        public int estimate { get; set; }
        public int totaltimespent { get; set; }
        public List<Timespent> timespent { get; set; }
    }

    public class TodoListModel
    {
        List<TodoModel> todoModels { get; set; }
    }
}
