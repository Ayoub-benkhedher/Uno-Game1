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

        ///// <summary>
        ///// A player in the game.
        ///// </summary>
        // public Player Player1;

        ///// <summary>
        ///// A computer opponent.
        ///// </summary>
        // public Player Player2;

        /// <summary>
        /// list of players in the game.
        /// </summary>
        public List<Player> Players;

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
                    this.Players[0].PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                    this.Players[1].PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                }
            }
            else if (this.GameMode == Mode.MultiplePlayers)
            {
                this.Players.ForEach(p =>
                {
                    for (int i = 0; i < 7; i++)
                    {
                        p.PlayerHand.Add(this.CurrentDeck[0]);
                        this.CurrentDeck.RemoveAt(0);
                    }

                    Console.WriteLine("p cards = " + p.PlayerHand.Count);
                });
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

        // public void DealCards(Mode mode, Player p)
        // {
        ////    Console.WriteLine("fi wast dealCards ");
        ////    this.GameMode = mode;
        ////    this.CurrentDeck = this.GameDeck.Deck.ToList<Card>();
        ////    Console.WriteLine("chouf mode  " + this.GameMode);
        ////    // if (this.GameMode == Mode.MultiplePlayers)
        ////    // {
        ////        Console.WriteLine("dalit wast hedhi " );
        ////        for (int i = 0; i < 7; i++)
        ////        {
        ////        if (this.CurrentDeck[0] == null)
        ////            Console.WriteLine("c null");
        ////        else
        ////           Console.WriteLine("c not null");

        ////            p.PlayerHand.Add(this.CurrentDeck[0]);
        ////            this.CurrentDeck.RemoveAt(0);
        ////            Console.WriteLine("currentt deck now has " + this.CurrentDeck.Count);
        //        }
        //        Console.WriteLine("p after dealCards " + p.PlayerHand.ToString());
        //    // }
        //        // this.CentralPile = new List<Card>();
        //        // int index = 0;

        ////        // while (true)
        //        // {
        //        //    Card c = this.CurrentDeck[index];
        //        //    if (c.MyType == Card.Type.Number)
        //        //    {
        //        //        this.CentralPile.Add(this.CurrentDeck[index]);
        //        //        this.CurrentDeck.RemoveAt(index);
        //        //        break;
        //        //    }
        //        //    else
        //        //    {
        //        //        index++;
        //        //    }
        //        // }
            
        // }

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
            if (this.GameMode == Mode.MultiplePlayers)
            {
                int receiverIndex = -1;
                if (this.Clockwise)
                {
                    receiverIndex = this.PlayerTurn % this.Players.Count;
                }
                else
                {
                    receiverIndex = (this.PlayerTurn - 2 + this.Players.Count) % this.Players.Count;
                }

                for (int i = 0; i < n; i++)
                {
                    this.Players[receiverIndex].PlayerHand.Add(this.CurrentDeck[0]);
                    this.CurrentDeck.RemoveAt(0);
                }
            }
            else
            {
                if (this.PlayerTurn == 1)
                {
                    for (int i = 0; i < n; i++)
                    {
                        this.Players[1].PlayerHand.Add(this.CurrentDeck[0]);
                        this.CurrentDeck.RemoveAt(0);
                    }
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        this.Players[0].PlayerHand.Add(this.CurrentDeck[0]);
                        this.CurrentDeck.RemoveAt(0);
                    }
                }
            }
        }
    }
}