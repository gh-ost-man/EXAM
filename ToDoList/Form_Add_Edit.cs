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
    public partial class Form_Add_Edit : Form
    {
        ToDoTask todoTask = null;
        TypeF type;
        public Form_Add_Edit()
        {
            InitializeComponent();

            comboBox1.Items.Add(State.Open);
            comboBox1.Items.Add(State.InProgress);
            comboBox1.Items.Add(State.Close);
        }

        public Form_Add_Edit(ToDoTask task,TypeF typeF)
        {
            this.todoTask = task;
            this.type = typeF;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox_Title.Text) || String.IsNullOrEmpty(textBox_Description.Text) ||comboBox1.SelectedIndex==-1) return;
                
            if(type==TypeF.Add)
            {
                State state;


                MessageBox.Show(comboBox1.SelectedItem.ToString());


                todoTask.Title = textBox_Title.Text;
                todoTask.Description = textBox_Description.Text;
                todoTask.startDate = dateTimePicker_Start.Value;
                todoTask.endDate = dateTimePicker_End.Value;


            }
        }
    }
}
