using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem
{
    public class IdentificationData
    {
        private int _id;
        private string _login;
        private string _password;
        private string _userFIO;
        private int _role;

        public int ID
        {
            get => _id;
            set => _id = value;
        }
        public string Login
        {
            get => _login;
            set=>_login = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }
        public string UserFIO
        {
            get => _userFIO;
            set => _userFIO = value;
        }
        public int Role
        {
            get => _role;
            set => _role = value;
        }
    }
}
