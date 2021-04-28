//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="NWTC">
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Themes for game.
    /// </summary>
    public enum ThemeMode
    {
        /// <summary>
        /// Theme that is a mix.
        /// </summary>
        Mix = 1,

        /// <summary>
        /// Theme that is a sport.
        /// </summary>
        Sport = 2,

        /// <summary>
        /// Theme that is a Movie.
        /// </summary>
        Movies = 3,

        /// <summary>
        /// Theme that is a Countries.
        /// </summary>
        Countries = 4,

        /// <summary>
        /// Theme that is a TwoPlayersMode.
        /// </summary>
        TwoPlayersMode = 5
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Player thePlayers object.
        /// </summary>
        private Player thePlayers;

        /// <summary>
        /// Hangman game object.
        /// </summary>
        private HangMan game;

        /// <summary>
        /// Theme object
        /// </summary>
        private ThemeMode theme;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="thememode">Theme for game.</param>
        /// /// <param name="secretword">Secret word for game.</param>
        /// /// <param name="p">player for game.</param>
        public MainWindow(ThemeMode thememode, string secretword = null, Player p = null)
        {
            this.InitializeComponent();

            this.theme = thememode;
            this.game = new HangMan();
            this.thePlayers = p;
            if (this.theme == ThemeMode.TwoPlayersMode)
            {
                if (this.thePlayers.Player1IsHost)
                {
                    lblPlayerr.Content = "Player1";
                }
                else
                {
                    lblPlayerr.Content = "Player2";
                }
            }

            // Array to store words 
            string[] mix, sports, movies, countries;
            mix = new string[9] { "SOCCER", "BASKETBALL", "SKIING", "HARRYPOTTER", "AVATAR", "PIRATESOFTHECARIBBEAN", "TUNISIA", "USA", "RUSSIA" };
            sports = new string[3] { "SOCCER", "BASKETBALL", "SKIING" };
            movies = new string[3] { "HARRYPOTTER", "AVATAR", "PIRATESOFTHECARIBBEAN" };
            countries = new string[3] { "TUNISIA", "USA", "RUSSIA" };

            // Create a Random object  
            Random rand = new Random();

            if (this.theme == ThemeMode.Mix)
            {
                lblTheme.Content = "Mix";
                this.game.ThemeChosen = "Mix";

                // Generate a random index less than the size of the array.  
                int index = rand.Next(mix.Length);

                this.game.SecretWord = mix[index];
            }
            else if (this.theme == ThemeMode.Sport)
            {
                lblTheme.Content = "Sport";
                this.game.ThemeChosen = "Sports";

                // Generate a random index less than the size of the array.  
                int index = rand.Next(sports.Length);

                this.game.SecretWord = sports[index];
            }
            else if (this.theme == ThemeMode.Movies)
            {
                lblTheme.Content = "Movies";
                this.game.ThemeChosen = "Movies";

                // Generate a random index less than the size of the array.  
                int index = rand.Next(movies.Length);
                this.game.SecretWord = movies[index];
            }
            else if (this.theme == ThemeMode.Countries)
            {
                lblTheme.Content = "Countries";
               this.game.ThemeChosen = "Countries";

                // Generate a random index less than the size of the array.  
                int index = rand.Next(countries.Length);

                this.game.SecretWord = countries[index];
            }
            else
            {
                this.game.SecretWord = secretword.ToUpper();
            }

            this.game.WordLength = this.game.SecretWord.Length;
            this.game.GuessedLetters = new string[this.game.WordLength];
            ////MessageBox.Show(this.game.SecretWord);

            // Filling the copy word with dashes
            for (int i = 0; i < this.game.WordLength; i++)
            {
                this.game.GuessedLetters[i] = "_";
            }

            // Filling the label with dashes
            for (int i = 0; i < this.game.WordLength; i++)
            {
                lblWord.Content += this.game.GuessedLetters[i];
            }
        }

        /// <summary>
        /// Host won increment.
        /// </summary>
        /// <param name="hostWon">Letter button that is clicked event..</param>
        public void HostWonIncrement(bool hostWon)
        {
            if (hostWon)
            {
                if (this.thePlayers.Player1IsHost)
                {
                    this.thePlayers.Player1Score++;
                }
                else
                {
                    this.thePlayers.Player2Score++;
                }
            }
            else
            {
                if (!this.thePlayers.Player1IsHost)
                {
                    this.thePlayers.Player2Score++;
                }
                else
                {
                    this.thePlayers.Player1Score++;
                }
            }
        }

        /// <summary>
        /// Stop game button.
        /// </summary>
        /// <param name="sender">Button Stop.</param>
        /// <param name="e">Not sure what this does.</param>
        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
            {
                App.Current.Windows[intCounter].Close();
            }    
        }

        /// <summary>
        /// Stop game button.
        /// </summary>
        /// <param name="sender">Letter button that is clicked event..</param>
        /// <param name="e">Not sure what this does.</param>
        private void BtnLetter_Click(object sender, RoutedEventArgs e)
        {   
            if (this.game.GameOver == false)
            {
                Button button = sender as Button;
                string letter = button.Content.ToString();
                
                bool isLetterinThere = false;

                button.IsEnabled = false;

                this.game.SecretWordLetters = new string[this.game.WordLength];

                for (int i = 0; i < this.game.WordLength; i++)
                {
                    this.game.SecretWordLetters[i] = this.game.SecretWord[i].ToString();
                }
                 
                if (button != null)
                {
                    for (int i = 0; i < this.game.WordLength; i++)
                    {
                        if (this.game.SecretWordLetters[i] == letter)
                        {
                            this.game.GuessedLetters[i] = this.game.SecretWordLetters[i];
                            isLetterinThere = true;
                            this.game.Counter++; 
                        }

                        lblWord.Content = string.Empty;

                        for (int j = 0; j < this.game.WordLength; j++)
                        {
                            lblWord.Content += this.game.GuessedLetters[j] + " ";
                        }
                    }

                    if (isLetterinThere == false)
                    {
                        this.game.WrongGuesses++;
                        MessageBox.Show("Wrong Guess");
                    }

                    imgHangMan.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/H" + this.game.WrongGuesses.ToString() + ".png"));
                    if (this.game.WrongGuesses >= 7)
                    {
                        if (this.theme == ThemeMode.TwoPlayersMode)
                        {
                            this.HostWonIncrement(true);
                        }

                        MessageBox.Show("Game Over! The correct word is : " + this.game.SecretWord.ToString());
                        this.game.GameOver = true;
                    } 

                    if (this.game.Counter >= this.game.WordLength)
                    {
                        if (this.theme == ThemeMode.TwoPlayersMode)
                        {
                            this.HostWonIncrement(false);
                        }

                        this.game.GameOver = true;
                        MessageBox.Show("Congrats! You Won");
                    }
                }   
            }
        }

        /// <summary>
        /// Restart game button.
        /// </summary>
        /// <param name="sender">Button restart.</param>
        /// <param name="e">Not sure what this does.</param>
        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}