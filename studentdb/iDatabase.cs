using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentdb
{
    interface iDatabase
    {
        Dictionary<string, object> addRow(string tableName, Student data);

        //Boolean bubleSort(string tableName);
    }
}
