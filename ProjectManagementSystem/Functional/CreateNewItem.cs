using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectManagementSystem
{
    public static class CreateNewItem
    {
        public static IdentificationData EnterDataUser(List<string> pathsFile)
        {
            IdentificationData newUser = new IdentificationData();

            if (File.ReadAllLines(pathsFile[0]).Length == 0)
            {
                newUser.ID = 1;
            }
            else
            {
                newUser.ID = File.ReadAllLines(pathsFile[0]).Length +1;
            }


            while (true)
            {
                Console.WriteLine("Введите логин:");
                newUser.Login = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(newUser.Login))
                {
                    Console.WriteLine("Логин не может быть пустым.");
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Введите пароль:");
                newUser.Password = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(newUser.Password))
                {
                    Console.WriteLine("Пароль не может быть пустым.");
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Введите фио:");
                newUser.UserFIO = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(newUser.UserFIO))
                {
                    Console.Clear();
                    Console.WriteLine("фио не может быть пустым.");
                }
                else
                {
                    break;
                }
            }
            return newUser;
        }
    
        public static Tasks EnterDataTask(List<string> pathsFile)
        {
            Tasks newTask = new Tasks();
            
            if(File.ReadAllLines(pathsFile[1]).Length == 0)
            {
                newTask.ID = 1;
            }
            else
            {
                newTask.ID = File.ReadAllLines(pathsFile[1]).Length + 1;
            }
            newTask.IDStatus = 1;
            while (true)
            {
                Console.WriteLine("Введите наименование задачи:");
                newTask.Name = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(newTask.Name))
                {
                    Console.Clear();
                    Console.WriteLine("Наименование не может быть пустым.");
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Введите описание задачи:");
                newTask.Description = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(newTask.Description))
                {
                    Console.Clear();
                    Console.WriteLine("Описание не может быть пустым.");
                }
                else
                {
                    break;
                }
            }

            List<IdentificationData> userCollection = new List<IdentificationData>();          
            using (var file = File.OpenText(pathsFile[0]))
            {
                string jsonItem;
                while ((jsonItem = file.ReadLine()) != null)
                {
                    Console.WriteLine("\nЗагрузка пользователей");
                    IdentificationData user = JsonSerializer.Deserialize<IdentificationData>(jsonItem);
                    if(user.Role == 2)
                    {
                        userCollection.Add(user);
                        Console.WriteLine(user.ID + " " + user.UserFIO);
                    }                  
                }
            }

            Console.WriteLine();

            if (userCollection.Count == 0)
            {
                Console.WriteLine("Стоит добавить сотрудника, некому присвоить задачу");
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Выберете по ID кому принадлежит задача:");
                    string idUser = Console.ReadLine();
                    Regex rNumber = new Regex("[0-9]{0, }");
                    if (rNumber.IsMatch(idUser))
                    {
                        try
                        {
                            IdentificationData selectUser = userCollection.Where(x => x.ID == Convert.ToInt32(idUser)).FirstOrDefault();
                            newTask.IDUser = selectUser.ID;
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Пользователь не найден");
                        }
                    }
                }
            }
            return newTask;
        }
    }
}
