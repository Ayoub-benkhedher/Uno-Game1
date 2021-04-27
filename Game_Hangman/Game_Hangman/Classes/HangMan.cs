//-----------------------------------------------------------------------
// <copyright file="HangMan.cs" company="NWTC">
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

    /// <summary> 
    /// A hangman class for the hangman game.
    /// </summary>
    public class HangMan
    {
        /// <summary>
        /// Theme chosen by user.
        /// </summary>
        private string themeChosen;

        /// <summary>
        /// SecretWord randomly chosen.
        /// </summary>
        private string secretWord;

        /// <summary>
        /// Length of the secret word.
        /// </summary>
        private int wordLength;

        /// <summary>
        /// Array of letters that were guessed.
        /// </summary>
        private string[] guessedLetters;

        /// <summary>
        /// Array that holds the letters of the secret word.
        /// </summary>
        private string[] secretWordLetters;

        /// <summary>
        /// The count of wrong guesses by user.
        /// </summary>
        private int wrongGuesses;

        /// <summary>
        /// Game is over.
        /// </summary>
        private bool gameOver;

        /// <summary>
        /// Variable used as a counter.
        /// </summary>
        private int counter;

        /// <summary>
        /// Boolean variable if the game was won.
        /// </summary>
        private bool gameWon;

        /// <summary>
        /// Initializes a new instance of the <see cref="HangMan"/> class.
        /// </summary>
        public HangMan()
        {
            this.WrongGuesses = 0;
            this.GameOver = false;
            this.Counter = 0;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Game is over. 
        /// </summary>
        public bool GameOver
        {
            get
            {
                return this.gameOver;
            }

            set
            {
                this.gameOver = value;
            }
        }

        /// <summary>
        /// Gets or sets Variable used as a counter.
        /// </summary>
        public int Counter 
        {
            get 
            {
                return this.counter; 
            }
            
            set 
            {
                this.counter = value; 
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Boolean variable if the game was won.
        /// </summary>
        public bool GameWon 
        {
            get 
            {
                return this.gameWon; 
            }
            
            set 
            {
                this.gameWon = value; 
            }
        }

        /// <summary>
        /// Gets or sets Theme chosen by user.
        /// </summary>
        public string ThemeChosen 
        {
            get 
            {
                return this.themeChosen; 
            }
            
            set 
            {
                this.themeChosen = value; 
            }
        }

        /// <summary>
        /// Gets or sets SecretWord randomly chosen. 
        /// </summary>
        public string SecretWord 
        {
            get 
            {
                return this.secretWord; 
            }

            set 
            {
                this.secretWord = value; 
            }
        }

        /// <summary>
        /// Gets or sets Length of the secret word.
        /// </summary>
        public int WordLength 
        {
            get 
            {
                return this.wordLength; 
            }
            
            set 
            {
                this.wordLength = value; 
            }
        }

        /// <summary>
        /// Gets or sets Array of letters that were guessed.
        /// </summary>
        public string[] GuessedLetters 
        {
            get 
            {
                return this.guessedLetters; 
            }

            set 
            {
                this.guessedLetters = value; 
            }
        }

        /// <summary>
        /// Gets or sets Array that holds the letters of the secret word.
        /// </summary>
        public string[] SecretWordLetters 
        {
            get 
            {
                return this.secretWordLetters; 
            }

            set 
            {
                this.secretWordLetters = value; 
            }
        }

        /// <summary>
        /// Gets or sets The count of wrong guesses by user.
        /// </summary>
        public int WrongGuesses 
        {
            get 
            {
                return this.wrongGuesses; 
            }

            set 
            {
                this.wrongGuesses = value; 
            }
        }
    }   
}
