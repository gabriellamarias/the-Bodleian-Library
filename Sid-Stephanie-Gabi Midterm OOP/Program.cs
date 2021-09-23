using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using Sid_Stephanie_Gabi_Midterm_OOP;


namespace MidtermPractice
{
    public class LibraryApplication
    {
        public static void LibraryContents()
        {

            List<Materials> allMaterials = new List<Materials>();

            allMaterials.Add(new potionsSupplies("Pewter Cauldron", "Ancient Potion Maker", Status.onShelf));
            allMaterials.Add(new potionsSupplies("Glass Phial", "Diagon Alley Apothecary", Status.onShelf));
            allMaterials.Add(new potionsSupplies("Crystal Phial", "Potions Lady", Status.onShelf));
            allMaterials.Add(new potionsSupplies("Brass Scales", "Ancient Potion Maker", Status.onShelf));
            allMaterials.Add(new potionsSupplies("Juicing Board", "Diagon Alley Apothecary", Status.onShelf));
            allMaterials.Add(new potionsSupplies("Mortar and Pestle", "Ancient Potion Maker", Status.onShelf));
            allMaterials.Add(new Book("Fantastic Beasts and Where to Find Them", "Newt Scamander", Status.onShelf));
            allMaterials.Add(new Book("Quidditch Through the Ages", "Kennilworthy Whisp", Status.onShelf));
            allMaterials.Add(new Book("Hogwarts: A History", "Bathilda Bagshot", Status.onShelf));
            allMaterials.Add(new Book("Magical Drafts and Potions", "Arsenic Jigger", Status.onShelf));
            allMaterials.Add(new Book("Unfogging the Future", "Blenheim Stalk", Status.onShelf));
            allMaterials.Add(new Book("Magical Me", "Gilderoy Lockhart", Status.onShelf));
            allMaterials.Add(new Manga("Azuallmanga Daioh", "Kiyohiko Azuma", Status.onShelf));
            allMaterials.Add(new Manga("K-On", "Kakifly", Status.onShelf));
            allMaterials.Add(new Manga("Lucky Star", "Kagami Yoshimizu", Status.onShelf));
            allMaterials.Add(new Manga("Daily lives of high school boys", "Yasunobu Yamauchi", Status.onShelf));
            allMaterials.Add(new Manga("Nichijou", "Keiichi Arawi", Status.onShelf));
            allMaterials.Add(new Manga("Kaguya-sama: Love is War", "Aka Akasaka", Status.onShelf));

            string Path = "MaterialsList.txt";

            using (TextWriter tw = new StreamWriter(Path))
            {
                foreach (Materials x in allMaterials)
                {
                    tw.WriteLine(string.Format("Material: {0} | Name: {1} | Creator: {2} | Status: {3}", x.typeOfMaterial, x.nameOfMaterial, x.Creator, x.statusOfMaterial.ToString()));
                }
            }
        }
        public static void LibraryStartMenu()
        {
            int userMenuChoice = 0;
            bool userRetry = false;

            Console.WriteLine("Welcome to the Bodleian Library!");
            Console.WriteLine("1 - Show library contents");
            Console.WriteLine("2 - Search by creator");
            Console.WriteLine("3 - Search by keyword");
            Console.WriteLine("4 - Check out an item");
            Console.WriteLine("5 - Return an item");

            do
            {
                userRetry = false;
                do Console.Write("What would you like to do?: ");
                while (!int.TryParse(Console.ReadLine(), out userMenuChoice));
                switch (userMenuChoice)
                {
                    case 1:
                        ShowLibraryContents();
                        break;
                    case 2:
                        SearchByCreator();
                        break;
                    case 3:
                        SearchByKeyword();
                        break;
                    case 4:
                        Console.WriteLine("Check out an item");
                        break;
                    case 5:
                        Console.WriteLine("Return an item");
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 5");
                        userRetry = true;
                        break;
                }
            }
            while (userRetry);
        }

        public static void ShowLibraryContents()
        {
            string Path = "MaterialsList.txt";
            int userMenuChoice = 0;
            bool userRetry = false;
            System.IO.StreamReader file =
                new System.IO.StreamReader("MaterialsList.txt");

            Console.WriteLine("1 - Show all contents");
            Console.WriteLine("2 - Show all books");
            Console.WriteLine("3 - Show all manga");
            Console.WriteLine("4 - Show all potions supplies");
            Console.WriteLine("5 - Return to menu");

            do
            {
                userRetry = false;
                do Console.Write("What would you like to do?: ");
                while (!int.TryParse(Console.ReadLine(), out userMenuChoice));
                switch (userMenuChoice)
                {
                    case 1:
                        using (StreamReader reader = new StreamReader(Path))
                        {
                            var line = string.Empty;
                            while (!reader.EndOfStream)
                            {
                                line = reader.ReadLine();
                                Console.WriteLine(line);
                            }
                        }
                        Console.WriteLine("1 - Check out");
                        Console.WriteLine("2 - Return to main menu");
                        do Console.Write("What do you wish to do next?: ");
                        while (!int.TryParse(Console.ReadLine(), out userMenuChoice));
                        switch (userMenuChoice)
                        {
                            case 1:
                                CheckOut();
                                break;
                            case 2:
                                LibraryStartMenu();
                                break;
                            default:
                                Console.WriteLine("Please enter a valid choice");
                                break;
                        }


                        break;
                    case 2:
                        using (file)
                        {
                            while (!file.EndOfStream)
                            {
                                var line = file.ReadLine();
                                if (String.IsNullOrEmpty(line)) continue;
                                if (line.IndexOf("Book", StringComparison.CurrentCultureIgnoreCase) >= 0)
                                {
                                    Console.WriteLine(line);
                                }
                            }
                        }
                        break;
                    case 3:
                        using (file)
                        {
                            while (!file.EndOfStream)
                            {
                                var line = file.ReadLine();
                                if (String.IsNullOrEmpty(line)) continue;
                                if (line.IndexOf("Manga", StringComparison.CurrentCultureIgnoreCase) >= 0)
                                {
                                    Console.WriteLine(line);
                                }
                            }
                        }
                        break;
                    case 4:
                        using (file)
                        {
                            while (!file.EndOfStream)
                            {
                                var line = file.ReadLine();
                                if (String.IsNullOrEmpty(line)) continue;
                                if (line.IndexOf("Potions Supplies", StringComparison.CurrentCultureIgnoreCase) >= 0)
                                {
                                    Console.WriteLine(line);
                                }
                            }
                        }
                        break;
                    case 5:
                        LibraryStartMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        userRetry = true;
                        break;
                }
            }
            while (userRetry);
        }
        public static void SearchByCreator()
        {
            
            Console.Write("Enter creator: ");
            var text = Console.ReadLine();

            System.IO.StreamReader file =
                new System.IO.StreamReader("TextFile1.txt");

       
            using (file)
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();
                    if (String.IsNullOrEmpty(line)) continue;
                    if (line.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            file.Close();

            Console.ReadLine();
        }

        public static void SearchByKeyword()
        {
            Console.Write("Enter keyword: ");
            var text = Console.ReadLine();

            System.IO.StreamReader file =
                new System.IO.StreamReader("MaterialsList.txt");


            using (file)
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();
                    if (String.IsNullOrEmpty(line)) continue;
                    if (line.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            file.Close();

            Console.ReadLine();
        }
        public static void CheckOut()
        {

        }

        public static void Return()
        {

        }
        static void Main(string[] args)
        {
            LibraryStartMenu();
   
        }
    }
}
