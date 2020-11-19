using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        // public State state { get; set; }
    }

    public enum State
    {
        Open = 1, InProgress = 2, Close = 3
    }

    public class ListTasks
    {
        public List<Task> Tasks = new List<Task>();

        public void Add(Task task);
        public void Edit(Task task);
        public void Remove(Task task);
    }
}
