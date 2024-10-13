using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagementSystem
{
    public static class Authorization
    {
        public static IdentificationData Entrance(string login, string password, string pathFile)
        {
            try
            {
                using (var file = File.OpenText(pathFile))
                {
                    string jsonItem;
                    while ((jsonItem = file.ReadLine()) != null)
                    {
                        IdentificationData user = JsonSerializer.Deserialize<IdentificationData>(jsonItem);
                        if (login == user.Login && password == user.Password)
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
    }
}
