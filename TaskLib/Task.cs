using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TaskLib
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public State state { get; set; }
    }

    public enum State
    {
        Open = 1, InProgress = 2, Close = 3
    }

    public class ListTasks
    {
        public List<Task> Tasks = new List<Task>();

        public void Add(Task task)
        {
            if (task == null) throw new Exception("item was null");

            Tasks.Add(task);
        }
        public void Edit(Task task)
        {
            if (task == null) throw new Exception("item was null");
            int index = -1;

            for (int i = 0; i < Tasks.Count; i++)
                if (task.Id == Tasks[i].Id) index = i;

            Tasks[index] = task;
        }
        public void Remove(Task task)
        {
            if (task == null) throw new Exception("item was null");

            Tasks.Remove(task);
        }

        public List<Task> ShowAllTasks()
        {
            return Tasks;
        }
    }
}
