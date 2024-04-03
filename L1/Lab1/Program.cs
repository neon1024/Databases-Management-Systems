using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Dropshipping;Integrated Security=true;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            // SqlCommand
            string sqlCouriersString = "SELECT * FROM Couriers";
            string sqlEmployeesString = "SELECT * FROM Employees";

            // SqlCommand command = new SqlCommand(sqlCouriersString, sqlConnection);

            // SqlDataReader
            /*
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    Console.WriteLine("{0}, {1}, {2}", reader[0], reader[1], reader[2]);
                }
            }
            */

            DataSet dataSet = new DataSet();

            SqlDataAdapter dataAdapterCouriers = new SqlDataAdapter(sqlCouriersString, sqlConnection);
            SqlDataAdapter dataAdapterEmployees = new SqlDataAdapter(sqlEmployeesString, sqlConnection);

            dataAdapterCouriers.Fill(dataSet, "Couriers");
            dataAdapterEmployees.Fill(dataSet, "Employees");

            foreach(DataRow dataRow in dataSet.Tables["Couriers"].Rows)
            {
                Console.WriteLine("{0}", dataRow["CourierName"]);
            }

            foreach (DataRow dataRow in dataSet.Tables["Employees"].Rows)
            {
                Console.WriteLine("{0} {1}", dataRow["FirstName"], dataRow["LastName"]);
            }

            sqlConnection.Close();
        }
    }
}