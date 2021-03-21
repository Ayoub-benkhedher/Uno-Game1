//-----------------------------------------------------------------------
// <copyright file="DeckOfCards.cs" company="UNO">
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
    /// The class that represents the deck of cards.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class DeckOfCards : Card
    {
        /// <summary>
        /// The total amount of cards in a game of Uno.
        /// </summary>
        public const int NumOfCards = 108;

        /// <summary>
        /// The deck of cards.
        /// </summary>
        public Card[] Deck;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeckOfCards"/> class.
        /// </summary>
        public DeckOfCards()
        {
            this.Deck = new Card[NumOfCards];
        }

        /// <summary>
        /// Gets the deck of cards.
        /// </summary>
        public Card[] GetDeck
        {
            get { return this.Deck; }
            //// set { this.Deck = value; }
        }

        /// <summary>
        /// The method used when setting up the deck.
        /// </summary>
        public void SetUpDeck()
        {
            int i = 0;
            string cardColor = string.Empty;
            string cardType = string.Empty;
            int cardNumber = 0;

            foreach (Type t in Enum.GetValues(typeof(Type)))
            {
                cardType = t.ToString();
                if (t == Type.Number || t == Type.Skip || t == Type.Draw2 || t == Type.Reverse)
                {
                    foreach (Color c in Enum.GetValues(typeof(Color)))
                    {
                        cardColor = c.ToString();
                        if (t == Type.Number)
                        {
                            foreach (Number n in Enum.GetValues(typeof(Number)))
                            {
                                cardNumber = (int)n;
                                ////int num = (int)n;

                                if (n != 0)
                                {
                                    int num = (int)n;
                                    string path = cardColor + cardNumber.ToString() + ".png";
                                    this.Deck[i] = new Card { MyType = t, MyColor = c, MyNumber = n, MyValue = num, MyImagePath = path };
                                    this.Deck[i + 1] = new Card { MyType = t, MyColor = c, MyNumber = n, MyValue = num, MyImagePath = path };
                                    i += 2;
                                }
                                else
                                {
                                    int num = (int)n;
                                    string path = cardColor + cardNumber.ToString() + ".png";
                                    this.Deck[i] = new Card { MyType = t, MyColor = c, MyNumber = n, MyValue = num, MyImagePath = path };
                                    i++;
                                }
                            }
                        }
                        else
                        {
                            string path = cardType + cardColor + ".png";
                            this.Deck[i] = new Card { MyType = t, MyColor = c, MyValue = 20, MyImagePath = path };
                            this.Deck[i + 1] = new Card { MyType = t, MyColor = c, MyValue = 20, MyImagePath = path };
                            i += 2;
                        }
                    }
                }
                else
                {
                    string path = cardType + ".png";
                    this.Deck[i] = new Card { MyType = t, MyValue = 50, MyImagePath = path };
                    this.Deck[i + 1] = new Card { MyType = t, MyValue = 50, MyImagePath = path };
                    this.Deck[i + 2] = new Card { MyType = t, MyValue = 50, MyImagePath = path };
                    this.Deck[i + 3] = new Card { MyType = t, MyValue = 50, MyImagePath = path };
                    i += 4;
                }
            }

            this.ShuffleCards();
        }

        /// <summary>
        /// The method used when shuffling the cards.
        /// </summary>
        public void ShuffleCards()
        {
            Random rand = new Random();
            Card temp;

            for (int shuffleTimes = 0; shuffleTimes < 100; shuffleTimes++)
            {
                for (int i = 0; i < NumOfCards; i++)
                {
                    int secondCardIndex = rand.Next(30);
                    temp = this.Deck[i];
                    this.Deck[i] = this.Deck[secondCardIndex];
                    this.Deck[secondCardIndex] = temp;
                }
            }
        }
    }
}
