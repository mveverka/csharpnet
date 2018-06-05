using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Serialization;

namespace students.Model
{
    public class Student : INotifyPropertyChanged, IDataErrorInfo
    {

        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    RaisePropertyChanged("FirstName");
                    RaisePropertyChanged("FullName");
                }
            }
        }

        public string LastName { get { return lastName; } set
            {
                if (lastName != value)
                {
                    lastName = value;
                    RaisePropertyChanged("LastName");
                    RaisePropertyChanged("FullName");
                }
            }

        }
        public string FullName { get
            {
                return FirstName + " " + LastName;
            }
        }

        [XmlIgnore]
        public bool Credit
        {
            get { return hasCredit(); }
        }

        private bool hasCredit()
        {
            int minCreditPoints = Int32.Parse(ConfigurationManager.AppSettings["MinCreditPoints"]);
            int credits = 0;
            foreach (HomeWork w in HomeWorks)
            {
                credits += w.Points;
            }
            if (credits > minCreditPoints) return true;
            return false;
        }

        public Student()
        {
            HomeWorks = new ObservableCollection<HomeWork>();
            HomeWorks.CollectionChanged += HomeWorks_CollectionChanged;
            Exams = new ObservableCollection<Exam>();
        }

        private void HomeWorks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("Credit");
        }

        public ObservableCollection<Exam> Exams { get; set; }
            
        public ObservableCollection<HomeWork> HomeWorks { get; set; }
        public string Error => throw new NotImplementedException();

        public string this[string columnName] => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public bool canSave()
        {
            return true;
        }

    }
}
