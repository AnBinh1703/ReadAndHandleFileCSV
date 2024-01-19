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

        // version 1: read data from csv file

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

        
                //Calculate average math scores of candidates in a province
                public static double CalculateAverageMathScore(DataView csvData, string province)
                {
                    double sum = 0;
                    int count = 0;

                    int mathScoreColumnIndex = 3; // Replace with the actual column index of the math scores

                    foreach (DataRowView rowView in csvData)
                    {
                        DataRow row = rowView.Row;
                        if (row["Province"].ToString() == province)
                        {
                            if (double.TryParse(row[mathScoreColumnIndex].ToString(), out double mathScore))
                            {
                                sum += mathScore;
                                count++;
                            }
                        }
                    }

                    if (count > 0)
                    {
                        return sum / count;
                    }

                    return 0; // or any other value to indicate that there are no math scores available for the province
                }

        /* // Sort in descending order of average math score AND Calculate average math scores of candidates in a province
         public static Dictionary<string, double> CalculateAverageMathScores(DataView csvData)
         {
             Dictionary<string, double> averageMathScores = new Dictionary<string, double>();

             Dictionary<string, Tuple<double, int>> sumAndCountByProvince = new Dictionary<string, Tuple<double, int>>();

             foreach (DataRowView rowView in csvData)
             {
                 DataRow row = rowView.Row;
                 string province = row["Province"].ToString();

                 if (csvData.Table.Columns.Contains("MathScore")) // Check if the column exists
                 {
                     if (double.TryParse(row["MathScore"].ToString(), out double mathScore))
                     {
                         if (sumAndCountByProvince.ContainsKey(province))
                         {
                             Tuple<double, int> sumAndCount = sumAndCountByProvince[province];
                             double sum = sumAndCount.Item1 + mathScore;
                             int count = sumAndCount.Item2 + 1;
                             sumAndCountByProvince[province] = new Tuple<double, int>(sum, count);
                         }
                         else
                         {
                             sumAndCountByProvince[province] = new Tuple<double, int>(mathScore, 1);
                         }
                     }
                 }
             }

             foreach (var kvp in sumAndCountByProvince)
             {
                 double average = kvp.Value.Item1 / kvp.Value.Item2;
                 averageMathScores[kvp.Key] = average;
             }

             return averageMathScores;
         }*/
    }
}


        /* vERSON CODE 2
                //Calculate average math scores of candidates in a province
                public static double CalculateAverageMathScore(DataView csvData, string province)
                {
                    double sum = 0;
                    int count = 0;

                    int mathScoreColumnIndex = 3; // Replace with the actual column index of the math scores

                    foreach (DataRowView rowView in csvData)
                    {
                        DataRow row = rowView.Row;
                        if (row["Province"].ToString() == province)
                        {
                            if (double.TryParse(row[mathScoreColumnIndex].ToString(), out double mathScore))
                            {
                                sum += mathScore;
                                count++;
                            }
                        }
                    }

                    if (count > 0)
                    {
                        return sum / count;
                    }

                    return 0; // or any other value to indicate that there are no math scores available for the province
                }*/
    

//  version1; read and handle csv file.
/*  public static DataView GetCSVData(string path)
  {
      DataTable dataTable = new DataTable();
      TextFieldParser parser = new TextFieldParser(path);
      dataTable.Columns.Add("Province Code");
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
          string provinceCode = row[0].Length >= 2 ? row[0].Substring(0, 2) : row[0];

          dataTable.Rows.Add(provinceCode,row);
      }

      return dataTable.DefaultView;

  }
}
}
*/
