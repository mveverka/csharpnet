using students.Model;
using students.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students.ViewModel
{
    class EditStudentViewModel : BindableBase
    {

        public Student Student { get; set; }
        private MainWindowViewModel MainViewModel;    
        public EditStudentViewModel(Student student, MainWindowViewModel mainViewModel)
        {
            this.MainViewModel = mainViewModel;
            this.Student = student;
            CancelCommand = new MyCommand(OnCancel);
            AddExamCommand = new MyCommand(AddExam);
            SaveCommand = new MyCommand(OnSave, CanSave);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e) { }
        public MyCommand AddExamCommand { get; private set; }
        public MyCommand CancelCommand { get; private set; }
        public MyCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private void AddExam(object property)
        {
            AddExamView window = new AddExamView((Student)property);
            window.ShowDialog();
        }

        private void OnCancel(object property) { Done(); }
        private void OnSave(object property) { Done(); }
        private bool CanSave(object property) { return Student.canSave(); }



    }
}
