using System.Security.Cryptography.X509Certificates;

namespace Word_Search
{
    internal class WordSearch
    {
        static void Main(string[] args)
        {
            Words.GenerateWordsFile();
            GenerateBoard();
            ReadCategories();
            DisplayCategories();
            string[] board = GenerateBoard();
            string selectedCategories = DisplayCategories();
            Console.WriteLine("You chose: " + selectedCategories);
            if(DisplayCategories().Length == 0)
            {
                Console.WriteLine("No categoris found.");
                return;
            }
            string[] WordSearchBoard =
            {
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
             "....................",
            };
            string filePath = "Words.txt";
            string[] allLines = File.ReadAllLines(filePath);
            string[] allCategories = new string[10];
            int numberOfCategores = 10;
            int numberOfWords = 15;
            string[] allWords = new string[numberOfWords];
            Random rnd = new Random();
            string[] selectedWords = new string[8];
            for(int i = 0; i < selectedWords.Length; i++)
            {
                int randomIndex;
                string potentialWord;
                do
                {
                    randomIndex = rnd.Next(0, numberOfWords);
                    potentialWord = allWords[randomIndex];
                }
                while (selectedWords.Contains(potentialWord));
                selectedWords[i] = potentialWord;
                Console.WriteLine("Randomly chosen words: ");
                foreach(var word in selectedWords)
                {
                    Console.WriteLine(word);
                }
            }
        }
        static string[] GenerateBoard()
        {
            Random rand = new Random();
            string[] board = new string[20];

            for (int i = 0; i < 20; i++)
            {
                string row = "";
                for (int j = 0; j < 20; j++)
                {
                    row += (char)rand.Next('A', 'Z' + 1);
                }
                board[i] = row;
            }
            return board;
        }
        static string[] ReadCategories()
        {
            string filePath = "Words.txt";
            int numberOfCategories = 9;
            string[] allCategoriesAndWords = File.ReadAllLines(filePath);
            string[] categories = new string[numberOfCategories];
                for (int i = 0; i < numberOfCategories + 1; i++)
                {
                    int index = i * (15 + 1);
                    if(index < allCategoriesAndWords.Length)
                    {
                    categories[i] = allCategoriesAndWords[index];
                    }
                }
                return categories;
            
        }
        static string DisplayCategories()
        {
            string[] categories = ReadCategories();

            if (categories.Length == 0)
            {
                Console.WriteLine("No categories found");
                return "";
            }
            string input;
            while (true)
            {
                Console.WriteLine("\n enter a category: ");
                input = Console.ReadLine();
                if (categories.Contains(input))
                {
                    Console.WriteLine("\nValid input");
                    return input;
                }
                else
                {
                    Console.WriteLine("\nInvalid input? Try again.");
                }

            }

        }
    }
}
