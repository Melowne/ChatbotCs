using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChatBotCs
{
   public class Answers
    {
        private Dictionary<string, string>answersdic ;

        private List<string> rndanswers;
        public Answers() {
            answersdic = new Dictionary<string, string>()
        {{"schmeckt","ich habe keinen Geschmackssinn" },
            {"hallo","aber hallo" },
            {"so","wer so sagt hat heute noch nichts gemacht" } };

            rndanswers = new List<string>()
        {"das sehe ich ähnlich","das freut mich","absolutely","keines wegs","wochenende inc" };
        
        }

        public Dictionary<string, string> Answersdic { get => answersdic; set => answersdic = value; }
        public List<string> Rndanswers { get => rndanswers; set => rndanswers = value; }
    }
}
