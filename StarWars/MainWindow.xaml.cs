using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StarWars
{
    public partial class MainWindow : Window
    {
        private string currentPlayer = "Obi-Wan"; // Obi-Wan Kenobi
        private string[,] board = new string[3, 3];
        private MediaPlayer player = new MediaPlayer();
        private bool isGameActive;
        public MainWindow()
        {
            InitializeComponent();
            CreateGrid();
        }

        // Create Grid for game
        private void CreateGrid()
        {
            // 3 by 3
            for (int i = 0; i < 3; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            // 9 buttons
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    var button = new Button
                    {
                        Content = new Image
                        {
                            Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/empty.png")),
                            Stretch = Stretch.Uniform
                        }
                    };
                    button.Click += Button_Click;
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    GameGrid.Children.Add(button);
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            isGameActive = true;
            EnableGameButtons(true);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            isGameActive = false;
            EnableGameButtons(false);
        }

        private void EnableGameButtons(bool enable)
        {
            foreach (var chilld in GameGrid.Children)
            {
                if (chilld is Button btn)
                {
                    btn.IsEnabled = enable;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isGameActive)
            {
                MessageBox.Show($"Please select a mode.");
                return;
            }
            // gets the button
            if (sender is not Button btn)
                return;
            int row = Grid.GetRow(btn);
            int col = Grid.GetColumn(btn);

            if (board[row, col] != null)
                return;

            string imagePath = currentPlayer == "Obi-Wan" 
                ? @"pack://application:,,,/Images/obi.png"
                : @"pack://application:,,,/Images/ani.png";

            btn.Content = new Image
            {
                Source = new BitmapImage(new Uri(imagePath)),
                Stretch = Stretch.Uniform
            };

            // mark the board
            board[row, col] = currentPlayer;
            if(checkForWin(out string winDirection))
            {
                try
                {
                    if (currentPlayer == "Obi-Wan")
                    {
                        player.Open(new Uri("..\\sounds\\obisound.mp3", UriKind.Relative)); 
                        player.Play();
                    } else  if (currentPlayer == "Anakin")
                    {
                        player.Open(new Uri("..\\sounds\\anisound.mp3", UriKind.Relative));
                        player.Play();
                    }
                } catch  (Exception ex)
                {
                    MessageBox.Show($"Error playing sound: {ex.Message}");
                }
                MessageBox.Show($"{currentPlayer} wins.");
                ResetBoard();
                return;
            }

            // check for a draw
            if(IsBoardFull())
            {
                MessageBox.Show($"It's a tie.");
                ResetBoard();
                return;
            }

            // switch player
            currentPlayer = currentPlayer == "Obi-Wan" ? "Anakin" : "Obi-Wan";
        }

        private bool checkForWin(out string direction)
        {
            direction = "";

            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                {
                    direction = $"row{i}";
                    return true;
                }
                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                {
                    direction = $"col{i}";
                    return true;
                }
            }

            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            {
                direction = $"diag1";
                return true;
            }
            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            {
                direction = $"diag2";
                return true;
            }

            return false;
        }

        private bool IsBoardFull()
        {
            foreach (var cell in board)
            {
                if (cell == null)
                    return false;
            }
            return true;
        }

        private void ResetBoard()
        {
            board = new string[3, 3];
            currentPlayer = "Obi-Wan";

            foreach (var child in GameGrid.Children)
            {
                if (child is Button btn && btn.Content is Image  img)
                {
                    img.Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/empty.png"));
                }
            }
        }
    }
}