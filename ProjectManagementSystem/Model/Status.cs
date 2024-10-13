using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem
{
    /// <summary>
    /// Статус задачи
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Идентификатор статуса
        /// </summary>
        private int _id;

        /// <summary>
        /// Наименование статуса
        /// </summary>
        private string _name;

        /// <summary>
        /// Идентификатор статуса
        /// </summary>
        public int ID
        {
            get => _id;
            set => _id = value;
        }
        /// <summary>
        /// Наименование статуса
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}
