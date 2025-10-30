using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModulesPR5.Models;

namespace ModulesPR5
{
    internal class Helper
    {
        private static cadrAgEntities _context;

        public static cadrAgEntities GetContext()
        {
            if (_context == null)
            {
                _context = new cadrAgEntities();
            }
            return _context;
        }
        
        public void CreateApplicants(Applicants applicant)
        {
            _context.Applicants.Add(applicant);
            _context.SaveChanges();
        }
        
        public void UpdateApplicants(Applicants applicant)
        {
            _context.Entry(applicant).State = System.Data.EntityState.Modified;
            _context.SaveChanges();
        }
        
        public void RemoveApplicants(int idApplicant)
        {
            var users = _context.Applicants.Find(idApplicant);
            _context.Applicants.Remove(users);
            _context.SaveChanges();
        }
    }
}
