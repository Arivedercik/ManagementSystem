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
        //Имена файлов
        const string PathJsonFileUsers = "Users.json";
        const string PathJsonFileTasks = "Tasks.json";
        const string PathJsonFileStatus = "Status.json";
        const string PathJsonFileRole = "Role.json";
        const string PathJsonFileStatistics = "Statistics.json";

        static void Main(string[] args)
        {
            List<string> pathCollection = new List<string>() { PathJsonFileUsers, PathJsonFileTasks, PathJsonFileStatus, PathJsonFileRole };
            IdentificationData currentUser;

            //Проверка первого запуска
            if (!File.Exists(PathJsonFileUsers))
            {
                Console.WriteLine("Первый вход: Регистрация управляющего");
                WorkWithFile.CreateJsonFiles(pathCollection);
                WorkWithFile.WriteInJsonFiles(pathCollection);                
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Авторизация\n2. Регистрация");
                string answer = Console.ReadLine();
                switch(answer)
                {
                    case "1":
                        currentUser = Entrance.Authorization(pathCollection[0]);
                        if (currentUser != null)
                        {
                            Console.Clear();
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
                        }
                        break;
                    case "2":
                        Entrance.Registration(pathCollection);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }          
        }
     }
}
