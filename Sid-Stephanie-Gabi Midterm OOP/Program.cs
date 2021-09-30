using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using Sid_Stephanie_Gabi_Midterm_OOP;
using System.Linq;

namespace MidtermPractice
{
    public class LibraryApplication
    {


        //public static void LibraryContents()
        //{
        //    List<Materials> allMaterials = new List<Materials>();
        //    string line;
           
        //    System.IO.StreamReader file =
        //        new System.IO.StreamReader("MaterialsList.txt");
        //    while ((line = file.ReadLine()) != null)
        //    {
        //        string[] words = line.Split(',');
        //        if (words[0] == "Potions Supplies" )
        //        {
        //            allMaterials.Add(new potionsSupplies(int.Parse(words[1]), words[2], words[3], (Status)Enum.Parse(typeof(Status), words[4]))); 
        //        }
        //        else if (words[0] == "Books")
        //        {
        //            allMaterials.Add(new Book(int.Parse(words[1]), words[2], words[3], (Status)Enum.Parse(typeof(Status), words[4])));
        //        }

        //        else if (words[0] == "Manga")
        //        {
        //            allMaterials.Add(new Manga(int.Parse(words[1]), words[2], words[3], (Status)Enum.Parse(typeof(Status), words[4])));
        //        }
        //    }

        //    //foreach (Materials x in allMaterials)
        //    //{
        //    //    Console.WriteLine($"ISBN: {x.ISBN} | Type: {x.typeOfMaterial} | Name: {x.nameOfMaterial} | Creator: {x.Creator} | Status: {x.statusOfMaterial}");
        //    //}

        //    file.Close();

