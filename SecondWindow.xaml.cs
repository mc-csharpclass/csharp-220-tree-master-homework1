﻿using System;
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
using System.Windows.Shapes;
using System.ComponentModel;


namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            // create a list of user to show up on ListView control
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "4DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
            
        }

        public void Header_Click(object sender, RoutedEventArgs e)
        {
            
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(((GridViewColumnHeader)e.OriginalSource).Column.Header.ToString(), ListSortDirection.Ascending));
            
            //MessageBox.Show(((GridViewColumnHeader)e.OriginalSource).Column.Header.ToString());
        }

        

    }
}
