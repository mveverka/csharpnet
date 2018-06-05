using students.Model;
using students.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students.ViewModel
{
    class AddExamViewModel
    {

        public Student Student { get; set; }
        private AddExamView window;
        public Exam Exam { get; set; }

        public AddExamViewModel(Student student, AddExamView window)
        {
            this.Student = student;
            this.Exam = new Exam();
            this.window = window;
            this.SaveCommand = new MyCommand(SaveExam);
            this.CancelCommand = new MyCommand(Cancel);
        }

        public MyCommand SaveCommand { get; set; }

        public void SaveExam(object property)
        {
            Student.Exams.Add(Exam);
            this.window.Close();
        }

        public MyCommand CancelCommand { get; set; }

        public void Cancel(object property)
        {
            this.window.Close();
        }

    }
}
