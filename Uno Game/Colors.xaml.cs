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

namespace Uno_Game
{
    /// <summary>
    /// Interaction logic for Colors.xaml
    /// </summary>
    public partial class Colors : Window
    {
        Card c;
        public Colors(Card checkCard)
        {
            InitializeComponent();

            c = checkCard;
        }



        private void Img_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            string color = image.Name.ToString();

            //MessageBox.Show(color);
            switch (color)
            {
                case "Red":
                    c.MyColor = Card.Color.Red;
                    break;
                case "Green":
                    c.MyColor = Card.Color.Green;
                    break;
                case "Blue":
                    c.MyColor = Card.Color.Blue;
                    break;
                case "Yellow":
                    c.MyColor = Card.Color.Yellow;
                    break;

            }
            this.Close();
        }


    }
}
