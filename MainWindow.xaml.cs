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
using System.Windows.Threading;
using Newtonsoft.Json;
using System.IO;
namespace ChatBotCs
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Gui gui = new Gui();
        Bot bot;
        
        public void botintro() {
            gui.BotMsg.Content = "Wilkommen !\nStellen sie eine Frage und zwar pronto.... ";
        }
        public MainWindow()
        {
            // erstellt json file vom answersobjekt im lokalen repo  mit zuffallsantworten und keyantworten
            StreamWriter sw= new StreamWriter(Environment.CurrentDirectory + @"\botassets\botMessages.json");
            Answers answ = new Answers();
            sw.WriteLine(JsonConvert.SerializeObject(answ));sw.Close();
            //deserialisiert json file aus lokalen repo wieder zurück in answers objekt
            bot = new Bot(JsonConvert.DeserializeObject<Answers>(File.ReadAllText(Environment.CurrentDirectory + @"\botassets\botMessages.json"))); 

            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 6);
            gui.Apply.Click += Apply_Click;
            gui.Bye.Click += Bye_Click;
            gui.UserTxt.KeyDown += UserTxt_KeyDown;
            this.AddChild(gui.Grid);
            
            botintro();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            botintro();
        }

        private void UserTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                timer.Stop(); timer.Start();
                if (gui.UserTxt.Text == "bye") this.Close();
                if (gui.UserTxt.Text == "")
                {
                    gui.BotMsg.Content = "Stellen sie eine richtige Frage";

                }
                else
                {
                    gui.BotMsg.Content = bot.get_Response(gui.UserTxt.Text);
                    gui.UserTxt.Text = "";
                }
            }
            else if (e.Key == Key.Escape) this.Close();
        }

        private void Bye_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {

            timer.Stop(); timer.Start();
            if (gui.UserTxt.Text == "bye") this.Close();
            if (gui.UserTxt.Text == "")
            {
                botintro();            }
            else
            {
                gui.BotMsg.Content = bot.get_Response(gui.UserTxt.Text);
                gui.UserTxt.Text = "";
            }
        }
    }
}
