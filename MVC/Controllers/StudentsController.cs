using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVC.Models;
using MVC.Views;

namespace MVC.Controllers
{
    class StudentsController : IStudentsController
    {
        IStudentsView _view;
        public StudentsController(IStudentsView view)
        {
            _view = view;
        }

        Academy academy = new Academy();
        public IEnumerable<Student> GetStudents()
        {
            return academy.Students;
        }

        public void AddStudent()
        {

            var student = new Student
            {
                FirstName = _view.FirstName,
                LastName = _view.LastName,
                Group = _view.Group
            };

            academy.AddStudent(student);

            _view.AddStudentToList(student);
        }

        public void RemoveStudent()
        {
            var student = new Student
            {
                FirstName = _view.FirstName,
                LastName = _view.LastName,
                Group = _view.Group,
                Id = _view.Id
            };

            academy.RemoveStudent(student);
            _view.UpadateList(GetStudents());
        }

        public void EditStudent()
        {
            var student = new Student
            {
                FirstName = _view.FirstName,
                LastName = _view.LastName,
                Group = _view.Group,
                Id = _view.Id
            };
            academy.RemoveStudent(student.Id);
            academy.AddStudent(student);
            _view.UpadateList(GetStudents());
        }
    }
}
