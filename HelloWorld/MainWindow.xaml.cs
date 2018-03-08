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
using System.ComponentModel;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// hw#1 you can modify the xaml manually or in the ui select the same method.



    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        public int nameEntered = 0;
        public int passwordEntered = 0;

        private Models.User user = new Models.User();


        public override void EndInit()
        {
            base.EndInit();
            uxContainer.DataContext = user;
        }

        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password: " + uxPassword.Text);

            // close current window and launch second window
            var window = new SecondWindow();
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }

        private void submitCheck()
        {
            if (String.IsNullOrEmpty(uxPassword.Text) == false && String.IsNullOrEmpty(uxName.Text) == false)
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            submitCheck();
        }


        //private void namePasswordCheck()
        //    {
        //        if (nameEntered == 1 && passwordEntered == 1)
        //        {
        //             uxSubmit.IsEnabled = true;
        //        }
        //        else
        //        {
        //            uxSubmit.IsEnabled = false;
        //        }
        //    }

        //private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    submitCheck();
        //    //if (String.IsNullOrEmpty(uxPassword.Text) == true)
        //    //{
        //    //    passwordEntered = 0;
        //    //    namePasswordCheck();

        //    //} 
        //    //else
        //    //{
        //    //    passwordEntered = 1;
        //    //    namePasswordCheck();
        //    //}

        //}

        //private void uxName_TextChanged_1(object sender, TextChangedEventArgs e)
        //{
        //    submitCheck();
        //    //if (String.IsNullOrEmpty(uxName.Text) == true)
        //    //{
        //    //    nameEntered = 0;
        //    //    namePasswordCheck();
        //    //}
        //    //else
        //    //{
        //    //    nameEntered = 1;
        //    //    namePasswordCheck();
        //    //}
        //}


    }
}

