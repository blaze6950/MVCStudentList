using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVC.Models;

namespace MVC.Views
{
    interface IStudentsView
    {
        void AddStudentToList(Student student);
        //void RemoveStudentFromList(Student student);


        void ClearList();
        void UpadateList(IEnumerable<Student> students);

        string FirstName { get; set; }
        string LastName { get; set; }
        string Group { get; set; }
        int Id { get; }

    }
}
