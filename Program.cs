using System.Globalization;

namespace Hangman;

class Program
{
    static void Main(string[] args)
    {
        const int MAX_GUESSES = 5;
        const int EMPTY_LIST_CHECK = 0;
        const char UNDERSCORE = '_';

        List<string> words = new List<string>()
        {
            "bed",
            "apple",
            "camera",
            "zebra",
            "hippopotamus"
        };
        List<char> enteredLetters = new List<char>(); 
        List<char> correctLetters = new List<char>();   
        string selectedWord = words[new Random().Next(0, words.Count -1)];
        Console.Clear();
        Console.WriteLine("#################");
        Console.WriteLine("#####HANGMAN#####");
        Console.WriteLine("#################");

        int guesses = 0;
        while(true) 
        {   

            foreach(char c in selectedWord) 
            {
                if(enteredLetters.Contains(c))
                {
                    Console.Write(c);
                } 
                else 
                {
                    Console.Write(UNDERSCORE);      
                }

                if(enteredLetters.Count > EMPTY_LIST_CHECK && enteredLetters.Last() == c)
                {
                    correctLetters.Add(c);
                }   
            }
            Console.WriteLine(string.Empty);
            
            if(guesses == MAX_GUESSES)
            {
              Console.WriteLine("#################");
              Console.WriteLine("###GAME OVER!####");
              Console.WriteLine($"The word was {selectedWord}");
              Console.WriteLine("#################");
              break;
            } 

            if(correctLetters.Count == selectedWord.Length)
            {   
                Console.WriteLine("#################");
                Console.WriteLine($"You won with { MAX_GUESSES - guesses} lives remaining");
                Console.WriteLine("#################");
                break;
            }

            Console.Write("Enter a Letter: ");
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine(string.Empty);

            if(enteredLetters.Contains(input))
            {
                Console.WriteLine($"You have already entered letter {input}");
                continue;
            }

            enteredLetters.Add(input);

            if(!selectedWord.Contains(input))
            {
              guesses++;
              Console.WriteLine($"You have {MAX_GUESSES - guesses} lives left");  
            } 
        }
    }
}
