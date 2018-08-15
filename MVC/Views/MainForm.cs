using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MVC.Models;
using MVC.Controllers;

namespace MVC.Views
{
    enum Action
    {
        add,
        edit,
        remove
    }

    public partial class MainForm : Form, IStudentsView
    {
        private Action _action;
        IStudentsController controller;
        public MainForm()
        {
            InitializeComponent();

            controller = new StudentsController(this);

            listBox.DisplayMember = "LastName";
            listBox.ValueMember = "Id";
        }

        public void AddStudentToList(Student student)
        {
            listBox.Items.Add(student);
        }

        public void ClearList()
        {
            listBox.Items.Clear();
        }

        public void UpadateList(IEnumerable<Student> students)
        {
            listBox.Items.Clear();
            foreach (Student st in students)
            {
                listBox.Items.Add(st);
            }
        }

        public string FirstName
        {
            get
            {
                return firstNameTB.Text;
            }
            set
            {
                firstNameTB.Text = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastNameTB.Text;
            }
            set
            {
                lastNameTB.Text = value;
            }
        }

        public string Group
        {
            get
            {
                return groupTB.Text;
            }
            set
            {
                groupTB.Text = value;
            }
        }

        public int Id
        {
            get { return ((Student) listBox.SelectedItem).Id; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            switch (_action)
            {
                case Action.add:
                    controller.AddStudent();
                    break;
                case Action.edit:
                    controller.EditStudent();
                    break;
                case Action.remove:
                    controller.RemoveStudent();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            groupBox.Enabled = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _action = Action.add;
            groupBox.Enabled = true;
            FirstName = String.Empty;
            LastName = String.Empty;
            Group = String.Empty;
        }
        
        private void listBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                removeButton.Enabled = true;
                editButton.Enabled = true;
                FirstName = ((Student)listBox.SelectedItem).FirstName;
                LastName = ((Student) listBox.SelectedItem).LastName;
                Group = ((Student) listBox.SelectedItem).Group;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            _action = Action.edit;
            groupBox.Enabled = true;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            _action = Action.remove;
            DialogResult result = MessageBox.Show("Are you sure?", "Remove", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (result == DialogResult.OK)
            {
                okButton_Click(sender, EventArgs.Empty);
            }
            else
            {
                cancelButton_Click(sender, EventArgs.Empty);
            }
            FirstName = String.Empty;
            LastName = String.Empty;
            Group = String.Empty;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            switch (_action)
            {
                case Action.add:
                    FirstName = String.Empty;
                    LastName = String.Empty;
                    Group = String.Empty;
                    listBox_SelectedValueChanged(sender, EventArgs.Empty);
                    break;
                case Action.edit:
                    listBox_SelectedValueChanged(sender, EventArgs.Empty);
                    break;
                case Action.remove:
                    controller.RemoveStudent();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            groupBox.Enabled = false;
        }
    }
}
