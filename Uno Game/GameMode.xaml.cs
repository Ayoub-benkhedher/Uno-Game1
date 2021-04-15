//-----------------------------------------------------------------------
// <copyright file="GameMode.xaml.cs" company="UNO">
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
    /// Interaction logic for GameMode
    /// </summary>
    public partial class GameMode : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameMode"/> class.
        /// </summary>
        public GameMode()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Shows that the current player is Player Two.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnTwoPlayer_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(Mode.TwoPlayers).ShowDialog();
        }

        /// <summary>
        /// Shows that the current player is Player Three.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnThreePlayers_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(Mode.ThreePlayers).ShowDialog();
        }

        /// <summary>
        /// Shows that the current player is Player Four.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnFourPlayers_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(Mode.FourPlayers).ShowDialog();
        }

        /// <summary>
        /// Shows that the current player is Player Five.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnFivePlayers_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(Mode.FivePlayers).ShowDialog();
        }

        /// <summary>
        /// Shows that the current player is Player Six.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnSixPlayers_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(Mode.SixPlayers).ShowDialog();
        }

        /// <summary>
        /// Shows that the current player is Player Seven.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnSevenPlayers_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(Mode.SevenPlayers).ShowDialog();
        }

        /// <summary>
        /// Shows that the current player is Player Eight.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnEightPlayers_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(Mode.EightPlayers).ShowDialog();
        }

        /// <summary>
        /// Shows that the current player is Player Nine.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnNinePlayers_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(Mode.NinePlayers).ShowDialog();
        }

        /// <summary>
        /// Shows that the current player is Player Ten.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnTenPlayers_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(Mode.TenPlayers).ShowDialog();
        }
    }
}
