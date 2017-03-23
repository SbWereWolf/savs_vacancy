using System.Windows;
using DuckMigrationBL;

namespace DuckMigrationGui
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculatePathMapButton_Click(object sender, RoutedEventArgs e)
        {
            var rawRoadMap = string.Empty;

            if (RoadMapTextBox != null)
            {
                rawRoadMap = RoadMapTextBox.Text;
            }

            var pathMap = CalculatePathMap(rawRoadMap);

            if (PathMapTextBox != null)
            {
                PathMapTextBox.Text = pathMap;
            }
        }

        private string CalculatePathMap(string roadMap)
        {

            var busnessLogic = new BusinessLogic(roadMap);
            var pathMap = busnessLogic.CalculatePathMap();

            return pathMap;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (e != null)
            {
                e.Cancel = true;
            }
            this.Hide();
        }
    }
}
