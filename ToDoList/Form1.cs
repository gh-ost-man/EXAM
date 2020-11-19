using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskLib;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        ListTasks tasks = new ListTasks();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = tasks.GetAllTasks(); ;
            }
            catch { }
        }

        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            ToDoTask task = new ToDoTask();

            Form_Add_Edit add = new Form_Add_Edit(task, TypeF.Add);
            add.ShowDialog();


            //ToDoTask task = new ToDoTask("F1", "sadsa", DateTime.Now, new DateTime(2020, 11, 22), State.Open);
            //tasks.Add(task);
            //dataGridView1.DataSource = null;
            //dataGridView1.DataSource= tasks.GetAllTasks();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tasks.GetAllTasks();
        }
    }
}
