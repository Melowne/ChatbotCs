using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ChatBotCs
{
    public class Bot
    {
        private Dictionary<string, string> answers = new Dictionary<string, string>();
        private List<string> randomanswers = new List<string>();
        //Answers ans =new Answers();
        public Bot(Answers ans)
        {
            answers = ans.Answersdic;
            randomanswers = ans.Rndanswers;
        }
        public string get_Response(string Usereingabe)
        {
            Usereingabe.ToLower(); string s = "";
            var words = Usereingabe.Split(); bool isthere = false;
            foreach (var item in words)
            {
                if (answers.Keys.Contains(item))
                {
                    isthere = true;
                    return answers[item];
                }
            }
            var ran = new Random();
            if (!isthere && Usereingabe != "bye") return randomanswers[ran.Next(randomanswers.Count())];
            else return "";
        }
    }
}