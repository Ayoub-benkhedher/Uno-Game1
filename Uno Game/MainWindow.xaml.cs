//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="UNO">
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
    /// The game mode.
    /// </summary>
    public enum Mode
    {
        /// <summary>
        /// Theme that is a mix.
        /// </summary>
        TwoPlayers = 1,

        /// <summary>
        /// Theme that is a sport.
        /// </summary>
        MultiplePlayers = 2
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Our Uno game.
        /// </summary>
        public Gameflow UnoGame;

        /// <summary>
        /// Used to determine current placement of cards in player hand.
        /// </summary>
        public int X = 70;

        /// <summary>
        /// Used to determine current placement of cards in player hand.
        /// </summary>
        public int X2 = 800;

        /// <summary>
        /// Used to determine current placement of cards in computer hand.
        /// </summary>
        public int CompX = 70;

        /// <summary>
        /// Last image of the computer
        /// </summary>
        public Image LastImage;

        /// <summary>
        /// Determines whether we are in tutorial
        /// </summary>
        private bool tutorial;

        /// <summary>
        /// The type of Game Mode.
        /// </summary>
        private Mode gameMode;

        /// <summary>
        /// number of players in game
        /// </summary>
        private int numberOfPlayers;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="mode">The game mode.</param>
        /// <param name="p">The number of players</param>
        /// <param name="tut">Whether we are in tutorial</param>
        public MainWindow(Mode mode, int p, bool tut)
        {
            this.gameMode = mode;
            this.InitializeComponent();
            this.numberOfPlayers = p;
            this.tutorial = tut;
            if (tut)
            {
                this.lblTutorialStep1.Visibility = Visibility.Visible;
                this.stepOneCircle.Visibility = Visibility.Visible;
                this.BtnChooseDealerTutorial.Visibility = Visibility.Visible;
            }
            else
            {
                this.BtnChooseDealer.Visibility = Visibility.Visible;
            }

            this.BtnNewGame.Visibility = Visibility.Hidden;
            this.imgDeckPile.Visibility = Visibility.Hidden;
            this.DataContext = this;
            this.lblDrawCard.Visibility = Visibility.Hidden;
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(((i + 1) % 10) + 1);
            }
        }

        /// <summary>
        /// Rebinds the cards to the computer.
        /// </summary>
        public void RebindComputerCards()
        {
            //// Creates image for new card
            Image dynamicImage1 = new Image();
            dynamicImage1.Width = 150;
            dynamicImage1.Height = 100;

            //// Create a BitmapSource  
            BitmapImage bitmap1 = new BitmapImage();
            bitmap1.BeginInit();
            bitmap1.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/Back.jpg");
            bitmap1.EndInit();

            //// Set Image.Source  
            dynamicImage1.Source = bitmap1;
            dynamicImage1.HorizontalAlignment = HorizontalAlignment.Left;
            dynamicImage1.VerticalAlignment = VerticalAlignment.Top;
            dynamicImage1.Margin = new Thickness(this.CompX, 0, 0, 0);
            //// Add Image to Window  
            grdMainWindow.Children.Add(dynamicImage1);
        }

        /// <summary>
        /// Shows computer draw card
        /// </summary>
        /// <param name="path"> Sends in the path for the string.</param>
        public void CreateComputerDrawCard(string path)
        {
            //// Create Image and set its width and height  
            Image dynamicImage = new Image();
            dynamicImage.Width = 150;
            dynamicImage.Height = 100;

            //// Create a BitmapSource  
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/" + path);
            bitmap.EndInit();

            //// Set Image.Source  
            dynamicImage.Source = bitmap;
            dynamicImage.HorizontalAlignment = HorizontalAlignment.Left;
            dynamicImage.VerticalAlignment = VerticalAlignment.Top;
            dynamicImage.Margin = new Thickness(this.X, 0, 0, 0);

            dynamicImage.MouseLeftButtonUp += this.DynamicImage_MouseLeftButtonUp;
            this.X += 70;
            ////Add Image to Window  
            grdMainWindow.Children.Add(dynamicImage);
        }

        /// <summary>
        /// Displays which players turn it is.
        /// </summary>
        public void DisplayPlayerTurn()
        {
            if (this.UnoGame.PlayerTurn == 2)
            {
                lblPlayer.Content = "Computer";
            }
            else
            {
                lblPlayer.Content = "Player " + this.UnoGame.PlayerTurn;
            }
        }

        /// <summary>
        /// Closes the game.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Sets up the images for the game.
        /// </summary>
        /// <param name="path"> Sends in the path for the string.</param>
        private void CreateViewImageDynamically(string path)
        {
            //// Create Image and set its width and height  
            Image dynamicImage = new Image();
            dynamicImage.Width = 150;
            dynamicImage.Height = 100;

            //// Create a BitmapSource  
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/" + path);
            bitmap.EndInit();

            //// Set Image.Source  
            dynamicImage.Source = bitmap;
            dynamicImage.HorizontalAlignment = HorizontalAlignment.Left;
            dynamicImage.VerticalAlignment = VerticalAlignment.Top;
            dynamicImage.Margin = new Thickness(this.X, 400, 0, 0);

            dynamicImage.MouseLeftButtonUp += this.DynamicImage_MouseLeftButtonUp;
            this.X += 70;
            ////Add Image to Window  
            grdMainWindow.Children.Add(dynamicImage);
        }

        /// <summary>
        /// Creates the player hand card images.
        /// </summary>
        /// <param name="player"> Sends in the player.</param>
        private void CreatePlayerHandCardImages(Player player)
        {
            if (this.UnoGame.PlayerTurn != 2)
            {
                this.X = 70;
                for (int i = 0; i < player.PlayerHand.Count; i++)
                {
                    this.CreateViewImageDynamically(player.PlayerHand[i].MyImagePath);
                }
            }
        }

        /// <summary>
        /// Deletes the card images.
        /// </summary>
        /// <param name="player"> Sends in the player.</param>
        private void DeleteCardImages(Player player)
        {
            //// used to determine how many images have been already removed
            int count = 0;

            //// used to determine index in grid
            int currentIndex = 0;

            while (count < player.PlayerHand.Count)
            {
                UIElement element = grdMainWindow.Children[currentIndex];

                //// checks to see if the element is of an image
                if (element.GetType().Equals(typeof(Image)))
                {
                    Image image = element as Image;
                    if ((int)image.Margin.Top == 400)
                    {
                        //// we remove every image in PlayerHand (where margin.top == 400)
                        grdMainWindow.Children.Remove(image);

                        //// increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                        count++;
                    }
                    else
                    {
                        //// if element is not image in PlayerHand, we increment index
                        currentIndex++;
                    }
                }
                else
                {
                    //// If element is not an image, we increment index
                    currentIndex++;
                }
            }
        }

        /// <summary>
        /// Shows how many cards are in the players hand.
        /// </summary>
        private void Playershandscount()
        {
            lstPlayers.Items.Clear();
            for (int i = 1; i < this.numberOfPlayers + 1; i++)
            {
                lstPlayers.Items.Add("Player " + i + " has " + this.UnoGame.Players[i - 1].PlayerHand.Count + " cards");
            }
        }

        /// <summary>
        /// Sets up the images for the game.
        /// </summary>
        /// <param name="path"> Sends in the path for the string.</param>
        //// private void CreateViewImageDynamically2(string path)
        //// {
        ////    //// Create Image and set its width and height  
        ////    Image dynamicImage = new Image();
        ////    dynamicImage.Width = 150;
        ////   dynamicImage.Height = 100;

        ////    //// Create a BitmapSource  
        ////    BitmapImage bitmap = new BitmapImage();
        ////    bitmap.BeginInit();
        ////    bitmap.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/" + path);
        ////    bitmap.EndInit();

        ////    //// Set Image.Source  
        ////    dynamicImage.Source = bitmap;
        ////    dynamicImage.HorizontalAlignment = HorizontalAlignment.Left;
        ////    dynamicImage.VerticalAlignment = VerticalAlignment.Top;
        ////    dynamicImage.Margin = new Thickness(this.X2, 250, 0, 0);

        ////    dynamicImage.MouseLeftButtonUp += this.DynamicImage1_MouseLeftButtonUp;
        ////    this.X2 += 70;
        ////    ////Add Image to Window  
        ////    grdMainWindow.Children.Add(dynamicImage);
        //// }

        /// <summary>
        /// Throw the card to the central pile.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void DynamicImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.tutorial)
            {
                if (this.UnoGame.Players[0].PlayerHand.Count == 2)
                {
                    this.lblTutorialStep4.Visibility = Visibility.Visible;
                }
                else
                {
                    this.lblTutorialStep4.Visibility = Visibility.Hidden;
                }

                this.lblTutorialStep6.Visibility = Visibility.Visible;
                this.lblTutorialStep3.Visibility = Visibility.Hidden;
                this.BtnEndTutorial.Visibility = Visibility.Visible;
            }

            int playerNumber = -1;
            for (int i = 1; i <= this.numberOfPlayers; i++)
            {
                if (i == this.UnoGame.PlayerTurn)
                {
                    playerNumber = i - 1;
                }
            }

            Image dynamicImage = sender as Image;

            string path = dynamicImage.Source.ToString();
            path = path.Remove(0, 34);
            Card checkCard = new Card();

            foreach (Card c in this.UnoGame.Players[playerNumber].PlayerHand)
            {
                if (c.MyImagePath == path)
                {
                    checkCard = c;
                    break;
                }
            }

            this.UnoGame.Players[playerNumber].Score = this.UnoGame.Players[playerNumber].TotalCardValue();

            if (this.UnoGame.CanPlaceCard(checkCard))
            {
                //// removes the image of the card we selected to play
                grdMainWindow.Children.Remove(dynamicImage);

                ////// used to determine how many images have been already removed
                ////int count = 0;

                ////// used to determine index in grid
                ////int currentIndex = 0;

                ////// since we have already removed one image, we will be completely removing the rest of the images, which is equivalent to number of cards in PlayerHand - 1
                ////while (count < this.UnoGame.Players[PlayerNumber].PlayerHand.Count - 1)
                ////{
                ////    UIElement element = grdMainWindow.Children[currentIndex];

                ////    //// checks to see if the element is of an image
                ////    if (element.GetType().Equals(typeof(Image)))
                ////    {
                ////        Image image = element as Image;
                ////        if ((int)image.Margin.Top == 400)
                ////        {
                ////            //// we remove every image in PlayerHand (where margin.top == 400)
                ////           grdMainWindow.Children.Remove(image);

                ////            //// increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                ////            count++;
                ////        }
                ////        else
                ////        {
                ////            //// if element is not image in PlayerHand, we increment index
                ////            currentIndex++;
                ////        }
                ////    }
                ////    else
                ////    {
                ////        //// if element is not an image, we increment index
                ////        currentIndex++;
                ////    }
                ////}
                imgMainPile.Source = dynamicImage.Source;

                //// update actual PlayerHand and Center Pile
                for (int i = 0; i < this.UnoGame.Players[playerNumber].PlayerHand.Count; i++)
                {
                    if (path == this.UnoGame.Players[playerNumber].PlayerHand[i].MyImagePath)
                    {
                        this.UnoGame.CentralPile.Add(this.UnoGame.Players[playerNumber].PlayerHand[i]);
                        this.UnoGame.Players[playerNumber].PlayerHand.RemoveAt(i);
                        break;
                    }
                }

                this.DeleteCardImages(this.UnoGame.Players[playerNumber]);

                ////this.X = 70;

                ////CreatePlayerHandCardImages(UnoGame.Players[PlayerNumber]);

                //// Perform the draw two card
                //// Else performs the wilddraw4 card
                if (path.Substring(0, 4) == "Draw")
                {
                    int n = int.Parse(path.Substring(4, 1));
                    if (this.gameMode == Mode.MultiplePlayers)
                    {
                        this.UnoGame.DrawTwoOrFour(n);

                        if (this.UnoGame.Clockwise)
                        {
                            if (this.UnoGame.PlayerTurn == 1)
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    this.RebindComputerCards();
                                    this.CompX += 70;
                                }
                            }
                            ////else
                            ////{
                            ////    CreatePlayerHandCardImages(this.UnoGame.Players[this.UnoGame.PlayerTurn % NumberOfPlayers]);

                            ////}
                        }
                        else
                        {
                            if (this.UnoGame.PlayerTurn == 3)
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    this.RebindComputerCards();
                                    this.CompX += 70;
                                }
                            }
                            else
                            {
                                ////this.X2 = 800;
                                int receiverIndex = (this.UnoGame.PlayerTurn - 2 + this.numberOfPlayers) % this.numberOfPlayers;
                                this.CreatePlayerHandCardImages(this.UnoGame.Players[receiverIndex]);
                            }
                            ////// display player's hand
                            ////foreach (Card crd in this.UnoGame.Players[2].PlayerHand)
                            ////{
                            ////    this.CreateViewImageDynamically2(crd.MyImagePath);
                            ////}
                        }
                    }
                    else
                    {
                        this.UnoGame.DrawTwoOrFour(n);
                        for (int i = 0; i < n; i++)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                    }
                }
                else if (path.Substring(0, 8) == "WildDraw")
                {
                    int n = int.Parse(path.Substring(8, 1));
                    this.UnoGame.DrawTwoOrFour(n);

                    ////if (this.UnoGame.Clockwise)
                    ////{
                    ////    if (this.UnoGame.PlayerTurn == 1)
                    ////    {
                    ////        for (int i = 0; i < n; i++)
                    ////        {
                    ////            this.RebindComputerCards();
                    ////            this.CompX += 70;
                    ////        }
                    ////    }
                    ////    else
                    ////    {
                    ////        CreatePlayerHandCardImages(this.UnoGame.Players[this.UnoGame.PlayerTurn % NumberOfPlayers]);
                    ////    }

                    ////    if (this.UnoGame.Clockwise)
                    ////{
                    ////    this.UnoGame.DrawTwoOrFour(n);
                    ////    for (int i = 0; i < n; i++)
                    ////    {
                    ////        this.RebindComputerCards();
                    ////        this.CompX += 70;
                    ////    }
                    ////}
                    ////else
                    ////{
                    ////    //// used to determine how many images have been already removed
                    ////    int count2 = 0;

                    ////    //// used to determine index in grid
                    ////    int currentIndex2 = 0;
                    ////    while (count2 < this.UnoGame.Players[2].PlayerHand.Count)
                    ////    {
                    ////        UIElement element = grdMainWindow.Children[currentIndex2];

                    ////        //// checks to see if the element is of an image
                    ////        if (element.GetType().Equals(typeof(Image)))
                    ////        {
                    ////            Image image = element as Image;
                    ////            if ((int)image.Margin.Top == 250)
                    ////            {
                    ////                //// we remove every image in PlayerHand (where margin.top == 400)
                    ////                grdMainWindow.Children.Remove(image);

                    ////                //// increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                    ////                count2++;
                    ////            }
                    ////            else
                    ////            {
                    ////                //// if element is not image in PlayerHand, we increment index
                    ////                currentIndex2++;
                    ////            }
                    ////        }
                    ////        else
                    ////        {
                    ////            //// If element is not an image, we increment index
                    ////            currentIndex2++;
                    ////        }
                    ////    }

                    ////    this.UnoGame.DrawTwoOrFour(n);
                    ////    this.X2 = 800;

                    ////    //// display player's hand
                    ////    //foreach (Card crd in this.UnoGame.Players[2].PlayerHand)
                    ////    //{
                    ////    //    this.CreateViewImageDynamically2(crd.MyImagePath);
                    ////    //}
                    ////}
                    if (this.gameMode == Mode.MultiplePlayers)
                    {
                        ////this.UnoGame.DrawTwoOrFour(n);

                        if (this.UnoGame.Clockwise)
                        {
                            if (this.UnoGame.PlayerTurn == 1)
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    this.RebindComputerCards();
                                    this.CompX += 70;
                                }
                            }
                            else
                            {
                                ////CreatePlayerHandCardImages(this.UnoGame.Players[this.UnoGame.PlayerTurn % NumberOfPlayers]);
                            }
                        }
                        else
                        {
                            if (this.UnoGame.PlayerTurn == 3)
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    this.RebindComputerCards();
                                    this.CompX += 70;
                                }
                            }
                            ////this.X2 = 800;
                            ////int receiverIndex = (this.UnoGame.PlayerTurn - 2 + this.NumberOfPlayers) % this.NumberOfPlayers;
                            ////CreatePlayerHandCardImages(this.UnoGame.Players[receiverIndex]);
                            ////// display player's hand
                            ////foreach (Card crd in this.UnoGame.Players[2].PlayerHand)
                            ////{
                            ////   this.CreateViewImageDynamically2(crd.MyImagePath);
                            ////}
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                    }

                    new Colors(checkCard).ShowDialog();
                    MessageBox.Show(checkCard.MyColor.ToString());
                }
                else if (path.Substring(0, 4) == "Wild")
                {
                    new Colors(checkCard).ShowDialog();
                    MessageBox.Show(checkCard.MyColor.ToString());
                }

                //// If the card is Reverse or Skip player stays the same 
                //// If the card is Reverse or Skip player stays the same 
                if ((path.Substring(0, 7) != "Reverse") && (path.Substring(0, 4) != "Skip") && (path.Substring(0, 4) != "Draw") && (path.Substring(0, 8) != "WildDraw"))
                {
                    if (this.gameMode == Mode.MultiplePlayers)
                    {
                        if (this.UnoGame.Clockwise)
                        {
                            if (playerNumber != this.numberOfPlayers - 1)
                            {
                                this.UnoGame.PlayerTurn = playerNumber + 2;
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 1;
                            }
                            ////this.imgDeckPile.IsEnabled = false;
                            ////if ((PlayerNumber == 0) && (this.UnoGame.Players[PlayerNumber].PlayerHand.Count != 0))
                            ////{
                            ////    this.NextPlayerButton_Click(sender, e);
                            ////}
                        }
                        else
                        {
                            ////this.UnoGame.PlayerTurn = 3;
                            ////this.imgDeckPile.IsEnabled = true;
                            if (playerNumber != 0)
                            {
                                this.UnoGame.PlayerTurn = playerNumber;
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = this.numberOfPlayers;
                            }
                            ////this.imgDeckPile.IsEnabled = false;
                            ////if ((PlayerNumber == 2) && (this.UnoGame.Players[PlayerNumber].PlayerHand.Count != 0))
                            ////{
                            ////    this.NextPlayerButton_Click(sender, e);
                            ////}
                        }
                    }
                    else
                    {
                        if (playerNumber == 0)
                        {
                            this.UnoGame.PlayerTurn = 2;
                            ////this.imgDeckPile.IsEnabled = false;
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 1;
                        }
                    }
                }
                else
                {
                    if (this.gameMode == Mode.MultiplePlayers)
                    {
                        if (this.UnoGame.Clockwise)
                        {
                            if (path.Substring(0, 7) == "Reverse")
                            {
                                this.UnoGame.Clockwise = !this.UnoGame.Clockwise;

                                if (playerNumber != 0)
                                {
                                    this.UnoGame.PlayerTurn = playerNumber;
                                }
                                else
                                {
                                    this.UnoGame.PlayerTurn = this.numberOfPlayers;
                                }
                            }
                            else if ((path.Substring(0, 4) == "Skip") || (path.Substring(0, 4) == "Draw") || (path.Substring(0, 8) == "WildDraw"))
                            {
                                this.UnoGame.PlayerTurn = ((this.UnoGame.PlayerTurn + 1) % this.numberOfPlayers) + 1;
                                ////if ((PlayerNumber != NumberOfPlayers - 2) && (PlayerNumber != NumberOfPlayers - 1))
                                ////{
                                ////    this.UnoGame.PlayerTurn = PlayerNumber + 2;
                                ////}
                                ////else if (PlayerNumber == NumberOfPlayers - 2)
                                ////{
                                ////    this.UnoGame.PlayerTurn = 1;
                                ////}
                                ////else if (PlayerNumber == NumberOfPlayers - 1)
                                ////{
                                ////    this.UnoGame.PlayerTurn = 2;
                                ////    if (this.UnoGame.Players[0].PlayerHand.Count != 0)
                                ////    {
                                ////        this.NextPlayerButton_Click(sender, e);
                                ////    }
                                ////}
                            }
                            ////this.UnoGame.PlayerTurn = 3;
                            ////this.imgDeckPile.IsEnabled = true;
                        }
                        else
                        {
                            if (path.Substring(0, 7) == "Reverse")
                            {
                                this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
                                if (playerNumber != this.numberOfPlayers - 1)
                                {
                                    this.UnoGame.PlayerTurn = playerNumber + 2;
                                }
                                else
                                {
                                    this.UnoGame.PlayerTurn = 1;
                                }
                            }
                            else if ((path.Substring(0, 4) == "Skip") || (path.Substring(0, 4) == "Draw") || (path.Substring(0, 8) == "WildDraw"))
                            {
                                this.UnoGame.PlayerTurn = ((this.numberOfPlayers + this.UnoGame.PlayerTurn - 3) % this.numberOfPlayers) + 1;
                                ////if (PlayerNumber != 0 && PlayerNumber != 1)
                                ////{
                                ////    this.UnoGame.PlayerTurn = PlayerNumber - 1;
                                ////}
                                ////else if (PlayerNumber == 0)
                                ////{
                                ////    this.UnoGame.PlayerTurn = NumberOfPlayers - 1;
                                ////}
                                ////else if (PlayerNumber == 1)
                                ////{
                                ////    this.UnoGame.PlayerTurn = NumberOfPlayers;
                                ////}
                            }
                            ////if (this.UnoGame.PlayerTurn == 2)
                            ////{
                            ////    ////this.imgDeckPile.IsEnabled = false;
                            ////    if (this.UnoGame.Players[0].PlayerHand.Count != 0)
                            ////    {
                            ////        this.NextPlayerButton_Click(sender, e);
                            ////    }
                            ////}
                        }
                    }
                    else
                    {
                        ////this.imgDeckPile.IsEnabled = true;
                    }
                }

                this.UnoGame.Players[playerNumber].Score = this.UnoGame.Players[playerNumber].TotalCardValue();

                ////DeleteCardImages(UnoGame.Players[PlayerNumber]);
                if (this.UnoGame.Players[playerNumber].PlayerHand.Count == 0)
                {
                    MessageBox.Show("Congrats! Player " + (playerNumber + 1) + " win!");
                    this.DisplayValues();
                    this.imgDeckPile.IsEnabled = false;
                    this.UnoGame.PlayerTurn = 0;
                }
                else if (this.UnoGame.Players[playerNumber].PlayerHand.Count == 1)
                {
                    if (this.gameMode == Mode.MultiplePlayers)
                    {
                        this.CreatePlayerHandCardImages(this.UnoGame.Players[this.UnoGame.PlayerTurn - 1]);
                        BtnNoticeMissedUno.Visibility = Visibility.Visible;
                        if (playerNumber == 0)
                        {
                            BtnPlayer1Uno.Visibility = Visibility.Visible;
                        }

                        if (playerNumber == 1)
                        {
                            BtnPlayer2Uno.Visibility = Visibility.Visible;
                        }

                        if (playerNumber == 2)
                        {
                            BtnPlayer3Uno.Visibility = Visibility.Visible;
                        }

                        if (playerNumber == 3)
                        {
                            BtnPlayer4Uno.Visibility = Visibility.Visible;
                        }

                        if (playerNumber == 4)
                        {
                            BtnPlayer5Uno.Visibility = Visibility.Visible;
                        }

                        if (playerNumber == 5)
                        {
                            BtnPlayer6Uno.Visibility = Visibility.Visible;
                        }

                        if (playerNumber == 6)
                        {
                            BtnPlayer7Uno.Visibility = Visibility.Visible;
                        }

                        if (playerNumber == 7)
                        {
                            BtnPlayer8Uno.Visibility = Visibility.Visible;
                        }

                        if (playerNumber == 8)
                        {
                            BtnPlayer9Uno.Visibility = Visibility.Visible;
                        }

                        if (playerNumber == 9)
                        {
                            BtnPlayer10Uno.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        this.CreatePlayerHandCardImages(this.UnoGame.Players[this.UnoGame.PlayerTurn - 1]);
                        if (playerNumber == 0)
                        {
                            BtnPlayer1Uno.Visibility = Visibility.Visible;
                        }

                        if (playerNumber == 1)
                        {
                            BtnPlayer2Uno.Visibility = Visibility.Visible;
                        }
                    }
                }
                else
                {
                     this.CreatePlayerHandCardImages(this.UnoGame.Players[this.UnoGame.PlayerTurn - 1]);
                }

                if (BtnPlayer1Uno.Visibility == Visibility.Visible && this.UnoGame.Players[0].PlayerHand.Count > 1)
                {
                    BtnPlayer1Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer2Uno.Visibility == Visibility.Visible && this.UnoGame.Players[1].PlayerHand.Count > 1)
                {
                    BtnPlayer2Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer3Uno.Visibility == Visibility.Visible && this.UnoGame.Players[2].PlayerHand.Count > 1)
                {
                    BtnPlayer3Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer4Uno.Visibility == Visibility.Visible && this.UnoGame.Players[3].PlayerHand.Count > 1)
                {
                    BtnPlayer4Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer5Uno.Visibility == Visibility.Visible && this.UnoGame.Players[4].PlayerHand.Count > 1)
                {
                    BtnPlayer5Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer6Uno.Visibility == Visibility.Visible && this.UnoGame.Players[5].PlayerHand.Count > 1)
                {
                    BtnPlayer6Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer7Uno.Visibility == Visibility.Visible && this.UnoGame.Players[6].PlayerHand.Count > 1)
                {
                    BtnPlayer7Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer8Uno.Visibility == Visibility.Visible && this.UnoGame.Players[7].PlayerHand.Count > 1)
                {
                    BtnPlayer8Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer9Uno.Visibility == Visibility.Visible && this.UnoGame.Players[8].PlayerHand.Count > 1)
                {
                    BtnPlayer9Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer10Uno.Visibility == Visibility.Visible && this.UnoGame.Players[9].PlayerHand.Count > 1)
                {
                    BtnPlayer10Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }
            }

            this.DisplayPlayerTurn();
            this.Playershandscount();
            ////MessageBox.Show("Now it is Player " + UnoGame.PlayerTurn + "Turn");
            ////if (this.UnoGame.Players[PlayerNumber].PlayerHand.Count == 0)
            ////{
            ////    MessageBox.Show("Congrats! Player " + UnoGame.PlayerTurn + " win!");
            ////    ////this.imgDeckPile.IsEnabled = false;
            ////    this.UnoGame.PlayerTurn = 0;
            ////}
            ////else
            ////{
            ////    CreatePlayerHandCardImages(UnoGame.Players[UnoGame.PlayerTurn - 1]);
            ////}
            if (this.UnoGame.PlayerTurn == 2)
            {
                this.NextPlayerButton_Click(sender, e);
            }
        }

        /*
        /// <summary>
        /// Throw the card to the central pile.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        ////private void DynamicImage1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        ////{
        ////    if (this.UnoGame.PlayerTurn == 3)
        ////    {
        //        Image dynamicImage = sender as Image;

        //        string path = dynamicImage.Source.ToString();
        //        path = path.Remove(0, 34);
        //        Card checkCard = new Card();

        //        foreach (Card c in this.UnoGame.Players[2].PlayerHand)
        //        {
        //            if (c.MyImagePath == path)
        //            {
        //                checkCard = c;
        //                break;
        //            }
        //        }

        //        if (this.UnoGame.CanPlaceCard(checkCard))
        //        {
        //            //// removes the image of the card we selected to play
        //            grdMainWindow.Children.Remove(dynamicImage);

        //            //// used to determine how many images have been already removed
        //            int count = 0;

        //            //// used to determine index in grid
        //            int currentIndex = 0;

        //            //// since we have already removed one image, we will be completely removing the rest of the images, which is equivalent to number of cards in PlayerHand - 1
        //            while (count < this.UnoGame.Players[2].PlayerHand.Count - 1)
        //            {
        //                UIElement element = grdMainWindow.Children[currentIndex];

        //                //// checks to see if the element is of an image
        //                if (element.GetType().Equals(typeof(Image)))
        //                {
        //                    Image image = element as Image;
        //                    if ((int)image.Margin.Top == 250)
        //                    {
        //                        //// we remove every image in PlayerHand (where margin.top == 400)
        //                        grdMainWindow.Children.Remove(image);

        //                        //// increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
        //                        count++;
        //                    }
        //                    else
        //                    {
        //                        //// if element is not image in PlayerHand, we increment index
        //                        currentIndex++;
        //                    }
        //                }
        //                else
        //                {
        //                    //// if element is not an image, we increment index
        //                    currentIndex++;
        //                }
        //            }

        //            imgMainPile.Source = dynamicImage.Source;

        //            //// update actual PlayerHand and Center Pile
        //            for (int i = 0; i < this.UnoGame.Players[2].PlayerHand.Count; i++)
        //            {
        //                if (path == this.UnoGame.Players[2].PlayerHand[i].MyImagePath)
        //                {
        //                    this.UnoGame.CentralPile.Add(this.UnoGame.Players[2].PlayerHand[i]);
        //                    this.UnoGame.Players[2].PlayerHand.RemoveAt(i);
        //                    break;
        //                }
        //            }

        //            this.X2 = 800;

        //            //// Recreate Playerhand now that images are updated
        //            foreach (Card crd in this.UnoGame.Players[2].PlayerHand)
        //            {
        //                this.CreateViewImageDynamically2(crd.MyImagePath);
        //            }

        //            //// Perform the draw two card
        //            //// Else performs the wilddraw4 card
        //            if (path.Substring(0, 4) == "Draw")
        //            {
        //                int n = int.Parse(path.Substring(4, 1));

        //                if (!this.UnoGame.Clockwise)
        //                {
        //                    this.UnoGame.DrawTwoOrFour(n);
        //                    for (int i = 0; i < n; i++)
        //                    {
        //                        this.RebindComputerCards();
        //                        this.CompX += 70;
        //                    }
        //                }
        //                else
        //                {
        //                    //// used to determine how many images have been already removed
        //                    int count1 = 0;

        //                    //// used to determine index in grid
        //                    int currentIndex1 = 0;

        //                    while (count1 < this.UnoGame.Players[0].PlayerHand.Count)
        //                    {
        //                        UIElement element = grdMainWindow.Children[currentIndex1];

        //                        //// checks to see if the element is of an image
        //                        if (element.GetType().Equals(typeof(Image)))
        //                        {
        //                            Image image = element as Image;
        //                            if ((int)image.Margin.Top == 400)
        //                            {
        //                                //// we remove every image in PlayerHand (where margin.top == 400)
        //                                grdMainWindow.Children.Remove(image);

        //                                //// increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
        //                                count1++;
        //                            }
        //                            else
        //                            {
        //                                //// if element is not image in PlayerHand, we increment index
        //                                currentIndex1++;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            //// If element is not an image, we increment index
        //                            currentIndex1++;
        //                        }
        //                    }

        //                    this.UnoGame.DrawTwoOrFour(n);
        //                    this.X = 70;

        //                    //// display player's hand
        //                    foreach (Card crd in this.UnoGame.Players[0].PlayerHand)
        //                    {
        //                        this.CreateViewImageDynamically(crd.MyImagePath);
        //                    }
        //                }
        //            }
        //            else if (path.Substring(0, 8) == "WildDraw")
        //            {
        //                int n = int.Parse(path.Substring(8, 1));

        //                if (!this.UnoGame.Clockwise)
        //                {
        //                    this.UnoGame.DrawTwoOrFour(n);
        //                    for (int i = 0; i < n; i++)
        //                    {
        //                        this.RebindComputerCards();
        //                        this.CompX += 70;
        //                    }
        //                }
        //                else
        //                {
        //                    //// used to determine how many images have been already removed
        //                    int count2 = 0;

        //                    //// used to determine index in grid
        //                    int currentIndex2 = 0;
        //                    while (count2 < this.UnoGame.Players[0].PlayerHand.Count)
        //                    {
        //                        UIElement element = grdMainWindow.Children[currentIndex2];

        //                        //// checks to see if the element is of an image
        //                        if (element.GetType().Equals(typeof(Image)))
        //                        {
        //                            Image image = element as Image;
        //                            if ((int)image.Margin.Top == 400)
        //                            {
        //                                //// we remove every image in PlayerHand (where margin.top == 400)
        //                                grdMainWindow.Children.Remove(image);

        //                                //// increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
        //                                count2++;
        //                            }
        //                            else
        //                            {
        //                                //// if element is not image in PlayerHand, we increment index
        //                                currentIndex2++;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            //// If element is not an image, we increment index
        //                            currentIndex2++;
        //                        }
        //                    }

        //                    this.UnoGame.DrawTwoOrFour(n);
        //                    this.X = 70;

        //                    //// display player's hand
        //                    foreach (Card crd in this.UnoGame.Players[0].PlayerHand)
        //                    {
        //                        this.CreateViewImageDynamically(crd.MyImagePath);
        //                    }
        //                }

        //                new Colors(checkCard).ShowDialog();
        //                MessageBox.Show(checkCard.MyColor.ToString());
        //            }
        //            else if (path.Substring(0, 4) == "Wild")
        //            {
        //                new Colors(checkCard).ShowDialog();
        //                MessageBox.Show(checkCard.MyColor.ToString());
        //            }

        //            //// If the card is Reverse or Skip player stays the same 
        //            if ((path.Substring(0, 7) != "Reverse") && (path.Substring(0, 4) != "Skip"))
        //            {
        //                if (!this.UnoGame.Clockwise)
        //                {
        //                    this.UnoGame.PlayerTurn = 2;
        //                    ////this.imgDeckPile.IsEnabled = false;
        //                    if (this.UnoGame.Players[2].PlayerHand.Count != 0)
        //                    {
        //                        this.NextPlayerButton_Click(sender, e);
        //                    }
        //                }
        //                else
        //                {
        //                    this.UnoGame.PlayerTurn = 1;
        //                }
        //            }
        //            else
        //            {
        //                if (!this.UnoGame.Clockwise)
        //                {
        //                    if (path.Substring(0, 7) == "Reverse")
        //                    {
        //                        this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
        //                    }

        //                    this.UnoGame.PlayerTurn = 1;
        //                }
        //                else 
        //                {
        //                    if (path.Substring(0, 7) == "Reverse")
        //                    {
        //                        this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
        //                    }

        //                    this.UnoGame.PlayerTurn = 2;
        //                    ////this.imgDeckPile.IsEnabled = false;
        //                    if (this.UnoGame.Players[2].PlayerHand.Count != 0)
        //                    {
        //                        this.NextPlayerButton_Click(sender, e);
        //                    }
        //                }
        //            }
        //        }

        //        this.DisplayPlayerTurn();
        //    }

        //    if (this.UnoGame.Players[2].PlayerHand.Count == 0)
        //    {
        //        MessageBox.Show("Congrats! Player 3 win!");
        //        this.imgDeckPile.IsEnabled = false;
        //        this.UnoGame.PlayerTurn = 0;
        //    }
        //}
        */

        /// <summary>
        /// Creates a new uno game when clicked.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnNewGame_Click(object sender, RoutedEventArgs e)
        {
            if (this.gameMode == Mode.TwoPlayers)
            {
                if (this.tutorial)
                {
                    this.UnoGame.InGame = true;
                    this.UnoGame.GameDeck = new DeckOfCards();
                    this.UnoGame.Clockwise = true;
                    this.UnoGame.GameDeck.SetUpDeck();
                    this.UnoGame.Players[0].PlayerHand.Clear();
                    this.UnoGame.Players[1].PlayerHand.Clear();
                    this.UnoGame.CurrentDeck = this.UnoGame.GameDeck.Deck.ToList<Card>();
                    for (int i = 0; i < 2; i++)
                    {
                        this.UnoGame.Players[0].PlayerHand.Add(this.UnoGame.CurrentDeck[0]);
                        this.UnoGame.CurrentDeck.RemoveAt(0);
                        this.UnoGame.Players[1].PlayerHand.Add(this.UnoGame.CurrentDeck[0]);
                        this.UnoGame.CurrentDeck.RemoveAt(0);
                    }

                    this.UnoGame.CentralPile = new List<Card>();
                    if (this.UnoGame.Players[0].PlayerHand[0].MyType != Card.Type.Wild && this.UnoGame.Players[0].PlayerHand[0].MyType != Card.Type.WildDraw4)
                    {
                        this.UnoGame.CentralPile.Add(this.UnoGame.Players[0].PlayerHand[0]);
                    }
                    else
                    {
                        this.UnoGame.CentralPile.Add(this.UnoGame.Players[0].PlayerHand[1]);
                    }

                    this.UnoGame.Players[0].Score = this.UnoGame.Players[0].TotalCardValue();
                    this.UnoGame.Players[1].Score = this.UnoGame.Players[1].TotalCardValue();
                    this.grdMainWindow.Children.Clear();
                    this.grdMainWindow.Children.Add(this.imgMainPile);
                    this.grdMainWindow.Children.Add(this.imgDeckPile);
                    this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                    this.grdMainWindow.Children.Add(this.BtnClose);
                    this.grdMainWindow.Children.Add(this.NextPlayerButton);
                    this.grdMainWindow.Children.Add(this.lblPlayer);
                    this.grdMainWindow.Children.Add(this.lstPlayers);
                    this.grdMainWindow.Children.Add(this.BtnPlayer1Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer2Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer3Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer4Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer5Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer6Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer7Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer8Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer9Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer10Uno);
                    this.grdMainWindow.Children.Add(this.BtnNoticeMissedUno);
                    this.grdMainWindow.Children.Add(this.lblTutorialStep3);
                    this.grdMainWindow.Children.Add(this.lblTutorialStep4);
                    this.grdMainWindow.Children.Add(this.lblTutorialStep5);
                    this.grdMainWindow.Children.Add(this.lblTutorialStep6);
                    this.grdMainWindow.Children.Add(this.BtnEndTutorial);
                    this.BtnEndTutorial.Visibility = Visibility.Hidden;
                    this.lblTutorialStep3.Visibility = Visibility.Visible;
                    this.lblTutorialStep5.Visibility = Visibility.Visible;
                    this.lblTutorialStep6.Visibility = Visibility.Hidden;
                    this.lblTutorialStep4.Visibility = Visibility.Hidden;
                    this.CompX = 70;
                    this.X = 70;
                    this.imgMainPile.Visibility = Visibility.Visible;
                    this.imgDeckPile.Visibility = Visibility.Visible;
                    this.imgDeckPile.IsEnabled = true;
                    this.BtnChooseDealer.Visibility = Visibility.Hidden;
                    this.BtnChooseDealer.IsEnabled = true;
                    this.lblDrawCard.Visibility = Visibility.Hidden;
                    this.UnoGame.PlayerTurn = 1;
                    this.DisplayPlayerTurn();
                }
                else
                {
                    this.UnoGame.InGame = true;
                    this.UnoGame.GameDeck = new DeckOfCards();
                    this.UnoGame.Clockwise = true;
                    this.UnoGame.GameDeck.SetUpDeck();
                    this.UnoGame.Players[0].PlayerHand.Clear();
                    this.UnoGame.Players[1].PlayerHand.Clear();
                    this.UnoGame.DealCards(this.gameMode);
                    this.UnoGame.Players[0].Score = this.UnoGame.Players[0].TotalCardValue();
                    this.UnoGame.Players[1].Score = this.UnoGame.Players[1].TotalCardValue();
                    this.grdMainWindow.Children.Clear();
                    this.grdMainWindow.Children.Add(this.imgMainPile);
                    this.grdMainWindow.Children.Add(this.imgDeckPile);
                    this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                    this.grdMainWindow.Children.Add(this.BtnClose);
                    this.grdMainWindow.Children.Add(this.NextPlayerButton);
                    this.grdMainWindow.Children.Add(this.lblPlayer);
                    this.grdMainWindow.Children.Add(this.lstPlayers);
                    this.grdMainWindow.Children.Add(this.BtnPlayer1Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer2Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer3Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer4Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer5Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer6Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer7Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer8Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer9Uno);
                    this.grdMainWindow.Children.Add(this.BtnPlayer10Uno);
                    this.grdMainWindow.Children.Add(this.BtnNoticeMissedUno);
                    this.CompX = 70;
                    this.X = 70;
                    this.imgMainPile.Visibility = Visibility.Visible;
                    this.imgDeckPile.Visibility = Visibility.Visible;
                    this.imgDeckPile.IsEnabled = true;
                    this.BtnChooseDealer.Visibility = Visibility.Visible;
                    this.BtnChooseDealer.IsEnabled = true;
                    this.lblDrawCard.Visibility = Visibility.Hidden;
                    this.DisplayPlayerTurn();
                }

                this.Playershandscount();
                //// display player's hand
                this.CreatePlayerHandCardImages(this.UnoGame.Players[0]);

                foreach (Card crd in this.UnoGame.Players[1].PlayerHand)
                {
                    this.RebindComputerCards();
                    this.CompX += 70;
                }

                //// creates center pile based on what is on top of the deck
                Card centralStart = new Card();

                centralStart = this.UnoGame.CentralPile[0];

                //// create image for central pile
                Image dynamicImageCentral = new Image();
                dynamicImageCentral.Width = 150;
                dynamicImageCentral.Height = 100;

                //// Create a BitmapSource  
                BitmapImage bitmapCentral = new BitmapImage();
                bitmapCentral.BeginInit();
                bitmapCentral.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/" + centralStart.MyImagePath);
                bitmapCentral.EndInit();
                dynamicImageCentral.Source = bitmapCentral;

                imgMainPile.Source = dynamicImageCentral.Source;
                if (this.UnoGame.PlayerTurn == 2)
                {
                    this.NextPlayerButton_Click(sender, e);
                }
            }
            else if (this.gameMode == Mode.MultiplePlayers)
            {
                ////this.UnoGame.DealCards(this.gameMode);
                this.UnoGame.InGame = true;
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                for (int i = 0; i < this.numberOfPlayers; i++)
                {
                    this.UnoGame.Players[i].PlayerHand.Clear();
                }

                this.UnoGame.DealCards(this.gameMode);
                for (int i = 0; i < this.numberOfPlayers; i++)
                {
                    this.UnoGame.Players[i].Score = this.UnoGame.Players[i].TotalCardValue();
                }

                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgMainPile);
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
                this.grdMainWindow.Children.Add(this.lstPlayers);
                this.CompX = 70;
                this.X = 70;
                this.X2 = 800;
                this.imgMainPile.Visibility = Visibility.Visible;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.BtnChooseDealer.Visibility = Visibility.Visible;
                this.BtnChooseDealer.IsEnabled = true;
                this.lblDrawCard.Visibility = Visibility.Hidden;
                //// display player's hand
                ////foreach (Card crd in this.UnoGame.Players[0].PlayerHand)
                ////{
                ////    this.CreateViewImageDynamically(crd.MyImagePath);
                ////}

                ////// display second player's hand
                ////foreach (Card crd in this.UnoGame.Players[2].PlayerHand)
                ////{
                ////    this.CreateViewImageDynamically2(crd.MyImagePath);
                ////}

                ////for (int i = 0; i < 7; i++)
                ////{
                ////    //// Create Image and set its width and height  
                ////    Image dynamicImage1 = new Image();
                ////    dynamicImage1.Width = 150;
                ////    dynamicImage1.Height = 100;

                ////    //// Create a BitmapSource  
                ////    BitmapImage bitmap1 = new BitmapImage();
                ////    bitmap1.BeginInit();
                ////    bitmap1.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/Back.jpg");
                ////    bitmap1.EndInit();

                ////    //// Set Image.Source  
                ////    dynamicImage1.Source = bitmap1;
                ////    dynamicImage1.HorizontalAlignment = HorizontalAlignment.Left;
                ////    dynamicImage1.VerticalAlignment = VerticalAlignment.Top;
                ////    dynamicImage1.Margin = new Thickness(this.CompX, 0, 0, 0);
                ////    this.CompX += 70;
                ////    //// Add Image to Window  
                ////    grdMainWindow.Children.Add(dynamicImage1);
                ////    this.LastImage = dynamicImage1;
                ////}
                foreach (Card crd in this.UnoGame.Players[1].PlayerHand)
                {
                    this.RebindComputerCards();
                    this.CompX += 70;
                }

                this.CreatePlayerHandCardImages(this.UnoGame.Players[this.UnoGame.PlayerTurn - 1]);
                Console.WriteLine("Player index: " + (this.UnoGame.PlayerTurn - 1));
                this.Playershandscount();
                this.DisplayPlayerTurn();

                //// creates center pile based on what is on top of the deck
                Card centralStart = new Card();

                centralStart = this.UnoGame.CentralPile[0];

                //// create image for central pile
                Image dynamicImageCentral = new Image();
                dynamicImageCentral.Width = 150;
                dynamicImageCentral.Height = 100;

                //// Create a BitmapSource  
                BitmapImage bitmapCentral = new BitmapImage();
                bitmapCentral.BeginInit();
                bitmapCentral.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/" + centralStart.MyImagePath);
                bitmapCentral.EndInit();
                dynamicImageCentral.Source = bitmapCentral;

                imgMainPile.Source = dynamicImageCentral.Source;
                if (this.UnoGame.PlayerTurn == 2)
                {
                    this.NextPlayerButton_Click(sender, e);
                }
            }
        }

        /// <summary>
        /// If a user cannot play a card after drawing, 
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private async void NextPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.tutorial)
            {
                this.lblTutorialStep3.Visibility = Visibility.Hidden;
            }

            if (this.UnoGame.InGame)
            {
                this.BtnChooseDealer.IsEnabled = false;
                await Task.Delay(1000);
                if (this.UnoGame.PlayerTurn == 2)
                {
                    this.UnoGame.Players[1].Score = this.UnoGame.Players[1].TotalCardValue();
                    Card findCard = this.UnoGame.CheckCompHand(this.UnoGame.Players[1].PlayerHand);
                    foreach (UIElement element in grdMainWindow.Children)
                    {
                        if (element.GetType().Equals(typeof(Image)))
                        {
                            Image image = element as Image;
                            if ((int)image.Margin.Left == this.CompX - 70 && (int)image.Margin.Top == 0)
                            {
                                this.LastImage = image;
                                break;
                            }
                        }
                    }

                    bool check = false;
                    if (findCard == null)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Players[1]);

                        //// creates image for new card
                        Image dynamicImage1 = new Image();
                        dynamicImage1.Width = 150;
                        dynamicImage1.Height = 100;

                        //// Create a BitmapSource  
                        BitmapImage bitmap1 = new BitmapImage();
                        bitmap1.BeginInit();
                        bitmap1.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/Back.jpg");
                        bitmap1.EndInit();

                        //// Set Image.Source  
                        dynamicImage1.Source = bitmap1;
                        dynamicImage1.HorizontalAlignment = HorizontalAlignment.Left;
                        dynamicImage1.VerticalAlignment = VerticalAlignment.Top;
                        dynamicImage1.Margin = new Thickness(this.CompX, 0, 0, 0);
                        this.CompX += 70;
                        //// Add Image to Window  
                        grdMainWindow.Children.Add(dynamicImage1);
                        await Task.Delay(500);

                        Card checkAgain = this.UnoGame.CheckCompHand(this.UnoGame.Players[1].PlayerHand);

                        if (checkAgain != null)
                        {
                            grdMainWindow.Children.Remove(dynamicImage1);
                            this.CompX -= 70;

                            //// create image for central pile
                            Image dynamicImageCentral = new Image();
                            dynamicImageCentral.Width = 150;
                            dynamicImageCentral.Height = 100;

                            //// Create a BitmapSource  
                            BitmapImage bitmapCentral = new BitmapImage();
                            bitmapCentral.BeginInit();
                            bitmapCentral.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/" + checkAgain.MyImagePath);
                            bitmapCentral.EndInit();
                            dynamicImageCentral.Source = bitmapCentral;

                            this.UnoGame.CentralPile.Add(checkAgain);

                            imgMainPile.Source = dynamicImageCentral.Source;
                            check = true;
                            findCard = checkAgain;
                        }

                        this.LastImage = dynamicImage1;
                        ////this.imgDeckPile.IsEnabled = true;
                    }
                    else
                    {
                        check = true;
                        grdMainWindow.Children.Remove(this.LastImage);
                        this.CompX -= 70;

                        //// create image for central pile
                        Image dynamicImageCentral = new Image();
                        dynamicImageCentral.Width = 150;
                        dynamicImageCentral.Height = 100;

                        //// Create a BitmapSource  
                        BitmapImage bitmapCentral = new BitmapImage();
                        bitmapCentral.BeginInit();
                        bitmapCentral.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/" + findCard.MyImagePath);
                        bitmapCentral.EndInit();
                        dynamicImageCentral.Source = bitmapCentral;

                        this.UnoGame.CentralPile.Add(findCard);

                        imgMainPile.Source = dynamicImageCentral.Source;
                    }

                    if (check)
                    {
                        if (this.gameMode == Mode.MultiplePlayers)
                        {
                            if (findCard.MyType == Card.Type.Draw2 || findCard.MyType == Card.Type.WildDraw4)
                            {
                                int n = 0;
                                if (findCard.MyType == Card.Type.Draw2)
                                {
                                    n = 2;
                                }
                                else if (findCard.MyType == Card.Type.WildDraw4)
                                {
                                    n = 4;
                                }

                                this.UnoGame.DrawTwoOrFour(n);
                                //// used to determine how many images have been already removed
                                ////int count = 0;

                                ////// used to determine index in grid
                                ////int currentIndex = 0;
                                if (!this.UnoGame.Clockwise)
                                {
                                    ////while (count < this.UnoGame.Players[0].PlayerHand.Count)
                                    ////{
                                    ////    UIElement element = grdMainWindow.Children[currentIndex];

                                    ////    //// checks to see if the element is of an image
                                    ////    if (element.GetType().Equals(typeof(Image)))
                                    ////    {
                                    ////        Image image = element as Image;
                                    ////        if ((int)image.Margin.Top == 400)
                                    ////        {
                                    ////            //// we remove every image in PlayerHand (where margin.top == 400)
                                    ////            grdMainWindow.Children.Remove(image);

                                    ////            //// increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                                    ////            count++;
                                    ////        }
                                    ////        else
                                    ////        {
                                    ////            //// if element is not image in PlayerHand, we increment index
                                    ////            currentIndex++;
                                    ////        }
                                    ////    }
                                    ////    else
                                    ////    {
                                    ////        //// If element is not an image, we increment index
                                    ////        currentIndex++;
                                    ////    }
                                    ////DeleteCardImages(UnoGame.Players[0]);
                                    ////this.UnoGame.DrawTwoOrFour(n);

                                    ////CreatePlayerHandCardImages(this.UnoGame.Players[0]);
                                }
                                else
                                {
                                    ////while (count < this.UnoGame.Players[2].PlayerHand.Count)
                                    ////{
                                    ////    UIElement element = grdMainWindow.Children[currentIndex];

                                    ////    //// checks to see if the element is of an image
                                    ////    if (element.GetType().Equals(typeof(Image)))
                                    ////    {
                                    ////        Image image = element as Image;
                                    ////        if ((int)image.Margin.Top == 250)
                                    ////        {
                                    ////            //// we remove every image in PlayerHand (where margin.top == 400)
                                    ////            grdMainWindow.Children.Remove(image);

                                    ////            //// increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                                    ////            count++;
                                    ////        }
                                    ////        else
                                    ////        {
                                    ////            //// if element is not image in PlayerHand, we increment index
                                    ////            currentIndex++;
                                    ////        }
                                    ////    }
                                    ////    else
                                    ////    {
                                    ////        //// If element is not an image, we increment index
                                    ////        currentIndex++;
                                    ////    }
                                    ////}
                                    ////DeleteCardImages(UnoGame.Players[2]);

                                    ////this.UnoGame.DrawTwoOrFour(n);

                                    ////CreatePlayerHandCardImages(this.UnoGame.Players[2]);
                                    ////this.X2 = 800;
                                    //// Recreate Playerhand now that images are updated
                                    ////foreach (Card crd in this.UnoGame.Players[2].PlayerHand)
                                    ////{
                                    ////    this.CreateViewImageDynamically2(crd.MyImagePath);
                                    ////}
                                }
                            }
                        }
                        else
                        {
                            if (findCard.MyType == Card.Type.Draw2 || findCard.MyType == Card.Type.WildDraw4)
                            {
                                int n = 0;
                                if (findCard.MyType == Card.Type.Draw2)
                                {
                                    n = 2;
                                }
                                else if (findCard.MyType == Card.Type.WildDraw4)
                                {
                                    n = 4;
                                }

                                ////// used to determine how many images have been already removed
                                ////int count = 0;

                                ////// used to determine index in grid
                                ////int currentIndex = 0;

                                ////while (count < this.UnoGame.Players[0].PlayerHand.Count)
                                ////{
                                ////    UIElement element = grdMainWindow.Children[currentIndex];

                                ////    //// checks to see if the element is of an image
                                ////    if (element.GetType().Equals(typeof(Image)))
                                ////    {
                                ////        Image image = element as Image;
                                ////        if ((int)image.Margin.Top == 400)
                                ////        {
                                ////            //// we remove every image in PlayerHand (where margin.top == 400)
                                ////            grdMainWindow.Children.Remove(image);

                                ////            //// increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                                ////            count++;
                                ////        }
                                ////        else
                                ////        {
                                ////            //// if element is not image in PlayerHand, we increment index
                                ////            currentIndex++;
                                ////        }
                                ////    }
                                ////    else
                                ////    {
                                ////        //// If element is not an image, we increment index
                                ////        currentIndex++;
                                ////    }
                                ////}

                                this.UnoGame.DrawTwoOrFour(n);

                                ////this.X = 70;
                                ////// Recreate Playerhand now that images are updated
                                ////foreach (Card crd in this.UnoGame.Players[0].PlayerHand)
                                ////{
                                ////    this.CreateViewImageDynamically(crd.MyImagePath);
                                ////}
                                this.CreatePlayerHandCardImages(this.UnoGame.Players[0]);
                            }
                        }

                        //// If the card is Reverse or Skip Player stays the same 
                        if ((findCard.MyType != Card.Type.Reverse) && (findCard.MyType != Card.Type.Skip) && (findCard.MyType != Card.Type.Draw2) && (findCard.MyType != Card.Type.WildDraw4))
                        {
                            if (this.gameMode == Mode.MultiplePlayers)
                            {
                                if (!this.UnoGame.Clockwise)
                                {
                                    this.UnoGame.PlayerTurn = 1;
                                    ////this.imgDeckPile.IsEnabled = true;
                                }
                                else
                                {
                                    this.UnoGame.PlayerTurn = 3;
                                    ////this.imgDeckPile.IsEnabled = true;
                                }
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 1;
                                ////this.imgDeckPile.IsEnabled = true;
                            }
                        }
                        else
                        {
                            if (this.gameMode == Mode.MultiplePlayers)
                            {
                                if (!this.UnoGame.Clockwise)
                                {
                                    ////if (findCard.MyType == Card.Type.Reverse)
                                    ////{
                                    ////    this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
                                    ////}

                                    this.UnoGame.PlayerTurn = 3;
                                    ////this.imgDeckPile.IsEnabled = true;
                                    ////if it is skip
                                    if ((findCard.MyType == Card.Type.Skip) || (findCard.MyType == Card.Type.Draw2) || (findCard.MyType == Card.Type.WildDraw4))
                                    {
                                        this.UnoGame.PlayerTurn = this.numberOfPlayers;
                                    }
                                }
                                else
                                {
                                    ////if (findCard.MyType == Card.Type.Reverse)
                                    ////{
                                    ////    this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
                                    ////}

                                    this.UnoGame.PlayerTurn = 1;
                                    ////this.imgDeckPile.IsEnabled = true;
                                    //// //if it is skip
                                    if ((findCard.MyType == Card.Type.Skip) || (findCard.MyType == Card.Type.Draw2) || (findCard.MyType == Card.Type.WildDraw4))
                                    {
                                        if (this.numberOfPlayers == 4)
                                        {
                                            this.UnoGame.PlayerTurn = 4;
                                        }
                                        else
                                        {
                                            this.UnoGame.PlayerTurn = 4 % this.numberOfPlayers;
                                        }
                                    }
                                }

                                if (findCard.MyType == Card.Type.Reverse)
                                {
                                    this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
                                }
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 2;
                                await Task.Delay(500);
                                ////this.imgDeckPile.IsEnabled = false;
                                this.NextPlayerButton_Click(sender, e);
                            }
                        }
                    }
                    else
                    {
                        if (this.gameMode == Mode.MultiplePlayers)
                        {
                            if (!this.UnoGame.Clockwise)
                            {
                                this.UnoGame.PlayerTurn = 1;
                                ////this.imgDeckPile.IsEnabled = true;
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 3;
                                ////this.imgDeckPile.IsEnabled = true;
                            }
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 1;
                            ////this.imgDeckPile.IsEnabled = true;
                        }
                    }

                    if (findCard != null && (findCard.MyType == Card.Type.Wild || findCard.MyType == Card.Type.WildDraw4))
                    {
                        MessageBox.Show("The computer has chosen color: " + findCard.MyColor.ToString());
                        await Task.Delay(500);
                    }
                }

                this.UnoGame.Players[1].Score = this.UnoGame.Players[1].TotalCardValue();
                this.DisplayPlayerTurn();
                this.Playershandscount();
                if (this.UnoGame.Players[1].PlayerHand.Count == 0)
                {
                    MessageBox.Show("Game over. Computer won");
                    this.DisplayValues();
                    ////this.imgDeckPile.IsEnabled = false;
                    this.UnoGame.PlayerTurn = 0;
                }
                else if (this.UnoGame.Players[1].PlayerHand.Count == 1)
                {
                    MessageBox.Show("Player2 has called Uno!");
                    this.CreatePlayerHandCardImages(this.UnoGame.Players[this.UnoGame.PlayerTurn - 1]);
                }
                else
                {
                    this.CreatePlayerHandCardImages(this.UnoGame.Players[this.UnoGame.PlayerTurn - 1]);
                }

                this.BtnChooseDealer.IsEnabled = true;
                if (BtnPlayer1Uno.Visibility == Visibility.Visible && this.UnoGame.Players[0].PlayerHand.Count > 1)
                {
                    BtnPlayer1Uno.Visibility = Visibility.Hidden;
                    this.lblTutorialStep4.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer2Uno.Visibility == Visibility.Visible && this.UnoGame.Players[1].PlayerHand.Count > 1)
                {
                    BtnPlayer2Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer3Uno.Visibility == Visibility.Visible && this.UnoGame.Players[2].PlayerHand.Count > 1)
                {
                    BtnPlayer3Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer4Uno.Visibility == Visibility.Visible && this.UnoGame.Players[3].PlayerHand.Count > 1)
                {
                    BtnPlayer4Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer5Uno.Visibility == Visibility.Visible && this.UnoGame.Players[4].PlayerHand.Count > 1)
                {
                    BtnPlayer5Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer6Uno.Visibility == Visibility.Visible && this.UnoGame.Players[5].PlayerHand.Count > 1)
                {
                    BtnPlayer6Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer7Uno.Visibility == Visibility.Visible && this.UnoGame.Players[6].PlayerHand.Count > 1)
                {
                    BtnPlayer7Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer8Uno.Visibility == Visibility.Visible && this.UnoGame.Players[7].PlayerHand.Count > 1)
                {
                    BtnPlayer8Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer9Uno.Visibility == Visibility.Visible && this.UnoGame.Players[8].PlayerHand.Count > 1)
                {
                    BtnPlayer9Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer10Uno.Visibility == Visibility.Visible && this.UnoGame.Players[9].PlayerHand.Count > 1)
                {
                    BtnPlayer10Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }
            }
            else
            {
                if (this.UnoGame.PlayerTurn == 2)
                {
                    Card card2 = null;
                    bool isFalse = false;
                    while (!isFalse)
                    {
                        await Task.Delay(500);
                        this.UnoGame.DrawCard(this.UnoGame.Players[1]);
                        card2 = this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1];
                        Console.WriteLine("Number of cards: " + (this.UnoGame.Players[1].PlayerHand.Count - 1));
                        this.X = 70;
                        this.CreateComputerDrawCard(card2.MyImagePath);
                        if (card2.MyType == Card.Type.Number)
                        {
                            isFalse = true;
                        }
                    }

                    if (this.gameMode == Mode.MultiplePlayers)
                    {
                        this.lblDrawCard.Visibility = Visibility.Visible;
                        this.lblDrawCard.Content = "Player 3, draw a card.";
                        this.UnoGame.PlayerTurn = 3;
                        this.DisplayPlayerTurn();
                        this.Playershandscount();
                    }
                    else
                    {
                        if (card2.MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 1;
                            MessageBox.Show("Player 2 is the dealer, and Player 1 gets to play first.");
                        }
                        else
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 2;
                            MessageBox.Show("Player 1 is the dealer, and Player 2 gets to play first.");
                        }

                        this.BtnChooseDealer.Content = "New Game";
                        this.BtnChooseDealer.Visibility = Visibility.Hidden;
                        this.BtnNewGame_Click(sender, e);
                    }
                }
            }
        }

        /// <summary>
        /// Draws a card for player if clicked.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private async void ImgDeckPile_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.UnoGame.InGame)
            { 
                if (this.gameMode == Mode.TwoPlayers && this.UnoGame.PlayerTurn == 1 && !this.UnoGame.CheckUserHand(this.UnoGame.Players[0].PlayerHand))
                {
                    this.UnoGame.Players[0].Score = this.UnoGame.Players[0].TotalCardValue();
                    this.UnoGame.DrawCard(this.UnoGame.Players[0]);
                    Card card = this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1];
                    this.UnoGame.Players[0].Score = this.UnoGame.Players[0].TotalCardValue();
                    this.CreateViewImageDynamically(card.MyImagePath);
                    ////this.imgDeckPile.IsEnabled = false;
                    if (!this.UnoGame.CheckUserHand(this.UnoGame.Players[0].PlayerHand))
                    {
                        await Task.Delay(1000);
                        this.DeleteCardImages(this.UnoGame.Players[this.UnoGame.PlayerTurn - 1]);
                        this.UnoGame.PlayerTurn = 2;
                        this.NextPlayerButton_Click(sender, e);
                    }
                }
                else if (this.gameMode == Mode.MultiplePlayers && (this.UnoGame.PlayerTurn != 2 && !this.UnoGame.CheckUserHand(this.UnoGame.Players[this.UnoGame.PlayerTurn - 1].PlayerHand)))
                {
                    this.UnoGame.Players[this.UnoGame.PlayerTurn - 1].Score = this.UnoGame.Players[this.UnoGame.PlayerTurn - 1].TotalCardValue();
                    this.UnoGame.DrawCard(this.UnoGame.Players[this.UnoGame.PlayerTurn - 1]);
                    this.UnoGame.Players[this.UnoGame.PlayerTurn - 1].Score = this.UnoGame.Players[this.UnoGame.PlayerTurn - 1].TotalCardValue();
                    Card card = this.UnoGame.Players[this.UnoGame.PlayerTurn - 1].PlayerHand[this.UnoGame.Players[this.UnoGame.PlayerTurn - 1].PlayerHand.Count - 1];
                    ////this.CreateViewImageDynamically2(card.MyImagePath);
                    this.CreateViewImageDynamically(card.MyImagePath);
                    ////this.imgDeckPile.IsEnabled = false;
                    if (!this.UnoGame.CheckUserHand(this.UnoGame.Players[this.UnoGame.PlayerTurn - 1].PlayerHand))
                    {
                        imgDeckPile.IsEnabled = false;
                        await Task.Delay(1000);
                        imgDeckPile.IsEnabled = true;
                        this.DeleteCardImages(this.UnoGame.Players[this.UnoGame.PlayerTurn - 1]);
                        if (this.UnoGame.Clockwise)
                        {
                            this.UnoGame.PlayerTurn = (this.UnoGame.PlayerTurn % this.numberOfPlayers) + 1;
                            MessageBox.Show("The turn goes to player " + this.UnoGame.PlayerTurn);
                            if (this.UnoGame.PlayerTurn == 2)
                            {
                                this.NextPlayerButton_Click(sender, e);
                            }
                            else
                            {
                                this.CreatePlayerHandCardImages(this.UnoGame.Players[this.UnoGame.PlayerTurn - 1]);
                            }
                            ////this.imgDeckPile.IsEnabled = true;
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = ((this.UnoGame.PlayerTurn - 2) % this.numberOfPlayers) + 1;
                            MessageBox.Show("The turn goes to player " + this.UnoGame.PlayerTurn);
                            if (this.UnoGame.PlayerTurn == 2)
                            {
                                this.NextPlayerButton_Click(sender, e);
                            }
                            else
                            {
                                this.CreatePlayerHandCardImages(this.UnoGame.Players[this.UnoGame.PlayerTurn - 1]);
                            }
                        }
                    }
                }

                if (BtnPlayer1Uno.Visibility == Visibility.Visible && this.UnoGame.Players[0].PlayerHand.Count > 1)
                {
                    BtnPlayer1Uno.Visibility = Visibility.Hidden;
                    this.lblTutorialStep4.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer2Uno.Visibility == Visibility.Visible && this.UnoGame.Players[1].PlayerHand.Count > 1)
                {
                    BtnPlayer2Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer3Uno.Visibility == Visibility.Visible && this.UnoGame.Players[2].PlayerHand.Count > 1)
                {
                    BtnPlayer3Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer4Uno.Visibility == Visibility.Visible && this.UnoGame.Players[3].PlayerHand.Count > 1)
                {
                    BtnPlayer4Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer5Uno.Visibility == Visibility.Visible && this.UnoGame.Players[4].PlayerHand.Count > 1)
                {
                    BtnPlayer5Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer6Uno.Visibility == Visibility.Visible && this.UnoGame.Players[5].PlayerHand.Count > 1)
                {
                    BtnPlayer6Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer7Uno.Visibility == Visibility.Visible && this.UnoGame.Players[6].PlayerHand.Count > 1)
                {
                    BtnPlayer7Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer8Uno.Visibility == Visibility.Visible && this.UnoGame.Players[7].PlayerHand.Count > 1)
                {
                    BtnPlayer8Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer9Uno.Visibility == Visibility.Visible && this.UnoGame.Players[8].PlayerHand.Count > 1)
                {
                    BtnPlayer9Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                if (BtnPlayer10Uno.Visibility == Visibility.Visible && this.UnoGame.Players[9].PlayerHand.Count > 1)
                {
                    BtnPlayer10Uno.Visibility = Visibility.Hidden;
                    if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
                    {
                        BtnNoticeMissedUno.Visibility = Visibility.Hidden;
                    }
                }

                this.DisplayPlayerTurn();
                this.Playershandscount();
                Console.WriteLine(this.UnoGame.CurrentDeck.Count);
            }
            else
            {
                ////this.UnoGame.InGame is false
                this.lblDrawCard.Visibility = Visibility.Hidden;
                this.imgDeckPile.IsEnabled = false;
                bool isNumber = false;
                if (this.UnoGame.PlayerTurn == 1)
                {
                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Players[0]);

                        Card card1 = this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card1.MyImagePath);
                        if (card1.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    this.UnoGame.PlayerTurn = 2;
                    this.DisplayPlayerTurn();
                    this.Playershandscount();
                    await Task.Delay(500);
                    this.NextPlayerButton_Click(sender, e);
                }
                else if (this.gameMode == Mode.MultiplePlayers && this.UnoGame.PlayerTurn == 3)
                {
                    isNumber = false;
                    Card card3 = null;

                    while (!isNumber)
                    {
                        this.X = 140;
                        this.UnoGame.DrawCard(this.UnoGame.Players[2]);
                        card3 = this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1];
                        ////this.X2 = 800;

                        if (card3.MyType == Card.Type.Number)
                        {
                            this.CreateViewImageDynamically(card3.MyImagePath);
                            isNumber = true;
                        }
                    }

                    if (this.UnoGame.PlayerTurn == this.UnoGame.Players.Count)
                    {
                        if (card3.MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && card3.MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 1;
                            MessageBox.Show("Player 3 is the dealer, so Player 1 begins play.");
                        }
                        else if (this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= card3.MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 3;
                            MessageBox.Show("Player 2 is the dealer, so Player 3 begins play.");
                        }
                        else
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 2;
                            MessageBox.Show("Player 1 is the dealer, so Player 2 begins play.");
                        }

                        this.BtnChooseDealer.Content = "New Game";
                        this.BtnChooseDealer.Visibility = Visibility.Hidden;
                        this.BtnNewGame_Click(sender, e);
                    }
                    else
                    {
                        this.lblDrawCard.Visibility = Visibility.Visible;
                        this.lblDrawCard.Content = "Player 4, draw a card.";
                        this.UnoGame.PlayerTurn = 4;
                        this.DisplayPlayerTurn();
                        this.Playershandscount();
                        await Task.Delay(500);
                    }
                }
                else if (this.gameMode == Mode.MultiplePlayers && this.UnoGame.PlayerTurn == 4)
                {
                    isNumber = false;
                    Card card4 = null;

                    while (!isNumber)
                    {
                        this.X = 140;
                        this.UnoGame.DrawCard(this.UnoGame.Players[3]);
                        card4 = this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1];
                        ////this.X2 = 800;

                        if (card4.MyType == Card.Type.Number)
                        {
                            this.CreateComputerDrawCard(card4.MyImagePath);
                            isNumber = true;
                        }
                    }

                    if (this.UnoGame.PlayerTurn == this.UnoGame.Players.Count)
                    {
                        if (card4.MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && card4.MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && card4.MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 1;
                            MessageBox.Show("Player 4 is the dealer, so Player 1 begins play.");
                        }
                        else if (this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= card4.MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 4;
                            MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                        }
                        else if (this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= card4.MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 3;
                            MessageBox.Show("Player 2 is the dealer, so Player 3 begins play.");
                        }
                        else
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 2;
                            MessageBox.Show("Player 1 is the dealer, so Player 2 begins play.");
                        }

                        this.BtnChooseDealer.Content = "New Game";
                        this.BtnChooseDealer.Visibility = Visibility.Hidden;
                        this.BtnNewGame_Click(sender, e);
                    }
                    else
                    {
                        this.lblDrawCard.Visibility = Visibility.Visible;
                        this.lblDrawCard.Content = "Player 5, draw a card.";
                        this.UnoGame.PlayerTurn = 5;
                        this.DisplayPlayerTurn();
                        this.Playershandscount();
                        await Task.Delay(500);
                    }
                }
                else if (this.gameMode == Mode.MultiplePlayers && this.UnoGame.PlayerTurn == 5)
                {
                    isNumber = false;
                    Card card5 = null;

                    while (!isNumber)
                    {
                        this.X = 210;
                        this.UnoGame.DrawCard(this.UnoGame.Players[4]);
                        card5 = this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1];
                        ////this.X2 = 800;

                        if (card5.MyType == Card.Type.Number)
                        {
                            this.CreateViewImageDynamically(card5.MyImagePath);
                            isNumber = true;
                        }
                    }

                    if (this.UnoGame.PlayerTurn == this.UnoGame.Players.Count)
                    {
                        if (card5.MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && card5.MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && card5.MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && card5.MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 1;
                            MessageBox.Show("Player 5 is the dealer, so Player 1 begins play.");
                        }
                        else if (this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= card5.MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 5;
                            MessageBox.Show("Player 4 is the dealer, so Player 5 begins play.");
                        }
                        else if (this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= card5.MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 4;
                            MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                        }
                        else if (this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= card5.MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 3;
                            MessageBox.Show("Player 2 is the dealer, so Player 3 begins play.");
                        }
                        else
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 2;
                            MessageBox.Show("Player 1 is the dealer, so Player 2 begins play.");
                        }

                        this.BtnChooseDealer.Content = "New Game";
                        this.BtnChooseDealer.Visibility = Visibility.Hidden;
                        this.BtnNewGame_Click(sender, e);
                    }
                    else
                    {
                        this.lblDrawCard.Visibility = Visibility.Visible;
                        this.lblDrawCard.Content = "Player 6, draw a card.";
                        this.UnoGame.PlayerTurn = 6;
                        this.DisplayPlayerTurn();
                        this.Playershandscount();
                        await Task.Delay(500);
                    }
                }
                else if (this.gameMode == Mode.MultiplePlayers && this.UnoGame.PlayerTurn == 6)
                {
                    isNumber = false;
                    Card card6 = null;

                    while (!isNumber)
                    {
                        this.X = 210;
                        this.UnoGame.DrawCard(this.UnoGame.Players[5]);
                        card6 = this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1];
                        ////this.X2 = 800;

                        if (card6.MyType == Card.Type.Number)
                        {
                            this.CreateComputerDrawCard(card6.MyImagePath);
                            isNumber = true;
                        }
                    }

                    if (this.UnoGame.PlayerTurn == this.UnoGame.Players.Count)
                    {
                        if (card6.MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && card6.MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && card6.MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && card6.MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && card6.MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 1;
                            MessageBox.Show("Player 6 is the dealer, so Player 1 begins play.");
                        }
                        else if (this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= card6.MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 6;
                            MessageBox.Show("Player 5 is the dealer, so Player 6 begins play.");
                        }
                        else if (this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= card6.MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 5;
                            MessageBox.Show("Player 4 is the dealer, so Player 5 begins play.");
                        }
                        else if (this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= card6.MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 4;
                            MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                        }
                        else if (this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= card6.MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 3;
                            MessageBox.Show("Player 2 is the dealer, so Player 3 begins play.");
                        }
                        else
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 2;
                            MessageBox.Show("Player 1 is the dealer, so Player 2 begins play.");
                        }

                        this.BtnChooseDealer.Content = "New Game";
                        this.BtnChooseDealer.Visibility = Visibility.Hidden;
                        this.BtnNewGame_Click(sender, e);
                    }
                    else
                    {
                        this.lblDrawCard.Visibility = Visibility.Visible;
                        this.lblDrawCard.Content = "Player 7, draw a card.";
                        this.UnoGame.PlayerTurn = 7;
                        this.DisplayPlayerTurn();
                        this.Playershandscount();
                        await Task.Delay(500);
                    }
                }
                else if (this.gameMode == Mode.MultiplePlayers && this.UnoGame.PlayerTurn == 7)
                {
                    isNumber = false;
                    Card card7 = null;

                    while (!isNumber)
                    {
                        this.X = 280;
                        this.UnoGame.DrawCard(this.UnoGame.Players[6]);
                        card7 = this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1];
                        ////this.X2 = 800;

                        if (card7.MyType == Card.Type.Number)
                        {
                            this.CreateViewImageDynamically(card7.MyImagePath);
                            isNumber = true;
                        }
                    }

                    if (this.UnoGame.PlayerTurn == this.UnoGame.Players.Count)
                    {
                        if (card7.MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && card7.MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && card7.MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && card7.MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && card7.MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && card7.MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 1;
                            MessageBox.Show("Player 7 is the dealer, so Player 1 begins play.");
                        }
                        else if (this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber <= card7.MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 7;
                            MessageBox.Show("Player 6 is the dealer, so Player 7 begins play.");
                        }
                        else if (this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= card7.MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 6;
                            MessageBox.Show("Player 5 is the dealer, so Player 6 begins play.");
                        }
                        else if (this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= card7.MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 5;
                            MessageBox.Show("Player 4 is the dealer, so Player 5 begins play.");
                        }
                        else if (this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= card7.MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 4;
                            MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                        }
                        else if (this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= card7.MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 3;
                            MessageBox.Show("Player 2 is the dealer, so Player 3 begins play.");
                        }
                        else
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 2;
                            MessageBox.Show("Player 1 is the dealer, so Player 2 begins play.");
                        }

                        this.BtnChooseDealer.Content = "New Game";
                        this.BtnChooseDealer.Visibility = Visibility.Hidden;
                        this.BtnNewGame_Click(sender, e);
                    }
                    else
                    {
                        this.lblDrawCard.Visibility = Visibility.Visible;
                        this.lblDrawCard.Content = "Player 8, draw a card.";
                        this.UnoGame.PlayerTurn = 8;
                        this.DisplayPlayerTurn();
                        this.Playershandscount();
                        await Task.Delay(500);
                    }
                }
                else if (this.gameMode == Mode.MultiplePlayers && this.UnoGame.PlayerTurn == 8)
                {
                    isNumber = false;
                    Card card8 = null;

                    while (!isNumber)
                    {
                        this.X = 280;
                        this.UnoGame.DrawCard(this.UnoGame.Players[7]);
                        card8 = this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1];
                        ////this.X2 = 800;

                        if (card8.MyType == Card.Type.Number)
                        {
                            this.CreateComputerDrawCard(card8.MyImagePath);
                            isNumber = true;
                        }
                    }

                    if (this.UnoGame.PlayerTurn == this.UnoGame.Players.Count)
                    {
                        if (card8.MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 1;
                            MessageBox.Show("Player 8 is the dealer, so Player 1 begins play.");
                        }
                        else if (this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 8;
                            MessageBox.Show("Player 7 is the dealer, so Player 8 begins play.");
                        }
                        else if (this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 7;
                            MessageBox.Show("Player 6 is the dealer, so Player 7 begins play.");
                        }
                        else if (this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 6;
                            MessageBox.Show("Player 5 is the dealer, so Player 6 begins play.");
                        }
                        else if (this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 5;
                            MessageBox.Show("Player 4 is the dealer, so Player 5 begins play.");
                        }
                        else if (this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 4;
                            MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                        }
                        else if (this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 3;
                            MessageBox.Show("Player 2 is the dealer, so Player 3 begins play.");
                        }
                        else
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 2;
                            MessageBox.Show("Player 1 is the dealer, so Player 2 begins play.");
                        }

                        this.BtnChooseDealer.Content = "New Game";
                        this.BtnChooseDealer.Visibility = Visibility.Hidden;
                        this.BtnNewGame_Click(sender, e);
                    }
                    else
                    {
                        this.lblDrawCard.Visibility = Visibility.Visible;
                        this.lblDrawCard.Content = "Player 9, draw a card.";
                        this.UnoGame.PlayerTurn = 9;
                        this.DisplayPlayerTurn();
                        this.Playershandscount();
                        await Task.Delay(500);
                    }
                }
                else if (this.gameMode == Mode.MultiplePlayers && this.UnoGame.PlayerTurn == 9)
                {
                    isNumber = false;
                    Card card8 = null;

                    while (!isNumber)
                    {
                        this.X = 350;
                        this.UnoGame.DrawCard(this.UnoGame.Players[8]);
                        card8 = this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1];
                        ////this.X2 = 800;

                        if (card8.MyType == Card.Type.Number)
                        {
                            this.CreateViewImageDynamically(card8.MyImagePath);
                            isNumber = true;
                        }
                    }

                    if (this.UnoGame.PlayerTurn == this.UnoGame.Players.Count)
                    {
                        if (card8.MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 1;
                            MessageBox.Show("Player 9 is the dealer, so Player 1 begins play.");
                        }
                        else if (this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 9;
                            MessageBox.Show("Player 8 is the dealer, so Player 9 begins play.");
                        }
                        else if (this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 8;
                            MessageBox.Show("Player 7 is the dealer, so Player 8 begins play.");
                        }
                        else if (this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 7;
                            MessageBox.Show("Player 6 is the dealer, so Player 7 begins play.");
                        }
                        else if (this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 6;
                            MessageBox.Show("Player 5 is the dealer, so Player 6 begins play.");
                        }
                        else if (this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 5;
                            MessageBox.Show("Player 4 is the dealer, so Player 5 begins play.");
                        }
                        else if (this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 4;
                            MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                        }
                        else if (this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 3;
                            MessageBox.Show("Player 2 is the dealer, so Player 3 begins play.");
                        }
                        else
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 2;
                            MessageBox.Show("Player 1 is the dealer, so Player 2 begins play.");
                        }

                        this.BtnChooseDealer.Content = "New Game";
                        this.BtnChooseDealer.Visibility = Visibility.Hidden;
                        this.BtnNewGame_Click(sender, e);
                    }
                    else
                    {
                        this.lblDrawCard.Visibility = Visibility.Visible;
                        this.lblDrawCard.Content = "Player 10, draw a card.";
                        this.UnoGame.PlayerTurn = 10;
                        this.DisplayPlayerTurn();
                        this.Playershandscount();
                        await Task.Delay(500);
                    }
                }
                else if (this.gameMode == Mode.MultiplePlayers && this.UnoGame.PlayerTurn == 10)
                {
                    isNumber = false;
                    Card card8 = null;

                    while (!isNumber)
                    {
                        this.X = 350;
                        this.UnoGame.DrawCard(this.UnoGame.Players[9]);
                        card8 = this.UnoGame.Players[9].PlayerHand[this.UnoGame.Players[9].PlayerHand.Count - 1];
                        ////this.X2 = 800;

                        if (card8.MyType == Card.Type.Number)
                        {
                            this.CreateComputerDrawCard(card8.MyImagePath);
                            isNumber = true;
                        }
                    }

                    if (this.UnoGame.PlayerTurn == this.UnoGame.Players.Count)
                    {
                        if (card8.MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 1;
                            MessageBox.Show("Player 10 is the dealer, so Player 1 begins play.");
                        }
                        else if (this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 10;
                            MessageBox.Show("Player 9 is the dealer, so Player 10 begins play.");
                        }
                        else if (this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 9;
                            MessageBox.Show("Player 8 is the dealer, so Player 9 begins play.");
                        }
                        else if (this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 8;
                            MessageBox.Show("Player 7 is the dealer, so Player 8 begins play.");
                        }
                        else if (this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 7;
                            MessageBox.Show("Player 6 is the dealer, so Player 7 begins play.");
                        }
                        else if (this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 6;
                            MessageBox.Show("Player 5 is the dealer, so Player 6 begins play.");
                        }
                        else if (this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 5;
                            MessageBox.Show("Player 4 is the dealer, so Player 5 begins play.");
                        }
                        else if (this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 4;
                            MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                        }
                        else if (this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[0].PlayerHand[this.UnoGame.Players[0].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[2].PlayerHand[this.UnoGame.Players[2].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[3].PlayerHand[this.UnoGame.Players[3].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[4].PlayerHand[this.UnoGame.Players[4].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber < this.UnoGame.Players[5].PlayerHand[this.UnoGame.Players[5].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[6].PlayerHand[this.UnoGame.Players[6].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[7].PlayerHand[this.UnoGame.Players[7].PlayerHand.Count - 1].MyNumber && this.UnoGame.Players[1].PlayerHand[this.UnoGame.Players[1].PlayerHand.Count - 1].MyNumber <= this.UnoGame.Players[8].PlayerHand[this.UnoGame.Players[8].PlayerHand.Count - 1].MyNumber)
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 3;
                            MessageBox.Show("Player 2 is the dealer, so Player 3 begins play.");
                        }
                        else
                        {
                            await Task.Delay(500);
                            this.UnoGame.PlayerTurn = 2;
                            MessageBox.Show("Player 1 is the dealer, so Player 2 begins play.");
                        }

                        this.lblDrawCard.Visibility = Visibility.Visible;
                        this.BtnChooseDealer.Content = "New Game";
                        this.BtnChooseDealer.Visibility = Visibility.Hidden;
                        this.BtnNewGame_Click(sender, e);
                    }
                }

                this.imgDeckPile.IsEnabled = true;
            }
        }

        /// <summary>
        /// Chooses the dealer before game starts
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnChooseDealer_Click(object sender, RoutedEventArgs e)
        {
            if (this.gameMode == Mode.TwoPlayers)
            {
                this.UnoGame = new Gameflow();
                this.UnoGame.InGame = false;
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Players = new List<Player>();
                this.UnoGame.Players.Add(new Player());
                this.UnoGame.Players.Add(new Player());
                ////this.UnoGame.Players[0] = new Player();
                ////this.UnoGame.Players[0].IsComputer = false;
                ////this.UnoGame.Players[1] = new Player();
                ////this.UnoGame.Players[1].IsComputer = true;
                this.UnoGame.Players[0].PlayerHand.Clear();
                this.UnoGame.Players[1].PlayerHand.Clear();
                this.UnoGame.PlayerTurn = 1;
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnNewGame);
                this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
                this.grdMainWindow.Children.Add(this.lblDrawCard);
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.BtnChooseDealer.IsEnabled = false;
                this.BtnChooseDealer.Content = "Draw Card";
                this.DisplayPlayerTurn();
                this.Playershandscount();
                this.lblDrawCard.Visibility = Visibility.Visible;
                this.lblDrawCard.Content = "Player 1, draw a card.";
            }
            else if (this.gameMode == Mode.MultiplePlayers)
            {
                Console.WriteLine("in else multipe");
                this.UnoGame = new Gameflow();
                this.UnoGame.InGame = false;
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Players = new List<Player>();
                ////this.UnoGame.Players[0] = new Player();
                ////this.UnoGame.Players[1] = new Player();

                //// start of our new method

                for (int i = 0; i < this.numberOfPlayers; i++)
                {
                    Player p = new Player();
                    this.UnoGame.Players.Add(p);
                }

                //// end of method

                ////this.UnoGame.Players[2] = new Player();
                ////this.UnoGame.Players[0].PlayerHand.Clear();
                ////this.UnoGame.Players[1].PlayerHand.Clear();
                ////this.UnoGame.Players[2].PlayerHand.Clear();
                this.UnoGame.PlayerTurn = 1;
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnNewGame);
                this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
                this.grdMainWindow.Children.Add(this.lblDrawCard);
                this.imgDeckPile.IsEnabled = true;
                this.BtnChooseDealer.IsEnabled = false;
                this.BtnChooseDealer.Content = "Draw Card";
                this.CompX = 70;
                this.X = 70;
                ////this.X2 = 800;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.DisplayPlayerTurn();
                this.Playershandscount();
                this.lblDrawCard.Visibility = Visibility.Visible;
                this.lblDrawCard.Content = "Player 1, draw a card.";
            }
        }

        /// <summary>
        /// Displays the values of each player in the game
        /// </summary>
        private void DisplayValues()
        {
            int i = 1;
            string last = string.Empty;
            string recent = string.Empty;
            foreach (Player p in this.UnoGame.Players)
            {
                last = recent;
                p.Score = p.TotalCardValue();
                recent = "Player " + i + " score is: " + p.Score + Environment.NewLine + last;
                i++;
            }

            MessageBox.Show(recent);
        }

        /// <summary>
        /// Button for player to call Uno
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnPlayer1Uno_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Player1 called Uno!");
            this.lblTutorialStep4.Visibility = Visibility.Hidden;
            BtnPlayer1Uno.Visibility = Visibility.Hidden;
            if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
            {
                BtnNoticeMissedUno.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Button for player to call Uno
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnPlayer2Uno_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Player2 called Uno!");
            BtnPlayer2Uno.Visibility = Visibility.Hidden;
            if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
            {
                BtnNoticeMissedUno.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Button for player to call out those who haven't called Uno
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnNoticeMissedUno_Click(object sender, RoutedEventArgs e)
        {
            if (BtnPlayer1Uno.Visibility == Visibility.Visible)
            {
                BtnPlayer1Uno.Visibility = Visibility.Hidden;
                int saveTurn = this.UnoGame.PlayerTurn;
                this.UnoGame.PlayerTurn = 1;
                this.UnoGame.DrawTwoOrFour(2);
                this.UnoGame.PlayerTurn = saveTurn;
            }

            if (BtnPlayer2Uno.Visibility == Visibility.Visible)
            {
                BtnPlayer2Uno.Visibility = Visibility.Hidden;
                int saveTurn = this.UnoGame.PlayerTurn;
                this.UnoGame.PlayerTurn = 2;
                this.UnoGame.DrawTwoOrFour(2);
                this.UnoGame.PlayerTurn = saveTurn;
            }

            if (BtnPlayer3Uno.Visibility == Visibility.Visible)
            {
                BtnPlayer3Uno.Visibility = Visibility.Hidden;
                int saveTurn = this.UnoGame.PlayerTurn;
                this.UnoGame.PlayerTurn = 3;
                this.UnoGame.DrawTwoOrFour(2);
                this.UnoGame.PlayerTurn = saveTurn;
            }

            if (BtnPlayer4Uno.Visibility == Visibility.Visible)
            {
                BtnPlayer4Uno.Visibility = Visibility.Hidden;
                int saveTurn = this.UnoGame.PlayerTurn;
                this.UnoGame.PlayerTurn = 4;
                this.UnoGame.DrawTwoOrFour(2);
                this.UnoGame.PlayerTurn = saveTurn;
            }

            if (BtnPlayer5Uno.Visibility == Visibility.Visible)
            {
                BtnPlayer5Uno.Visibility = Visibility.Hidden;
                int saveTurn = this.UnoGame.PlayerTurn;
                this.UnoGame.PlayerTurn = 5;
                this.UnoGame.DrawTwoOrFour(2);
                this.UnoGame.PlayerTurn = saveTurn;
            }

            if (BtnPlayer6Uno.Visibility == Visibility.Visible)
            {
                BtnPlayer6Uno.Visibility = Visibility.Hidden;
                int saveTurn = this.UnoGame.PlayerTurn;
                this.UnoGame.PlayerTurn = 6;
                this.UnoGame.DrawTwoOrFour(2);
                this.UnoGame.PlayerTurn = saveTurn;
            }

            if (BtnPlayer7Uno.Visibility == Visibility.Visible)
            {
                BtnPlayer7Uno.Visibility = Visibility.Hidden;
                int saveTurn = this.UnoGame.PlayerTurn;
                this.UnoGame.PlayerTurn = 7;
                this.UnoGame.DrawTwoOrFour(2);
                this.UnoGame.PlayerTurn = saveTurn;
            }

            if (BtnPlayer8Uno.Visibility == Visibility.Visible)
            {
                BtnPlayer8Uno.Visibility = Visibility.Hidden;
                int saveTurn = this.UnoGame.PlayerTurn;
                this.UnoGame.PlayerTurn = 8;
                this.UnoGame.DrawTwoOrFour(2);
                this.UnoGame.PlayerTurn = saveTurn;
            }

            if (BtnPlayer9Uno.Visibility == Visibility.Visible)
            {
                BtnPlayer9Uno.Visibility = Visibility.Hidden;
                int saveTurn = this.UnoGame.PlayerTurn;
                this.UnoGame.PlayerTurn = 9;
                this.UnoGame.DrawTwoOrFour(2);
                this.UnoGame.PlayerTurn = saveTurn;
            }

            if (BtnPlayer10Uno.Visibility == Visibility.Visible)
            {
                BtnPlayer10Uno.Visibility = Visibility.Hidden;
                int saveTurn = this.UnoGame.PlayerTurn;
                this.UnoGame.PlayerTurn = 10;
                this.UnoGame.DrawTwoOrFour(2);
                this.UnoGame.PlayerTurn = saveTurn;
            }

            BtnNoticeMissedUno.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Button for player to call Uno
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnPlayer3Uno_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Player3 called Uno!");
            BtnPlayer3Uno.Visibility = Visibility.Hidden;
            if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
            {
                BtnNoticeMissedUno.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Button for player to call Uno
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnPlayer4Uno_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Player4 called Uno!");
            BtnPlayer4Uno.Visibility = Visibility.Hidden;
            if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
            {
                BtnNoticeMissedUno.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Button for player to call Uno
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnPlayer5Uno_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Player5 called Uno!");
            BtnPlayer5Uno.Visibility = Visibility.Hidden;
            if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
            {
                BtnNoticeMissedUno.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Button for player to call Uno
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnPlayer6Uno_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Player6 called Uno!");
            BtnPlayer6Uno.Visibility = Visibility.Hidden;
            if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
            {
                BtnNoticeMissedUno.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Button for player to call Uno
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnPlayer7Uno_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Player7 called Uno!");
            BtnPlayer7Uno.Visibility = Visibility.Hidden;
            if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
            {
                BtnNoticeMissedUno.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Button for player to call Uno
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnPlayer8Uno_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Player8 called Uno!");
            BtnPlayer8Uno.Visibility = Visibility.Hidden;
            if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
            {
                BtnNoticeMissedUno.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Button for player to call Uno
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnPlayer9Uno_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Player9 called Uno!");
            BtnPlayer9Uno.Visibility = Visibility.Hidden;
            if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
            {
                BtnNoticeMissedUno.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Button for player to call Uno
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnPlayer10Uno_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Player10 called Uno!");
            BtnPlayer10Uno.Visibility = Visibility.Hidden;
            if (BtnPlayer1Uno.Visibility == Visibility.Hidden && BtnPlayer2Uno.Visibility == Visibility.Hidden && BtnPlayer3Uno.Visibility == Visibility.Hidden && BtnPlayer4Uno.Visibility == Visibility.Hidden && BtnPlayer5Uno.Visibility == Visibility.Hidden && BtnPlayer6Uno.Visibility == Visibility.Hidden && BtnPlayer7Uno.Visibility == Visibility.Hidden && BtnPlayer8Uno.Visibility == Visibility.Hidden && BtnPlayer9Uno.Visibility == Visibility.Hidden && BtnPlayer10Uno.Visibility == Visibility.Hidden)
            {
                BtnNoticeMissedUno.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Chooses the dealer before game starts for tutorial
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnChooseDealerTutorial_Click(object sender, RoutedEventArgs e)
        {
            this.UnoGame = new Gameflow();
            this.UnoGame.InGame = false;
            this.UnoGame.GameDeck = new DeckOfCards();
            this.UnoGame.Players = new List<Player>();
            this.UnoGame.Players.Add(new Player());
            this.UnoGame.Players.Add(new Player());
            ////this.UnoGame.Players[0] = new Player();
            ////this.UnoGame.Players[0].IsComputer = false;
            ////this.UnoGame.Players[1] = new Player();
            ////this.UnoGame.Players[1].IsComputer = true;
            this.UnoGame.Players[0].PlayerHand.Clear();
            this.UnoGame.Players[1].PlayerHand.Clear();
            this.UnoGame.PlayerTurn = 1;
            this.UnoGame.Clockwise = true;
            this.UnoGame.GameDeck.SetUpDeck();
            this.grdMainWindow.Children.Clear();
            this.grdMainWindow.Children.Add(this.stepTwoCircle);
            this.grdMainWindow.Children.Add(this.imgDeckPile);
            this.grdMainWindow.Children.Add(this.BtnNewGame);
            this.grdMainWindow.Children.Add(this.BtnChooseDealer);
            this.grdMainWindow.Children.Add(this.BtnClose);
            this.grdMainWindow.Children.Add(this.NextPlayerButton);
            this.grdMainWindow.Children.Add(this.lblPlayer);
            this.grdMainWindow.Children.Add(this.lblDrawCard);
            this.grdMainWindow.Children.Add(this.lblTutorialStep2);
            this.stepTwoCircle.Visibility = Visibility.Visible;
            this.lblTutorialStep2.Visibility = Visibility.Visible;
            this.imgDeckPile.Visibility = Visibility.Visible;
            this.imgDeckPile.IsEnabled = true;
            this.BtnChooseDealer.IsEnabled = false;
            this.BtnChooseDealer.Content = "Draw Card";
            this.DisplayPlayerTurn();
            this.Playershandscount();
            this.lblDrawCard.Visibility = Visibility.Visible;
            this.lblDrawCard.Content = "Player 1, draw a card.";
        }

        /// <summary>
        /// Ends tutorial
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnEndTutorial_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}