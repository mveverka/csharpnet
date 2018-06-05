using Microsoft.Win32;
using students.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students.ViewModel
{
    class MainWindowViewModel : BindableBase
    {

        public DBContext DBContext;

        public MainWindowViewModel()
        {
            DBContext = new DBContext();
            NavCommand = new MyCommand(OnNav);
            SaveCommand = new MyCommand(Save);
            LoadCommand = new MyCommand(Load);
            HTMLCommand = new MyCommand(ExportToHTML);
            studentListViewModel = new StudentListViewModel(this, DBContext.Students);
        }

        private StudentListViewModel studentListViewModel;
        private BindableBase _CurrentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyCommand NavCommand { get; private set; }
        public MyCommand SaveCommand { get; private set; }
        public MyCommand LoadCommand { get; private set; }
        public MyCommand HTMLCommand { get; private set; }

        private void OnNav(object destination)
        {
            switch (destination) {
                case "students":
                default:
                    CurrentViewModel = studentListViewModel;
                    break;
            }
        }

        private void Save(object property)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            string filename = null;
            if (fileDialog.ShowDialog() == true)
                filename = fileDialog.FileName;
            if(filename!=null)this.DBContext.SaveToXML(filename);
        }

        private void Load(object property)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string filename = null;
            if (openFileDialog.ShowDialog() == true)
                filename = openFileDialog.FileName;
            if(filename!=null)this.DBContext.LoadFromXML(filename);
        }

        private void ExportToHTML(object property)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            string filename = null;
            if (fileDialog.ShowDialog() == true)
                filename = fileDialog.FileName;
            if (filename != null) this.DBContext.ExportToHTML(filename);
        }

    }
}
