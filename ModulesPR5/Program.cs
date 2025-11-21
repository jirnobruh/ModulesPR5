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
            int status;
            
            Console.WriteLine("Создание новой учетной записи для соискателя");
            
            Console.WriteLine();
            
            Console.Write("Введите имя пользователя: ");
            string lastName = Console.ReadLine();
            
            Console.Write("Введите фамилию пользователя: ");
            string firstName = Console.ReadLine();
            
            Console.Write("Введите отчество пользователя (при наличии): ");
            string middleName = Console.ReadLine();
            
            Console.Write("Введите электронную почту пользователя: ");
            string email = Console.ReadLine();
            
            Console.Write("Введите номер телефона пользователя: ");
            string phone = Console.ReadLine();
            
            Console.WriteLine("Введите цифру статуса пользователя пользователя: ");
            Console.WriteLine("1 - безработный");
            Console.WriteLine("2 - трудоустроен");
            try
            {
                status = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}");
                Console.WriteLine("Введите цифру статуса пользователя пользователя: ");
                Console.WriteLine("1 - безработный");
                Console.WriteLine("2 - трудоустроен");
                status = int.Parse(Console.ReadLine());
            }
            
            Console.Write("Введите дату рождения (гггг-мм-дд): ");
            DateTime birthDate;
            while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                Console.Write("Неверный формат даты. Введите дату рождения (гггг-мм-дд): ");
            }
            
            Console.Write("Введите логин пользователя: ");
            string login = Console.ReadLine();
            
            Console.Write("Введите пароль пользователя: ");
            string password = Console.ReadLine();

            string hashPassw = HashPassword.GetHashPassword(password);
            
            Console.WriteLine($"Хэшированный пароль пользователя: {hashPassw}");

            try
            {
                Entities db = Helper.GetContext();
                
                Auth newAuth = new Auth
                {
                    login = login,
                    password = hashPassw,
                    role_id = 1
                };
                
                int authId = Helper.CreateAuth(newAuth);
                Console.WriteLine($"Создана запись аутентификации с ID: {authId}");
                
                Applicants newApplicant = new Applicants
                {
                    last_name = lastName,
                    first_name = firstName,
                    middle_name = string.IsNullOrEmpty(middleName) ? null : middleName,
                    birth_date = birthDate,
                    email = email,
                    phone = phone,
                    status_id = status,
                    auth_id = authId
                };

                // Добавляем в базу данных
                Helper.CreateApplicants(newApplicant);
                
                Console.WriteLine("Соискатель успешно создан!");
                Console.WriteLine($"ID нового соискателя: {newApplicant.id}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}