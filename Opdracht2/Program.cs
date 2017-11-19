using System;
using System.Collections.Generic;
using System.Linq;

namespace Opdracht2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();


            IList<Question> questions = new List<Question>()
            {
                new Question() { Category = "History", Difficulty = 2, Text = "In which year did the first World War Start ?", Answer = "1914"},
                new Question() { Category = "Sport", Difficulty = 1, Text = "What does the NBA stand for ?", Answer = "National Basketball Association"},
                new Question() { Category = "Science", Difficulty = 3, Text = "When was the Hubble Space Telescope launched into space ?", Answer = "1990"},
                new Question() { Category = "Sport", Difficulty = 1, Text = "How are teams participate in the NBA? ", Answer = "30"},
                new Question() { Category = "Tech", Difficulty = 2, Text = "Who is the founder of Tesla Motors? ", Answer = "Elon Musk"},
                new Question() { Category = "Tech", Difficulty = 2, Text = "What does MB mean? ", Answer = "Megabyte"},
                new Question() { Category = "Sport", Difficulty = 1, Text = "How many basketball teams are located in Los Angeles that play in the NBA? ", Answer = "2"},
                new Question() { Category = "History", Difficulty = 2, Text = "In what year was the UN founded ? ", Answer = "1945"},
                new Question() { Category = "Science", Difficulty = 3, Text = " ", Answer = "Elon Musk"}
            };
            
            Console.WriteLine("Do you want to play based on difficulty or category ? \nfor Difficulty press 1, for Category press 2");
            String inp = Console.ReadLine();

            if (inp == "1")
            {
                var order = questions.OrderBy(x => x.Difficulty);

                program.Play(order);
            }
            else if (inp == "2")
            {
                Console.WriteLine("Choose a following Category: History, Science, Sport, Tech");
                String Choice = Console.ReadLine();
                                
                var category = questions.Where(x => x.Category == Choice);
                program.Play(category);
            }
            else
            {
                Console.WriteLine("This choice is not possible");
            }
           
            Console.ReadKey();
        }

        public void Play(IEnumerable<Question> results)
        {
            int score = 0;
            string failed = "";
            foreach (var z in results)
            {
                z.Display();
                String userAnswer = Console.ReadLine();
                Console.WriteLine(z.checkAnswer(userAnswer));
                if (z.checkAnswer(userAnswer) == true)
                {
                    score++;
                }
                else
                {
                    failed += "\n" + z.Text;
                }
            }
                Console.WriteLine("Your Score is: " + score.ToString());
                Console.WriteLine("\n");
                Console.WriteLine("These were your wrong questions: " + failed);
            
        }

    }
}
