//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="UNO">
//     UNO copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Uno_Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The class that represents the player.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Player
    {
        /// <summary>
        /// The player places a card on the discard pile.
        /// </summary>
        public string PlaceCard;

        /// <summary>
        /// The players score starts at 0.
        /// </summary>
        public int Score = 0;

        ///// <summary>
        ///// Used to determine if player is a computer or actual person.
        ///// </summary>
        ////public bool IsComputer;

        /// <summary>
        /// The cards in the player's hand.
        /// </summary>
        public List<Card> PlayerHand = new List<Card>();

        /// <summary>
        /// Used to determine if player is dealer
        /// </summary>
        public bool IsDealer;
    }
}
