using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.IO;
using System.Data;

namespace ReadAndHandleFileCSV
{
    /// <summary>
    /// Interaction logic for ProvindeAverage.xaml
    /// </summary>
    public partial class ProvindeAverage : Window
    {
        public ProvindeAverage()
        {
            InitializeComponent();
        }
        Dictionary<String, ExcelRecordStructure> map;

        public class DataGridViewModel
        {
            public String ProvinceId { get; set; }
            public String ProvinceName { get; set; }
            public Double AverageMark { get; set; }
        }

        static DataTable ReadCsvFile(string filePath)
        {
            DataTable dataTable = new DataTable();
            ExcelRecordStructure excelRecordStructure = new ExcelRecordStructure();

            // Sử dụng StreamReader để đọc tệp CSV
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Đọc tiêu đề cột và thêm cột vào DataTable
                string[] headers = reader.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header.Trim());
                }

                // Đọc dữ liệu từ các dòng còn lại và thêm vào DataTable
                while (!reader.EndOfStream)
                {
                    string[] fields = reader.ReadLine().Split(',');
                    DataRow row = dataTable.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        row[i] = fields[i].Trim();
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }

        private List<DataGridViewModel> ConvertCsvToModel(String path)
        {
            List<ExcelRecordStructure> list = new List<ExcelRecordStructure>();
            DataTable dataTable = ReadCsvFile(path);

            map = new Dictionary<string, ExcelRecordStructure>();

            int column = 0;
            string province = "";
            foreach (DataRow row in dataTable.Rows)
            {
                column = 0;
                int count = 0;
                double mark = 0;

                foreach (var item in row.ItemArray)
                {
                    ++column;
                    if (column == 2)
                    {
                        province = item.ToString();
                    }
                    if (column > 2 && province != "")
                    {

                        if (!map.ContainsKey(province))
                            map.Add(province, new ExcelRecordStructure { Count = 0, TotalMark = 0 });

                        if (item != null && item.ToString() != "")
                        {
                            mark += Convert.ToDouble((item.ToString() == "") ? 0 : item);
                            ++count;
                        }
                    }
                }
                map[province].TotalMark += (mark);
                map[province].Count += count;
            }

            List<DataGridViewModel> dgvList = new List<DataGridViewModel>();

            foreach (var item in map.Keys)
            {
                double totalMark = map[item].TotalMark;
                int count = map[item].Count;
                dgvList.Add(new DataGridViewModel
                {
                    ProvinceName = item.ToString(),
                    AverageMark = (map[item].Count == 0) ? 0 : map[item].TotalMark / map[item].Count
                }
                );
            }

            return dgvList.OrderByDescending(i => i.AverageMark).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            //FolderBrowserDialog dialog = new FileBrowserDialog();

            // DialogResult result = dialog.ShowDialog();
            bool? result = dialog.ShowDialog();

            /*if (result == System.Windows.Forms.DialogResult.OK)
            {
                String filePath = dialog.FileName;

                txtFolderPath.Text = filePath;

                dgvData.ItemsSource = ConvertCsvToModel(filePath);
            }*/
            if (result == true)  // Change here: Use 'true' instead of 'System.Windows.Forms.DialogResult.OK'
            {
                String filePath = dialog.FileName;

                txtFolderPath.Text = filePath;

                dgvData.ItemsSource = ConvertCsvToModel(filePath);
            }
        }
    }

}
