using System;
using System.Windows;
using System.Windows.Controls;

namespace пр_1._24
{
    public partial class MainWindow : Window
    {
        Random random = new Random();
        Button[,] buttons;
        private bool isPlayerXTurn = false;

        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[3, 3];
            buttons[0, 0] = _1;
            buttons[0, 1] = _2;
            buttons[0, 2] = _3;
            buttons[1, 0] = _4;
            buttons[1, 1] = _5;
            buttons[1, 2] = _6;
            buttons[2, 0] = _7;
            buttons[2, 1] = _8;
            buttons[2, 2] = _9;
        }

        private void NewGameBut_Click(object sender, RoutedEventArgs e)
        {
            InitializeGame();
            isPlayerXTurn = !isPlayerXTurn;

        }

        private void InitializeGame()
        {
            Notice.Text = "";
            foreach (var button in buttons)
            {
                
                button.Content = "";
                button.IsEnabled = true;
            }
        }

        private void _1_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (button.Content.ToString() == "")
            {

                button.Content = isPlayerXTurn ? "X" : "O";
                button.IsEnabled = false;

                if (CheckForWinner(isPlayerXTurn ? "X" : "O"))
                {
                    Notice.Text = "Выиграли " + (isPlayerXTurn ? "крестики" : "нолики") + "!";

                    foreach (var button1 in buttons)
                    {
                        button1.IsEnabled = false;
                    }
                    return;
                }
                else if (CheckForDraw())
                {
                    Notice.Text = "Ничья!!!";
                    foreach (var button2 in buttons)
                    {
                        button2.IsEnabled = false;
                    }
                    return;
                }
                else AI();
 
            }
        }

        private bool CheckForWinner(string player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Content.ToString() == player && buttons[i, 1].Content.ToString() == player &&
                    buttons[i, 2].Content.ToString() == player)
                    return true;

                if (buttons[0, i].Content.ToString() == player && buttons[1, i].Content.ToString() == player &&
                    buttons[2, i].Content.ToString() == player)
                    return true;
            }

            if ((buttons[0, 0].Content.ToString() == player && buttons[1, 1].Content.ToString() == player &&
                 buttons[2, 2].Content.ToString() == player) ||
                (buttons[2, 0].Content.ToString() == player && buttons[1, 1].Content.ToString() == player &&
                 buttons[0, 2].Content.ToString() == player))
                return true;

            return false;
        }

        private bool CheckForDraw()
        {
            foreach (var button in buttons)
            {
                if (button.Content.ToString() == "")
                {
                    return false;
                }
            }
            return true;
        }

        void AI()
        {
            int choice, choices;
            do
            {
                choice = random.Next(0, 3);
                choices = random.Next(0, 3);
            } while (buttons[choice, choices].Content.ToString() != "");

            buttons[choice, choices].Content = isPlayerXTurn ? "O" : "X";
            buttons[choice, choices].IsEnabled = false;

            if (CheckForWinner(isPlayerXTurn ? "O" : "X"))
            {
                Notice.Text = "Выиграли " + (isPlayerXTurn ? "нолики" : "крестики") + "!";
                foreach (var button in buttons)
                {
                    button.IsEnabled = false;
                }
                return;
            }
            else if (CheckForDraw())
            {
                foreach (var button in buttons)
                {
                    button.IsEnabled = false;
                }
                Notice.Text = "Ничья!!!";

            }
        }
    }
}