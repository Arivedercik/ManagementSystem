using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem
{
    /// <summary>
    /// Задачи пользователя
    /// </summary>
    public class Tasks
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        private int _id;

        /// <summary>
        /// Наименование задачи
        /// </summary>
        private string _name;

        /// <summary>
        /// Описание задачи
        /// </summary>
        private string _description;

        /// <summary>
        /// Идентификатор сотрудника задачи
        /// </summary>
        private int _idUser;

        /// <summary>
        /// Идентификатор статуса задачи
        /// </summary>
        private int _idStatus;

        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public int ID
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// Наименование задачи
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description
        {
            get => _description;
            set => _description = value;
        }

        /// <summary>
        /// Идентификатор сотрудника задачи
        /// </summary>
        public int IDUser
        {
            get => _idUser;
            set => _idUser = value;
        }

        /// <summary>
        /// Идентификатор статуса задачи
        /// </summary>
        public int IDStatus
        {
            get => _idStatus;
            set => _idStatus = value;
        }
    }
}
