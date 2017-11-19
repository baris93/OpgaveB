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

        

    }
}
