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
        public static void CreateJsonFiles(List<string> pathsFile)
        {
            try
            {
                File.Create(pathsFile[0]).Close();             
                File.Create(pathsFile[1]).Close();
                File.Create(pathsFile[2]).Close();
                File.Create(pathsFile[3]).Close();
            }
            catch
            {
                Console.WriteLine("Файл данных не был создан");
            }
        }

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

        public static void AddNewUser(string pathUser, IdentificationData newUser)
        {
            using (var file = File.AppendText(pathUser)) 
            {
                file.WriteLine(JsonSerializer.Serialize<IdentificationData>(newUser));
            }
        }

        public static void AddNewTask(string pathTask, Tasks newTask)
        {
            using (var file = File.AppendText(pathTask))
            {
                file.WriteLine(JsonSerializer.Serialize<Tasks>(newTask));
            }

        }
    }
}
