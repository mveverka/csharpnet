using students.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students.ViewModel
{
    class StudentListViewModel : BindableBase
    {

        public MyCommand EditCommand { get; private set; }

        private MainWindowViewModel MainViewModel;

        public StudentListViewModel(MainWindowViewModel mainViewModel, ObservableCollection<Student> students)
        {
            this.MainViewModel = mainViewModel;
            EditCommand = new MyCommand(Edit);
            this.Students = students;
            //SelectedStudents = new ObservableCollection<Student>();
            //initSelectedStudents();
        }

        public ObservableCollection<Student> Students { get; set; }
        //public ObservableCollection<Student> SelectedStudents { get; set; }

        /*private void initSelectedStudents()
        {
            foreach (Student st in Students)
            {
                SelectedStudents.Add(st);
            }
        }*/

        private void Edit(object parameter)
        {
            Student s = null;
            foreach(Student st in Students)
            {
                if (st.FullName.Equals((string)parameter))
                {
                    s = st;
                }
            }

            if (s != null) this.MainViewModel.CurrentViewModel = new EditStudentViewModel(s, this.MainViewModel);
        }

        public void selectWithCredit(int credit)
        {
            /*switch (credit)
            {
                case 0:
                default:
                    AddItems(Students);
                    break;
                case 1:
                    AddItems(new ObservableCollection<Student>(from student in Students where student.Credit == true select student));
                    break;
                case 2:
                    AddItems(new ObservableCollection<Student>(from student in Students where student.Credit == false select student));
                    break;
            }*/
        }

        /*public void AddItems(ObservableCollection<Student> selected)
        {
            SelectedStudents.Clear();
            foreach (Student s in selected)
                SelectedStudents.Add(s);
        }*/


    }
}
