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

namespace Fifteen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> dices;
        public MainWindow()
        {
            InitializeComponent();

            ShakeDices();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int position = Convert.ToInt32((sender as Button).Tag);
            Button btnPlaceToMove = ButtonPlaceToMove(position);
            if (btnPlaceToMove != null)
            {

                (sender as Button).Visibility = Visibility.Hidden;

                string tempContent = btnPlaceToMove.Content.ToString();
                btnPlaceToMove.Visibility = Visibility.Visible;
                btnPlaceToMove.Content = (sender as Button).Content;
                (sender as Button).Content = 16;


                //Button temp = sender as Button;
                //sender = btnPlaceToMove;
                //btnPlaceToMove = temp;
            }
            if (IsEndGame())
            {
                //MessageBox.Show("Complete");
                WindowComplete wc = new WindowComplete();
                wc.ShowDialog();
            }
        }

        private int GetDice()
        {
            if (dices.Count == 0)
            {
                return 16;
            }

            Random rnd = new Random();
            int index = rnd.Next(0, dices.Count);

            int dice = dices[index];
            dices.Remove(dice);
            return dice;
        }

        private void ShakeDices()
        {
            dices = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            foreach (var item in grid.Children)
            {
                if (item is Menu)
                {
                    continue;
                }
                
                (item as Button).Content = GetDice();
                (item as Button).Visibility = Visibility.Visible;

                if ((item as Button).Content.Equals(16))
                {
                    (item as Button).Visibility = Visibility.Hidden;
                }
            }
        }
        private Button ButtonPlaceToMove(int position)
        {
            Button btn = GetButtonForPosition(position - 1);
            if (btn != null && !btn.Tag.Equals("4") && !btn.Tag.Equals("8") && !btn.Tag.Equals("12") && btn.Visibility == Visibility.Hidden)
            {
                return btn;
            }
            btn = GetButtonForPosition(position + 1);
            if (btn != null && !btn.Tag.Equals("5") && !btn.Tag.Equals("9") && !btn.Tag.Equals("13") && btn.Visibility == Visibility.Hidden)
            {
                return btn;
            }
            btn = GetButtonForPosition(position - 4);
            if (btn != null && btn.Visibility == Visibility.Hidden)
            {
                return btn;
            }
            btn = GetButtonForPosition(position + 4);
            if (btn != null && btn.Visibility == Visibility.Hidden)
            {
                return btn;
            }
            return null;
        }
        private Button GetButtonForPosition(int position)
        {
            switch (position)
            {
                case 1:
                    return button1;
                case 2:
                    return button2;
                case 3:
                    return button3;
                case 4:
                    return button4;
                case 5:
                    return button5;
                case 6:
                    return button6;
                case 7:
                    return button7;
                case 8:
                    return button8;
                case 9:
                    return button9;
                case 10:
                    return button10;
                case 11:
                    return button11;
                case 12:
                    return button12;
                case 13:
                    return button13;
                case 14:
                    return button14;
                case 15:
                    return button15;
                case 16:
                    return button16;
                defaut:
                    return null;
            }
            return null;
        }
        private bool IsEndGame()
        {
            foreach (var item in grid.Children)
            {
                if (item is Menu)
                {
                    continue;
                }
                if (!(item as Button).Content.ToString().Equals((item as Button).Tag))
                {
                    return false;
                }
            }
            return true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ShakeDices();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

     
    }
}
