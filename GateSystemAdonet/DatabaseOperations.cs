using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSystemAdonet
{
    internal class DatabaseOperations
    {
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

        public static void AllCities()
        {
            using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-ATVPBPS; Initial Catalog = GateSystem; Integrated Security = true"))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("select * from GateCityInfo", connection);

                SqlDataReader reader = cmd.ExecuteReader(); // var tanımlasak da olur

                Console.WriteLine("Şehirler:");

                while (reader.Read()) // kayıt olduğu müddetçe burası çalışır.
                {
                    Console.WriteLine($"{reader[1]}");
                }

                Console.ReadLine();

            }
        }

        public static void InsertPlate()
        {
            using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-ATVPBPS; Initial Catalog = GateSystem; Integrated Security = true"))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("insert into PlateInfo (Name, LastName, PlateNo, BirthDate) " +
                    "values (@Name, @LastName, @PlateNo, @BirthDate)", connection);
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 10).Value = "Tuğçe";
                cmd.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar, 10).Value = "Biçer";
                cmd.Parameters.Add("@PlateNo", System.Data.SqlDbType.VarChar, 10).Value = "45 TAZ 45";
                cmd.Parameters.Add("@BirthDate", System.Data.SqlDbType.Date).Value = "1997-09-08";

                cmd.ExecuteNonQuery(); // crud işlemlerinde kullanmamız gerekir.

            }
        }
    }


}
