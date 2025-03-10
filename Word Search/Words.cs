﻿

namespace Word_Search
{
    internal class Words
    {
        public static void GenerateWordsFile()
        {
            string linesFilePath = "Words.txt";
            StreamWriter writer = new StreamWriter(linesFilePath);
            string[,] categoriesAndWords =
            {
             { "Jedi", "Anakin", "Luke", "QuiGon", "Revan", "JocastaNu", "BastilleShan", "Jolee", "Ahsoka", "GalenMarek", "ObiWan", "PloKoon", "KitFisto", "BarrissOffee", "CalKestis"},
             { "Sith", "Vader", "Nihilus", "Sidious", "Vitiate", "Malak", "Dooku", "Savage", "Malgus", "Talon", "SecondSister", "SeventhSister", "Bane", "Krayt", "Maul" },
             { "Ranged", "Pistol", "Shotgun", "Rifle", "RocketLauncher", "Plasma", "Energy", "Goo", "Electrical", "FlameThrower", "BloodSiphon", "Decay", "LongNeckRifle", "SniperRifle", "Revolver"},
             { "Melee", "Sword", "Dagger", "Shield", "Flail", "Mace", "Spear", "Axe", "Halberd", "GreatSword", "DualBlade", "Pike", "Sickle", "Machete", "Club"},
             { "Carnivores", "TRex", "Carno", "Argi", "Yuti", "Allo", "Spino", "Megalodon", "Wyvern", "Thylacoleo", "Raptor", "Baryonyx", "Carchar", "Troodon", "Managrmr"},
             { "Herbivores", "Pachy", "Stego", "Iguanadon", "Bronto", "Anky", "Trike", "Doedic", "Therizino", "GigantoRaptor", "Diplo", "Paracer", "Gallimimus", "Chalico", "Mantis"},
             { "Planets", "Tatooine", "Korribane", "Coruscant", "Kamino", "Kashyyyk", "MalacorFive", "Utapau", "Ilum", "Felucia", "Rishi", "Zeffo", "Vardos", "Batuu", "Eriadu"},
             { "Races", "Human", "Greenskin", "Norsca", "VampireCounts", "VampireCoast", "High elf", "Wood elf", "Slanesh", "Khorne", "Tzeentch", "Nurgle", "Beastman", "DarkElves", "Dwarfs"},
             { "Killers", "Wraith", "Doctor", "Huntress", "Clown", "Legion", "Plague", "Trickster", "Mastermind", "DeathSlinger", "Shape", "Blight", "DarkLord", "Unknown", "Knight"},
            };
            for (int i = 0; i < categoriesAndWords.GetLength(0); i++)
            {
                string line = categoriesAndWords[i, 0]; 

                for (int j = 1; j < categoriesAndWords.GetLength(1); j++)
                {
                    line += "," + categoriesAndWords[i, j]; 
                }
                writer.WriteLine(line);
            }
            writer.Close();
            Console.WriteLine("Words.Txt has been created");
        }
    }
}
