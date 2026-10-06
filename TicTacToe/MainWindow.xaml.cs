/// <summary>
/// Title: MainWindow.xaml.cs / TicTacToe Game
/// Desc: This is the code for the logic behind the tic tac toe game.
///       Sorry for the late submission was very exhausted with work.
/// Author: Andrew Filson (Adu Poku)
/// Date: 2026-10-05
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
    }
}