        //}


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
                                //Console.WriteLine(string.Format($"{0}, {1}, {2}, {3}, {4}", [1], [2], [3])
                            }
                        }
                        Console.WriteLine("1 - Check out");
                        Console.WriteLine("2 - Return to main menu");
                        do Console.Write("What do you wish to do next?: ");
                        while (!int.TryParse(Console.ReadLine(), out userMenuChoice));
                        switch (userMenuChoice)
                        {
                            case 1:
                                file.Close();
                                UserSelect();
                                break;
                            case 2:
                                file.Close();
                                LibraryStartMenu();
                                break;
                            default:
                                Console.WriteLine("Please enter a valid choice");
                                file.Close();
                                break;
                        }
                        break;
                    case 2:
                        while (!file.EndOfStream)
                        {
                            var line = file.ReadLine();
                            if (String.IsNullOrEmpty(line)) continue;
                            if (line.IndexOf("Book", StringComparison.CurrentCultureIgnoreCase) >= 0)
                            {
                                Console.WriteLine(line);
                            }
                            file.Close();
                        }
                        break;
                    case 3:
                        while (!file.EndOfStream)
                        {
                            var line = file.ReadLine();
                            if (String.IsNullOrEmpty(line)) continue;
                            if (line.IndexOf("Manga", StringComparison.CurrentCultureIgnoreCase) >= 0)
                            {
                                Console.WriteLine(line);
                            }
                            file.Close();
                        }
                        break;
                    case 4:
                        while (!file.EndOfStream)
                        {
                            var line = file.ReadLine();
                            if (String.IsNullOrEmpty(line)) continue;
                            if (line.IndexOf("Potions Supplies", StringComparison.CurrentCultureIgnoreCase) >= 0)
                            {
                                Console.WriteLine(line);
                            }
                            file.Close();
                        }
                        break;
                    case 5:
                        file.Close();
                        LibraryStartMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        userRetry = true;
                        file.Close();
                        break;
                }
                file.Close();
            }
            while (userRetry);
        }
        public static void SearchByCreator()
        {

            Console.Write("Enter creator: ");
            var text = Console.ReadLine();

            using (System.IO.StreamReader file =
                new System.IO.StreamReader("MaterialsList.txt"))
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
            Console.ReadLine();
        }

        public static void SearchByKeyword()
        {
            Console.Write("Enter keyword: ");
            var text = Console.ReadLine();

            using (System.IO.StreamReader file1 =
                new System.IO.StreamReader("MaterialsList.txt"))
            {
                while (!file1.EndOfStream)
                {
                    var line1 = file1.ReadLine();
                    if (String.IsNullOrEmpty(line1)) continue;
                    if (line1.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        Console.WriteLine(line1);
                    }
                }
            }
            Console.ReadLine();


            List<Materials> allMaterials = TextToList();
            UserSelect();
        }

        public static void UserSelect()
        {
            List<Materials> allMaterials = TextToList();

            int userISBN = 0;
            do Console.Write("Enter the ISBN of the item you would like to check out: ");
            while (!int.TryParse(Console.ReadLine(), out userISBN));
            {

                var obj = allMaterials.FirstOrDefault(x => x.ISBN == userISBN);

                Console.WriteLine($"{obj.statusOfMaterial}");

                if (obj.statusOfMaterial != Status.onShelf)
                {
                    Console.WriteLine("I'm sorry, that item is unavailable");
                    LibraryStartMenu();
                }
                else
                {
                    CheckOut(obj, allMaterials);
                }
            }
        }


        public static void CheckOut(Materials userCheckOut, List<Materials> allMaterials)
        {
            userCheckOut.statusOfMaterial = Status.checkedOut;

            string Path = "MaterialsList.txt";
            using (TextWriter tw = new StreamWriter(Path))
            {
                foreach (Materials x in allMaterials)
                {
                    tw.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}", x.ISBN, x.typeOfMaterial, x.nameOfMaterial, x.Creator, x.statusOfMaterial.ToString()));
                }
                tw.Close();
            }
            DueDateTracker();
        }

        public static void DueDateTracker()
        {

            DateTime checkoutDate = DateTime.Today;
            DateTime dueDate = checkoutDate.AddDays(14);

            DateTime returnDate = DateTime.Now;
            TimeSpan intervalDate = (returnDate - dueDate);
            double t = Math.Round(intervalDate.TotalDays);

            int result = DateTime.Compare(checkoutDate, returnDate);
            Console.WriteLine($"Please return your item by {dueDate.ToShortDateString()}, to avoid unwanted fees");

            if (result < 0)
            {
                Console.WriteLine($"This book is overdue by {t} days!");
            }
            else if (result >= 0)
            {
                Console.WriteLine("This book was returned on time.");
            }
        }


        public static void Return()
        {

        }

        public static List<Materials> TextToList()
        {
            List<Materials> allMaterials = new List<Materials>();
            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader("MaterialsList.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                if (words[0] == "Potions Supplies")
                {
                    allMaterials.Add(new potionsSupplies(int.Parse(words[1]), words[2], words[3], (Status)Enum.Parse(typeof(Status), words[4])));
                }
                else if (words[0] == "Books")
                {
                    allMaterials.Add(new Book(int.Parse(words[1]), words[2], words[3], (Status)Enum.Parse(typeof(Status), words[4])));
                }

                else if (words[0] == "Manga")
                {
                    allMaterials.Add(new Manga(int.Parse(words[1]), words[2], words[3], (Status)Enum.Parse(typeof(Status), words[4])));
                }
            }
            file.Close();
            return allMaterials;
        }
        static void Main(string[] args)
        {
            //LibraryContents();
            LibraryStartMenu();
            //DueDateTracker();
            //    //    using (TextWriter tw = new StreamWriter(Path))
            //    //    {
            //    //        foreach (Materials x in allMaterials)
            //    //        {
            //    //            tw.WriteLine(string.Format("ISBN: {0} | Material: {1} | Name: {2} | Creator: {3} | Status: {4}", x.ISBN, x.typeOfMaterial, x.nameOfMaterial, x.Creator, x.statusOfMaterial.ToString()));
            //    //        }
            //    //        tw.Close();
            //    //    }
        }
    }
}
