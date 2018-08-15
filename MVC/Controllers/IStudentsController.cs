using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVC.Models;

namespace MVC.Controllers
{
    interface IStudentsController
    {
        IEnumerable<Student> GetStudents();
        void AddStudent();
        void RemoveStudent();
        void EditStudent();
    }
}
