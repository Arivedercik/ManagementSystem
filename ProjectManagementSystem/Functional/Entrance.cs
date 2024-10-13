using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagementSystem
{
    public static class Entrance
    {
        public static IdentificationData Authorization(string pathFile)
        {
            try
            {
                Console.WriteLine("Авторизация");

                IdentificationData currentUser = new IdentificationData();
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

                using (var file = File.OpenText(pathFile))
                {
                    string jsonItem;
                    while ((jsonItem = file.ReadLine()) != null)
                    {
                        IdentificationData user = JsonSerializer.Deserialize<IdentificationData>(jsonItem);
                        if (currentUser.Login== user.Login && currentUser.Password == user.Password)
                        {
                            return user;
                        }
                    }
                    Console.WriteLine("Пользователя не сущесвует");
                    return null;
                }
            }
            catch
            {
                Console.WriteLine("Файла не сущесвует");
                return null;
            }
        }

        public static void Registration(List<string> pathCollection)
        {
            IdentificationData newUser = CreateNewItem.EnterDataUser(pathCollection);
            WorkWithFile.AddNewUser(pathCollection[0], newUser);
        }
    }
}
