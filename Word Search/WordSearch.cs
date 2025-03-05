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
            string selectedCategory = DisplayCategories();
            if (string.IsNullOrEmpty(selectedCategory))
            {
                Console.WriteLine("No categories found.");
                return;
            }
            Console.WriteLine("You chose:" + selectedCategory);
            List<string> wordsInCategory = GetWordsFromCategory(selectedCategory);
            List<string> selectedWords = SelectRandomWord(wordsInCategory);
            Console.WriteLine("\n Randomly chosen words: ");
            foreach (string word in selectedWords)
            {
                Console.WriteLine(word);
            }
            string[] board = GenerateBoard();
            foreach(string row in board)
            {
                Console.WriteLine(row);
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
        }
        public static string[] GenerateBoard()
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
        public static List<string> ReadCategories()
        {
            string filePath = "Words.txt";
            string[] allLines = File.ReadAllLines(filePath);
            List<string> categories = new List<string>();
            foreach (string line in allLines)
            {
                string[] parts = line.Split(",");
                    if (parts.Length > 0)
                    {
                        categories.Add(parts[0]);
                    }
              
            }
            return categories;
        }
        public static string DisplayCategories()
        {
            List<string> categories = new List<string>(ReadCategories());
            Console.WriteLine("\n Available categories");
            foreach (string category in categories)
            {
                Console.WriteLine(category);
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
                Console.WriteLine("\nInvalid input! Try again.");
            }
        }
        public static List<string> GetWordsFromCategory(string chosenCategory)
        {
            string filePath = "Words.txt";
            string[] allLines = File.ReadAllLines(filePath);
            List<string> words = new List<string>();
            bool categoryFound = false;
            foreach (string line in allLines)
            {
                string[] parts = line.Split(",");
                if (parts.Length > 0 && parts[0] == chosenCategory)
                {
                    words.AddRange(parts.Skip(1));
                }
            }
            return words;
        }
        public static List<string> SelectRandomWord(List<string> words)
        {
            Random rnd = new Random();
            List<string> selectedWords = new List<string>();
            int wordCount = rnd.Next(Math.Min(8, words.Count));
            while (selectedWords.Count < wordCount)
            {
                string potentialWord = words[rnd.Next(words.Count)];
                if (!selectedWords.Contains(potentialWord))
                {
                    selectedWords.Add(potentialWord);
                }
            }
            return selectedWords;
        }
    }
}
