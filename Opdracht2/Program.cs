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
                new Question() { Category = "Science", Difficulty = 3, Text = "What is the name of our planet ? ", Answer = "Earth"},

                 new Question() {Difficulty = 2, Category = "Sport", Text = "Who is the fastest runner ever ? ",Answers = { "George Bush", "Usain Bolt", "Bill Gates", "LeBron James" },
                choicequestion = new ChoiceQuestion(){ CorrectAnswer = "Usain Bolt"}},
            new Question() { Difficulty = 2, Category = "Tech", Text = "Who founded Apple ? ",Answers = { "Steve Jobs","Kobe Bryant", "Steve Nash", "Leonardo da vinci" },
                choicequestion = new ChoiceQuestion(){ CorrectAnswer = "Steve Jobs"}},
            new Question() { Difficulty = 3, Category = "History", Text = "What is the age of the Earth ? ",Answers = { "2017","4.6 Billion Years", "40,000 years", "We Live in a simulation" },
                choicequestion = new ChoiceQuestion(){ CorrectAnswer = "4.6 Billion Years"}}
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

                                
                var category = questions.OrderBy(x => x.Category);
                program.Play(category);
            }
            else
            {
                Console.WriteLine("This choice is not possible");
            }

            Console.WriteLine("Quiz 2 Select one of the two");
            String choice2 = Console.ReadLine();

            if (choice2 == "1")
            {
                Console.WriteLine("Choose difficulty: 1, 2 or 3");
                String DiffChoice = Console.ReadLine();
                int asd = Int32.Parse(DiffChoice);
                IEnumerable<Question> result = questions.Where(x => x.Difficulty==asd);
                program.Play(result);
            }
            else if(choice2 == "2")
            {
                Console.WriteLine("Choose Category: Sport, Science, History, Tech");
                String CatChoice = Console.ReadLine();
                IEnumerable<Question> result = questions.Where(x => x.Category == CatChoice);
                program.Play(result);
            }

            Console.ReadKey();

           

        }

        public void Play(IEnumerable<Question> results)
        {
            int score = 0;
            string failed = "";
            foreach (var z in results)
            {
                if (z.choicequestion != null)
                {
                    Console.WriteLine(z.Text);
                    z.GetChoiceQuestions();
                    var answer = Console.ReadLine();
                    int input = Int32.Parse(answer);

                    Console.WriteLine(z.checkChoiceAnswer(input));
                    if (z.checkChoiceAnswer(input) == true)
                    {
                        score++;
                    }

                }
                else
                {
                    z.Display();
                    String userAnswer = Console.ReadLine();
                    Console.WriteLine(z.checkAnswer(userAnswer));
                    if (z.checkAnswer(userAnswer))
                    {
                        score++;
                    }
                    else
                    {
                        failed += "\n" + z.Text;
                    }
                }
            }
                Console.WriteLine("Your Score is: " + score.ToString());
                Console.WriteLine("\n");
                Console.WriteLine("These were your wrong questions: " + failed);            
        }


    }
}
