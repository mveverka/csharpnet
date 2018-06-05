using students.Model;
using students.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace students.View
{
    /// <summary>
    /// Interaction logic for StudentListView.xaml
    /// </summary>
    public partial class StudentListView : UserControl
    {
        public StudentListView()
        {
            InitializeComponent();
        }


        private void creditSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lvUsers == null) return;
            int index = creditSelection.SelectedIndex;
            ICollectionView v = CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            if (index==0)
                v.Filter = null;
            else
            {
                v.Filter = o =>
                {
                    Student s = o as Student;
                    bool credit = (index == 1) ? true : false;
                    return (s.Credit == credit);
                };
            }
            /*if(DataContext!=null)
                ((StudentListViewModel)DataContext).selectWithCredit(index);*/
        }
    }
}
