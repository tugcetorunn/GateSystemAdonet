using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSystemAdonet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AllPlates();
        }

        public static void AllPlates()
        {
            //const string connStr = "Data Source = DESKTOP-ATVPBPS; Initial Catalog = GateSystem; Integrated Security = true";
            //const string query = "select * from PlateInfo";

            //SqlConnection connection = new SqlConnection(connStr);

            //connection.Open();

            //SqlCommand cmd = new SqlCommand(query, connection);

            //SqlDataReader reader = cmd.ExecuteReader(); // var tanımlasak da olur

            //while (reader.Read()) // kayıt olduğu müddetçe burası çalışır.
            //{
            //    Console.WriteLine($"Plaka : {reader["PlateNo"]}  Sahibi : {reader[1] + " " + reader[2]}");
            //}

            //Console.ReadLine();
            //connection.Close();

            //kısaltılmış hali;

            //bağlantı açma kapama gibi süreç işlerinde using kullanabiliriz. using açtığı bağlantıyı kendi kapatır.
            //connection string data source yerine server, initial catalog yerine database yazılabilir.
            
            using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-ATVPBPS; Initial Catalog = GateSystem; Integrated Security = true"))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("select * from PlateInfo", connection);

                SqlDataReader reader = cmd.ExecuteReader(); // var tanımlasak da olur

                while (reader.Read()) // kayıt olduğu müddetçe burası çalışır.
                {
                    Console.WriteLine($"Plaka : {reader["PlateNo"]}  Sahibi : {reader[1] + " " + reader[2]}");
                }

                Console.ReadLine();

            }
            
        }
    }
}
