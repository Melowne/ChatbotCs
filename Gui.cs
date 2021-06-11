using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace ChatBotCs
{
    class Gui
    {
        private Grid grid = new Grid();
        private Label botMsg = new Label();
        private TextBox userTxt = new TextBox();
        private Button apply = new Button();
        private Button bye = new Button();
        public Gui()
        {
            for (int i = 0; i < 4; i++)
            {
                RowDefinition r = new RowDefinition();
                
                Grid.RowDefinitions.Add(r);
            }
          
            Grid.RowDefinitions[0].Height =new GridLength(40);
            Label header = new Label();header.Content = "Chatbot Cs";
            header.Background = Brushes.Gray;header.HorizontalAlignment = HorizontalAlignment.Center;header.FontSize = 22;
            Grid.SetRow(header, 0);Grid.Children.Add(header);
            Grid.Background = Brushes.Gray;
            Grid.RowDefinitions[1].Height = new GridLength(140);
            botMsg.Background = Brushes.DarkGray;
            BotMsg.FontSize = 16;
            Grid.SetRow(botMsg, 1); Grid.Children.Add(BotMsg);

            Grid.RowDefinitions[2].Height = new GridLength(140);
            userTxt.Background = Brushes.LightGray;
            userTxt.FontSize = 16;
            Grid.SetRow(userTxt, 2); Grid.Children.Add(UserTxt);

            StackPanel buttons = new StackPanel();
            Apply.Content = "Abschicken";Bye.Content = "Abbrechen";
            buttons.Children.Add(Apply); buttons.Children.Add(Bye);
            buttons.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(buttons, 3);grid.Children.Add(buttons);
        }

        public Grid Grid { get => grid; set => grid = value; }
        public Label BotMsg { get => botMsg; set => botMsg = value; }
        public TextBox UserTxt { get => userTxt; set => userTxt = value; }
        public Button Apply { get => apply; set => apply = value; }
        public Button Bye { get => bye; set => bye = value; }
    }
}
