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

namespace HelloWorld
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
        public int nameEntered = 0;
        public int passwordEntered = 0;

        
        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password: " + uxPassword.Text);
        }

        //private void uxName_TextInput(object sender, TextCompositionEventArgs e)
        //{
        //    nameEntered = 1;
        //    namePasswordCheck();
        //}

        //private void uxPassword_TextInput(object sender, TextCompositionEventArgs e)
        //{
        //    passwordEntered = 1;
        //    namePasswordCheck();
        //}

        private void namePasswordCheck()
        { if (nameEntered == 1 && passwordEntered == 1)
            { uxSubmit.IsEnabled = true; }
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            nameEntered = 1;
            namePasswordCheck();
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            passwordEntered = 1;
            namePasswordCheck();
        }
    }
}
