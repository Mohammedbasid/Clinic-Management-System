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
        static SqlConnection cnn;
        static SqlCommand cmd;

        private SqlConnection getConnection()
        {
            cnn = new SqlConnection("Data Source =.; Initial Catalog" + " = Clinicmanagement; Integrated Security = True");
            cnn.Open();
            return cnn;
        }
        public bool loginUser(string username, string password)
        {
            cnn = getConnection();
            cmd = new SqlCommand("select * from users where username=@username and password = @password");
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password); 
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                return true;
            }
            throw new LoginException("Login Failed Please Enter a Valid username or password.");
        }

       
    }
}
