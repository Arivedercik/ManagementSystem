using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    public class StatusTasks
    {
        private DateTime _date;
        private string _fioUser;
        private int _idTask;
        private string _status;

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }
        public string FIOUser
        {
            get => _fioUser;
            set => _fioUser = value;
        }
        public int IDTask
        {
            get => _idTask;
            set => _idTask = value;
        }
        public string Status
        {
            get => _status;
            set => _status = value;
        }
    }
}
