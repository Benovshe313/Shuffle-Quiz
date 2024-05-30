namespace Shuffle_Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] question1 = new string[]
           {
                "1. Capital of Austria is ...",
                "Vienna",
                "Bern",
                "Dublin"
           };

            string[] question2 = new string[]
            {
                "2. Select a European country:",
                "Malaysia",
                "Jordan",
                "Norway"
            };

            string[] question3 = new string[]
            {
                "3. Capital of Denmark is ...",
                "Stockholm",
                "Copenhagen",
                "Warsaw"
            };

            string[] question4 = new string[]
            {
                "4. Niagara waterfall in ...",
                "South America",
                "North America",
                "Africa"
            };

            string[] question5 = new string[]
            {
                "5. Capital of Germany is ...",
                "Budapest",
                "Berlin",
                "Tallinn"
            };

            string[] question6 = new string[]
            {
                "6. Red Square in ...",
                "India",
                "Japan",
                "Russia"
            };

            string[] question7 = new string[]
            {
                "7. Maiden Tower in ...",
                "Baku",
                "Shirvan",
                "Ganja"
            };

            string[] question8 = new string[]
            {
                "8. City in the United Arab Emirates:",
                "Amsterdam",
                "Barcelona",
                "Dubai"
            };

            string[] question9 = new string[]
            {
                "9. UK famous for:",
                "London Eye",
                "Eiffel Tower",
                "Old City"
            };

            string[] question10 = new string[]
            {
                "10. Flame Towers located in ...",
                "Kazakhstan",
                "Georgia",
                "Azerbaijan"
            };

            string[][] Questions = new string[][]
            {
                question1,
                question2,
                question3,
                question4,
                question5,
                question6,
                question7,
                question8,
                question9,
                question10
            };

            string[] Answers = new string[]
            {
                "Vienna",
                "Norway",
                "Copenhagen",
                "North America",
                "Berlin",
                "Russia",
                "Baku",
                "Dubai",
                "London Eye",
                "Azerbaijan"
            };

            Random variants = new Random();
            int score = 0;

            for (int a = 0; a < Questions.Length; a++)
            {
                var question = Questions[a];
                string[] options = new string[3];
                Array.Copy(question, 1, options, 0, 3);

                for (int i = 0; i < options.Length; i++)
                {
                    int j = variants.Next(i, options.Length);
                    string temp = options[i];
                    options[i] = options[j];
                    options[j] = temp;
                }

                Thread.Sleep(1000);
                Console.Clear();

                Console.WriteLine(question[0]);
                Console.WriteLine($"a. {options[0]}");
                Console.WriteLine($"b. {options[1]}");
                Console.WriteLine($"c. {options[2]}");
              
                string userAnswer = GetUserAnswer();

                if (userAnswer == "a") userAnswer = options[0];
                else if (userAnswer == "b") userAnswer = options[1];
                else if (userAnswer == "c") userAnswer = options[2];

                bool isCorrect = userAnswer == Answers[a];
                if (isCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    score += 10;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    score -= 10;
                }
                Console.Clear();

                if (isCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine(question[0]);
                Console.ResetColor();
                Console.WriteLine($"a. {options[0]}");
                Console.WriteLine($"b. {options[1]}");
                Console.WriteLine($"c. {options[2]}");
            }

            //if (score < 0)
            //{
            //    Console.WriteLine("Final Score: " + "0");
            //}
            //else
            //{
            //    Console.WriteLine("Final Score: " + score);
            //}

            Console.WriteLine("Final Score: " + (score < 0 ? "0" : score));

        }
        static string GetUserAnswer()
        {
            while (true)
            {
                Console.Write("Answer: ");
                string userInput = Console.ReadLine().Trim().ToLower();
                if (userInput == "a" || userInput == "b" || userInput == "c")
                {
                    return userInput;
                }
                Console.WriteLine("Invalid input");
            }
        }
    }
}
