//-----------------------------------------------------------------------
// <copyright file="Gameflow.cs" company="UNO">
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
    /// The class that represents the game flow.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Gameflow
    {
        /// <summary>
        /// The game deck for Uno.
        /// </summary>
        public DeckOfCards GameDeck;

        /// <summary>
        /// A player in the game.
        /// </summary>
        public Player Player1;

        /// <summary>
        /// A computer opponent.
        /// </summary>
        public Player Player2;

        /// <summary>
        /// Another player
        /// </summary>
        public Player Player3;

        /// <summary>
        /// Another player
        /// </summary>
        public Player Player4;

        /// <summary>
        /// Another player
        /// </summary>
        public Player Player5;

        /// <summary>
        /// Another player
        /// </summary>
        public Player Player6;

        /// <summary>
        /// Another player
        /// </summary>
        public Player Player7;

        /// <summary>
        /// Another player
        /// </summary>
        public Player Player8;

        /// <summary>
        /// Another player
        /// </summary>
        public Player Player9;

        /// <summary>
        /// Another player
        /// </summary>
        public Player Player10;

        /// <summary>
        /// The current deck as cards are removed.
        /// </summary>
        public List<Card> CurrentDeck;

        /// <summary>
        /// The Central Pile Cards.
        /// </summary>
        public List<Card> CentralPile;

        /// <summary>
        /// Used to determine who's turn it is (1 for Player, 2 for Computer).
        /// </summary>
        public int PlayerTurn;

        /// <summary>
        /// Used to determine the type of game mode.
        /// </summary>
        public Mode GameMode;

        /// <summary>
        /// Used to determine the rotation in which turns take place.
        /// </summary>
        public bool Clockwise;

        /// <summary>
        /// determines whether we are currently in game
        /// </summary>
        public bool InGame = false;

        /// <summary>
        /// The method used to deal cards to the players.
        /// </summary>
        /// <param name="mode">The mode of the game.</param>
        public void DealCards(Mode mode)
        {
            this.GameMode = mode;
            this.CurrentDeck = this.GameDeck.Deck.ToList<Card>();
            if (this.GameMode == Mode.TwoPlayers)
            {
                for (int i = 0; i < 7; i++)
                {
                    this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                }
            }
            else if (this.GameMode == Mode.ThreePlayers)
            {
                for (int i = 0; i < 7; i++)
                {
                    this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                }
            }
            else if (this.GameMode == Mode.FourPlayers)
            {
                for (int i = 0; i < 7; i++)
                {
                    this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                }
            }
            else if (this.GameMode == Mode.FivePlayers)
            {
                for (int i = 0; i < 7; i++)
                {
                    this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                }
            }
            else if (this.GameMode == Mode.SixPlayers)
            {
                for (int i = 0; i < 7; i++)
                {
                    this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                }
            }
            else if (this.GameMode == Mode.SevenPlayers)
            {
                for (int i = 0; i < 7; i++)
                {
                    this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player7.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                }
            }
            else if (this.GameMode == Mode.EightPlayers)
            {
                for (int i = 0; i < 7; i++)
                {
                    this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player7.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player8.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                }
            }
            else if (this.GameMode == Mode.NinePlayers)
            {
                for (int i = 0; i < 7; i++)
                {
                    this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player7.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player8.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player9.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                }
            }
            else if (this.GameMode == Mode.TenPlayers)
            {
                for (int i = 0; i < 7; i++)
                {
                    this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player7.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player8.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player9.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Player10.PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                }
            }

            this.CentralPile = new List<Card>();
            int index = 0;
            
            while (true)
            {
                Card c = this.CurrentDeck[index];
                if (c.MyType == Card.Type.Number)
                {
                    this.CentralPile.Add(this.CurrentDeck[index]);
                    this.CurrentDeck.RemoveAt(index);
                    break;
                }
                else
                {
                    index++;
                }
            }    
        }

        /// <summary>
        /// Draws a card.
        /// </summary>
        /// <param name="player">The player who is drawing the card.</param>
        public void DrawCard(Player player)
        {
            if (this.InGame)
            {
                player.PlayerHand.Add(this.CurrentDeck[0]);
                this.CurrentDeck.RemoveAt(0);
            }
            else
            {
                if (this.CurrentDeck == null)
                {
                    this.CurrentDeck = this.GameDeck.Deck.ToList<Card>();
                }

                player.PlayerHand.Add(this.CurrentDeck[0]);
                this.CurrentDeck.RemoveAt(0);
            }
        }

        /// <summary>
        /// Checks to see if the computer has a card to play and places the first card that works
        /// </summary>
        /// <param name="hand">The hand that is being looked at.</param>
        /// <returns>The card that the computer plans to play.</returns>
        public Card CheckCompHand(List<Card> hand)
        {
            Card card = null;
            Card check = this.CentralPile[this.CentralPile.Count - 1];
            foreach (Card c in hand)
            {
                if (((c.MyNumber == check.MyNumber) && (check.MyValue != 20 && check.MyValue != 50) && (c.MyValue != 20)) || c.MyColor == check.MyColor || c.MyType == Card.Type.Wild || c.MyType == Card.Type.WildDraw4 || 
                    (c.MyType == Card.Type.Skip && check.MyType == Card.Type.Skip) || (c.MyType == Card.Type.Reverse && check.MyType == Card.Type.Reverse) || 
                    (c.MyType == Card.Type.Draw2 && check.MyType == Card.Type.Draw2))
                {
                    card = c;
                    hand.Remove(c);
                    break;
                }
            }

            if (card != null && (card.MyType == Card.Type.Wild || card.MyType == Card.Type.WildDraw4))
            {
                int redCount = 0;
                int blueCount = 0;
                int greenCount = 0;
                int yellowCount = 0;

                foreach (Card c in hand)
                {
                    if (c.MyColor == Card.Color.Blue)
                    {
                        blueCount++;
                    }
                    else if (c.MyColor == Card.Color.Red)
                    {
                        redCount++;
                    }
                    else if (c.MyColor == Card.Color.Green)
                    {
                        greenCount++;
                    }
                    else if (c.MyColor == Card.Color.Yellow)
                    {
                        yellowCount++;
                    }
                }

                if (redCount >= blueCount && redCount >= greenCount && redCount >= yellowCount)
                {
                    card.MyColor = Card.Color.Red;
                }
                else if (blueCount > redCount && blueCount >= greenCount && blueCount >= yellowCount)
                {
                    card.MyColor = Card.Color.Blue;
                }
                else if (greenCount > redCount && greenCount > blueCount && greenCount >= yellowCount)
                {
                    card.MyColor = Card.Color.Green;
                }
                else
                {
                    card.MyColor = Card.Color.Yellow;
                }
            }

            return card;
        }

        /// <summary>
        /// Checks to see if the card the player is trying to place works with the given Pile card
        /// </summary>
        /// <param name="c">Returns the card.</param>
        /// <returns>true or false</returns>
        public bool CanPlaceCard(Card c)
        {
            Card check = this.CentralPile[this.CentralPile.Count - 1];
            if ((c.MyNumber == check.MyNumber && (check.MyValue != 20 && check.MyValue != 50) && (c.MyValue != 20)) || c.MyColor == check.MyColor || c.MyType == Card.Type.Wild ||
                c.MyType == Card.Type.WildDraw4 || (c.MyType == Card.Type.Skip && check.MyType == Card.Type.Skip) || (c.MyType == Card.Type.Reverse && check.MyType == Card.Type.Reverse) ||
                (c.MyType == Card.Type.Draw2 && check.MyType == Card.Type.Draw2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks the users hand for any of the cards available in the cards list.
        /// </summary>
        /// <param name="hand">Returns the hand that the player has.</param>
        /// <returns>True or false</returns>
        public bool CheckUserHand(List<Card> hand)
        {
            Card check = this.CentralPile[this.CentralPile.Count - 1];
            foreach (Card c in hand)
            {
                if ((c.MyNumber == check.MyNumber && (check.MyValue != 20 && check.MyValue != 50) && (c.MyValue != 20)) || c.MyColor == check.MyColor || c.MyType == Card.Type.Wild || 
                    c.MyType == Card.Type.WildDraw4 || (c.MyType == Card.Type.Skip && check.MyType == Card.Type.Skip) || (c.MyType == Card.Type.Reverse && check.MyType == Card.Type.Reverse) || 
                    (c.MyType == Card.Type.Draw2 && check.MyType == Card.Type.Draw2))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Uses the draw two or four method.
        /// </summary>
        /// <param name="n">Returns the integer n.</param>
        public void DrawTwoOrFour(int n)
        {
            if (this.GameMode == Mode.TenPlayers)
            {
                if (this.Clockwise)
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 4)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 5)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 6)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player7.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 7)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player8.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 8)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player9.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 9)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player10.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player10.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 4)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 5)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 6)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 7)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 8)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player7.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 9)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player8.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player9.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
            }
            else if (this.GameMode == Mode.NinePlayers)
            {
                if (this.Clockwise)
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 4)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 5)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 6)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player7.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 7)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player8.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 8)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player9.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player9.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 4)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 5)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 6)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 7)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 8)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player7.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player8.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
            }
            else if (this.GameMode == Mode.EightPlayers)
            {
                if (this.Clockwise)
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 4)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 5)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 6)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player7.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 7)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player8.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player8.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 4)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 5)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 6)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 7)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player7.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
            }
            else if (this.GameMode == Mode.SevenPlayers)
            {
                if (this.Clockwise)
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 4)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 5)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 6)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player7.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player7.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 4)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 5)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 6)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
            }
            else if (this.GameMode == Mode.SixPlayers)
            {
                if (this.Clockwise)
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 4)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 5)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player6.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 4)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 5)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
            }
            else if (this.GameMode == Mode.FivePlayers)
            {
                if (this.Clockwise)
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 4)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player5.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 4)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
            }
            else if (this.GameMode == Mode.FourPlayers)
            {
                if (this.Clockwise)
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player4.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 3)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
            }
            else if (this.GameMode == Mode.ThreePlayers)
            {
                if (this.Clockwise)
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    if (this.PlayerTurn == 1)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player3.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else if (this.PlayerTurn == 2)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                            this.CurrentDeck.RemoveAt(0);
                        }
                    }
                }
            }
            else
            {
                if (this.PlayerTurn == 1)
                {
                    for (int i = 0; i < n; i++)
                    {
                        this.Player2.PlayerHand.Add(this.CurrentDeck[0]);
                        this.CurrentDeck.RemoveAt(0);
                    }
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        this.Player1.PlayerHand.Add(this.CurrentDeck[0]);
                        this.CurrentDeck.RemoveAt(0);
                    }
                }
            }
        }
    }
}