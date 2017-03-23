using System;
using System.Windows;

namespace Menu
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DuckMigrationGui.MainWindow DuckMigrationWindow { get; set; }

        private AlienLanguageGui.MainWindow AlienLanguageWindow { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DuckMigrationWindow = null;
            AlienLanguageWindow = null;
        }

        private void ShowAlienLanguageButton_Click(object sender, RoutedEventArgs e)
        {
            if (AlienLanguageWindow == null )
            {
                AlienLanguageWindow = new AlienLanguageGui.MainWindow();
            }

            AlienLanguageWindow.Show();
        }

        private void ShowDuckMigrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (DuckMigrationWindow == null)
            {
                DuckMigrationWindow = new DuckMigrationGui.MainWindow();
            }

            DuckMigrationWindow.Show();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Application.Current != null)
            {

                AlienLanguageWindow = null;
                DuckMigrationWindow = null;

                Application.Current.Shutdown();
            }
        }
    }
}
