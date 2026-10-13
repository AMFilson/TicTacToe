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

        // A counter to keep track of turns to validate draws
        private int turnCounter = 0;
        // I need an array of buttons to store the buttons on the game board so I can sort through them to check for wins and draws
        private Button[] gameBoardButtons;

        // Set current player
        private string currentPlayer = "X";

        // dog it took me 1 billion years to realize I dont need to declare a variable in mainwindow()
        public MainWindow()
        {
            InitializeComponent();
            // Start game with a defined focus
            entryBoxPlayerX.Focus();


            // The array of buttons has to be inside mainwindow I think so I can actually access the buttons by xName
            gameBoardButtons = new Button[]
            {   
                // By placing each button into an array I can sort through them via int index (0..8) and check for wins and draws
                // Then all I have to do is check the content of each button in the array and see if they match a winning pattern
                // If the content value of a set of 3 buttons matches a winning pattern then the player has won the game
                buttonTopLeft, buttonTopCentre,buttonTopRight,
                buttonMiddleLeft,buttonMiddleCentre, buttonMiddleRight,
                buttonBottomLeft,buttonBottomCentre, buttonBottomRight
            };

        }

        // One array for sorting through all winning patterns.
        // There are 3 possible winning row patterns
        // There are 3 possible winning column pattern
        // There are 2 possible winning diagonal patterns 
        private readonly int[][] winningPatterns = new int[][]
            { 
                // So in a 2 dimensional array the first index is the row and 2nd index is the column
                // So if I want to sort through it I can use a for loop
                // Row patterns
                // Top row [0][0..2]
                new int[] { 0, 1, 2 },
                // Middle row [1][0..2]
                new int[] { 3, 4, 5 },
                // Bottom row [2][0..2]
                new int[] { 6, 7, 8 }, 

                // Column patterns
                // Left column [3][0..2]
                new int[] { 0, 3, 6 },
                // Middle column [4][0..2]
                new int[] { 1, 4, 7 }, 
                // Right column [5][0..2]
                new int[] { 2, 5, 8 },
                
                // Diagonal patterns
                // Top left to bottom right diagonal [6][0]
                new int[] { 0, 4, 8 },
                // Top right to bottom left diagonal [7][0]
                new int[] { 2, 4, 6 }

            };



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        // Ends the program when the exit button is clicked.
        private void ButtonExit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        // This is a temp function to ensure event handlers on buttons work. Will be removed once the game logic is implemented.
        private void ButtonGameBoardClick(object sender, RoutedEventArgs e)
        {   
            // This stupid function doesnt work unless I declare a selection condition
            // That condition is that the object which causes the event must be a Button object
            // And if so that Button object is acted upon according to the PlayerMove function
            if (sender is Button clickedButton)
            {
                PlayerMove(clickedButton);
            }
        }

        private void ButtonResetClick(object sender, RoutedEventArgs e)
        {
            entryBoxPlayerX.Clear();
            entryBoxPlayerO.Clear();
            entryBoxPlayerX.Focus();
            turnCounter = 0;
        }


        //This function checks all possible winning combos for a player by calling the CheckLine function for each possible winning line.
        // There has to be a cleaner way to do this with an array but ill wait for now and finish the logic
        private void CheckForWin()
        {
            /*            // check rows
                        CheckLine(player, buttonTopLeft, buttonTopCentre, buttonTopRight);
                        CheckLine(player, buttonMiddleLeft, buttonMiddleCentre, buttonMiddleRight);
                        CheckLine(player, buttonBottomLeft, buttonBottomCentre, buttonBottomRight);
                        // check columns
                        CheckLine(player, buttonTopLeft, buttonMiddleLeft, buttonBottomLeft);
                        CheckLine(player, buttonTopCentre, buttonMiddleCentre, buttonBottomCentre);
                        CheckLine(player, buttonTopRight, buttonMiddleRight, buttonBottomRight);
                        // check diagonals
                        CheckLine(player, buttonTopLeft, buttonMiddleCentre, buttonBottomRight);
                        CheckLine(player, buttonTopRight, buttonMiddleCentre, buttonBottomLeft);*/

            if (turnCounter >= 5)
            {
                // A foreach loop is superior to a for loop since I don't need to iterate through the each column of a winning pattern/row
                // I just need to see if each row is a direct match with a combination of buttons
                foreach (var validPattern in winningPatterns)
                {

                    string firstButtonXorO = gameBoardButtons[validPattern[0]].Content?.ToString() ?? "";
                    string secondButtonXorO = gameBoardButtons[validPattern[0]].Content?.ToString() ?? "";
                    string thirdButtonXorO = gameBoardButtons[validPattern[0]].Content?.ToString() ?? "";

                    // Check if the values of the 3 buttons match
                    // can't use compare because compare is valid in some combinations on 3 empty boxes
                    // Here I just gotta make sure I compare one button to the rest, and that my primary button doesnt contain an empty value
                    // Okay nvm I actually gotta compare all 3 buttons or it doesnt care lmao
                    if (!string.IsNullOrEmpty(firstButtonXorO) && firstButtonXorO == secondButtonXorO && secondButtonXorO == thirdButtonXorO)
                    {

                        // Display win message
                        MessageBox.Show($"Winner winner {entryBoxPlayerX.Text} gets Chow Mein for dinner!");
                        // Stop any new plays until they reset or quit.
                    }

                }

                // If 9 turns have passed with 0 wins they both suck and a draw happens
                if (turnCounter == 9)
                {
                    // Display win message
                    MessageBox.Show("It's a draw! Try again, double or nothing.");
                    // Stop any new plays until they reset or quit.
                }
            }
            else
            {
                // nothing should happen if there arent enough turns to win
                return;
            }
            ;
        }


        // A function to handle clicks for all 9 buttons on the game board
        // When a button is clicked it follows a sequence of actions.
        // First. A player should be able to press Enter when focus is on a button to attempt to place a unit in it's content field

        // Second. When a player presses enter the field should be checked to see if the content field contains any data, if empty the unit is entered.
        // Third. If a button is already filled with a players move, it will not allow the player to place a move there
        // instead the button will be in ReadOnly mode and the player will have to choose another button.
        // Fourth. If the button is empty, it will place the current players move on the button.
        // Fifth. It will increment the turn counter.
        // Sixth. It will check the amount of turns that have passed, if >=5 it will check if the current player has won the game.
        private void PlayerMove(Button clickedButton)
        {
            if (clickedButton.Content != null && !string.IsNullOrEmpty(clickedButton.Content.ToString()))
            {
                // Do nothing the box is already taken
                return;
            }
            else
            {
                // Place the current players symbol (X or O) in the content field of the button
                clickedButton.Content = currentPlayer;
                // Stop anything from changing the value once a player has entered theirs
                clickedButton.IsEnabled = false;
            }

            turnCounter++;

            // Check win condition if turns >= 5
            if (turnCounter >= 5)
            {
                CheckForWin();
                return;
            }
            // Switch turns between X and O
            currentPlayer = (currentPlayer == "X") ? "O" : "X";
        }
    }
}