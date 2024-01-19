using Microsoft.Win32;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReadAndHandleFileCSV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_ImportCSV(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Csv File| *.csv";
            if (openFile.ShowDialog() == true)
            {
                var csvData = CSVData.GetCSVData(openFile.FileName);
                CSVDataView.ItemsSource = csvData;
               
            }
        }

        private void Button_CalculateAverage(object sender, RoutedEventArgs e)
        {
            /* string province = ProvinceTextBox.Text;

             if (!string.IsNullOrEmpty(province) && csvData != null)
             {
                 Dictionary<string, double> averageMathScores = CSVData.CalculateAverageMathScores(csvData);

                 if (averageMathScores.ContainsKey(province))
                 {
                     double averageMathScore = averageMathScores[province];
                     MessageBox.Show($"Average Math Score for {province}: {averageMathScore}");
                 }
                 else
                 {
                     MessageBox.Show($"No math scores available for {province}");
                 }

                 // Sort the average math scores in descending order
                 var sortedScores = averageMathScores.OrderByDescending(kvp => kvp.Value);

                 // Display the sorted scores (for debugging purposes)
                 foreach (var kvp in sortedScores)
                 {
                     Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                 }
             }

 */
            string province = ProvinceTextBox.Text;

            if (!string.IsNullOrEmpty(province))
            {
                var csvData = CSVDataView.ItemsSource as DataView;
                double averageMathScore = CSVData.CalculateAverageMathScore(csvData, province);
                System.Windows.MessageBox.Show($"Average Math Score for {province}: {averageMathScore}");
            }
        }

        private void Button_Calculate_All (object sender, RoutedEventArgs e)
        {
            ProvindeAverage provindeAverageWindow = new ProvindeAverage();
            provindeAverageWindow.Show();
        }
    }

    }
/* vERSON CODE 2
       //Calculate average math scores of candidates in a province
       /*private void Button_CalculateAverage(object sender, RoutedEventArgs e)
       {
           string province = ProvinceTextBox.Text;

           if (!string.IsNullOrEmpty(province))
           {
               var csvData = CSVDataView.ItemsSource as DataView;
               double averageMathScore = CSVData.CalculateAverageMathScore(csvData, province);
               MessageBox.Show($"Average Math Score for {province}: {averageMathScore}");
           }
       }*/