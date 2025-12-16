using Mei.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mei.Services
{
    //public interface IAuthService
    //{
    //    void AuthUser(string username, string password);
    //}

    public class AuthService
    {

        //This is not safe
        private string connStr = "server=localhost;user=root;database=requiem;port=3306;password=root;";
        private readonly FormAddViewModel _formAddViewModel;

        public AuthService(FormAddViewModel formAddViewModel)
        {
            _formAddViewModel = formAddViewModel;
        }

        public int GetTotalUsers()
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM Users", conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }


        public bool DBquery(string sql, Dictionary<string, object> parameters)
        {
            int count = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        foreach (var p in parameters)
                            cmd.Parameters.AddWithValue(p.Key, p.Value);

                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read()) count++;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return count == 1;
        }

        //Depency Injection???
        public bool Authenticate(string username, string password)
        {
            return CheckUser(username, password);
        }


        private bool CheckUser(string username, string password)
        {
            int count = 0;

            string sqlCommand = $"SELECT * FROM login WHERE username='{username}' and password='{password}'";

            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(sqlCommand, conn))
                    {
                        count =  Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            if(count==1)
            {
                return true;
            }
           
            
            return false;
        }

    }
}
