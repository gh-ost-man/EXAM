﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaskLib
{
    /**
     @class ToDoMask
     Contains the basic properties of the task.
     */

    public class ToDoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public State state { get; set; }


        public ToDoTask() { }

        public ToDoTask(string title, string description, DateTime s_Date, DateTime e_Date, State state)
        {

            this.Title = title;
            this.Description = description;
            this.startDate = s_Date;
            this.endDate = e_Date;
            this.state = state;
        }


    }

    /**
    @enum State
    Contains task states
    */

    public enum State
    {
        Open = 1, InProgress = 2, Close = 3
    }

    /**
     @class ListTasks
     Contains the list tasks.
     */
    public class ListTasks
    {
        public List<ToDoTask> Tasks = new List<ToDoTask>();

        static int id = -1;

        ///@param task new task.
        public void Add(ToDoTask task)
        {
            if (task == null) throw new Exception("item was null");

            if (Tasks.Count == 0) id = 1;
            else id = Tasks[Tasks.Count - 1].Id + 1;

            task.Id = id;
            Tasks.Add(task);
            id++;

            XmlSerializer xs = new XmlSerializer(typeof(List<ToDoTask>));

            using (FileStream fs = new FileStream("Tasks.xml", FileMode.Truncate))
            {
                xs.Serialize(fs, Tasks);
            }
        }
        ///@param task changeв task.
        public void Edit(ToDoTask task)
        {
            if (task == null) throw new Exception("item was null");
            int index = -1;

            for (int i = 0; i < Tasks.Count; i++)
                if (task.Id == Tasks[i].Id) index = i;

            Tasks[index] = task;
        }

        ///@param task for remove
        public void Remove(ToDoTask task)
        {
            if (task == null) throw new Exception("item was null");

            Tasks.Remove(task);
        }

        ///@param id task ID
        ///@return task by id
        public ToDoTask FindById(int _id)
        {
            return Tasks.Where(x => x.Id == _id).FirstOrDefault();
        }

        ///@return the entire to-do list.
        public List<ToDoTask> GetAllTasks()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<ToDoTask>));

            if (!File.Exists("Tasks.xml")) throw new Exception("File not found");

            using (FileStream fs = new FileStream("Tasks.xml", FileMode.OpenOrCreate))
            {
                Tasks = (List<ToDoTask>)xs.Deserialize(fs);

                return Tasks;
            }

        }
    }
}
