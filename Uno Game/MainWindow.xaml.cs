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

    public enum Mode
    {
        /// <summary>
        /// Theme that is a mix.
        /// </summary>
        TwoPlayers = 1,

        /// <summary>
        /// Theme that is a sport.
        /// </summary>
        ThreePlayers = 2
    }
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

        private Mode gameMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow(Mode mode)
        {
            this.gameMode = mode;
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
        /// Sets up the images for the game.
        /// </summary>
        /// <param name="path"> Sends in the path for the string.</param>
        private void CreateViewImageDynamically2(string path)
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
            dynamicImage.Margin = new Thickness(this.X2, 250, 0, 0);

            dynamicImage.MouseLeftButtonUp += this.DynamicImage1_MouseLeftButtonUp;
            this.X2 += 70;
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

                    //// Recreate Playerhand now that images are updated
                    foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                    {
                        this.CreateViewImageDynamically(crd.MyImagePath);
                    }

                    //// Perform the draw two card
                    //// Else performs the wilddraw4 card
                    if (path.Substring(0, 4) == "Draw")
                    {
                        int n = int.Parse(path.Substring(4, 1));
                        if (this.gameMode == Mode.ThreePlayers)
                        {
                            if (this.UnoGame.Clockwise)
                            {
                                this.UnoGame.DrawTwoOrFour(n);
                                for (int i = 0; i < n; i++)
                                {
                                    RebindComputerCards();
                                    this.CompX += 70;
                                }
                            }
                            else
                            {
                                // used to determine how many images have been already removed
                                int count1 = 0;

                                // used to determine index in grid
                                int currentIndex1 = 0;

                                while (count1 < this.UnoGame.Player3.PlayerHand.Count)
                                {
                                    UIElement element = grdMainWindow.Children[currentIndex1];

                                    // checks to see if the element is of an image
                                    if (element.GetType().Equals(typeof(Image)))
                                    {
                                        Image image = element as Image;
                                        if ((int)image.Margin.Top == 250)
                                        {
                                            // we remove every image in PlayerHand (where margin.top == 400)
                                            grdMainWindow.Children.Remove(image);

                                            // increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                                            count1++;
                                        }
                                        else
                                        {
                                            // if element is not image in PlayerHand, we increment index
                                            currentIndex1++;
                                        }
                                    }
                                    else
                                    {
                                        //// If element is not an image, we increment index
                                        currentIndex1++;
                                    }
                                }
                                this.UnoGame.DrawTwoOrFour(n);
                                this.X2 = 800;

                                // display player's hand
                                foreach (Card crd in this.UnoGame.Player3.PlayerHand)
                                {
                                    this.CreateViewImageDynamically2(crd.MyImagePath);
                                }
                            }
                        }
                        else
                        {
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
                    }
                    else if (path.Substring(0, 8) == "WildDraw")
                    {
                        int n = int.Parse(path.Substring(8, 1));

                        if (this.UnoGame.Clockwise)
                        {
                            this.UnoGame.DrawTwoOrFour(n);
                            for (int i = 0; i < n; i++)
                            {
                                RebindComputerCards();
                                this.CompX += 70;
                            }
                        }
                        else
                        {
                            // used to determine how many images have been already removed
                            int count2 = 0;

                            // used to determine index in grid
                            int currentIndex2 = 0;
                            while (count2 < this.UnoGame.Player3.PlayerHand.Count)
                            {
                                UIElement element = grdMainWindow.Children[currentIndex2];

                                // checks to see if the element is of an image
                                if (element.GetType().Equals(typeof(Image)))
                                {
                                    Image image = element as Image;
                                    if ((int)image.Margin.Top == 250)
                                    {
                                        // we remove every image in PlayerHand (where margin.top == 400)
                                        grdMainWindow.Children.Remove(image);

                                        // increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                                        count2++;
                                    }
                                    else
                                    {
                                        // if element is not image in PlayerHand, we increment index
                                        currentIndex2++;
                                    }
                                }
                                else
                                {
                                    //// If element is not an image, we increment index
                                    currentIndex2++;
                                }
                            }

                            this.UnoGame.DrawTwoOrFour(n);
                            this.X2 = 800;

                            // display player's hand
                            foreach (Card crd in this.UnoGame.Player3.PlayerHand)
                            {
                                this.CreateViewImageDynamically2(crd.MyImagePath);
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
                    if ((path.Substring(0, 7) != "Reverse") && (path.Substring(0, 4) != "Skip"))
                    {
                        if (this.gameMode == Mode.ThreePlayers)
                        {
                            if (this.UnoGame.Clockwise)
                            {
                                this.UnoGame.PlayerTurn = 2;
                                //this.imgDeckPile.IsEnabled = false;
                                this.NextPlayerButton_Click(sender, e);
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 3;
                                //this.imgDeckPile.IsEnabled = true;
                            }
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 2;
                            //this.imgDeckPile.IsEnabled = false;
                            this.NextPlayerButton_Click(sender, e);
                        }

                    }
                    else
                    {
                        if (this.gameMode == Mode.ThreePlayers)
                        {
                            if (this.UnoGame.Clockwise)
                            {
                                if (path.Substring(0, 7) == "Reverse")
                                {
                                    this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
                                }
                                this.UnoGame.PlayerTurn = 3;
                                //this.imgDeckPile.IsEnabled = true;
                            }
                            else
                            {
                                if (path.Substring(0, 7) == "Reverse")
                                {
                                    this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
                                }
                                this.UnoGame.PlayerTurn = 2;
                                //this.imgDeckPile.IsEnabled = false;
                                this.NextPlayerButton_Click(sender, e);
                            }
                        }
                        else
                        {
                            //this.imgDeckPile.IsEnabled = true;
                        }
                    }
                }
            DisplayPlayerTurn();
            }

            if (this.UnoGame.Player1.PlayerHand.Count == 0)
            {
                MessageBox.Show("Congrats! Player1 win!");
                //this.imgDeckPile.IsEnabled = false;
                this.UnoGame.PlayerTurn = 0;
            }
        }

        /// <summary>
        /// Throw the card to the central pile.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void DynamicImage1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.UnoGame.PlayerTurn == 3)
            {
                Image dynamicImage = sender as Image;

                string path = dynamicImage.Source.ToString();
                path = path.Remove(0, 34);
                Card checkCard = new Card();

                foreach (Card c in this.UnoGame.Player3.PlayerHand)
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
                    while (count < this.UnoGame.Player3.PlayerHand.Count - 1)
                    {
                        UIElement element = grdMainWindow.Children[currentIndex];

                        // checks to see if the element is of an image
                        if (element.GetType().Equals(typeof(Image)))
                        {
                            Image image = element as Image;
                            if ((int)image.Margin.Top == 250)
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
                    for (int i = 0; i < this.UnoGame.Player3.PlayerHand.Count; i++)
                    {
                        if (path == this.UnoGame.Player3.PlayerHand[i].MyImagePath)
                        {
                            this.UnoGame.CentralPile.Add(this.UnoGame.Player3.PlayerHand[i]);
                            this.UnoGame.Player3.PlayerHand.RemoveAt(i);
                            break;
                        }
                    }

                    this.X2 = 800;

                    //// Recreate Playerhand now that images are updated
                    foreach (Card crd in this.UnoGame.Player3.PlayerHand)
                    {
                        this.CreateViewImageDynamically2(crd.MyImagePath);
                    }

                    //// Perform the draw two card
                    //// Else performs the wilddraw4 card
                    if (path.Substring(0, 4) == "Draw")
                    {
                        int n = int.Parse(path.Substring(4, 1));
                        
                        if (!this.UnoGame.Clockwise)
                        {
                            this.UnoGame.DrawTwoOrFour(n);
                            for (int i = 0; i < n; i++)
                            {
                                RebindComputerCards();
                                this.CompX += 70;
                            }
                        }
                        else
                        {
                            // used to determine how many images have been already removed
                            int count1 = 0;

                            // used to determine index in grid
                            int currentIndex1 = 0;

                            while (count1 < this.UnoGame.Player1.PlayerHand.Count)
                            {
                                UIElement element = grdMainWindow.Children[currentIndex1];

                                // checks to see if the element is of an image
                                if (element.GetType().Equals(typeof(Image)))
                                {
                                    Image image = element as Image;
                                    if ((int)image.Margin.Top == 400)
                                    {
                                        // we remove every image in PlayerHand (where margin.top == 400)
                                        grdMainWindow.Children.Remove(image);

                                        // increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                                        count1++;
                                    }
                                    else
                                    {
                                        // if element is not image in PlayerHand, we increment index
                                        currentIndex1++;
                                    }
                                }
                                else
                                {
                                    //// If element is not an image, we increment index
                                    currentIndex1++;
                                }
                            }
                            this.UnoGame.DrawTwoOrFour(n);
                            this.X = 70;

                            // display player's hand
                            foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                            {
                                this.CreateViewImageDynamically(crd.MyImagePath);
                            }
                        }
                    }
                    else if (path.Substring(0, 8) == "WildDraw")
                    {
                        int n = int.Parse(path.Substring(8, 1));

                        if (!this.UnoGame.Clockwise)
                        {
                            this.UnoGame.DrawTwoOrFour(n);
                            for (int i = 0; i < n; i++)
                            {
                                RebindComputerCards();
                                this.CompX += 70;
                            }
                        }
                        else
                        {
                            // used to determine how many images have been already removed
                            int count2 = 0;

                            // used to determine index in grid
                            int currentIndex2 = 0;
                            while (count2 < this.UnoGame.Player1.PlayerHand.Count)
                            {
                                UIElement element = grdMainWindow.Children[currentIndex2];

                                // checks to see if the element is of an image
                                if (element.GetType().Equals(typeof(Image)))
                                {
                                    Image image = element as Image;
                                    if ((int)image.Margin.Top == 400)
                                    {
                                        // we remove every image in PlayerHand (where margin.top == 400)
                                        grdMainWindow.Children.Remove(image);

                                        // increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                                        count2++;
                                    }
                                    else
                                    {
                                        // if element is not image in PlayerHand, we increment index
                                        currentIndex2++;
                                    }
                                }
                                else
                                {
                                    //// If element is not an image, we increment index
                                    currentIndex2++;
                                }
                            }

                            this.UnoGame.DrawTwoOrFour(n);
                            this.X = 70;

                            // display player's hand
                            foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                            {
                                this.CreateViewImageDynamically(crd.MyImagePath);
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
                    if ((path.Substring(0, 7) != "Reverse") && (path.Substring(0, 4) != "Skip"))
                    {
                        
                        if (!this.UnoGame.Clockwise)
                        {
                            this.UnoGame.PlayerTurn = 2;
                            //this.imgDeckPile.IsEnabled = false;
                            this.NextPlayerButton_Click(sender, e);
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 1;
                        }

                    }
                    else
                    {
                        if (!this.UnoGame.Clockwise)
                        {
                            if (path.Substring(0, 7) == "Reverse")
                            {
                                this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
                            }
                                this.UnoGame.PlayerTurn = 1;
                        }
                        else 
                        {
                            if (path.Substring(0, 7) == "Reverse")
                            {
                                this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
                            }
                            this.UnoGame.PlayerTurn = 2;
                            //this.imgDeckPile.IsEnabled = false;
                            this.NextPlayerButton_Click(sender, e);
                        }
                    }
                }
            DisplayPlayerTurn();
            }

            if (this.UnoGame.Player3.PlayerHand.Count == 0)
            {
                MessageBox.Show("Congrats! Player 3 win!");
                //this.imgDeckPile.IsEnabled = false;
                this.UnoGame.PlayerTurn = 0;
            }
        }

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
        /// Creates a new uno game when clicked.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnNewGame_Click(object sender, RoutedEventArgs e)
        {

            if (this.gameMode == Mode.TwoPlayers)
            {
                this.UnoGame = new Gameflow();
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Player1 = new Player();
                //this.UnoGame.Player1.IsComputer = false;
                this.UnoGame.Player2 = new Player();
                //this.UnoGame.Player2.IsComputer = true;
                this.UnoGame.PlayerTurn = 1;
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                this.UnoGame.DealCards(gameMode);
                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgMainPile);
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnNewGame);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
                this.CompX = 70;
                this.X = 70;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;

                // display player's hand
                foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                {
                    this.CreateViewImageDynamically(crd.MyImagePath);
                }

                for (int i = 0; i < 7; i++)
                {
                    RebindComputerCards();
                    this.CompX += 70;
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
            else if (this.gameMode == Mode.ThreePlayers)
            {
                this.UnoGame = new Gameflow();
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Player1 = new Player();
                this.UnoGame.Player2 = new Player();
                this.UnoGame.Player3 = new Player();
                this.UnoGame.PlayerTurn = 1;
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                this.UnoGame.DealCards(gameMode);
                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgMainPile);
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnNewGame);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
                this.CompX = 70;
                this.X = 70;
                this.X2 = 800;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                // display player's hand
                foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                {
                    this.CreateViewImageDynamically(crd.MyImagePath);
                }
                // display second player's hand
                foreach (Card crd in this.UnoGame.Player3.PlayerHand)
                {
                    this.CreateViewImageDynamically2(crd.MyImagePath);
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
        }
        public void DisplayPlayerTurn()
        {
            if (this.UnoGame.PlayerTurn== 1)
            {
                lblPlayer.Content = "Player1";
            }else if (this.UnoGame.PlayerTurn == 2)
            {
                lblPlayer.Content = "Computer";
            }
            else { lblPlayer.Content = "Player3"; }
        }
        /// <summary>
        /// If a user cannot play a card after drawing, 
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private async void NextPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(1000);
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
                    //this.imgDeckPile.IsEnabled = true;
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
                    if (this.gameMode == Mode.ThreePlayers)
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

                            // used to determine how many images have been already removed
                            int count = 0;

                            // used to determine index in grid
                            int currentIndex = 0;
                            if (!this.UnoGame.Clockwise)
                            {
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
                                        //// If element is not an image, we increment index
                                        currentIndex++; 
                                    }
                                }

                                this.UnoGame.DrawTwoOrFour(n);

                                this.X = 70;
                                //// Recreate Playerhand now that images are updated
                                foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                                {
                                    this.CreateViewImageDynamically(crd.MyImagePath);
                                }
                            }
                            else
                            {
                                while (count < this.UnoGame.Player3.PlayerHand.Count)
                                {
                                    UIElement element = grdMainWindow.Children[currentIndex];

                                    // checks to see if the element is of an image
                                    if (element.GetType().Equals(typeof(Image)))
                                    {
                                        Image image = element as Image;
                                        if ((int)image.Margin.Top == 250)
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
                                        //// If element is not an image, we increment index
                                        currentIndex++;
                                    }
                                }

                                this.UnoGame.DrawTwoOrFour(n);

                                this.X2 = 800;
                                //// Recreate Playerhand now that images are updated
                                foreach (Card crd in this.UnoGame.Player3.PlayerHand)
                                {
                                    this.CreateViewImageDynamically2(crd.MyImagePath);
                                }

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
                                    //// If element is not an image, we increment index
                                    currentIndex++;
                                }
                            }

                            this.UnoGame.DrawTwoOrFour(n);

                            this.X = 70;
                            //// Recreate Playerhand now that images are updated
                            foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                            {
                                this.CreateViewImageDynamically(crd.MyImagePath);
                            }
                        }
                    }

                    //// If the card is Reverse or Skip Player stays the same 
                    if ((findCard.MyType != Card.Type.Reverse) && (findCard.MyType != Card.Type.Skip))
                    {
                        if (this.gameMode == Mode.ThreePlayers)
                        {
                            if (!this.UnoGame.Clockwise)
                            {
                                this.UnoGame.PlayerTurn = 1;
                                //this.imgDeckPile.IsEnabled = true;

                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 3;
                                //this.imgDeckPile.IsEnabled = true;
                            }
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 1;
                            //this.imgDeckPile.IsEnabled = true;
                        }
                    }
                    else
                    {
                        if (this.gameMode == Mode.ThreePlayers)
                        {
                            if (!this.UnoGame.Clockwise)
                            {
                                if (findCard.MyType == Card.Type.Reverse)
                                {
                                    this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
                                }
                                this.UnoGame.PlayerTurn = 3;
                                //this.imgDeckPile.IsEnabled = true;
                            }
                            else
                            {
                                if (findCard.MyType == Card.Type.Reverse)
                                {
                                    this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
                                }
                                this.UnoGame.PlayerTurn = 1;
                                //this.imgDeckPile.IsEnabled = true;
                            }
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 2;
                            //this.imgDeckPile.IsEnabled = false;
                            this.NextPlayerButton_Click(sender, e);
                        }
                    }
                    
                }
                else
                {
                    if (this.gameMode == Mode.ThreePlayers)
                    {
                        if (!this.UnoGame.Clockwise)
                        {
                            this.UnoGame.PlayerTurn = 1;
                            //this.imgDeckPile.IsEnabled = true;

                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 3;
                            //this.imgDeckPile.IsEnabled = true;
                        }
                    }
                    else
                    {
                        this.UnoGame.PlayerTurn = 1;
                        //this.imgDeckPile.IsEnabled = true;
                    }
                }

                if (findCard != null && (findCard.MyType == Card.Type.Wild || findCard.MyType == Card.Type.WildDraw4))
                {
                    MessageBox.Show("The computer has chosen color: " + findCard.MyColor.ToString());
                }
            }

            if (this.UnoGame.Player2.PlayerHand.Count == 0)
            {
                MessageBox.Show("Game over. Computer won");
                //this.imgDeckPile.IsEnabled = false;
                this.UnoGame.PlayerTurn = 0;
            }
            DisplayPlayerTurn();
        }

        /// <summary>
        /// Draws a card for player if clicked.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void ImgDeckPile_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.UnoGame.PlayerTurn == 1 && !this.UnoGame.CheckUserHand(this.UnoGame.Player1.PlayerHand))
            {
                this.UnoGame.DrawCard(this.UnoGame.Player1);
                Card card = this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1];
                this.CreateViewImageDynamically(card.MyImagePath);
                //this.imgDeckPile.IsEnabled = false;
                if (!this.UnoGame.CheckUserHand(this.UnoGame.Player1.PlayerHand))
                {
                    if (this.UnoGame.Clockwise)
                    {
                        this.UnoGame.PlayerTurn = 2;
                        this.NextPlayerButton_Click(sender, e);
                    }
                    else
                    {
                        this.UnoGame.PlayerTurn = 3;
                        //this.imgDeckPile.IsEnabled = true;
                    }
                }
            }
            else if (this.gameMode== Mode.ThreePlayers &&(this.UnoGame.PlayerTurn == 3 && !this.UnoGame.CheckUserHand(this.UnoGame.Player3.PlayerHand)))
            {
                this.UnoGame.DrawCard(this.UnoGame.Player3);
                Card card = this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1];
                this.CreateViewImageDynamically2(card.MyImagePath);
                //this.imgDeckPile.IsEnabled = false;
                if (!this.UnoGame.CheckUserHand(this.UnoGame.Player3.PlayerHand))
                {
                    if (this.UnoGame.Clockwise)
                    {
                        this.UnoGame.PlayerTurn = 1;
                        //this.imgDeckPile.IsEnabled = true;


                    }
                    else
                    {
                        this.UnoGame.PlayerTurn = 2;
                        this.NextPlayerButton_Click(sender, e);
                    }
                }
            }
            DisplayPlayerTurn();
            Console.WriteLine(this.UnoGame.CurrentDeck.Count);
        }

    }
}
