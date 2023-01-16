using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator
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
        private void BClear_Click(object sender, RoutedEventArgs e)
        {
            TBAge.Clear();
            TBHeight.Clear();
            TBKg.Clear();
            TBAnswer.Text = "";
        }

        private void BCalculate_Click(object sender, RoutedEventArgs e)
        {
            var eror = "";
            if(TBKg.Text.Trim().Length == 0)
            {
                eror += "Введите вес в кг \n";
            }
            if (TBHeight.Text.Trim().Length == 0)
            {
                eror += "Введите рост в см \n";
            }
            if (TBAge.Text.Trim().Length == 0)
            {
                eror += "Введите возраст в годах \n";
            }
            if(eror != "")
            {
                MessageBox.Show(eror);
                return;
            }
            double Kg = double.Parse(TBKg.Text.Trim());
            double Height = double.Parse(TBHeight.Text.Trim());
            double Age = double.Parse(TBAge.Text.Trim());
            double BMR = 0;
            double IDEE = 0;
            if (CbFlo.SelectedIndex == 0 )
            {
                BMR = 66 + (13.7 * Kg) + (5 * Height) - (6.8 * Age);
            }
            else if (CbFlo.SelectedIndex == 1)
            {
                BMR = 65.5 + (9.6 * Kg) + (1.8 * Height) - (4.7 * Age);
            }

            if(CbActiv.SelectedIndex == 0)
            {
                IDEE = BMR * 1.375;
            }
            else if (CbActiv.SelectedIndex == 1)
            {
                IDEE = BMR * 1.55;
            }
            else if (CbActiv.SelectedIndex == 2)
            {
                IDEE = BMR * 1.725;
            }
            else if (CbActiv.SelectedIndex == 3)
            {
                IDEE = BMR * 1.9;
            }

            TBAnswer.Text = $"При возрасте {Age} лет, весе {Kg} кг и росте {Height} см - BMR: {BMR} калорий/сутки IDEE: {IDEE}";
      
        }

        private void TBAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
            {
                e.Handled = true;
            }
        }
    }
}
