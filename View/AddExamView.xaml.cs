using students.Model;
using students.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace students.View
{
    /// <summary>
    /// Interaction logic for AddExamView.xaml
    /// </summary>
    public partial class AddExamView : Window
    {

        public AddExamView(Student student)
        {
            InitializeComponent();
            AddExamViewModel vm = new AddExamViewModel(student, this);
            DataContext = vm;
            Owner = Application.Current.MainWindow;
        }
    }
}
