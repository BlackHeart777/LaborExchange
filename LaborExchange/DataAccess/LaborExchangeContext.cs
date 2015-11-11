using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess
{
    public class LaborExchangeContext:DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Employer> Employers { get; set; }
        //public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
    }
}
