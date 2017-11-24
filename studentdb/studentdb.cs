using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentdb
{
    class Studentdb : iDatabase
    {
        public Student[] tab1;
        public ArrayList tab2;

        private int _tableSize = 0;

        public string dbName = "";


        public Studentdb(string name)
        {
            this.dbName = name;

            this.tab2 = new ArrayList();
        }


        public Studentdb(string name, int size)
        {
            this.dbName = name;

            this._tableSize = size;

            this.tab1 = new Student[size];
            this.tab2 = new ArrayList();
        }

        public Dictionary<string, object> addRow(string tableName, Student data)
        {
            switch (tableName)
            {
                case "tab1":
                    return this.fillTab1(data);
                    break;

                case "tab2":
                    return this.fillTab2(data);
                    break;
                default:
                    return null;


            }
        }


       

       private Boolean toSort(object tb)
        {
            Boolean result = false;

            string nieco = tb.GetType().ToString();

            if (nieco == "studentdb.Student[]")
            {
                Student[] data = (Student[])tb;

                int count = data.Length;

                for (int i=0; i < count - 1; i++)
                {
                    if (data[i].age > data[i + 1].age)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }



        public Boolean bubleSort(object tab)
        {

           // db2 = this.tab1.Clone();

            if (!this.toSort(tab))
            {
                return false;
            }

            int size = 0;

            if (tab.GetType().ToString().IndexOf("Student[]") != -1)
            {
                size = this.tab1.Length;
                
                for (int i = 0; i < size - 1; i++)
                {
                    for (int j = 0; j < size - i - 1; j++)
                    {
                        if (this.tab1[j + 1].age < this.tab1[j].age)
                        {
                            var tmp = this.tab1[j + 1];
                            this.tab1[j + 1] = this.tab1[j];
                            this.tab1[j] = tmp;
                        }
                    }
                }

            }
               
          

           return true;
            
        }

        


        private Dictionary<string,object> fillTab2(Student data)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            this.tab2.Add(data);
            result.Add("status", true);

            return result;
            
        }


        private Dictionary<string,object> fillTab1(Student data)
        {
           

            Dictionary<string, object> result = new Dictionary<string, object>();

            try
            {
                if (this._tableSize == 0)
                {
                    throw new Exception("Tab1 has to have declared size, becuase it is of type Array");
                }


                if (data.id > this._tableSize-1)
                {
                    throw new Exception("Size of array is max " + this._tableSize.ToString());
                }

                this.tab1[data.id] = data;

                result.Add("status", true);
            }
            catch (Exception ex)
            {
                result.Add("status", false);
                result.Add("error", ex.ToString());

            }

            return result;
        }





    }
}
