using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht2
{
    public class Question
    {
        public int Difficulty { get; set; }
        public string Category { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public ChoiceQuestion choicequestion { get; set; }
        public List<String> Answers = new List<String>();

        public Boolean checkAnswer(String repsonse)
        {
            if(String.Compare(repsonse, Answer) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public void Display()
        {
            Console.Write(Text);
        }

        public Boolean checkChoiceAnswer(int getal)
        {

            int Antwoord = Answers.IndexOf(CorrecteAntwoord());

            if (getal == Antwoord)
            {
                return true;
            }

            else return false;


        }

        public void GetChoiceQuestions()
        {
            foreach (var i in Answers)
            {
                Console.WriteLine(Answers.IndexOf(i) + " " + i);

            }
        }
   
        public String CorrecteAntwoord()
        {
            return choicequestion.CorrectAnswer;
        }

    }
}
