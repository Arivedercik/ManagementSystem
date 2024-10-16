﻿using ProjectManagementSystem.Model;
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
    /// <summary>
    /// Создание элементов базы данных
    /// </summary>
    public static class CreateNewItem
    {
        /// <summary>
        /// Проверка ввода на null
        /// </summary>
        /// <param name="input">Проверяемая строка</param>
        /// <returns>Проверяемая строка</returns>
        public static string RepeatField(string input)
        {
            string strInput;

            while (true)
            {
                Console.WriteLine("Введите "+input);
                strInput = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(strInput))
                {
                    Console.WriteLine(input+" не может быть пустым.");
                }
                else
                {
                    break;
                }
            }

            return strInput;
        }

        /// <summary>
        /// Создание пользователя (ввод данных)
        /// </summary>
        /// <param name="pathCollection">Наименования файлов Json</param>
        /// <returns>Новый пользователь</returns>
        public static IdentificationData EnterDataUser(List<string> pathCollection)
        {
            IdentificationData newUser = new IdentificationData();

            if (File.ReadAllLines(pathCollection[0]).Length == 0)
            {
                newUser.ID = 1;
            }
            else
            {
                newUser.ID = File.ReadAllLines(pathCollection[0]).Length +1;
            }

            while (true)
            {
                newUser.Login = RepeatField("логин");
                int flag = 0;

                foreach(var item in WorkWithFile.SearchUser(pathCollection))
                {
                    if(newUser.Login == item.Login)
                    {
                        Console.WriteLine("Такой логин уже существует. Измените логин");
                        flag = 1;

                        break;
                    }                    
                }

                if (flag == 0)
                {
                    break;
                }
            }
            
            newUser.Password = RepeatField("пароль");
            newUser.UserFIO = RepeatField("фио");
          
            while (true)
            {
                Console.WriteLine("Выберете роль: ");

                foreach(var item in WorkWithFile.SearchRole(pathCollection))
                {
                    Console.WriteLine(item.ID + ". " + item.Name);
                }

                string idRole = Console.ReadLine();

                if(new Regex("^[0-9]").IsMatch(idRole))
                {
                    newUser.Role = Convert.ToInt32(idRole);

                    break;
                }
                else
                {
                    Console.WriteLine("Роль не определена");
                }
            }
            
            return newUser;
        }

        /// <summary>
        /// Создание задач (ввод данных)
        /// </summary>
        /// <param name="pathCollection">Наименования файлов Json</param>
        /// <returns>Новая задача</returns>
        public static Tasks EnterDataTask(List<string> pathCollection)
        {
            Tasks newTask = new Tasks();
            
            if(File.ReadAllLines(pathCollection[1]).Length == 0)
            {
                newTask.ID = 1;
            }
            else
            {
                newTask.ID = File.ReadAllLines(pathCollection[1]).Length + 1;
            }

            newTask.IDStatus = 1;
            newTask.Name = RepeatField("Наименование задачи");
            newTask.Description = RepeatField("Описание задачи");
           
            List<IdentificationData> userCollection = new List<IdentificationData>();    
            
            using (var file = File.OpenText(pathCollection[0]))
            {
                string jsonItem;
                Console.WriteLine("\nЗагрузка пользователей");

                while ((jsonItem = file.ReadLine()) != null)
                {
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

                return null;
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Выберете по ID кому принадлежит задача:");
                    string idUser = Console.ReadLine();
                    Regex rNumber = new Regex("^[0-9]{0,}");

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
