﻿using Microsoft.VisualBasic.FileIO;
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
}