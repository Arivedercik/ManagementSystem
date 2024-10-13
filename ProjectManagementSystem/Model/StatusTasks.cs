using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    /// <summary>
    /// Изменение статуса задачи 
    /// </summary>
    public class StatusTasks
    {
        /// <summary>
        /// Дата и время изменения
        /// </summary>
        private DateTime _date;

        /// <summary>
        /// ФИО пользователя, изменившего статус
        /// </summary>
        private string _fioUser;

        /// <summary>
        /// Идентификатор изменённой задачи
        /// </summary>
        private int _idTask;

        /// <summary>
        /// Изменённый статус
        /// </summary>
        private string _status;

        /// <summary>
        /// Дата и время изменения
        /// </summary>
        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        /// <summary>
        /// ФИО пользователя, изменившего статус
        /// </summary>
        public string FIOUser
        {
            get => _fioUser;
            set => _fioUser = value;
        }

        /// <summary>
        /// Идентификатор изменённой задачи
        /// </summary>
        public int IDTask
        {
            get => _idTask;
            set => _idTask = value;
        }

        /// <summary>
        /// Изменённый статус
        /// </summary>
        public string Status
        {
            get => _status;
            set => _status = value;
        }
    }
}
