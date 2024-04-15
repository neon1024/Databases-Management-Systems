using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppConfig
{
    public partial class Form1 : Form
    {
        string SCENARIO = "1";

        SqlConnection sqlConnection;
        SqlDataAdapter dataAdapterMaster;  // Couriers
        SqlDataAdapter dataAdapterDetail;  // Employees
        DataSet dataSet;
        BindingSource bindingSourceMaster;
        BindingSource bindingSourceDetail;

        SqlCommandBuilder commandBuilder;

        string masterQuery;
        string detailQuery;

        string masterTable;
        string detailTable;

        string masterTableID;
        string detailTableID;

        public Form1()
        {
            InitializeComponent();
        }

        void FillData()
        {
            masterTable = ConfigurationManager.AppSettings[SCENARIO + "." + "masterTable"];
            detailTable = ConfigurationManager.AppSettings[SCENARIO + "." + "detailTable"];

            masterLabel.Text = masterTable.ToString();
            detailLabel.Text = detailTable.ToString();

            masterTableID = ConfigurationManager.AppSettings[SCENARIO + "." + "masterTableID"];
            detailTableID = ConfigurationManager.AppSettings[SCENARIO + "." + "detailTableID"];

            masterQuery = $"SELECT * FROM {masterTable}";
            detailQuery = $"SELECT * FROM {detailTable}";

            dataAdapterMaster = new SqlDataAdapter(masterQuery, sqlConnection);
            dataAdapterDetail = new SqlDataAdapter(detailQuery, sqlConnection);

            dataSet = new DataSet();

            dataAdapterMaster.Fill(dataSet, masterTable);
            dataAdapterDetail.Fill(dataSet, detailTable);

            commandBuilder = new SqlCommandBuilder(dataAdapterDetail);

            dataSet.Relations.Add(masterTable + detailTable,
                dataSet.Tables[masterTable].Columns[masterTableID],
                dataSet.Tables[detailTable].Columns[masterTableID]);

            // Method 1
            
            this.dataGridView1.DataSource = dataSet.Tables[masterTable];
            this.dataGridView2.DataSource = this.dataGridView1.DataSource;
            this.dataGridView2.DataMember = masterTable + detailTable;
            

            // Method 2
            /*
            bindingSourceMaster = new BindingSource();
            bindingSourceMaster.DataSource = dataSet.Tables[masterTable];
            bindingSourceDetail = new BindingSource(bindingSourceDetail, masterTable + detailTable);

            this.dataGridView1.DataSource = bindingSourceMaster;
            this.dataGridView2.DataSource = bindingSourceDetail;
            */

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
            dataAdapterDetail.Update(dataSet, detailTable);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0 && dataGridView2.SelectedRows[0].Index < dataGridView2.Rows.Count - 1)
            {
                string command = $"DELETE FROM {detailTable} WHERE {detailTableID} =" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString();

                SqlCommand deleteCommand = new SqlCommand(command, sqlConnection);

                deleteCommand.ExecuteNonQuery();

                FillData();
            }
        }
    }
}