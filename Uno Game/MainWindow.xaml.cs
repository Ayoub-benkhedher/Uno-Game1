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
    /// Interaction logic for MainWindow
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
        /// Used to determine current placement of cards in computer hand.
        /// </summary>
        public int CompX = 70;

        /// <summary>
        /// Last image of the computer
        /// </summary>
        public Image LastImage;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.imgDeckPile.Visibility = Visibility.Hidden;
            this.DataContext = this;
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
        /// Throw the card to the central pile.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void DynamicImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.UnoGame.PlayerTurn == 1)
            {
                Image dynamicImage = sender as Image;

                string path = dynamicImage.Source.ToString();
                path = path.Remove(0, 34);
                Card checkCard = new Card();
                foreach (Card c in this.UnoGame.Player1.PlayerHand)
                {
                    if (c.MyImagePath == path)
                    {
                        checkCard = c;
                        break;
                    }
                }

                if (this.UnoGame.CanPlaceCard(checkCard))
                {
                    // removes the image of the card we selected to play
                    grdMainWindow.Children.Remove(dynamicImage);

                    // used to determine how many images have been already removed
                    int count = 0;

                    // used to determine index in grid
                    int currentIndex = 0;

                    // since we have already removed one image, we will be completely removing the rest of the images, which is equivalent to number of cards in PlayerHand - 1
                    while (count < this.UnoGame.Player1.PlayerHand.Count - 1)
                    {
                        UIElement element = grdMainWindow.Children[currentIndex];

                        // checks to see if the element is of an image
                        if (element.GetType().Equals(typeof(Image)))
                        {
                            Image image = element as Image;
                            if ((int)image.Margin.Top == 400)
                            {
                                // we remove every image in PlayerHand (where margin.top == 400)
                                grdMainWindow.Children.Remove(image);

                                // increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                                count++;
                            }
                            else
                            {
                                // if element is not image in PlayerHand, we increment index
                                currentIndex++;
                            }
                        }
                        else
                        {
                            // if element is not an image, we increment index
                            currentIndex++;
                        }
                    }

                    imgMainPile.Source = dynamicImage.Source;

                    // update actual PlayerHand and Center Pile
                    for (int i = 0; i < this.UnoGame.Player1.PlayerHand.Count; i++)
                    {
                        if (path == this.UnoGame.Player1.PlayerHand[i].MyImagePath)
                        {
                            this.UnoGame.CentralPile.Add(this.UnoGame.Player1.PlayerHand[i]);
                            this.UnoGame.Player1.PlayerHand.RemoveAt(i);
                            break;
                        }
                    }

                    this.X = 70;

                    // recreate Playerhand now that images are updated
                    foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                    {
                        this.CreateViewImageDynamically(crd.MyImagePath);
                    }

                    //Perform the draw two card
                    if ((path.Substring(0, 4) == "Draw"))
                    {
                        int n = int.Parse(path.Substring(4, 1));
                        this.UnoGame.DrawTwoOrFour(n);
                        for (int i = 0; i < n; i++)
                        {
                            // creates image for new card
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
                        }

                    }
                    //Perform the wilddraw4 card
                    else if (path.Substring(0, 8) == "WildDraw")
                    {
                        int n = int.Parse(path.Substring(8, 1));
                        this.UnoGame.DrawTwoOrFour(n);

                        for (int i = 0; i < n; i++)
                        {
                            // creates image for new card
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
                        }


                        new Colors(checkCard).ShowDialog();
                        MessageBox.Show(checkCard.MyColor.ToString());

                    }
                    else if (path.Substring(0, 4) == "Wild")
                    {
                        new Colors(checkCard).ShowDialog();
                        MessageBox.Show(checkCard.MyColor.ToString());
                    }


                    //if the card is Reverse or Skip player stays the same 
                    if ((path.Substring(0, 7) != "Reverse") && (path.Substring(0, 4) != "Skip"))
                    {
                        this.UnoGame.PlayerTurn = 2;
                        this.DrawCardButton.IsEnabled = false;
                        this.NextPlayerButton.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this.DrawCardButton.IsEnabled = true;
                    }

                }
            }

            if (UnoGame.Player1.PlayerHand.Count == 0)
            {
                MessageBox.Show("Congrats! You won");
                this.DrawCardButton.IsEnabled = false;
                this.NextPlayerButton.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Creates a new uno game when clicked.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnNewGame_Click(object sender, RoutedEventArgs e)
        {
            this.UnoGame = new Gameflow();
            this.UnoGame.GameDeck = new DeckOfCards();
            this.UnoGame.Player1 = new Player();
            this.UnoGame.Player1.IsComputer = false;
            this.UnoGame.Player2 = new Player();
            this.UnoGame.Player2.IsComputer = true;
            this.UnoGame.PlayerTurn = 1;
            this.UnoGame.GameDeck.SetUpDeck();
            this.UnoGame.DealCards();
            this.grdMainWindow.Children.Clear();
            this.grdMainWindow.Children.Add(this.imgMainPile);
            this.grdMainWindow.Children.Add(this.imgDeckPile);
            this.grdMainWindow.Children.Add(this.DrawCardButton);
            this.grdMainWindow.Children.Add(this.BtnNewGame);
            this.grdMainWindow.Children.Add(this.BtnClose);
            this.grdMainWindow.Children.Add(this.NextPlayerButton);
            this.CompX = 70;
            this.X = 70;
            this.imgDeckPile.Visibility = Visibility.Visible;
            this.DrawCardButton.Visibility = Visibility.Visible;
            this.DrawCardButton.IsEnabled = true;


            // display player's hand
            foreach (Card crd in this.UnoGame.Player1.PlayerHand)
            {
                this.CreateViewImageDynamically(crd.MyImagePath);
            }

            for (int i = 0; i < 7; i++)
            {
                //// Create Image and set its width and height  
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
                this.LastImage = dynamicImage1;
            }

            // creates center pile based on what is on top of the deck
            Card centralStart = new Card();

            centralStart = this.UnoGame.CentralPile[0];

            // create image for central pile
            Image dynamicImageCentral = new Image();
            dynamicImageCentral.Width = 150;
            dynamicImageCentral.Height = 100;


            // Create a BitmapSource  
            BitmapImage bitmapCentral = new BitmapImage();
            bitmapCentral.BeginInit();
            bitmapCentral.UriSource = new Uri(@"pack://siteoforigin:,,,/Resources/" + centralStart.MyImagePath);
            bitmapCentral.EndInit();
            dynamicImageCentral.Source = bitmapCentral;

            imgMainPile.Source = dynamicImageCentral.Source;

        }

        /// <summary>
        /// Draws a card for player if clicked.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void DrawCardButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.UnoGame.PlayerTurn == 1)
            {
                this.UnoGame.DrawCard(this.UnoGame.Player1);
                Card card = this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1];
                this.CreateViewImageDynamically(card.MyImagePath);
                this.DrawCardButton.IsEnabled = false;
                if (!this.UnoGame.CheckUserHand(this.UnoGame.Player1.PlayerHand))
                {
                    this.UnoGame.PlayerTurn = 2;
                    this.NextPlayerButton.Visibility = Visibility.Visible;
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
            if (this.UnoGame.PlayerTurn == 2)
            {
                Card findCard = this.UnoGame.CheckCompHand(this.UnoGame.Player2.PlayerHand);
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
                    this.UnoGame.DrawCard(this.UnoGame.Player2);

                    // creates image for new card
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

                    Card checkAgain = this.UnoGame.CheckCompHand(this.UnoGame.Player2.PlayerHand);

                    if (checkAgain != null)
                    {
                        grdMainWindow.Children.Remove(dynamicImage1);
                        this.CompX -= 70;

                        // create image for central pile
                        Image dynamicImageCentral = new Image();
                        dynamicImageCentral.Width = 150;
                        dynamicImageCentral.Height = 100;

                        // Create a BitmapSource  
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
                    this.DrawCardButton.IsEnabled = true;

                }
                else
                {
                    check = true;
                    grdMainWindow.Children.Remove(this.LastImage);
                    this.CompX -= 70;

                    // create image for central pile
                    Image dynamicImageCentral = new Image();
                    dynamicImageCentral.Width = 150;
                    dynamicImageCentral.Height = 100;

                    // Create a BitmapSource  
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
                    if ((findCard.MyType == Card.Type.Draw2 || findCard.MyType == Card.Type.WildDraw4))
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

                        // used to determine how many images have been already removed
                        int count = 0;

                        // used to determine index in grid
                        int currentIndex = 0;

                        while (count < this.UnoGame.Player1.PlayerHand.Count)
                        {
                            UIElement element = grdMainWindow.Children[currentIndex];

                            // checks to see if the element is of an image
                            if (element.GetType().Equals(typeof(Image)))
                            {
                                Image image = element as Image;
                                if ((int)image.Margin.Top == 400)
                                {
                                    // we remove every image in PlayerHand (where margin.top == 400)
                                    grdMainWindow.Children.Remove(image);

                                    // increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                                    count++;
                                }
                                else
                                {
                                    // if element is not image in PlayerHand, we increment index
                                    currentIndex++;
                                }
                            }
                            else
                            {
                                // if element is not an image, we increment index
                                currentIndex++;
                            }
                        }

                        this.UnoGame.DrawTwoOrFour(n);

                        this.X = 70;
                        // recreate Playerhand now that images are updated
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }

                    }

                    //if the card is Reverse or Skip Player stays the same 
                    if ((findCard.MyType != Card.Type.Reverse) && (findCard.MyType != Card.Type.Skip))
                    {

                        this.NextPlayerButton.Visibility = Visibility.Hidden;
                        this.UnoGame.PlayerTurn = 1;
                        this.DrawCardButton.IsEnabled = true;
                    }
                    else
                    {
                        this.UnoGame.PlayerTurn = 2;
                        this.DrawCardButton.IsEnabled = false;
                    }

                }
                else
                {
                    this.UnoGame.PlayerTurn = 1;
                    NextPlayerButton.Visibility = Visibility.Hidden;
                    this.DrawCardButton.IsEnabled = true;
                }

                if (findCard != null && (findCard.MyType == Card.Type.Wild || findCard.MyType == Card.Type.WildDraw4))
                {
                    MessageBox.Show("The computer has chosen color: " + findCard.MyColor.ToString());
                }


            }

            if (UnoGame.Player2.PlayerHand.Count == 0)
            {
                MessageBox.Show("Game over. Computer won");
                this.DrawCardButton.IsEnabled = false;
                this.NextPlayerButton.Visibility = Visibility.Hidden;
            }

        }
    }
}
