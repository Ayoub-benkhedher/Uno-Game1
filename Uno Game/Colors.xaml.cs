//-----------------------------------------------------------------------
// <copyright file="Colors.xaml.cs" company="UNO">
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
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for Colors
    /// </summary>
    public partial class Colors : Window
    {
        /// <summary>
        /// Setting the variable c to represent card.
        /// </summary>
        private Card c;

        /// <summary>
        /// Initializes a new instance of the <see cref="Colors"/> class.
        /// </summary>
        /// <param name="checkCard">Checks the card that was played.</param>
        public Colors(Card checkCard)
        {
            this.InitializeComponent();

            this.c = checkCard;
        }

        /// <summary>
        /// Interaction logic for Colors
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void Img_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            string color = image.Name.ToString();

            //// MessageBox.Show(color);
            switch (color)
            {
                case "Red":
                    this.c.MyColor = Card.Color.Red;
                    break;
                case "Green":
                    this.c.MyColor = Card.Color.Green;
                    break;
                case "Blue":
                    this.c.MyColor = Card.Color.Blue;
                    break;
                case "Yellow":
                    this.c.MyColor = Card.Color.Yellow;
                    break;
            }

            this.Close();
        }
    }
}
