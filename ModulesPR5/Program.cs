using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HashPasswords;
using ModulesPR5.Models;

namespace ModulesPR5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Создание новой учетной записи для соискателя");
            
            Console.WriteLine();
            
            Console.Write("Введите имя пользователя: ");
            string lastName = Console.ReadLine();
            Console.WriteLine();
            
            Console.Write("Введите фамилию пользователя: ");
            string firstName = Console.ReadLine();
            Console.WriteLine();
            
            Console.Write("Введите отчество пользователя (при наличии): ");
            string middleName = Console.ReadLine();
            Console.WriteLine();
            
            Console.Write("Введите логин пользователя: ");
            string login = Console.ReadLine();
            Console.WriteLine();
            
            Console.Write("Введите пароль пользователя: ");
            string password = Console.ReadLine();
            Console.WriteLine();

            string hashPassw = HashPassword.GetHashPassword(password);
            
            Console.WriteLine($"Хэшированный пароль пользователя: {hashPassw}");

            try
            {
                cadrAgEntities db = Helper.GetContext();
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}