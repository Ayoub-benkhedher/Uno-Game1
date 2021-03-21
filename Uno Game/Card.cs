//-----------------------------------------------------------------------
// <copyright file="Card.cs" company="UNO">
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
    /// The class that represents the cards in the game.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Card
    {
        /// <summary>
        /// The different type of cards.
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// The Number type of card.
            /// </summary>
            Number,

            /// <summary>
            /// The Skip card.
            /// </summary>
            Skip,

            /// <summary>
            /// The Reverse card.
            /// </summary>
            Reverse,

            /// <summary>
            /// The Draw Two card.
            /// </summary>
            Draw2,

            /// <summary>
            /// The Wild Draw Four card.
            /// </summary>
            WildDraw4,

            /// <summary>
            /// The Wild card.
            /// </summary>
            Wild
        }

        /// <summary>
        /// The different number options.
        /// </summary>
        public enum Number
        {
            /// <summary>
            /// The number zero card.
            /// </summary>
            Zero = 0,

            /// <summary>
            /// The number one card.
            /// </summary>
            One = 1,

            /// <summary>
            /// The number two card.
            /// </summary>
            Two = 2,

            /// <summary>
            /// The number three card.
            /// </summary>
            Three = 3,

            /// <summary>
            /// The number four card.
            /// </summary>
            Four = 4,

            /// <summary>
            /// The number five card.
            /// </summary>
            Five = 5,

            /// <summary>
            /// The number six card.
            /// </summary>
            Six = 6,

            /// <summary>
            /// The number seven card.
            /// </summary>
            Seven = 7,

            /// <summary>
            /// The number eight card.
            /// </summary>
            Eight = 8,

            /// <summary>
            /// The number nine card.
            /// </summary>
            Nine = 9
        }

        /// <summary>
        /// The different color options.
        /// </summary>
        public enum Color
        {
            /// <summary>
            /// The color blue.
            /// </summary>
            Blue,

            /// <summary>
            /// The color red.
            /// </summary>
            Red,

            /// <summary>
            /// The color yellow.
            /// </summary>
            Yellow,

            /// <summary>
            /// The color green.
            /// </summary>
            Green
        }

        /// <summary>
        /// Gets or sets the type of card.
        /// </summary>
        public Type MyType { get; set; }

        /// <summary>
        /// Gets or sets the number on the card.
        /// </summary>
        public Number MyNumber { get; set; }

        /// <summary>
        /// Gets or sets the color of the card.
        /// </summary>
        public Color MyColor { get; set; }

        /// <summary>
        /// Gets or sets the value of the card.
        /// </summary>
        public int MyValue { get; set; }

        /// <summary>
        /// Gets or sets the value of the card.
        /// </summary>
        public string MyImagePath { get; set; }
    }
}
