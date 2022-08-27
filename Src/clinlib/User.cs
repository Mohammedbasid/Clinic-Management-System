using System;
namespace clinlib
{
    public class User
    {
        string username { get; set; }
        string firstname { get; set; }
        string lastname { get; set; }
        string password { get; set; }

        public User()
        {

        }
        public User(string username, string firstname, string lastname, string password)
        {
            this.username = username;
            this.firstname = firstname;
            this.lastname = lastname;
            this.password = password;
        }
        public bool LoginUser(string username,string password)
        {
            return true;
        }
    }

}