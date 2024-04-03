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

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        SqlDataAdapter dataAdapterCouriers;  // Couriers
        SqlDataAdapter dataAdapterEmployees;  // Employees
        DataSet dataSet;
        BindingSource bindingSourceCouriers;
        BindingSource bindingSourceEmployees;

        SqlCommandBuilder commandBuilder;

        string queryCouriers;
        string queryEmployees;

        public Form1()
        {
            InitializeComponent();
        }

        void FillData()
        {
            queryCouriers = "SELECT * FROM Couriers";
            queryEmployees = "SELECT * FROM Employees";

            dataAdapterCouriers = new SqlDataAdapter(queryCouriers, sqlConnection);
            dataAdapterEmployees = new SqlDataAdapter(queryEmployees, sqlConnection);

            dataSet = new DataSet();

            dataAdapterCouriers.Fill(dataSet, "Couriers");
            dataAdapterEmployees.Fill(dataSet, "Employees");

            commandBuilder = new SqlCommandBuilder(dataAdapterEmployees);

            dataSet.Relations.Add("CouriersEmployees",
                dataSet.Tables["Couriers"].Columns["CourierID"],
                dataSet.Tables["Employees"].Columns["CourierID"]);

            // Method 1
            /*
            this.dataGridView1.DataSource = dataSet.Tables["Couriers"];
            this.dataGridView2.DataSource = this.dataGridView1.DataSource;
            this.dataGridView2.DataMember = "CouriersEmployees";
            */

            // Method 2
            bindingSourceCouriers = new BindingSource();
            bindingSourceCouriers.DataSource = dataSet.Tables["Couriers"];
            bindingSourceEmployees = new BindingSource(bindingSourceCouriers, "CouriersEmployees");

            this.dataGridView1.DataSource = bindingSourceCouriers;
            this.dataGridView2.DataSource = bindingSourceEmployees;

            commandBuilder.GetUpdateCommand();
        }

        string getSqlConnectionString()
        {
            return "Data Source=.\\SQLEXPRESS;Initial Catalog=Dropshipping;Integrated Security=true;";
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        ~Form1()
        {
            sqlConnection.Close();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(getSqlConnectionString());

            sqlConnection.Open();

            FillData();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            dataAdapterEmployees.Update(dataSet, "Employees");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0 && dataGridView2.SelectedRows[0].Index < dataGridView2.Rows.Count - 1)
            {
                string command = "DELETE FROM Employees WHERE EmployeeID =" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString();

                SqlCommand deleteCommand = new SqlCommand(command, sqlConnection);

                deleteCommand.ExecuteNonQuery();

                FillData();
            }
        }
    }
}