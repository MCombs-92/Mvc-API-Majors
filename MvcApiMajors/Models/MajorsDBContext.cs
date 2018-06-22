using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApiMajors.Models {
    public class MajorsDBContext : DbContext {

        public MajorsDBContext() : base() { }

        public DbSet<Major> Majors { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}