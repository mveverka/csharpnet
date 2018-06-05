using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students.Model
{
    public class Exam : INotifyPropertyChanged
    {

        private DateTime date;
        private int points;

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                RaisePropertyChanged("Date");
            }
        }

        public int Points
        {
            get { return points; }
            set
            {
                if (points != value && value>0)
                {
                    points = value;
                    RaisePropertyChanged("Points");

                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
