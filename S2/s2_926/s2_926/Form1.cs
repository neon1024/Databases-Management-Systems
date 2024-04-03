using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s2_926
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-IG95M02; Initial Catalog=sem_2023_2024; Integrated Security=true;");
        SqlDataAdapter dataAdapterBoards, dataAdapterTasks;
        DataSet dataSet = new DataSet();
        BindingSource bindingSourceBoards = new BindingSource();
        BindingSource bindingSourceTasks = new BindingSource();
        DataRelation dataRelation;
        SqlCommandBuilder commandBuilder;//= new SqlCommandBuilder();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //try { }
            dataAdapterTasks.Update(dataSet, "Tasks");
            //catch(pppp)
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            bindingSourceTasks.MoveNext();
            dataGridViewTasks.ClearSelection();
            dataGridViewTasks.Rows[bindingSourceTasks.Position].Selected = true;
        }

        private void dataGridViewBoards_CursorChanged(object sender, EventArgs e)
        {

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            dataAdapterBoards = new SqlDataAdapter("SELECT * FROM Boards", connect);
            dataAdapterTasks = new SqlDataAdapter("SELECT * FROM Tasks", connect);
            commandBuilder = new SqlCommandBuilder(dataAdapterTasks);

            dataAdapterBoards.Fill(dataSet, "Boards");
            dataAdapterTasks.Fill(dataSet, "Tasks");
            dataRelation = new DataRelation("FK_Boards_Tasks", dataSet.Tables["Boards"].Columns["bid"], dataSet.Tables["Tasks"].Columns["bid"]);
            dataSet.Relations.Add(dataRelation);

            bindingSourceBoards.DataSource = dataSet;
            bindingSourceBoards.DataMember = "Boards";
            bindingSourceTasks.DataSource = bindingSourceBoards;
            bindingSourceTasks.DataMember = "FK_Boards_Tasks";
            dataGridViewBoards.DataSource = bindingSourceBoards;
            dataGridViewBoards.ReadOnly = true;
            dataGridViewBoards.AllowUserToAddRows = false;
            dataGridViewBoards.AllowUserToDeleteRows = false;

            dataGridViewTasks.DataSource = bindingSourceTasks;
            taskNameTextBox.DataBindings.Add("Text", bindingSourceTasks, "tname");
        }
    }
}
