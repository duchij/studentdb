using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentdb
{
    class Program
    {
        private static string[] names;
        private static string[] surnames;


        static void Main(string[] args)
        {

            Program.loadData();

            Studentdb db = new Studentdb("databaz", 10);

            Student student = new Student();

            Dictionary<string, object> res = null;
            Random rand = new Random();

            for (int i=0; i<10; i++)
            {
                student.id = i;
                student.name = Program.names[rand.Next(0,4)];
                student.surname = Program.surnames[rand.Next(0, 4)];
                student.age = rand.Next(15, 80);

                res =  db.addRow("tab1", student);

                if (res == null)
                {
                    Console.WriteLine("unknown table");
                    Console.ReadKey();
                    return;
                    
                }
                if (!(Boolean)res["status"])
                {
                    Console.WriteLine("Error: " + res["error"].ToString());
                    Console.ReadKey();
                    return;
                }

                res = db.addRow("tab2", student);
            }

            int count = db.tab1.Length;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Name: {0}, Surname: {1}, Age: {2}", db.tab1[i].name, db.tab1[i].surname, db.tab1[i].age);
            }

            // var nico = db.tab1.Clone();
            // object dt = new object(); ; 

            //Student[] nieco = db.tab1.Clone();

            
           
            if (!db.bubleSort(db.tab1))
            {
                Console.WriteLine("Nie je nutne sortovat !!!");
                Console.ReadKey();
                return;
            }

          //  db.tab1[2].age > 

            Console.WriteLine("Je nutne Sortovat....");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Name: {0}, Surname: {1}, Age: {2}", db.tab1[i].name, db.tab1[i].surname, db.tab1[i].age);
            }

            Console.ReadKey();

            Student[] nieco = (Student[])db.tab2.ToArray(typeof(Student));

            Console.ReadKey();


        }

        protected static void loadData()
        {
            StreamReader sr = new StreamReader(@"../../names.txt");
            string data = sr.ReadToEnd();

            string[] tmp = data.Split('|');

            Program.names = tmp[0].Split(',');
            Program.surnames = tmp[1].Split(',');


        }
    }
}
