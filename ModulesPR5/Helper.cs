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

        public static Entities GetContext()
        {
            if (_context == null)
            {
                _context = new Entities();
            }
            return _context;
        }
        
        public static void CreateApplicants(Applicants applicant)
        {
            _context.Applicants.Add(applicant);
            _context.SaveChanges();
        }
        
        public static void UpdateApplicants(Applicants applicant)
        {
            _context.Entry(applicant).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
        }
        
        public static void RemoveApplicants(int idApplicant)
        {
            var users = _context.Applicants.Find(idApplicant);
            _context.Applicants.Remove(users);
            _context.SaveChanges();
        }
        
        public static int CreateAuth(Auth auth)
        {
            _context.Auth.Add(auth);
            _context.SaveChanges();
            _context.Entry(auth).GetDatabaseValues();
            return auth.id;
        }
    }
}
