using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagementSystem
{
    public static class WorkWithFile
    {
        /// <summary>
        /// Инициализация файлов
        /// </summary>
        /// <param name="pathsFile">Наименования файлов Json</param>
        public static void CreateJsonFiles(List<string> pathsFile)
        {
            try
            {
                File.Create(pathsFile[0]).Close();             
                File.Create(pathsFile[1]).Close();
                File.Create(pathsFile[2]).Close();
                File.Create(pathsFile[3]).Close();
                File.Create(pathsFile[4]).Close();
            }
            catch
            {
                Console.WriteLine("Файл данных не был создан");
            }
        }

        /// <summary>
        /// Заполнение файлов Роль и Статус (неизменяемые)
        /// </summary>
        /// <param name="pathsFile">Наименования файлов Json</param>
        public static void WriteInJsonFiles(List<string> pathsFile)
        {
            List<Role> roleCollection = new List<Role>() 
            { 
                new Role { ID = 1, Name = "Управляющий"}, 
                new Role { ID = 2, Name = "Сотрудник"} 
            };
            List<Status> statusesCollection = new List<Status>()
            {
                new Status {ID = 1, Name ="To do"},
                new Status {ID = 2, Name ="In Progress"},
                new Status {ID = 3, Name ="Done"}
            };

            using (var file = File.AppendText(pathsFile[2]))
            {
                foreach (var item in statusesCollection)
                {
                    file.WriteLine(JsonSerializer.Serialize<Status>(item));
                }
            }

            using (var file = File.AppendText(pathsFile[3]))
            {
                foreach (var item in roleCollection)
                {
                    file.WriteLine(JsonSerializer.Serialize<Role>(item));
                }
            }
        }

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="pathUser">Наименования файлов Json</param>
        /// <param name="newUser">Добавляемый пользователь</param>
        public static void AddNewUser(string pathUser, IdentificationData newUser)
        {
            using (var file = File.AppendText(pathUser)) 
            {
                file.WriteLine(JsonSerializer.Serialize<IdentificationData>(newUser));
            }
        }

        /// <summary>
        /// Добавление новой задачи
        /// </summary>
        /// <param name="pathTask">Наименования файлов Json</param>
        /// <param name="newTask">Добавляемая задача</param>
        public static void AddNewTask(string pathTask, Tasks newTask)
        {
            using (var file = File.AppendText(pathTask))
            {
                file.WriteLine(JsonSerializer.Serialize<Tasks>(newTask));
            }
        }

        public static List<IdentificationData> SearchUser( List<string> pathCollection)
        {
            List<IdentificationData> userCurrentUser = new List<IdentificationData>();

            using (var file = File.OpenText(pathCollection[1]))
            {
                string sJson;
                while ((sJson = file.ReadLine()) != null)
                {
                    userCurrentUser.Add(JsonSerializer.Deserialize<IdentificationData>(sJson));
                }
            }
            return userCurrentUser;
        }

        /// <summary>
        /// Поиск задач пользователя
        /// </summary>
        /// <param name="currentUser">Пользователь</param>
        /// <param name="pathCollection">Наименования файлов Json</param>
        /// <returns></returns>
        public static List<Tasks> SearchTaskUser(IdentificationData currentUser, List<string> pathCollection)
        {
            List<Tasks> taskCurrentUser = new List<Tasks>();

            using (var file = File.OpenText(pathCollection[1]))
            {
                string sJson;
                while ((sJson = file.ReadLine()) != null)
                {
                    Tasks itemTask = JsonSerializer.Deserialize<Tasks>(sJson);
                    if (itemTask.IDUser == currentUser.ID)
                    {
                        taskCurrentUser.Add(itemTask);
                    }
                }
            }
            return taskCurrentUser;
        }

        /// <summary>
        /// Список Статусов
        /// </summary>
        /// <param name="pathCollection">Наименования файлов Json</param>
        /// <returns></returns>
        public static List<Status> SearchStatus(List<string> pathCollection)
        {
            List<Status> statusCollection = new List<Status>();
            using (var file = File.OpenText(pathCollection[2]))
            {
                string sJson;
                while ((sJson = file.ReadLine()) != null)
                {
                    statusCollection.Add(JsonSerializer.Deserialize<Status>(sJson));                    
                }
            }
            return statusCollection;
        }

        /// <summary>
        /// Поиск Ролей
        /// </summary>
        /// <param name="pathCollection">Наименования файлов Json</param>
        /// <returns></returns>
        public static List<Role> SearchRole(List<string> pathCollection)
        {
            List<Role> roleCollection = new List<Role>();
            using (var file = File.OpenText(pathCollection[3]))
            {
                string sJson;
                while ((sJson = file.ReadLine()) != null)
                {
                    roleCollection.Add(JsonSerializer.Deserialize<Role>(sJson));
                }
            }
            return roleCollection;
        }

        /// <summary>
        /// Поиск логов изменения задач
        /// </summary>
        /// <param name="pathCollection">Наименования файлов Json</param>
        /// <returns></returns>
        public static List<StatusTasks> SearchStatusTask(List<string> pathCollection)
        {
            List<StatusTasks> statusTaskCollection = new List<StatusTasks>();
            try
            {
                using (var file = File.OpenText(pathCollection[4]))
                {
                    string sJson;
                    while ((sJson = file.ReadLine()) != null)
                    {
                        StatusTasks statusTask = JsonSerializer.Deserialize<StatusTasks>(sJson);
                        statusTaskCollection.Add(statusTask);
                        Console.WriteLine(statusTask.Date + " - " + statusTask.FIOUser + " изменил статус задачи " + statusTask.IDTask + " на " + statusTask.Status);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Файл пуст или не найден");
            }
            return statusTaskCollection;
        }

        /// <summary>
        /// Изменение статуса задач
        /// </summary>
        /// <param name="pathCollection">Наименования файлов Json</param>
        /// <param name="newStatusTask">Новая запись</param>
        public static void EditStatusTask(List<string> pathCollection, StatusTasks newStatusTask)
        {
            using (var file = File.AppendText(pathCollection[2]))
            {
                file.WriteLine(JsonSerializer.Serialize<StatusTasks>(newStatusTask));
            }
        }
    }
}
