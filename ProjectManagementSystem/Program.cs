using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static ProjectManagementSystem.UserOperations;


namespace ProjectManagementSystem
{

    internal class Program
    {
        const string PathJsonFileUsers = "Users.json";
        const string PathJsonFileTasks = "Tasks.json";
        const string PathJsonFileStatus = "Status.json";
        const string PathJsonFileRole = "Role.json";

        static void Main(string[] args)
        {
            List<string> pathCollection = new List<string>() { PathJsonFileUsers, PathJsonFileTasks, PathJsonFileStatus, PathJsonFileRole };
            IdentificationData currentUser;

            if (!File.Exists(PathJsonFileUsers))
            {
                WorkWithFile.CreateJsonFiles(pathCollection);
                WorkWithFile.WriteInJsonFiles(pathCollection);
                currentUser = CreateNewItem.EnterDataUser(pathCollection);
                currentUser.Role = 1;
                WorkWithFile.AddNewUser(PathJsonFileUsers, currentUser);
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Авторизация");
                    while (true)
                    {
                        currentUser = new IdentificationData();
                        while (true)
                        {
                            Console.WriteLine("Введите логин:");
                            currentUser.Login = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(currentUser.Login))
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
                            currentUser.Password = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(currentUser.Password))
                            {
                                Console.WriteLine("Пароль не может быть пустым.");
                            }
                            else
                            {
                                break;
                            }
                        }

                        if ((currentUser = Authorization.Entrance(currentUser.Login, currentUser.Password, PathJsonFileUsers)) != null)
                        {
                            break;
                        }
                    }
                    UserOperations actionUser = new UserOperations();
                    switch (currentUser.Role)
                    {
                        case 1:
                            actionUser.Admin(pathCollection);
                            break;
                        case 2:
                            actionUser.Emp(currentUser, pathCollection);
                            break;
                        default:
                            break;
                    }
                    Console.Clear();
                }
            }
        
            Console.ReadKey();
        }
    }
}
