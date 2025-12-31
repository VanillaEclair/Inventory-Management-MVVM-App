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

        //Depency Injection???
        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            const string sqlCommand = "SELECT COUNT(*) FROM login WHERE username=@username AND password=@password";

            try
            {
                using var conn = new MySqlConnection(connStr);
                await conn.OpenAsync();

                using var cmd = new MySqlCommand(sqlCommand, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                var result = await cmd.ExecuteScalarAsync();
                int count = Convert.ToInt32(result);

                return count == 1;
            }
            catch
            {
                throw;
            }
        }

    }
}
