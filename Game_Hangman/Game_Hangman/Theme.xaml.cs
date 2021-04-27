//-----------------------------------------------------------------------
// <copyright file="Theme.xaml.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Game_Hangman
{
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
    using System.Windows.Shapes;
    
    /// <summary>
    /// Interaction logic for Theme.xaml
    /// </summary>
    public partial class Theme : Window
    {
        /// <summary>
        /// Player thePlayers object.
        /// </summary>
        private Player thePlayers;

        /// <summary>
        /// Initializes a new instance of the <see cref="Theme"/> class.
        /// </summary>
        public Theme()
        {
            this.InitializeComponent();
            lblTheme.Visibility = Visibility.Hidden;
            recTheme.Visibility = Visibility.Hidden;
            btnMix.Visibility = Visibility.Hidden;
            btnMovies.Visibility = Visibility.Hidden;
            btnSport.Visibility = Visibility.Hidden;
            BtnCountries.Visibility = Visibility.Hidden;
            lblHost.Visibility = Visibility.Hidden;
            lblIsHost.Visibility = Visibility.Hidden;
            lblScoring.Visibility = Visibility.Hidden;
            lblPlayer1.Visibility = Visibility.Hidden;
            lblPlayerOneScore.Visibility = Visibility.Hidden;
            lblPlayer2.Visibility = Visibility.Hidden;
            lblPlayerTwoScore.Visibility = Visibility.Hidden;
            this.thePlayers = new Player();
            this.thePlayers.Player1IsHost = true;
            this.thePlayers.Player1Score = 0;
            this.thePlayers.Player2Score = 0;
        }

        /// <summary>
        /// Mix theme button.
        /// </summary>
        /// <param name="sender">Not sure what to put here.</param>
        /// <param name="e">Not sure what this does.</param>
        private void BtnMix_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(ThemeMode.Mix).ShowDialog();
        }

        /// <summary>
        /// Sport theme button.
        /// </summary>
        /// <param name="sender">Not sure what to put here.</param>
        /// <param name="e">Not sure what this does.</param>
        private void BtnSport_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(ThemeMode.Sport).ShowDialog();
        }

        /// <summary>
        /// Movie theme button.
        /// </summary>
        /// <param name="sender">Not sure what to put here.</param>
        /// <param name="e">Not sure what this does.</param>
        private void BtnMovies_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(ThemeMode.Movies).ShowDialog();
        }

        /// <summary>
        /// Countries theme button.
        /// </summary>
        /// <param name="sender">Not sure what to put here.</param>
        /// <param name="e">Not sure what this does.</param>
        private void BtnCountries_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(ThemeMode.Countries).ShowDialog();
        }

        /// <summary>
        /// One player mode button.
        /// </summary>
        /// <param name="sender">Not sure what to put here.</param>
        /// <param name="e">Not sure what this does.</param>
        private void BtnOnePlayer_Click(object sender, RoutedEventArgs e)
        {
            lblTheme.Visibility = Visibility.Visible;
            recTheme.Visibility = Visibility.Visible;
            btnMix.Visibility = Visibility.Visible;
            btnMovies.Visibility = Visibility.Visible;
            btnSport.Visibility = Visibility.Visible;
            BtnCountries.Visibility = Visibility.Visible;
            lblHost.Visibility = Visibility.Hidden;
            lblIsHost.Visibility = Visibility.Hidden;
            lblScoring.Visibility = Visibility.Hidden;
            lblPlayer1.Visibility = Visibility.Hidden;
            lblPlayerOneScore.Visibility = Visibility.Hidden;
            lblPlayer2.Visibility = Visibility.Hidden;
            lblPlayerTwoScore.Visibility = Visibility.Hidden;

            MessageBox.Show("Please pick a theme");
        }

        /// <summary>
        /// Two players mode button.
        /// </summary>
        /// <param name="sender">Not sure what to put here.</param>
        /// <param name="e">Not sure what this does.</param>
        private void BtnTwoPlayers_Click(object sender, RoutedEventArgs e)
        {
            lblTheme.Visibility = Visibility.Hidden;
            recTheme.Visibility = Visibility.Hidden;
            btnMix.Visibility = Visibility.Hidden;
            btnMovies.Visibility = Visibility.Hidden;
            btnSport.Visibility = Visibility.Hidden;
            BtnCountries.Visibility = Visibility.Hidden;
            lblHost.Visibility = Visibility.Visible;
            lblIsHost.Visibility = Visibility.Visible;
            lblScoring.Visibility = Visibility.Visible;
            lblPlayer1.Visibility = Visibility.Visible;
            lblPlayerOneScore.Visibility = Visibility.Visible;
            lblPlayer2.Visibility = Visibility.Visible;
            lblPlayerTwoScore.Visibility = Visibility.Visible;

            new SecretWord(this.thePlayers).ShowDialog();
            this.thePlayers.Player1IsHost = !this.thePlayers.Player1IsHost;
            lblPlayerOneScore.Content = this.thePlayers.Player1Score;
            lblPlayerTwoScore.Content = this.thePlayers.Player2Score;
            
            if (this.thePlayers.Player1IsHost)
            {
                lblIsHost.Content = "Player1";
            }
            else
            {
                lblIsHost.Content = "Player2";
            }
        }

        /// <summary>
        /// About button that display a message.
        /// </summary>
        /// <param name="sender">Not sure what to put here.</param>
        /// <param name="e">Not sure what this does.</param>
        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Developpers: \n Ayoub Ben Khedher \n Eric Raabe \n Version: 0.0.0.2");
        }
    }
}
