using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Text.RegularExpressions;


namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            submitButton.IsEnabled = false;
        }

        private void EnableClick(object sender, TextChangedEventArgs e)
        {
            ZipCheck(); 
        }

        public void ZipCheck()
        {
            Regex US1 = new Regex("^[0-9]{5}$");
            Regex US2 = new Regex("^[0-9]{5}-[0-9]{4}$");
            Regex Canada = new Regex("^[a-z]{1}[0-9]{1}[a-z]{1}[0-9]{1}[a-z]{1}[0-9]{1}$");
            if (US1.IsMatch(uxZipcode.Text) == true || US2.IsMatch(uxZipcode.Text) == true || Canada.IsMatch(uxZipcode.Text.ToLower()) == true)
            {
                submitButton.IsEnabled = true;
            }
            
            else 
            {
                submitButton.IsEnabled = false;
            }
        }
    }
}
