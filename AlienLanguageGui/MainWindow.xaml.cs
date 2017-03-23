using System.Windows;
using AlienLanguageBL;

namespace AlienLanguageGui
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateNumberButton_Click(object sender, RoutedEventArgs e)
        {
            var s = string.Empty;
            if (AlienStringTextBox != null)
            {
                s = AlienStringTextBox.Text;
            }

            var n = string.Empty;
            if (ResultStringLenghtDecimalUpDown != null)
            {
                n = ResultStringLenghtDecimalUpDown.Text;
            }

            var number = CalculateNumber(s, n);
            var isEmpty = string.IsNullOrWhiteSpace(number);
            if (isEmpty)
            {
                number=string.Empty;
            }
            if (CalculateResultTextBox != null)
            {
                CalculateResultTextBox.Text = number;
            }
        }

        private static string CalculateNumber(string s, string n)
        {
            var result = string.Empty;

            var isSuccess = long.TryParse(n, out long stringLength);
            if (isSuccess)
            {
                var businesLogic = new BusinessLogic();
                var number = businesLogic.Translate(s, stringLength);
                result = number.ToString();
            }
            if (!isSuccess)
            {
                result = "Не удалось распознать формат числа N";
            }

            return result;
        }

        private void GuiWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (e != null)
            {
                e.Cancel = true;
            }
            this.Hide();
        }
    }
}
