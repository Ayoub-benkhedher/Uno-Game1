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
        ThreePlayers = 2,

        /// <summary>
        /// Four player mode
        /// </summary>
        FourPlayers = 3,

        /// <summary>
        /// Five player mode
        /// </summary>
        FivePlayers = 4,

        /// <summary>
        /// Six player mode
        /// </summary>
        SixPlayers = 5,

        /// <summary>
        /// Seven player mode
        /// </summary>
        SevenPlayers = 6,

        /// <summary>
        /// Eight player mode
        /// </summary>
        EightPlayers = 7,

        /// <summary>
        /// Nine player mode
        /// </summary>
        NinePlayers = 8,

        /// <summary>
        /// Ten player mode
        /// </summary>
        TenPlayers = 9
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
        /// The type of Game Mode.
        /// </summary>
        private Mode gameMode;

        private int playerCount;

       /// <summary>
       /// Initializes a new instance of the <see cref="MainWindow"/> class.
       /// </summary>
       /// <param name="mode">The game mode.</param>
        public MainWindow(Mode mode)
        {
            this.gameMode = mode;
            this.InitializeComponent();
            this.BtnNewGame.Visibility = Visibility.Hidden;
            this.BtnChooseDealer.Visibility = Visibility.Visible;
            this.imgDeckPile.Visibility = Visibility.Hidden;
            this.DataContext = this;
            this.lblDrawCard.Visibility = Visibility.Hidden;
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
            if (this.UnoGame.PlayerTurn == 1)
            {
                lblPlayer.Content = "Player1";
            }
            else if (this.UnoGame.PlayerTurn == 2)
            {
                lblPlayer.Content = "Computer";
            }
            else if (this.UnoGame.PlayerTurn == 3)
            {
                lblPlayer.Content = "Player3";
            }
            else if (this.UnoGame.PlayerTurn == 4)
            {
                lblPlayer.Content = "Player4";
            }
            else if (this.UnoGame.PlayerTurn == 5)
            {
                lblPlayer.Content = "Player5";
            }
            else if (this.UnoGame.PlayerTurn == 6)
            {
                lblPlayer.Content = "Player6";
            }
            else if (this.UnoGame.PlayerTurn == 7)
            {
                lblPlayer.Content = "Player7";
            }
            else if (this.UnoGame.PlayerTurn == 8)
            {
                lblPlayer.Content = "Player8";
            }
            else if (this.UnoGame.PlayerTurn == 9)
            {
                lblPlayer.Content = "Player9";
            }
            else
            {
                lblPlayer.Content = "Player10";
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

        /*
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
        }*/

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
                    //// removes the image of the card we selected to play
                    grdMainWindow.Children.Remove(dynamicImage);

                    //// used to determine how many images have been already removed
                    int count = 0;

                    //// used to determine index in grid
                    int currentIndex = 0;

                    //// since we have already removed one image, we will be completely removing the rest of the images, which is equivalent to number of cards in PlayerHand - 1
                    while (count < this.UnoGame.Player1.PlayerHand.Count - 1)
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
                            //// if element is not an image, we increment index
                            currentIndex++;
                        }
                    }

                    imgMainPile.Source = dynamicImage.Source;

                    //// update actual PlayerHand and Center Pile
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
                                    this.RebindComputerCards();
                                    this.CompX += 70;
                                }
                            }
                            else
                            {
                                //// used to determine how many images have been already removed
                                int count1 = 0;

                                //// used to determine index in grid
                                int currentIndex1 = 0;

                                while (count1 < this.UnoGame.Player3.PlayerHand.Count)
                                {
                                    UIElement element = grdMainWindow.Children[currentIndex1];

                                    //// checks to see if the element is of an image
                                    if (element.GetType().Equals(typeof(Image)))
                                    {
                                        Image image = element as Image;
                                        if ((int)image.Margin.Top == 250)
                                        {
                                            //// we remove every image in PlayerHand (where margin.top == 400)
                                            grdMainWindow.Children.Remove(image);

                                            //// increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                                            count1++;
                                        }
                                        else
                                        {
                                            //// if element is not image in PlayerHand, we increment index
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

                                //// display player's hand
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
                                this.RebindComputerCards();
                                this.CompX += 70;
                            }
                        }
                        else
                        {
                            //// used to determine how many images have been already removed
                            int count2 = 0;

                            //// used to determine index in grid
                            int currentIndex2 = 0;
                            while (count2 < this.UnoGame.Player3.PlayerHand.Count)
                            {
                                UIElement element = grdMainWindow.Children[currentIndex2];

                                //// checks to see if the element is of an image
                                if (element.GetType().Equals(typeof(Image)))
                                {
                                    Image image = element as Image;
                                    if ((int)image.Margin.Top == 250)
                                    {
                                        //// we remove every image in PlayerHand (where margin.top == 400)
                                        grdMainWindow.Children.Remove(image);

                                        //// increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                                        count2++;
                                    }
                                    else
                                    {
                                        //// if element is not image in PlayerHand, we increment index
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

                            //// display player's hand
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
                                ////this.imgDeckPile.IsEnabled = false;
                                if (this.UnoGame.Player1.PlayerHand.Count != 0)
                                {
                                    this.NextPlayerButton_Click(sender, e);
                                }
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 3;
                                ////this.imgDeckPile.IsEnabled = true;
                            }
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 2;
                            ////this.imgDeckPile.IsEnabled = false;
                            if (this.UnoGame.Player1.PlayerHand.Count != 0)
                            {
                                this.NextPlayerButton_Click(sender, e);
                            }
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
                                ////this.imgDeckPile.IsEnabled = true;
                            }
                            else
                            {
                                if (path.Substring(0, 7) == "Reverse")
                                {
                                    this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
                                }

                                this.UnoGame.PlayerTurn = 2;
                                ////this.imgDeckPile.IsEnabled = false;
                                if (this.UnoGame.Player1.PlayerHand.Count != 0)
                                {
                                    this.NextPlayerButton_Click(sender, e);
                                }
                            }
                        }
                        else
                        {
                            ////this.imgDeckPile.IsEnabled = true;
                        }
                    }
                }
              
                this.DisplayPlayerTurn();
            }

            if (this.UnoGame.Player1.PlayerHand.Count == 0)
            {
                MessageBox.Show("Congrats! Player1 win!");
                ////this.imgDeckPile.IsEnabled = false;
                this.UnoGame.PlayerTurn = 0;
            }
        }

        /*
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
                    //// removes the image of the card we selected to play
                    grdMainWindow.Children.Remove(dynamicImage);

                    //// used to determine how many images have been already removed
                    int count = 0;

                    //// used to determine index in grid
                    int currentIndex = 0;

                    //// since we have already removed one image, we will be completely removing the rest of the images, which is equivalent to number of cards in PlayerHand - 1
                    while (count < this.UnoGame.Player3.PlayerHand.Count - 1)
                    {
                        UIElement element = grdMainWindow.Children[currentIndex];

                        //// checks to see if the element is of an image
                        if (element.GetType().Equals(typeof(Image)))
                        {
                            Image image = element as Image;
                            if ((int)image.Margin.Top == 250)
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
                            //// if element is not an image, we increment index
                            currentIndex++;
                        }
                    }

                    imgMainPile.Source = dynamicImage.Source;

                    //// update actual PlayerHand and Center Pile
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
                                this.RebindComputerCards();
                                this.CompX += 70;
                            }
                        }
                        else
                        {
                            //// used to determine how many images have been already removed
                            int count1 = 0;

                            //// used to determine index in grid
                            int currentIndex1 = 0;

                            while (count1 < this.UnoGame.Player1.PlayerHand.Count)
                            {
                                UIElement element = grdMainWindow.Children[currentIndex1];

                                //// checks to see if the element is of an image
                                if (element.GetType().Equals(typeof(Image)))
                                {
                                    Image image = element as Image;
                                    if ((int)image.Margin.Top == 400)
                                    {
                                        //// we remove every image in PlayerHand (where margin.top == 400)
                                        grdMainWindow.Children.Remove(image);

                                        //// increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                                        count1++;
                                    }
                                    else
                                    {
                                        //// if element is not image in PlayerHand, we increment index
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

                            //// display player's hand
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
                                this.RebindComputerCards();
                                this.CompX += 70;
                            }
                        }
                        else
                        {
                            //// used to determine how many images have been already removed
                            int count2 = 0;

                            //// used to determine index in grid
                            int currentIndex2 = 0;
                            while (count2 < this.UnoGame.Player1.PlayerHand.Count)
                            {
                                UIElement element = grdMainWindow.Children[currentIndex2];

                                //// checks to see if the element is of an image
                                if (element.GetType().Equals(typeof(Image)))
                                {
                                    Image image = element as Image;
                                    if ((int)image.Margin.Top == 400)
                                    {
                                        //// we remove every image in PlayerHand (where margin.top == 400)
                                        grdMainWindow.Children.Remove(image);

                                        //// increment since image has been removed.  We do not increment currentIndex, because the next element will automatically take index of the image that was removed
                                        count2++;
                                    }
                                    else
                                    {
                                        //// if element is not image in PlayerHand, we increment index
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

                            //// display player's hand
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
                            ////this.imgDeckPile.IsEnabled = false;
                            if (this.UnoGame.Player3.PlayerHand.Count != 0)
                            {
                                this.NextPlayerButton_Click(sender, e);
                            }
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
                            ////this.imgDeckPile.IsEnabled = false;
                            if (this.UnoGame.Player3.PlayerHand.Count != 0)
                            {
                                this.NextPlayerButton_Click(sender, e);
                            }
                        }
                    }
                }
            
                this.DisplayPlayerTurn();
            }

            if (this.UnoGame.Player3.PlayerHand.Count == 0)
            {
                MessageBox.Show("Congrats! Player 3 win!");
                this.imgDeckPile.IsEnabled = false;
                this.UnoGame.PlayerTurn = 0;
            }
        }*/

        /// <summary>
        /// Creates a new uno game when clicked.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnNewGame_Click(object sender, RoutedEventArgs e)
        {
            if (this.gameMode == Mode.TwoPlayers)
            {
                this.UnoGame.InGame = true;
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.DealCards(this.gameMode);
                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgMainPile);
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
                this.CompX = 70;
                this.X = 70;
                this.imgMainPile.Visibility = Visibility.Visible;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.BtnChooseDealer.Visibility = Visibility.Visible;
                this.BtnChooseDealer.IsEnabled = true;
                this.lblDrawCard.Visibility = Visibility.Hidden;

                //// display player's hand
                foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                {
                    this.CreateViewImageDynamically(crd.MyImagePath);
                }

                foreach (Card crd in this.UnoGame.Player2.PlayerHand)
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
            else if (this.gameMode == Mode.ThreePlayers)
            {
                this.UnoGame.InGame = true;
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.DealCards(this.gameMode);
                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgMainPile);
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
                this.CompX = 70;
                this.X = 70;
                this.imgMainPile.Visibility = Visibility.Visible;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.BtnChooseDealer.Visibility = Visibility.Visible;
                this.BtnChooseDealer.IsEnabled = true;
                this.lblDrawCard.Visibility = Visibility.Hidden;

                switch (this.UnoGame.PlayerTurn)
                {
                    case 1:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 2:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 3:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player3.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
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
            else if (this.gameMode == Mode.FourPlayers)
            {
                this.UnoGame.InGame = true;
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.UnoGame.DealCards(this.gameMode);
                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgMainPile);
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
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

                switch (this.UnoGame.PlayerTurn)
                {
                    case 1:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 2:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 3:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player3.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 4:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player4.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
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
            else if (this.gameMode == Mode.FivePlayers)
            {
                this.UnoGame.InGame = true;
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.UnoGame.Player5.PlayerHand.Clear();
                this.UnoGame.DealCards(this.gameMode);
                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgMainPile);
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
                this.CompX = 70;
                this.X = 70;
                this.imgMainPile.Visibility = Visibility.Visible;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.BtnChooseDealer.Visibility = Visibility.Visible;
                this.BtnChooseDealer.IsEnabled = true;
                this.lblDrawCard.Visibility = Visibility.Hidden;
                //// display player's hand

                switch (this.UnoGame.PlayerTurn)
                {
                    case 1:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 2:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 3:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player3.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 4:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player4.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 5:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player5.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
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
            else if (this.gameMode == Mode.SixPlayers)
            {
                this.UnoGame.InGame = true;
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.UnoGame.Player5.PlayerHand.Clear();
                this.UnoGame.Player6.PlayerHand.Clear();
                this.UnoGame.DealCards(this.gameMode);
                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgMainPile);
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
                this.CompX = 70;
                this.X = 70;
                this.imgMainPile.Visibility = Visibility.Visible;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.BtnChooseDealer.Visibility = Visibility.Visible;
                this.BtnChooseDealer.IsEnabled = true;
                this.lblDrawCard.Visibility = Visibility.Hidden;
                //// display player's hand

                switch (this.UnoGame.PlayerTurn)
                {
                    case 1:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 2:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 3:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player3.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 4:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player4.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 5:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player5.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 6:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player6.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
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
            else if (this.gameMode == Mode.SevenPlayers)
            {
                this.UnoGame.InGame = true;
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.UnoGame.Player5.PlayerHand.Clear();
                this.UnoGame.Player6.PlayerHand.Clear();
                this.UnoGame.Player7.PlayerHand.Clear();
                this.UnoGame.DealCards(this.gameMode);
                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgMainPile);
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
                this.CompX = 70;
                this.X = 70;
                this.imgMainPile.Visibility = Visibility.Visible;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.BtnChooseDealer.Visibility = Visibility.Visible;
                this.BtnChooseDealer.IsEnabled = true;
                this.lblDrawCard.Visibility = Visibility.Hidden;
                //// display player's hand

                switch (this.UnoGame.PlayerTurn)
                {
                    case 1:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 2:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 3:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player3.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 4:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player4.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 5:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player5.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 6:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player6.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 7:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player7.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
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
            else if (this.gameMode == Mode.EightPlayers)
            {
                this.UnoGame.InGame = true;
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.UnoGame.Player5.PlayerHand.Clear();
                this.UnoGame.Player6.PlayerHand.Clear();
                this.UnoGame.Player7.PlayerHand.Clear();
                this.UnoGame.Player8.PlayerHand.Clear();
                this.UnoGame.DealCards(this.gameMode);
                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgMainPile);
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
                this.CompX = 70;
                this.X = 70;
                this.imgMainPile.Visibility = Visibility.Visible;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.BtnChooseDealer.Visibility = Visibility.Visible;
                this.BtnChooseDealer.IsEnabled = true;
                this.lblDrawCard.Visibility = Visibility.Hidden;
                //// display player's hand

                switch (this.UnoGame.PlayerTurn)
                {
                    case 1:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 2:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 3:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player3.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 4:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player4.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 5:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player5.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 6:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player6.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 7:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player7.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 8:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player8.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
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
            else if (this.gameMode == Mode.NinePlayers)
            {
                this.UnoGame.InGame = true;
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.UnoGame.Player5.PlayerHand.Clear();
                this.UnoGame.Player6.PlayerHand.Clear();
                this.UnoGame.Player7.PlayerHand.Clear();
                this.UnoGame.Player8.PlayerHand.Clear();
                this.UnoGame.Player9.PlayerHand.Clear();
                this.UnoGame.DealCards(this.gameMode);
                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgMainPile);
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
                this.CompX = 70;
                this.X = 70;
                this.imgMainPile.Visibility = Visibility.Visible;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.BtnChooseDealer.Visibility = Visibility.Visible;
                this.BtnChooseDealer.IsEnabled = true;
                this.lblDrawCard.Visibility = Visibility.Hidden;
                //// display player's hand

                switch (this.UnoGame.PlayerTurn)
                {
                    case 1:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 2:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 3:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player3.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 4:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player4.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 5:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player5.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 6:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player6.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 7:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player7.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 8:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player8.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 9:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player9.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
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
            else if (this.gameMode == Mode.TenPlayers)
            {
                this.UnoGame.InGame = true;
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Clockwise = true;
                this.UnoGame.GameDeck.SetUpDeck();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.UnoGame.Player5.PlayerHand.Clear();
                this.UnoGame.Player6.PlayerHand.Clear();
                this.UnoGame.Player7.PlayerHand.Clear();
                this.UnoGame.Player8.PlayerHand.Clear();
                this.UnoGame.Player9.PlayerHand.Clear();
                this.UnoGame.Player10.PlayerHand.Clear();
                this.UnoGame.DealCards(this.gameMode);
                this.grdMainWindow.Children.Clear();
                this.grdMainWindow.Children.Add(this.imgMainPile);
                this.grdMainWindow.Children.Add(this.imgDeckPile);
                this.grdMainWindow.Children.Add(this.BtnChooseDealer);
                this.grdMainWindow.Children.Add(this.BtnClose);
                this.grdMainWindow.Children.Add(this.NextPlayerButton);
                this.grdMainWindow.Children.Add(this.lblPlayer);
                this.CompX = 70;
                this.X = 70;
                this.imgMainPile.Visibility = Visibility.Visible;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.BtnChooseDealer.Visibility = Visibility.Visible;
                this.BtnChooseDealer.IsEnabled = true;
                this.lblDrawCard.Visibility = Visibility.Hidden;
                //// display player's hand

                switch (this.UnoGame.PlayerTurn)
                {
                    case 1:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 2:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player1.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 3:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player3.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 4:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player4.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 5:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player5.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 6:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player6.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 7:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player7.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 8:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player8.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 9:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player9.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
                    case 10:
                        //// display player's hand
                        foreach (Card crd in this.UnoGame.Player10.PlayerHand)
                        {
                            this.CreateViewImageDynamically(crd.MyImagePath);
                        }
                        foreach (Card crd in this.UnoGame.Player2.PlayerHand)
                        {
                            this.RebindComputerCards();
                            this.CompX += 70;
                        }
                        break;
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
        }

        /// <summary>
        /// If a user cannot play a card after drawing, 
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private async void NextPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.UnoGame.InGame)
            {
                this.BtnChooseDealer.IsEnabled = false;
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

                        Card checkAgain = this.UnoGame.CheckCompHand(this.UnoGame.Player2.PlayerHand);

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

                                //// used to determine how many images have been already removed
                                int count = 0;

                                //// used to determine index in grid
                                int currentIndex = 0;
                                if (!this.UnoGame.Clockwise)
                                {
                                    while (count < this.UnoGame.Player1.PlayerHand.Count)
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

                                        //// checks to see if the element is of an image
                                        if (element.GetType().Equals(typeof(Image)))
                                        {
                                            Image image = element as Image;
                                            if ((int)image.Margin.Top == 250)
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

                                //// used to determine how many images have been already removed
                                int count = 0;

                                //// used to determine index in grid
                                int currentIndex = 0;

                                while (count < this.UnoGame.Player1.PlayerHand.Count)
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
                            if (this.gameMode == Mode.ThreePlayers)
                            {
                                if (!this.UnoGame.Clockwise)
                                {
                                    if (findCard.MyType == Card.Type.Reverse)
                                    {
                                        this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
                                    }

                                    this.UnoGame.PlayerTurn = 3;
                                    ////this.imgDeckPile.IsEnabled = true;
                                }
                                else
                                {
                                    if (findCard.MyType == Card.Type.Reverse)
                                    {
                                        this.UnoGame.Clockwise = !this.UnoGame.Clockwise;
                                    }

                                    this.UnoGame.PlayerTurn = 1;
                                    ////this.imgDeckPile.IsEnabled = true;
                                }
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 2;
                                ////this.imgDeckPile.IsEnabled = false;
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
                    }
                }

                this.DisplayPlayerTurn();
                if (this.UnoGame.Player2.PlayerHand.Count == 0)
                {
                    MessageBox.Show("Game over. Computer won");
                    ////this.imgDeckPile.IsEnabled = false;
                    this.UnoGame.PlayerTurn = 0;
                }

                this.BtnChooseDealer.IsEnabled = true;
            }
            else
            {
                if (this.UnoGame.PlayerTurn == 2)
                {
                    Card card2 = null;
                    bool isFalse = false;
                    while (!isFalse)
                    {
                        await Task.Delay(1000);
                        this.UnoGame.DrawCard(this.UnoGame.Player2);
                        card2 = this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateComputerDrawCard(card2.MyImagePath);
                        if (card2.MyType == Card.Type.Number)
                        {
                            isFalse = true;
                        }
                    }

                    if (this.playerCount > 2)
                    {
                        this.lblDrawCard.Visibility = Visibility.Visible;
                        this.lblDrawCard.Content = "Player 3, draw a card.";
                        this.UnoGame.PlayerTurn = 3;
                        this.DisplayPlayerTurn();
                    }
                    else
                    {
                        if (card2.MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber)
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
                if (this.UnoGame.PlayerTurn == 1 && !this.UnoGame.CheckUserHand(this.UnoGame.Player1.PlayerHand))
                {
                    this.UnoGame.DrawCard(this.UnoGame.Player1);
                    Card card = this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1];
                    this.CreateViewImageDynamically(card.MyImagePath);
                    ////this.imgDeckPile.IsEnabled = false;
                    if (!this.UnoGame.CheckUserHand(this.UnoGame.Player1.PlayerHand))
                    {
                        if (this.UnoGame.Clockwise)
                        {
                            this.UnoGame.PlayerTurn = 2;
                            this.NextPlayerButton_Click(sender, e);
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = playerCount;
                            if (this.playerCount == 2)
                            {
                                this.NextPlayerButton_Click(sender, e);
                            }
                        }
                    }
                }
                else if (this.UnoGame.PlayerTurn == 3 && !this.UnoGame.CheckUserHand(this.UnoGame.Player3.PlayerHand))
                {
                    this.UnoGame.DrawCard(this.UnoGame.Player3);
                    Card card = this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1];
                    ////this.imgDeckPile.IsEnabled = false;
                    if (!this.UnoGame.CheckUserHand(this.UnoGame.Player3.PlayerHand))
                    {
                        if (this.UnoGame.Clockwise)
                        {
                            if (this.playerCount > 3)
                            {
                                this.UnoGame.PlayerTurn = 4;
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 1;
                            }
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 2;
                            this.NextPlayerButton_Click(sender, e);
                        }
                    }
                }
                else if (this.UnoGame.PlayerTurn == 4 && !this.UnoGame.CheckUserHand(this.UnoGame.Player4.PlayerHand))
                {
                    this.UnoGame.DrawCard(this.UnoGame.Player4);
                    Card card = this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1];
                    ////this.imgDeckPile.IsEnabled = false;
                    if (!this.UnoGame.CheckUserHand(this.UnoGame.Player4.PlayerHand))
                    {
                        if (this.UnoGame.Clockwise)
                        {
                            if (this.playerCount > 4)
                            {
                                this.UnoGame.PlayerTurn = 5;
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 1;
                            }
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 3;
                        }
                    }
                }
                else if (this.UnoGame.PlayerTurn == 5 && !this.UnoGame.CheckUserHand(this.UnoGame.Player5.PlayerHand))
                {
                    this.UnoGame.DrawCard(this.UnoGame.Player5);
                    Card card = this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1];
                    ////this.imgDeckPile.IsEnabled = false;
                    if (!this.UnoGame.CheckUserHand(this.UnoGame.Player5.PlayerHand))
                    {
                        if (this.UnoGame.Clockwise)
                        {
                            if (this.playerCount > 5)
                            {
                                this.UnoGame.PlayerTurn = 6;
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 1;
                            }
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 4;
                        }
                    }
                }
                else if (this.UnoGame.PlayerTurn == 6 && !this.UnoGame.CheckUserHand(this.UnoGame.Player6.PlayerHand))
                {
                    this.UnoGame.DrawCard(this.UnoGame.Player6);
                    Card card = this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1];
                    ////this.imgDeckPile.IsEnabled = false;
                    if (!this.UnoGame.CheckUserHand(this.UnoGame.Player6.PlayerHand))
                    {
                        if (this.UnoGame.Clockwise)
                        {
                            if (this.playerCount > 6)
                            {
                                this.UnoGame.PlayerTurn = 7;
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 1;
                            }
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 5;
                        }
                    }
                }
                else if (this.UnoGame.PlayerTurn == 7 && !this.UnoGame.CheckUserHand(this.UnoGame.Player7.PlayerHand))
                {
                    this.UnoGame.DrawCard(this.UnoGame.Player7);
                    Card card = this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1];
                    ////this.imgDeckPile.IsEnabled = false;
                    if (!this.UnoGame.CheckUserHand(this.UnoGame.Player7.PlayerHand))
                    {
                        if (this.UnoGame.Clockwise)
                        {
                            if (this.playerCount > 7)
                            {
                                this.UnoGame.PlayerTurn = 8;
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 1;
                            }
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 6;
                        }
                    }
                }
                else if (this.UnoGame.PlayerTurn == 8 && !this.UnoGame.CheckUserHand(this.UnoGame.Player8.PlayerHand))
                {
                    this.UnoGame.DrawCard(this.UnoGame.Player8);
                    Card card = this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1];
                    ////this.imgDeckPile.IsEnabled = false;
                    if (!this.UnoGame.CheckUserHand(this.UnoGame.Player8.PlayerHand))
                    {
                        if (this.UnoGame.Clockwise)
                        {
                            if (this.playerCount > 8)
                            {
                                this.UnoGame.PlayerTurn = 9;
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 1;
                            }
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 7;
                        }
                    }
                }
                else if (this.UnoGame.PlayerTurn == 9 && !this.UnoGame.CheckUserHand(this.UnoGame.Player9.PlayerHand))
                {
                    this.UnoGame.DrawCard(this.UnoGame.Player9);
                    Card card = this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1];
                    ////this.imgDeckPile.IsEnabled = false;
                    if (!this.UnoGame.CheckUserHand(this.UnoGame.Player9.PlayerHand))
                    {
                        if (this.UnoGame.Clockwise)
                        {
                            if (this.playerCount > 9)
                            {
                                this.UnoGame.PlayerTurn = 10;
                            }
                            else
                            {
                                this.UnoGame.PlayerTurn = 1;
                            }
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 8;
                        }
                    }
                }
                else if (this.UnoGame.PlayerTurn == 10 && !this.UnoGame.CheckUserHand(this.UnoGame.Player10.PlayerHand))
                {
                    this.UnoGame.DrawCard(this.UnoGame.Player10);
                    Card card = this.UnoGame.Player10.PlayerHand[this.UnoGame.Player10.PlayerHand.Count - 1];
                    ////this.imgDeckPile.IsEnabled = false;
                    if (!this.UnoGame.CheckUserHand(this.UnoGame.Player10.PlayerHand))
                    {
                        if (this.UnoGame.Clockwise)
                        {
                            this.UnoGame.PlayerTurn = 1;
                        }
                        else
                        {
                            this.UnoGame.PlayerTurn = 9;
                        }
                    }
                }

                this.DisplayPlayerTurn();
                Console.WriteLine(this.UnoGame.CurrentDeck.Count);
            }
            else
            {
                this.lblDrawCard.Visibility = Visibility.Hidden;
                this.imgDeckPile.IsEnabled = false;
                bool isNumber = false;
                if (this.UnoGame.PlayerTurn == 1)
                {
                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player1);
                        Card card1 = this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card1.MyImagePath);
                        if (card1.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    this.UnoGame.PlayerTurn = 2;
                    this.DisplayPlayerTurn();
                    await Task.Delay(500);
                    this.NextPlayerButton_Click(sender, e);
                }
                else if (this.gameMode == Mode.ThreePlayers && this.UnoGame.PlayerTurn == 3)
                {
                    isNumber = false;
                    Card card3 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player3);
                        card3 = this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card3.MyImagePath);
                        if (card3.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    if (card3.MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && card3.MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 1;
                        MessageBox.Show("Player 3 is the dealer, so Player 1 begins play.");
                    }
                    else if (this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= card3.MyNumber)
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
                else if (playerCount > 3 && this.UnoGame.PlayerTurn == 3)
                {
                    isNumber = false;
                    Card card3 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player3);
                        card3 = this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card3.MyImagePath);
                        if (card3.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    this.lblDrawCard.Visibility = Visibility.Visible;
                    this.lblDrawCard.Content = "Player 4, draw a card.";
                    this.UnoGame.PlayerTurn = 4;
                    this.DisplayPlayerTurn();
                    await Task.Delay(500);
                }
                else if (this.gameMode == Mode.FourPlayers && this.UnoGame.PlayerTurn == 4)
                {
                    isNumber = false;
                    Card card4 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player4);
                        card4 = this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card4.MyImagePath);
                        if (card4.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    if (card4.MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && card4.MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && card4.MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 1;
                        MessageBox.Show("Player 4 is the dealer, so Player 1 begins play.");
                    }
                    else if (this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= card4.MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 4;
                        MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                    }
                    else if (this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= card4.MyNumber)
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
                else if (playerCount > 4 && this.UnoGame.PlayerTurn == 4)
                {
                    isNumber = false;
                    Card card4 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player4);
                        card4 = this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card4.MyImagePath);
                        if (card4.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    this.lblDrawCard.Visibility = Visibility.Visible;
                    this.lblDrawCard.Content = "Player 5, draw a card.";
                    this.UnoGame.PlayerTurn = 5;
                    this.DisplayPlayerTurn();
                    await Task.Delay(500);
                    this.NextPlayerButton_Click(sender, e);
                }
                else if (this.gameMode == Mode.FivePlayers && this.UnoGame.PlayerTurn == 5)
                {
                    isNumber = false;
                    Card card5 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player5);
                        card5 = this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card5.MyImagePath);
                        if (card5.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    if (card5.MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && card5.MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && card5.MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && card5.MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 1;
                        MessageBox.Show("Player 5 is the dealer, so Player 1 begins play.");
                    }
                    else if (this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= card5.MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 5;
                        MessageBox.Show("Player 4 is the dealer, so Player 5 begins play.");
                    }
                    else if (this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= card5.MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 4;
                        MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                    }
                    else if (this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= card5.MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber)
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
                else if (playerCount > 5 && this.UnoGame.PlayerTurn == 5)
                {
                    isNumber = false;
                    Card card5 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player5);
                        card5 = this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card5.MyImagePath);
                        if (card5.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    this.UnoGame.PlayerTurn = 6;
                    this.lblDrawCard.Visibility = Visibility.Visible;
                    this.lblDrawCard.Content = "Player 6, draw a card.";
                    this.DisplayPlayerTurn();
                    await Task.Delay(500);
                    this.NextPlayerButton_Click(sender, e);
                }
                else if (this.gameMode == Mode.SixPlayers && this.UnoGame.PlayerTurn == 6)
                {
                    isNumber = false;
                    Card card6 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player6);
                        card6 = this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card6.MyImagePath);
                        if (card6.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    if (card6.MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && card6.MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && card6.MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && card6.MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && card6.MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 1;
                        MessageBox.Show("Player 6 is the dealer, so Player 1 begins play.");
                    }
                    else if (this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= card6.MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 6;
                        MessageBox.Show("Player 5 is the dealer, so Player 6 begins play.");
                    }
                    else if (this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= card6.MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count-1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 5;
                        MessageBox.Show("Player 4 is the dealer, so Player 5 begins play.");
                    }
                    else if (this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= card6.MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 4;
                        MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                    }
                    else if (this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= card6.MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber)
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
                else if (playerCount > 6 && this.UnoGame.PlayerTurn == 6)
                {
                    isNumber = false;
                    Card card6 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player6);
                        card6 = this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card6.MyImagePath);
                        if (card6.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    this.UnoGame.PlayerTurn = 7;
                    this.lblDrawCard.Visibility = Visibility.Visible;
                    this.lblDrawCard.Content = "Player 7, draw a card.";
                    this.DisplayPlayerTurn();
                    await Task.Delay(500);
                    this.NextPlayerButton_Click(sender, e);
                }
                else if (this.gameMode == Mode.SevenPlayers && this.UnoGame.PlayerTurn == 7)
                {
                    isNumber = false;
                    Card card7 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player7);
                        card7 = this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card7.MyImagePath);
                        if (card7.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    if (card7.MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && card7.MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && card7.MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && card7.MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && card7.MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && card7.MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 1;
                        MessageBox.Show("Player 7 is the dealer, so Player 1 begins play.");
                    }
                    else if (this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber <= card7.MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 7;
                        MessageBox.Show("Player 6 is the dealer, so Player 7 begins play.");
                    }
                    else if (this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= card7.MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 6;
                        MessageBox.Show("Player 5 is the dealer, so Player 6 begins play.");
                    }
                    else if (this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= card7.MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 5;
                        MessageBox.Show("Player 4 is the dealer, so Player 5 begins play.");
                    }
                    else if (this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= card7.MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 4;
                        MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                    }
                    else if (this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= card7.MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber)
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
                else if (playerCount > 7 && this.UnoGame.PlayerTurn == 7)
                {
                    isNumber = false;
                    Card card7 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player7);
                        card7 = this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card7.MyImagePath);
                        if (card7.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    this.UnoGame.PlayerTurn = 8;
                    this.lblDrawCard.Visibility = Visibility.Visible;
                    this.lblDrawCard.Content = "Player 8, draw a card.";
                    this.DisplayPlayerTurn();
                    await Task.Delay(500);
                    this.NextPlayerButton_Click(sender, e);
                }
                else if (this.gameMode == Mode.EightPlayers && this.UnoGame.PlayerTurn == 8)
                {
                    isNumber = false;
                    Card card8 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player8);
                        card8 = this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card8.MyImagePath);
                        if (card8.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    if (card8.MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 1;
                        MessageBox.Show("Player 8 is the dealer, so Player 1 begins play.");
                    }
                    else if (this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 8;
                        MessageBox.Show("Player 7 is the dealer, so Player 8 begins play.");
                    }
                    else if (this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 7;
                        MessageBox.Show("Player 6 is the dealer, so Player 7 begins play.");
                    }
                    else if (this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 6;
                        MessageBox.Show("Player 5 is the dealer, so Player 6 begins play.");
                    }
                    else if (this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 5;
                        MessageBox.Show("Player 4 is the dealer, so Player 5 begins play.");
                    }
                    else if (this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 4;
                        MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                    }
                    else if (this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber)
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
                else if (playerCount > 8 && this.UnoGame.PlayerTurn == 8)
                {
                    isNumber = false;
                    Card card8 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player8);
                        card8 = this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card8.MyImagePath);
                        if (card8.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    this.UnoGame.PlayerTurn = 9;
                    this.lblDrawCard.Visibility = Visibility.Visible;
                    this.lblDrawCard.Content = "Player 9, draw a card.";
                    this.DisplayPlayerTurn();
                    await Task.Delay(500);
                    this.NextPlayerButton_Click(sender, e);
                }
                else if (this.gameMode == Mode.NinePlayers && this.UnoGame.PlayerTurn == 9)
                {
                    isNumber = false;
                    Card card8 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player9);
                        card8 = this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card8.MyImagePath);
                        if (card8.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    if (card8.MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 1;
                        MessageBox.Show("Player 9 is the dealer, so Player 1 begins play.");
                    }
                    else if (this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 9;
                        MessageBox.Show("Player 8 is the dealer, so Player 9 begins play.");
                    }
                    else if (this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 8;
                        MessageBox.Show("Player 7 is the dealer, so Player 8 begins play.");
                    }
                    else if (this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 7;
                        MessageBox.Show("Player 6 is the dealer, so Player 7 begins play.");
                    }
                    else if (this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 6;
                        MessageBox.Show("Player 5 is the dealer, so Player 6 begins play.");
                    }
                    else if (this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 5;
                        MessageBox.Show("Player 4 is the dealer, so Player 5 begins play.");
                    }
                    else if (this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 4;
                        MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                    }
                    else if (this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber)
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
                else if (playerCount > 9 && this.UnoGame.PlayerTurn == 9)
                {
                    isNumber = false;
                    Card card9 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player9);
                        card9 = this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card9.MyImagePath);
                        if (card9.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    this.lblDrawCard.Visibility = Visibility.Visible;
                    this.lblDrawCard.Content = "Player 10, draw a card.";
                    this.UnoGame.PlayerTurn = 10;
                    this.DisplayPlayerTurn();
                    await Task.Delay(500);
                    this.NextPlayerButton_Click(sender, e);
                }
                else if (this.gameMode == Mode.TenPlayers && this.UnoGame.PlayerTurn == 10)
                {
                    isNumber = false;
                    Card card8 = null;

                    while (!isNumber)
                    {
                        this.UnoGame.DrawCard(this.UnoGame.Player10);
                        card8 = this.UnoGame.Player10.PlayerHand[this.UnoGame.Player10.PlayerHand.Count - 1];
                        this.X = 70;
                        this.CreateViewImageDynamically(card8.MyImagePath);
                        if (card8.MyType == Card.Type.Number)
                        {
                            isNumber = true;
                        }
                    }

                    if (card8.MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber && card8.MyNumber < this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 1;
                        MessageBox.Show("Player 10 is the dealer, so Player 1 begins play.");
                    }
                    else if (this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 10;
                        MessageBox.Show("Player 9 is the dealer, so Player 10 begins play.");
                    }
                    else if (this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 9;
                        MessageBox.Show("Player 8 is the dealer, so Player 9 begins play.");
                    }
                    else if (this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 8;
                        MessageBox.Show("Player 7 is the dealer, so Player 8 begins play.");
                    }
                    else if (this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 7;
                        MessageBox.Show("Player 6 is the dealer, so Player 7 begins play.");
                    }
                    else if (this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 6;
                        MessageBox.Show("Player 5 is the dealer, so Player 6 begins play.");
                    }
                    else if (this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 5;
                        MessageBox.Show("Player 4 is the dealer, so Player 5 begins play.");
                    }
                    else if (this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber)
                    {
                        await Task.Delay(500);
                        this.UnoGame.PlayerTurn = 4;
                        MessageBox.Show("Player 3 is the dealer, so Player 4 begins play.");
                    }
                    else if (this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player1.PlayerHand[this.UnoGame.Player1.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player3.PlayerHand[this.UnoGame.Player3.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= card8.MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player4.PlayerHand[this.UnoGame.Player4.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player5.PlayerHand[this.UnoGame.Player5.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber < this.UnoGame.Player6.PlayerHand[this.UnoGame.Player6.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player7.PlayerHand[this.UnoGame.Player7.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player8.PlayerHand[this.UnoGame.Player8.PlayerHand.Count - 1].MyNumber && this.UnoGame.Player2.PlayerHand[this.UnoGame.Player2.PlayerHand.Count - 1].MyNumber <= this.UnoGame.Player9.PlayerHand[this.UnoGame.Player9.PlayerHand.Count - 1].MyNumber)
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
                this.UnoGame.Player1 = new Player();
                ////this.UnoGame.Player1.IsComputer = false;
                this.UnoGame.Player2 = new Player();
                ////this.UnoGame.Player2.IsComputer = true;
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.playerCount = 2;
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
                this.lblDrawCard.Visibility = Visibility.Visible;
                this.lblDrawCard.Content = "Player 1, draw a card.";
            }
            else if (this.gameMode == Mode.ThreePlayers)
            {
                this.UnoGame = new Gameflow();
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Player1 = new Player();
                this.UnoGame.Player2 = new Player();
                this.UnoGame.Player3 = new Player();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.playerCount = 3;
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
                this.X2 = 800;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.DisplayPlayerTurn();
                this.lblDrawCard.Visibility = Visibility.Visible;
                this.lblDrawCard.Content = "Player 1, draw a card.";
            }
            else if (this.gameMode == Mode.FourPlayers)
            {
                this.UnoGame = new Gameflow();
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Player1 = new Player();
                this.UnoGame.Player2 = new Player();
                this.UnoGame.Player3 = new Player();
                this.UnoGame.Player4 = new Player();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.playerCount = 4;
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
                this.X2 = 800;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.DisplayPlayerTurn();
                this.lblDrawCard.Visibility = Visibility.Visible;
                this.lblDrawCard.Content = "Player 1, draw a card.";
            }
            else if (this.gameMode == Mode.FivePlayers)
            {
                this.UnoGame = new Gameflow();
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Player1 = new Player();
                this.UnoGame.Player2 = new Player();
                this.UnoGame.Player3 = new Player();
                this.UnoGame.Player4 = new Player();
                this.UnoGame.Player5 = new Player();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.UnoGame.Player5.PlayerHand.Clear();
                this.playerCount = 5;
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
                this.X2 = 800;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.DisplayPlayerTurn();
                this.lblDrawCard.Visibility = Visibility.Visible;
                this.lblDrawCard.Content = "Player 1, draw a card.";
            }
            else if (this.gameMode == Mode.SixPlayers)
            {
                this.UnoGame = new Gameflow();
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Player1 = new Player();
                this.UnoGame.Player2 = new Player();
                this.UnoGame.Player3 = new Player();
                this.UnoGame.Player4 = new Player();
                this.UnoGame.Player5 = new Player();
                this.UnoGame.Player6 = new Player();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.UnoGame.Player5.PlayerHand.Clear();
                this.UnoGame.Player6.PlayerHand.Clear();
                this.playerCount = 6;
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
                this.X2 = 800;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.DisplayPlayerTurn();
                this.lblDrawCard.Visibility = Visibility.Visible;
                this.lblDrawCard.Content = "Player 1, draw a card.";
            }
            else if (this.gameMode == Mode.SevenPlayers)
            {
                this.UnoGame = new Gameflow();
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Player1 = new Player();
                this.UnoGame.Player2 = new Player();
                this.UnoGame.Player3 = new Player();
                this.UnoGame.Player4 = new Player();
                this.UnoGame.Player5 = new Player();
                this.UnoGame.Player6 = new Player();
                this.UnoGame.Player7 = new Player();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.UnoGame.Player5.PlayerHand.Clear();
                this.UnoGame.Player6.PlayerHand.Clear();
                this.UnoGame.Player7.PlayerHand.Clear();
                this.playerCount = 7;
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
                this.X2 = 800;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.DisplayPlayerTurn();
                this.lblDrawCard.Visibility = Visibility.Visible;
                this.lblDrawCard.Content = "Player 1, draw a card.";
            }
            else if (this.gameMode == Mode.EightPlayers)
            {
                this.UnoGame = new Gameflow();
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Player1 = new Player();
                this.UnoGame.Player2 = new Player();
                this.UnoGame.Player3 = new Player();
                this.UnoGame.Player4 = new Player();
                this.UnoGame.Player5 = new Player();
                this.UnoGame.Player6 = new Player();
                this.UnoGame.Player7 = new Player();
                this.UnoGame.Player8 = new Player();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.UnoGame.Player5.PlayerHand.Clear();
                this.UnoGame.Player6.PlayerHand.Clear();
                this.UnoGame.Player7.PlayerHand.Clear();
                this.UnoGame.Player8.PlayerHand.Clear();
                this.playerCount = 8;
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
                this.X2 = 800;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.DisplayPlayerTurn();
                this.lblDrawCard.Visibility = Visibility.Visible;
                this.lblDrawCard.Content = "Player 1, draw a card.";
            }
            else if (this.gameMode == Mode.NinePlayers)
            {
                this.UnoGame = new Gameflow();
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Player1 = new Player();
                this.UnoGame.Player2 = new Player();
                this.UnoGame.Player3 = new Player();
                this.UnoGame.Player4 = new Player();
                this.UnoGame.Player5 = new Player();
                this.UnoGame.Player6 = new Player();
                this.UnoGame.Player7 = new Player();
                this.UnoGame.Player8 = new Player();
                this.UnoGame.Player9 = new Player();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.UnoGame.Player5.PlayerHand.Clear();
                this.UnoGame.Player6.PlayerHand.Clear();
                this.UnoGame.Player7.PlayerHand.Clear();
                this.UnoGame.Player8.PlayerHand.Clear();
                this.UnoGame.Player9.PlayerHand.Clear();
                this.playerCount = 9;
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
                this.X2 = 800;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.DisplayPlayerTurn();
                this.lblDrawCard.Visibility = Visibility.Visible;
                this.lblDrawCard.Content = "Player 1, draw a card.";
            }
            else if (this.gameMode == Mode.TenPlayers)
            {
                this.UnoGame = new Gameflow();
                this.UnoGame.GameDeck = new DeckOfCards();
                this.UnoGame.Player1 = new Player();
                this.UnoGame.Player2 = new Player();
                this.UnoGame.Player3 = new Player();
                this.UnoGame.Player4 = new Player();
                this.UnoGame.Player5 = new Player();
                this.UnoGame.Player6 = new Player();
                this.UnoGame.Player7 = new Player();
                this.UnoGame.Player8 = new Player();
                this.UnoGame.Player9 = new Player();
                this.UnoGame.Player10 = new Player();
                this.UnoGame.Player1.PlayerHand.Clear();
                this.UnoGame.Player2.PlayerHand.Clear();
                this.UnoGame.Player3.PlayerHand.Clear();
                this.UnoGame.Player4.PlayerHand.Clear();
                this.UnoGame.Player5.PlayerHand.Clear();
                this.UnoGame.Player6.PlayerHand.Clear();
                this.UnoGame.Player7.PlayerHand.Clear();
                this.UnoGame.Player8.PlayerHand.Clear();
                this.UnoGame.Player9.PlayerHand.Clear();
                this.UnoGame.Player10.PlayerHand.Clear();
                this.playerCount = 10;
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
                this.X2 = 800;
                this.imgDeckPile.Visibility = Visibility.Visible;
                this.imgDeckPile.IsEnabled = true;
                this.DisplayPlayerTurn();
                this.lblDrawCard.Visibility = Visibility.Visible;
                this.lblDrawCard.Content = "Player 1, draw a card.";
            }
        }
    }
}
