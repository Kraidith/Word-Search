using System.Security.Cryptography.X509Certificates;

namespace Word_Search
{
    internal class WordSearch
    {
        static void Main(string[] args)
        {
            GenerateBoard();
            ReadCategories();
            DisplayCategories();
            string[] board = GenerateBoard();
            string selectedCategories = DisplayCategories();
            Console.WriteLine("You chose: " + selectedCategories);
            // user input is a Console.ReadLine()
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

            string[] allCategories = {"Anakin", "Luke", "QuiGon", "Revan", "JocastaNu", "BastilleShan", "Jolee", "Ahsoka",
                "GalenMarek", "ObiWan", "PloKoon", "KitFisto", "BarrissOffee", "CalKestis" };
            string[] allWords = new string[15];
            Random rnd = new Random();
            for (int i = 0; i < allWords.Length; i++)
            {
                int randomIndex = rnd.Next(0, allWords.Length);
                string potentialWord = allWords[randomIndex++];
                if (allWords.Contains(potentialWord))
                {
                    i--;
                    continue;
                }
                allWords[i] = potentialWord;
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
            int numberOfWords = 15;
            string filePath = "Words.txt";
            string[] allCategoriesAndWords = File.ReadAllLines(filePath);
            string[][] categoriesAndWords = new string[10][];
            for (int i = 0; i < categoriesAndWords.Length; i++)
            {
                categoriesAndWords[i] = new string[numberOfWords];
                for (int j = 0; j < categoriesAndWords.Length; j++)
                {
                    categoriesAndWords[i][j] = allCategoriesAndWords[i * numberOfWords + j];
                }
            }
        }
        static string DisplayCategories()
        {
            string[] categories = ReadCategories();

            if (categories.Length == 0)
            {
                Console.WriteLine("No categories found");
                return "";
            }
            foreach (string category in categories)
            {
                Console.WriteLine("" + category);
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
                    Console.WriteLine("\nInvalid input? Try agasin.");
                }

            }

        }
    }
}
