using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectManagementSystem
{
    public class UserOperations
    {
        public void Admin(List<string> pathsFile)
        {           
            string answerUser;
            Regex rNumber = new Regex("^[0-9]");
            while (true)
            {
                Console.Clear();
               
                while (true)
                {
                    Console.WriteLine("Выберете дейсвия:\n1. Создание задачи\n2. Регистрация пользователя\n3. Выход");
                    answerUser = Console.ReadLine();
                    if (rNumber.IsMatch(answerUser))
                    {
                        switch (answerUser)
                        {
                            case "1":
                                Tasks newTask = CreateNewItem.EnterDataTask(pathsFile);
                                WorkWithFile.AddNewTask(pathsFile[1], newTask);
                                Console.WriteLine("Задача была добавлена");
                                break;
                            case "2":
                                IdentificationData newUser =  CreateNewItem.EnterDataUser(pathsFile);
                                newUser.Role = 2;
                                WorkWithFile.AddNewUser(pathsFile[0], newUser);
                                Console.WriteLine("Пользователь был добавлен");
                                break;
                            case "3":
                                break;
                        }
                    }
                }
            }
        }

        public void Emp()
        {

        }
    }
}
