//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Game_Interface
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Creates a hangman game
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnHangman_Click(object sender, RoutedEventArgs e)
        {
            Game_Hangman.Theme frm = new Game_Hangman.Theme();
            frm.ShowDialog();
        }

        /// <summary>
        /// Creates a Uno game
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnUno_Click(object sender, RoutedEventArgs e)
        {
            Uno_Game.GameMode frm1 = new Uno_Game.GameMode();
            frm1.ShowDialog(); 
        }
    }
}
