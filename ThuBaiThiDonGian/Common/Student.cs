using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Student
    {
        public string ID { get; set; }
        public string FristName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return LastName + " " + FristName; } }

        public string FullNameAndId { get { return ID + "-" + LastName + " " + FristName; } }

        public Student()
        {

        }
        public Student(string iD,string fristName,string lastName)
        {
            this.ID = iD;
            this.FristName = fristName;
            this.LastName = lastName;


        }
    }
}
