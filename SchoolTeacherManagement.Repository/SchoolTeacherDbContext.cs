using Microsoft.EntityFrameworkCore;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTeacherManagement.Repository
{
    public class SchoolTeacherDbContext:DbContext
    {
        public SchoolTeacherDbContext()
        {

        }
        public SchoolTeacherDbContext(DbContextOptions<SchoolTeacherDbContext>options)
            :base(options)
        {

        }
        public DbSet<School> Schools { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subjects> Subjetcs { get; set; }
    }
}
