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
            cboSelectionMode.Visibility = Visibility.Hidden;
            lblPick.Visibility = Visibility.Hidden;

        }

        /// <summary>
        /// Shows that the current player is Player Two.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnTwoPlayer_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(Mode.TwoPlayers, 2).ShowDialog();
        }

        /// <summary>
        /// Shows that the current player is Player Three.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void BtnMultiplePlayers_Click(object sender, RoutedEventArgs e)
        {
            cboSelectionMode.Visibility = Visibility.Visible;
            lblPick.Visibility = Visibility.Visible;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            new MainWindow(Mode.MultiplePlayers, cboSelectionMode.SelectedIndex + 3).ShowDialog();
        }
    }
}
