using MvcApiMajors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApiMajors.Controllers
{
    public class StudentsController : ApiController {

        private MajorsDBContext db = new MajorsDBContext();

        [HttpGet]
        [ActionName("List")]
        public IEnumerable<Student> List() {
            return db.Students.ToList();
        }

        [HttpGet]
        [ActionName("Get")]
        public Student Get(int? id) {
            if (id == null) {
                return null;
            }
            return db.Students.Find(id);

        }

        [HttpPost]
        [ActionName("Create")]
        public bool Create(Student student) {
            if (student == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            db.Students.Add(student);
            db.SaveChanges();
            return true;

        }

        [HttpPost]
        [ActionName("Change")]
        public bool Change(Student student) {
            if (student == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            var stud = db.Students.Find(student.Id);
            stud.MajorId = student.MajorId;
            stud.Name = student.Name;
            stud.Sat = student.Sat;
            db.SaveChanges();
            return true;
        }

        [HttpPost]
        [ActionName("Remove")]
        public bool Remove(Student student) {
            if (student == null) {
                return false;
            }
            if (!ModelState.IsValid) {
                return false;
            }
            var stud = db.Students.Find(student.Id);
            db.Students.Remove(stud);
            db.SaveChanges();
            return true;

        }

    }
}
