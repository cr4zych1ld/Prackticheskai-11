using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практическая_работа__11
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

        /// <summary>
        /// Метод осуществляющий вывод информации о разработчике программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfoSozdatel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Студент группы ИСП-31\nЖаров Артём Андреевич", "О создателе:", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Метод осуществляющий вывод информации о задании для разработке программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfoProga_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана строка 'aa aba abba abbba abca abea'. \nНапишите регулярное выражение, которое " +
                "\nнайдет строки aba, abba, abbba.\nДана строка '23 2+3 2++3 2+++3 445 677'. \nНапишите регулярное выражение, которое " +
                "\nнайдет строки 23, 2+3, 2++3, 2+++3, не зах-\nватив остальные. ", "О программе:", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Метод осуществляющий закрытие программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Метод осуществляющий заполнение строки символов, а так же написание регулярного выражения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirstString_Click(object sender, RoutedEventArgs e)
        {
            InputString.Clear();
            RegexPattern.Clear();
            regex = null;
            Results.Clear();
            InputString.Text = $"aa aba abba abbba abca abea";
            RegexPattern.Text = $@"\b(a(b(a|bb|bbb)? )|aa)\b";
            firstString = true;
            secondString = false;
        }

        /// <summary>
        /// Метод осуществляющий заполнение строки символов, а так же написание регулярного выражения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSecondString_Click(object sender, RoutedEventArgs e)
        {
            InputString.Clear();
            RegexPattern.Clear();
            regex = null;
            Results.Clear();
            InputString.Text = $"23 2+3 2++3 2+++3 445 677";
            RegexPattern.Text = $@"\b\d(\+\d)*\b";
            firstString = false;
            secondString = true;
        }
        
        /// <summary>
        /// Метод осуществляющий очистку всей программы от введенных знечений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            InputString.Clear();
            RegexPattern.Clear();
            regex = null;
            Results.Clear();
            firstString = false;
            secondString = false;
        }

        Regex regex;
        bool firstString;
        bool secondString;

        /// <summary>
        /// Метод для нахождения определенных строк в исходной строке при помощи регулярного выражения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindMatches_Click(object sender, RoutedEventArgs e)
        {
            if (InputString.Text != "" && firstString == true || secondString == true)
            {
                if (RegexPattern.Text != "" && firstString == true || secondString == true)
                {
                    if (firstString == true)
                    {
                        regex = new Regex(@"\b(a(b(a|bb|bbb)? )|aa)\b");
                    }
                    else firstString = false;

                    if (secondString == true)
                    {
                        regex = new Regex(@"\b\d(\+\d)*\b");
                    }
                    else secondString = false;

                    MatchCollection matches = regex.Matches(InputString.Text);

                    Results.Clear();
                    if (matches.Count > 0)
                    {
                        for (int i = 0; i < matches.Count; i++)
                        {
                            Results.Text += matches[i].ToString() + Environment.NewLine;
                        }
                    }
                    else MessageBox.Show("Совпадений не найдено!", "Ошибка: ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Напишите регулярное выражение!", "Внимание: ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show("Заполните строку для поиска симфолов!", "Внимание: ", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}