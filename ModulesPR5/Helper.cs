using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModulesPR5.Models;

namespace ModulesPR5
{
    public class Helper
    {
        private static Entities _context;

        /// <summary>
        /// Возвращает экземпляр контекста базы данных, создавая его при первом обращении.
        /// </summary>
        /// <returns>Инициализированный контекст базы данных <see cref="Entities"/>.</returns>
        public static Entities GetContext()
        {
            if (_context == null)
            {
                _context = new Entities();
            }
            return _context;
        }
        
        /// <summary>
        /// Добавляет нового соискателя в базу данных.
        /// </summary>
        /// <param name="applicant">Модель соискателя, которую необходимо сохранить.</param>
        public static void CreateApplicants(Applicants applicant)
        {
            _context.Applicants.Add(applicant);
            _context.SaveChanges();
        }
        
        /// <summary>
        /// Обновляет данные существующего соискателя в базе данных.
        /// </summary>
        /// <param name="applicant">Модель соискателя с изменёнными данными.</param>
        public static void UpdateApplicants(Applicants applicant)
        {
            _context.Entry(applicant).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
        }
        
        /// <summary>
        /// Удаляет соискателя из базы данных по его идентификатору.
        /// </summary>
        /// <param name="idApplicant">Идентификатор соискателя, которого нужно удалить.</param>
        public static void RemoveApplicants(int idApplicant)
        {
            var users = _context.Applicants.Find(idApplicant);
            _context.Applicants.Remove(users);
            _context.SaveChanges();
        }
        
        /// <summary>
        /// Создаёт запись авторизации в базе данных и возвращает её идентификатор.
        /// </summary>
        /// <param name="auth">Модель авторизации, которую необходимо сохранить.</param>
        /// <returns>Идентификатор созданной записи авторизации.</returns>
        public static int CreateAuth(Auth auth)
        {
            _context.Auth.Add(auth);
            _context.SaveChanges();
            _context.Entry(auth).GetDatabaseValues();
            return auth.id;
        }
    }
}
