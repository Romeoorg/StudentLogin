//using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp2
{
    public class ConnectToDB
    {
        SqlConnection conns = new SqlConnection(@"Data Source=ROMEO-AI;Initial Catalog=MettusLoginDatabase;Integrated Security=True");
        SqlCommand? command;
        public DataTable table;
        DataRow row;
        SqlDataReader reader;
        public void Registration(int StudentID, string firstname, string Surname, string City, string address, string CellPhone)
        {
            conns.Open();
            command = new SqlCommand(string.Format("insert into Registrations values ('{0}','{1}','{2}','{3}','{4}','{5}')", StudentID, firstname, Surname, address, City, CellPhone), conns);
            command.ExecuteNonQuery();
            conns.Close();
            command.Dispose();
        }
        public void UpdateStudentsInfo(int StudentID, string Firstname, string Surname, string city, string address, string cellphone)
        {
            conns.Open();
            command = new SqlCommand(string.Format("update Registrations set Firstname = @Firstname" + ", Surname=@Surname" + ",address = @address" + ",  city = @city" + ", Cellphone =@cellphone" + " where StudentiD = @StudentID"), conns);
            command.Parameters.AddWithValue("@Firstname", Firstname);
            command.Parameters.AddWithValue("@Surname", Surname);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@StudentID", StudentID);
            command.Parameters.AddWithValue("@cellphone", cellphone);
            command.ExecuteNonQuery();
            conns.Close();
            command.Dispose();

        }
        public void DeleteStudentInfo(int StudentID)
        {
            conns.Open();
            command = new SqlCommand(string.Format("Delete Registrations " + " where StudentID = @StudentID"), conns);
            command.Parameters.AddWithValue("@StudentID", StudentID);
            command.ExecuteNonQuery();
            conns.Close();
            command.Dispose();
        }
        public void DisplayStudentsInfo()
        {
            table = new DataTable();
            conns.Open();
            command = new SqlCommand(@"select * from Registrations", conns);
            reader = command.ExecuteReader();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                table.Columns.Add(reader.GetName(i));
            }
            while (reader.Read())
            {
                row = table.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    {
                        row[i] = reader[i];
                    }
                    table.Rows.Add(row);

                }
                conns.Close();
                command.Dispose();
                reader.Close();
            }
        }
    }
}
