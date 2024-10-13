using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    /// <summary>
    /// Роль пользователя 
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        private int _id;

        /// <summary>
        /// Наименование роли
        /// </summary>
        private string _name;

        /// <summary>
        /// Идентификатор роли
        /// </summary>
        public int ID
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// Наименование роли
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}
