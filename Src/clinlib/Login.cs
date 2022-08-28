using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace clinlib
{
    
    public class Login : ILogin
    {
        static SqlConnection connection;
        static SqlCommand command;

        private SqlConnection getConnection()
        {
            connection = new SqlConnection("Data Source =.; Initial Catalog" + " = Clinicmanagement; Integrated Security = True");
            connection.Open();
            return connection;
        }
        /*This Method is used for user Login*/
        public bool loginUser(string username, string password)
        {
            connection = getConnection();
            command = new SqlCommand("select * from users where username=@username and password=@password");
            command.Connection = connection;
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password); 
            SqlDataReader sdr = command.ExecuteReader();
            if (sdr.HasRows)
            {
                return true;
            }
            throw new LoginException("Login Failed Please Enter a Valid username or password.");
        }       
    }
}
