//-----------------------------------------------------------------------
// <copyright file="player.cs" company="NWTC">
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
    /// A player class for the hangman game.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Boolean to indicate which player is the current host.
        /// </summary>
        private bool player1IsHost;

        /// <summary>
        /// Player 1 score.
        /// </summary>
        private int player1Score;

        /// <summary>
        /// Player 2 score.
        /// </summary>
        private int player2Score;

        /// <summary>
        /// Gets or sets a value indicating whether player 1 is the host.
        /// </summary>
        public bool Player1IsHost
        {
            get
            {
                return this.player1IsHost;
            }

            set
            {
                this.player1IsHost = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the score of the first player.
        /// </summary>
        public int Player1Score
        {
            get
            {
                return this.player1Score;
            }

            set
            {
                this.player1Score = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the score of the second player.
        /// </summary>
        public int Player2Score
        {
            get
            {
                return this.player2Score;
            }

            set
            {
                this.player2Score = value;
            }
        }
    }
}
