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

namespace Game_Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHangman_Click(object sender, RoutedEventArgs e)
        {
            Game_Hangman.Theme  frm= new Game_Hangman.Theme();
            frm.ShowDialog();
            
        }

        private void btnUno_Click(object sender, RoutedEventArgs e)
        {
            Uno_Game.GameMode frm1 = new Uno_Game.GameMode();
            frm1.ShowDialog(); 
        }
    }
}
