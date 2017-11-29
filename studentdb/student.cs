using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentdb
{
    struct Student
    {
        public string name, surname;
        public int id,age;

        public static bool operator <(Student std1, Student std2)
        {
            return std1.age < std2.age;
        }

        public static bool operator >(Student std1, Student std2)
        {
            return std1.age > std2.age;
        }


    }


   /* struct Student2
    {
        public Dictionary<string, int> id;
        public Dictionary<string, string> name;
        public Dictionary<string, string> surname;
        public Dictionary<string, int> age;
    }*/
}
