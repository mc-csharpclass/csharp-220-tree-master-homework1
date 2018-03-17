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

namespace Homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxTurn.Text = "x's turn";
        }

        string whosTurn = "x";
        string[] xMoves = new string[5];
        string[] oMoves = new string[5];
        int turnNumber = 0;

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }

        private void TurnUpdate()
        {
            if (whosTurn == "x")
            {
                whosTurn = "o";
            }
            else if (whosTurn == "o")
            {
                whosTurn = "x";
            }
            uxTurn.Text = whosTurn+"'s turn";
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.AddText = whosTurn;
            Button btn = sender as Button;
            btn.Content = whosTurn;
            //record each teams moves
            if (whosTurn == "x")
            {
                xMoves[turnNumber] = btn.Tag.ToString();
            }
            else if (whosTurn == "o")
            {
                oMoves[turnNumber] = btn.Tag.ToString();
                turnNumber++;
            }
            TurnUpdate();
            btn.IsEnabled = false;
            WinnerCheck();
            //MessageBox.Show(btn.Tag.ToString());

        }

        private void WinnerCheck()
        {
            if ((xMoves.Contains("0,0") && xMoves.Contains("0,1") && xMoves.Contains("0,2")) ||
                (xMoves.Contains("1,0") && xMoves.Contains("1,1") && xMoves.Contains("1,2")) ||
                (xMoves.Contains("2,0") && xMoves.Contains("2,1") && xMoves.Contains("2,2")) ||
                (xMoves.Contains("0,0") && xMoves.Contains("1,0") && xMoves.Contains("2,0")) ||
                (xMoves.Contains("0,1") && xMoves.Contains("1,1") && xMoves.Contains("2,1")) ||
                (xMoves.Contains("0,2") && xMoves.Contains("1,2") && xMoves.Contains("2,2")) ||
                (xMoves.Contains("0,0") && xMoves.Contains("1,1") && xMoves.Contains("2,2")) ||
                (xMoves.Contains("0,2") && xMoves.Contains("1,1") && xMoves.Contains("2,0")))
            {
                uxTurn.Text = "X is the winner!";
                uxGrid.IsEnabled = false;
            }

            if ((oMoves.Contains("0,0") && oMoves.Contains("0,1") && oMoves.Contains("0,2")) ||
                (oMoves.Contains("1,0") && oMoves.Contains("1,1") && oMoves.Contains("1,2")) ||
                (oMoves.Contains("2,0") && oMoves.Contains("2,1") && oMoves.Contains("2,2")) ||
                (oMoves.Contains("0,0") && oMoves.Contains("1,0") && oMoves.Contains("2,0")) ||
                (oMoves.Contains("0,1") && oMoves.Contains("1,1") && oMoves.Contains("2,1")) ||
                (oMoves.Contains("0,2") && oMoves.Contains("1,2") && oMoves.Contains("2,2")) ||
                (oMoves.Contains("0,0") && oMoves.Contains("1,1") && oMoves.Contains("2,2")) ||
                (oMoves.Contains("0,2") && oMoves.Contains("1,1") && oMoves.Contains("2,0")))
            {
                uxTurn.Text = "o is the winner!";
                uxGrid.IsEnabled = false;
            }
        }
    }
}
