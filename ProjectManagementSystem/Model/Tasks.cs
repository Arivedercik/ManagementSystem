using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem
{
    public class Tasks
    {
        private int _id;
        private string _name;
        private string _description;
        private int _idUser;
        private int _idStatus;

        public int ID
        {
            get => _id;
            set => _id = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Description
        {
            get => _description;
            set => _description = value;
        }
        public int IDUser
        {
            get => _idUser;
            set => _idUser = value;
        }
        public int IDStatus
        {
            get => _idStatus;
            set => _idStatus = value;
        }
    }
}
