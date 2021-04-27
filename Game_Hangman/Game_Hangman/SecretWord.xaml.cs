//-----------------------------------------------------------------------
// <copyright file="SecretWord.xaml.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Game_Hangman
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
    /// Interaction logic for SecretWord.xaml
    /// </summary>
    public partial class SecretWord : Window
    {
        /// <summary>
        /// Player p object.
        /// </summary>
        private Player p;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecretWord"/> class.
        /// </summary>
        /// /// <param name="players">Not sure what to put here.</param>
        public SecretWord(Player players)
        {
            this.InitializeComponent(); 
            this.p = players; 
        }

        /// <summary>
        /// Enter Secret word to the system.
        /// </summary>
        /// <param name="sender">Not sure what to put here.</param>
        /// <param name="e">Not sure what this does.</param>
        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new MainWindow(ThemeMode.TwoPlayersMode, txtSecretWord.Text, this.p).ShowDialog();
        }
    }
}