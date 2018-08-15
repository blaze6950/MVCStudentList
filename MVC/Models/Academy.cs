using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models
{
    class Academy
    {
        List<Student> students = new List<Student>();
        int counter = 0;

        public void AddStudent(Student student)
        {
            counter++;
            student.Id = counter;
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(students.Find(studentItem =>
                {
                    return studentItem.FirstName == student.FirstName && studentItem.LastName == student.LastName &&
                           studentItem.Group == student.Group && studentItem.Id == student.Id;
                }));
            
        }

        public void RemoveStudent(int id)
        {
            students.Remove(students.Find(studentItem =>
            {
                return studentItem.Id == id;
            }));

        }

        public IEnumerable<Student> Students
        {
            get
            {
                return students;
            }
        }
    }
}
