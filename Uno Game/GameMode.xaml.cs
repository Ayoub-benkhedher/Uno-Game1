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
    /// Interaction logic for GameMode.xaml
    /// </summary>
    public partial class GameMode : Window
    {
        public GameMode()
        {
            InitializeComponent();
        }

        

        private void BtnTwoPlayer_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(Mode.TwoPlayers).ShowDialog();

        }

        private void BtnThreePlayers_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(Mode.ThreePlayers).ShowDialog();
        }
    }
}
