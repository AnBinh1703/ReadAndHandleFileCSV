using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadAndHandleFileCSV
{
    public class CSVData
    {

        public static DataView GetCSVData(string path)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Province Code");
            dataTable.Columns.Add("Test Score");

            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (fields.Length > 0)
                    {
                        string provinceCode = fields[0].Substring(0, 2);

                        for (int i = 1; i < fields.Length; i++)
                        {
                            string testScore = fields[i];
                            dataTable.Rows.Add(provinceCode, testScore);
                        }
                    }
                }
            }

            return dataTable.DefaultView;
        }
    }
}
// version 1: read data from csv file

/* public static DataView GetCSVData(string path)
 {
     DataTable dataTable = new DataTable();
     TextFieldParser parser = new TextFieldParser(path);
     parser.SetDelimiters(",");

     if (!parser.EndOfData)
     {
         var columns = parser.ReadFields();

         foreach (var col in columns)
         {
             dataTable.Columns.Add(col);
         }
     }

     while (!parser.EndOfData)
     {
         var row = parser.ReadFields();
         dataTable.Rows.Add(row);
     }

     return dataTable.DefaultView;

 }

}
}*/
