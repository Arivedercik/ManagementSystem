using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem
{
    /// <summary>
    /// Пользователи
    /// </summary>
    public class IdentificationData
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        private int _id;

        /// <summary>
        /// Логин пользователя
        /// </summary>
        private string _login;

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        private string _password;

        /// <summary>
        /// Фамилия, имя, отчество пользователя
        /// </summary>
        private string _userFIO;

        /// <summary>
        /// Роль пользователя
        /// </summary>
        private int _role;

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int ID
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login
        {
            get => _login;
            set => _login = value;
        }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password
        {
            get => _password;
            set => _password = value;
        }

        /// <summary>
        /// Фамилия, имя, отчество пользователя
        /// </summary>
        public string UserFIO
        {
            get => _userFIO;
            set => _userFIO = value;
        }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public int Role
        {
            get => _role;
            set => _role = value;
        }
    }
}
