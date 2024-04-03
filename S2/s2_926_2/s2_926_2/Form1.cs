using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s2_926_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void boardsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.boardsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sem_2023_2024DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sem_2023_2024DataSet.Tasks' table. You can move, or remove it, as needed.
            this.tasksTableAdapter.Fill(this.sem_2023_2024DataSet.Tasks);
            // TODO: This line of code loads data into the 'sem_2023_2024DataSet.Boards' table. You can move, or remove it, as needed.
            this.boardsTableAdapter.Fill(this.sem_2023_2024DataSet.Boards);

        }
    }
}
