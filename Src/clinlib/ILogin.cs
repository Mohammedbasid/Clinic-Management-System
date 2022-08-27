using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinlib
{
    public interface ILogin
    {
        public bool loginUser(string username, string password);

    }
}
