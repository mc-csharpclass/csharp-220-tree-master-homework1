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
using GamesListApp.Models;
using System.ComponentModel;
using System.Text.RegularExpressions;


namespace GamesListApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxIDEdit.IsEnabled = false;
            uxIDDelte.IsEnabled = false;
            LoadGames();
        }

        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        private GameModel selectedGame;

        private void uxGameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedGame = (GameModel)uxGameList.SelectedValue;
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new GameWindow();

            if (window.ShowDialog() == true)
            {
                var uiGameModel = window.Game;

                var repositoryGameModel = uiGameModel.ToRepositoryModel();

                App.GameRepository.Add(repositoryGameModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());
            }
        }

        private void LoadGames()
        {
            var games = App.GameRepository.GetAll();

            uxGameList.ItemsSource = games
                .Select(t => GameModel.ToModel(t))
                .ToList();
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new GameWindow();
            //window.Contact = selectedContact;
            window.Game = selectedGame.ShallowCopy();

            if (window.ShowDialog() == true)
            {
                App.GameRepository.Update(window.Game.ToRepositoryModel());
                LoadGames();
            }
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.GameRepository.Remove(selectedGame.Id);
            selectedGame = null;
            LoadGames();
        }



        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedGame != null);
            uxContextFileDelete.IsEnabled = (selectedGame != null);
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxContextFileChange.IsEnabled = (selectedGame != null);
            uxContextFileChange.IsEnabled = (selectedGame != null);
        }

        private void uxColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                uxGameList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            uxGameList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        public class SortAdorner : Adorner
        {
            private static Geometry ascGeometry =
                    Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

            private static Geometry descGeometry =
                    Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

            public ListSortDirection Direction { get; private set; }

            public SortAdorner(UIElement element, ListSortDirection dir)
                    : base(element)
            {
                this.Direction = dir;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);

                if (AdornedElement.RenderSize.Width < 20)
                    return;

                TranslateTransform transform = new TranslateTransform
                        (
                                AdornedElement.RenderSize.Width - 15,
                                (AdornedElement.RenderSize.Height - 5) / 2
                        );
                drawingContext.PushTransform(transform);

                Geometry geometry = ascGeometry;
                if (this.Direction == ListSortDirection.Descending)
                    geometry = descGeometry;
                drawingContext.DrawGeometry(Brushes.Black, null, geometry);

                drawingContext.Pop();
            }
        }

        private void uxFileChange_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var window = new GameWindow();
            //window.Contact = selectedContact;
            window.Game = selectedGame.ShallowCopy();

            if (window.ShowDialog() == true)
            {
                App.GameRepository.Update(window.Game.ToRepositoryModel());
                LoadGames();
            }
        }

        private void uxFileClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void uxRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadGames();
        }

        private void uxFileChangeById_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void uxIDEdit_Click(object sender, RoutedEventArgs e)
        {
            if (uxIDEdit != null)
            {
                gamesListSearchEdit(uxIDNumber.Text);
            }
        }

        private void uxIDDelete_Click(object sender, RoutedEventArgs e)
        {
            if (uxIDEdit != null)
            {
                gamesListSearchDelete(uxIDNumber.Text);
            }
        }

        private void enableClick(object sender, TextChangedEventArgs e)
        {
            intCheck();
        }

        private void intCheck()
        {
            Regex regex = new Regex("^[0-9]+$");
            if (regex.IsMatch(uxIDNumber.Text) == true)
            {
                uxIDEdit.IsEnabled = true;
                uxIDDelte.IsEnabled = true;
            }
            else
            {
                uxIDEdit.IsEnabled = false;
                uxIDDelte.IsEnabled = false;
            }
        }

        private void gamesListSearchEdit(string IDNumber)
        {

            int num = int.Parse(IDNumber);

            var games = App.GameRepository.GetAll();

            var idNum = from game in games
                        where game.Id == num
                        select game;


            foreach (var q in idNum)
            {

                var window = new GameWindow();

                window.Game = GameModel.ToModel(q).ShallowCopy();

                if (window.ShowDialog() == true)
                {
                    App.GameRepository.Update(window.Game.ToRepositoryModel());
                    LoadGames();
                }
            }

        }

        private void gamesListSearchDelete(string IDNumber)
        {

            int num = int.Parse(IDNumber);

            var games = App.GameRepository.GetAll();

            var idNum = from game in games
                        where game.Id == num
                        select game;


            foreach (var q in idNum)
            {
                App.GameRepository.Remove(q.Id);
                selectedGame = null;
                LoadGames();
            }
        }
    }
}
