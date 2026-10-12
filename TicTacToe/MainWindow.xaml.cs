/// <summary>
/// Title: MainWindow.xaml.cs / TicTacToe Game
/// Desc: This is the code for the logic behind the tic tac toe game.
///       Sorry for the late submission was very exhausted with work.
/// Author: Andrew Filson (Adu Poku)
/// Date: 2026-10-05
/// Date Updated: 2026-10-12
/// </summary>


using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            entryBoxPlayerX.Focus();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonTopCentre(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("You clicked the Top Center button!");
        }

        private void ButtonResetClick(object sender, RoutedEventArgs e)
        {
            entryBoxPlayerX.Clear();
            entryBoxPlayerO.Clear();
            entryBoxPlayerX.Focus();
        }

        // This function checks if a player has won the game by checking the contents of three buttons
        // in a line, row, or diagonal. Note this function wont be triggered til at least 5 moves have been made, since a player
        // cannot win before that point. From thereon, this function is called after each move to check if a player has won.
        private void CheckLine(string player, Button button1, Button button2, Button button3)
        { 
            if (button1.Content.ToString() == player && button2.Content.ToString() == player && button3.Content.ToString() == player)
            {
                // typical message box but need to use the $ sign to use the variable in the string
                System.Windows.MessageBox.Show($"Player {player} wins!");
                // reset the game after a win
                // Since this isnt being triggered by an event, need to provide null values for the sender and event args parameters
                ButtonResetClick(null, null);
            }
        }
    }
}