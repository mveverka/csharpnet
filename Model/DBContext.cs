using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace students.Model
{
    class DBContext
    {

       public ObservableCollection<Student> Students { get; private set; }

        public DBContext()
        {
            this.Students = new ObservableCollection<Student>();
            initFill();
        }

        private void initFill()
        {
            Student s1 = new Student { FirstName = "John", LastName = "Shepard" };
            s1.Exams.Add(new Exam { Date = new DateTime(), Points = 10 });
            s1.HomeWorks.Add(new HomeWork { Name = "Du1", Comment = "ok", Points = 20 });
            Students.Add(s1);
            Students.Add(new Student { FirstName = "Emily", LastName = "Rakowski" });
            Students.Add(new Student { FirstName = "Candice", LastName = "Washington" });
        }

        public void SaveToXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Student>));
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, Students);
            }
        }

        public void LoadFromXML(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ObservableCollection<Student>));
            using (TextReader reader = new StreamReader(path)) {
                object obj = deserializer.Deserialize(reader);
                ObservableCollection<Student> readStudents = (ObservableCollection<Student>)obj;
                foreach(Student s in readStudents){
                    Students.Add(s);
                }
            }
        }

        public void ExportToHTML(string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<title>Studenti</title>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            foreach(Student s in Students)
            {
                sb.AppendLine("<h3>" + s.FullName + "</h3>");
                string credit = (s.Credit) ? "ano" : "ne";
                sb.Append("<span>Zapocet: "+ credit+"</span>");
            }
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");
            using(TextWriter writer = new StreamWriter(path))
            {
                writer.Write(sb.ToString());
            }
        }

    }
}
