namespace Hangman;

class Program
{
    static void Main(string[] args)
    {
        //const int GUESSES = 6;
        List<string> words = new List<string>()
        {
            "bed",
            "apple",
            "camera",
            "zebra",
            "hippopotamus"
        };

        List<char> characters = new List<char>(); 

        string selectedWord = words[new Random().Next(0, words.Count -1)];
        
        Console.WriteLine("#################");
        Console.WriteLine("#####HANGMAN#####");
        Console.WriteLine("#################");
        Console.WriteLine("-----------------");
        while(true) 
        {

            Console.Write("Enter a Letter: ");
            string input = Console.ReadLine();
            characters.Add(input.ToCharArray()[0]);

            foreach(char c in selectedWord) 
            {
                if(characters.Contains(c))
                {
                    Console.Write(c);
                } 
                else 
                {
                    Console.Write('_');   
                }
            }
            Console.WriteLine("");
        }
    }
}
