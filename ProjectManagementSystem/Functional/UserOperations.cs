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
    public class UserOperations
    {
        private string answerUser;
        Regex rNumber = new Regex("^[0-9]");
        public void Admin(List<string> pathCollection)
        {
            while (true)
            {
                Console.WriteLine("Выберете дейсвия:\n1. Создание задачи\n2. Регистрация пользователя\n3. Выход");
                answerUser = Console.ReadLine();
                if (rNumber.IsMatch(answerUser))
                {
                    switch (answerUser)
                    {
                        case "1":
                            if (CreateNewItem.EnterDataTask(pathCollection) != null)
                            {
                                Tasks newTask = CreateNewItem.EnterDataTask(pathCollection);
                                WorkWithFile.AddNewTask(pathCollection[1], newTask);
                                Console.WriteLine("Задача была добавлена");
                            }
                            else
                            {
                                Console.WriteLine("Задача не загрузилась..");
                            }
                            break;
                        case "2":
                            if (CreateNewItem.EnterDataUser(pathCollection) != null)
                            {
                                IdentificationData newUser = CreateNewItem.EnterDataUser(pathCollection);
                                newUser.Role = 2;
                                WorkWithFile.AddNewUser(pathCollection[0], newUser);
                                Console.WriteLine("Пользователь был добавлен");
                            }
                            else
                            {
                                Console.WriteLine("Пользователь не загрузился..");
                            }
                            break;
                        case "3":
                            return;
                    }
                }
            }
        }

        public void Emp(IdentificationData currentUser, List<string> pathCollection)
        {
            while (true)
            {
                Console.WriteLine("Выберете дейсвия:\n1. Просмотр задач\n2. Изменение статуса задач\n3. Выход");
                answerUser = Console.ReadLine();
                if (rNumber.IsMatch(answerUser))
                {
                    switch (answerUser)
                    {
                        case "1":
                            ViewTask(currentUser, pathCollection);
                            break;
                        case "2":
                            EditTask(currentUser, pathCollection);
                            break;
                        case "3":
                            return;
                    }
                }
            }
        }
        public void ViewTask(IdentificationData currentUser, List<string> pathCollection)
        {
            List<Tasks> taskCurrentUser = WorkWithFile.SearchTaskUser(currentUser, pathCollection);
            string thisStatus = "to do";

            if (taskCurrentUser.Count == 0)
            {
                Console.WriteLine("У вас нет задач");                
            }
            else
            {
                Console.WriteLine("Задачи:");
                foreach (var itemTask in taskCurrentUser)
                {
                    using (var fileStatus = File.OpenText(pathCollection[2]))
                    {
                        string sJsonStatus;
                        if ((sJsonStatus = fileStatus.ReadLine()) != null)
                        {
                            Status itemStatus = JsonSerializer.Deserialize<Status>(sJsonStatus);
                            if (itemStatus.ID == itemTask.IDStatus)
                            {
                                thisStatus = itemStatus.Name;
                            }
                        }
                        Console.WriteLine(itemTask.ID + " " + itemTask.Name + " " + itemTask.Description + " " + thisStatus);
                    }
                }
            }            
        }
        public void EditTask(IdentificationData currentUser, List<string> pathCollection)
        {            
            while (true)
            {
                Console.Clear();  
                ViewTask(currentUser, pathCollection);    
                while (true)
                {
                    Console.WriteLine("Выберете задачу по ID");
                    string idTask = Console.ReadLine();
                    Regex rNumber = new Regex("^[0-9]{0,}");
                    if (rNumber.IsMatch(idTask))
                    {
                        try
                        {
                            Tasks selectTask = WorkWithFile.SearchTaskUser(currentUser, pathCollection).Where(x => x.ID == Convert.ToInt32(idTask)).FirstOrDefault();
                            while (true)
                            {
                                Console.WriteLine("Выберете новый статус по ID");
                                List<Status> statusCollection = WorkWithFile.SearchStatus(pathCollection);
                                foreach (var item in statusCollection)
                                {
                                    Console.WriteLine(item.ID + " " + item.Name);
                                }
                                string idStatus = Console.ReadLine();
                                if (rNumber.IsMatch(idStatus))
                                {
                                    selectTask.IDStatus = Convert.ToInt32(idStatus);
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Задача не найдена");
                        }
                    }
                }
            }
        }
    }
}
