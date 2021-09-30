using System;
using System.Collections.Generic;
using System.IO;
using Sid_Stephanie_Gabi_Midterm_OOP;
using System.Linq;


namespace MidtermPractice
{
    public class LibraryApplication
    {
        public static void LibraryStartMenu()
        {
            int userMenuChoice = 0;
            bool userRetry = false;

            Console.WriteLine(@"
1 - Show library contents");
            Console.WriteLine("2 - Search by creator");
            Console.WriteLine("3 - Search by keyword");
            Console.WriteLine("4 - Check out an item");
            Console.WriteLine("5 - Return an item");
            Console.WriteLine("6 - Exit the library");

            do
            {
                userRetry = false;
                do Console.Write(@"
What would you like to do?: ");
                while (!int.TryParse(Console.ReadLine(), out userMenuChoice));//regex
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
                        UserSelect();
                        break;
                    case 5:
                        ReturnSelect();
                        break;
                    case 6:
                        Console.WriteLine(@"
*~*Mischief Managed! Goodbye!*~*");
                        userRetry = false;
                        break;
                    default:
                        Console.WriteLine(@"
Please enter a number between 1 and 6");
                        userRetry = true;
                        break;
                }
            }
            while (userRetry);
        }

        public static void ShowLibraryContents()
        {
            int userMenuChoice = 0;
            bool userRetry = false;
            List<Materials> allMaterials = TextToList();

            Console.WriteLine(@"
1 - Show all contents");
            Console.WriteLine("2 - Show all books");
            Console.WriteLine("3 - Show all manga");
            Console.WriteLine("4 - Show all potions supplies");
            Console.WriteLine("5 - Return to menu");

            do
            {
                userRetry = false;
                do Console.Write(@"
What would you like to do?: ");
                while (!int.TryParse(Console.ReadLine(), out userMenuChoice));
                switch (userMenuChoice)
                {
                    case 1:
                        foreach (Materials x in allMaterials)
                        {
                            Console.WriteLine($"ISBN: {x.ISBN} | TYPE: {x.typeOfMaterial} | NAME: {x.nameOfMaterial} | CREATOR: {x.Creator} | STATUS: {x.statusOfMaterial}");
                        }

                        SecondaryMenu();
                        break;
                    case 2:
                        foreach (var x in allMaterials.Where(p => p.GetType() == typeof(Book)))
                        {
                            Console.WriteLine($"ISBN: {x.ISBN} | TYPE: {x.typeOfMaterial} | NAME: {x.nameOfMaterial} | CREATOR: {x.Creator} | STATUS: {x.statusOfMaterial}");
                        }
                        SecondaryMenu();
                        break;
                    case 3:
                        foreach (var x in allMaterials.Where(p => p.GetType() == typeof(Manga)))
                        {
                            Console.WriteLine($"ISBN: {x.ISBN} | TYPE: {x.typeOfMaterial} | NAME: {x.nameOfMaterial} | CREATOR: {x.Creator} | STATUS: {x.statusOfMaterial}");
                        }
                        SecondaryMenu();
                        break;
                    case 4:
                        foreach (var x in allMaterials.Where(p => p.GetType() == typeof(potionsSupplies)))
                        {
                            Console.WriteLine($"ISBN: {x.ISBN} | TYPE: {x.typeOfMaterial} | NAME: {x.nameOfMaterial} | CREATOR: {x.Creator} | STATUS: {x.statusOfMaterial}");
                        }
                        SecondaryMenu();
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
            List<Materials> allMaterials = TextToList();
            Console.Write("Enter creator: ");
            var search = Console.ReadLine().ToUpper();
            var items = allMaterials.FindAll(x => x.Creator.Contains(search));

            if (items.Any() != true)
            {
                Console.WriteLine($"I'm sorry, we do not have any items created by {search}");
            }
           
            else
            {
                foreach (Materials x in items)
                {
                    Console.WriteLine($"ISBN: {x.ISBN} | TYPE: {x.typeOfMaterial} | NAME: {x.nameOfMaterial} | CREATOR: {x.Creator} | STATUS: {x.statusOfMaterial}");
                }
            }
           
            SecondaryMenu();
        }

        public static void SearchByKeyword()
        {
            List<Materials> allMaterials = TextToList();
            Console.Write("Enter keyword: ");
            var search = Console.ReadLine().ToUpper();
            var items = allMaterials.FindAll(x => x.nameOfMaterial.Contains(search));

            if (items.Any() != true)
            {
                Console.WriteLine($"I'm sorry, we do not have any items with {search} keyword");
            }

            else
            {
                foreach (Materials x in items)
                {
                    Console.WriteLine($"ISBN: {x.ISBN} | TYPE: {x.typeOfMaterial} | NAME: {x.nameOfMaterial} | CREATOR: {x.Creator} | STATUS: {x.statusOfMaterial}");
                }
            }

            SecondaryMenu();
        }
        public static void SecondaryMenu()
        {
            bool userRetry = false;
            int userMenuChoice = 0;
            do
            {
                userRetry = false;
                Console.WriteLine(@"
1 - Check out");
                Console.WriteLine(@"2 - Return to main menu");
                do Console.Write(@"
What do you wish to do next?: ");
                while (!int.TryParse(Console.ReadLine(), out userMenuChoice));
                switch (userMenuChoice)
                {
                    case 1:
                        UserSelect();
                        break;
                    case 2:
                        LibraryStartMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        userRetry = true;
                        break;
                }
            }
            while (userRetry);
        }
        public static void UserSelect()
        {
            List<Materials> allMaterials = TextToList();

            int userISBN = 0;
            do Console.Write(@"
1 - Show list of all items
2 - Return to Main Menu
Checkout an Item - Enter the ISBN of the item you would like to checkout

What do you wish to do next?: ");
            
            while (!int.TryParse(Console.ReadLine(), out userISBN));
            {
                if (userISBN != 1 && userISBN != 2)
                {
                  var obj = allMaterials.FirstOrDefault(x => x.ISBN == userISBN);
                    {
                        if (obj == null)
                        {
                            Console.WriteLine($@"
{userISBN} is not a valid ISBN");
                            UserSelect();
                        }

                        else if (obj.statusOfMaterial != Status.ONSHELF)
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
                else if (userISBN == 1)
                {
                    foreach (Materials x in allMaterials)
                    {
                        Console.WriteLine($"ISBN: {x.ISBN} | TYPE: {x.typeOfMaterial} | NAME: {x.nameOfMaterial} | CREATOR: {x.Creator} | STATUS: {x.statusOfMaterial}");
                    }
                    UserSelect();
                }
                else if (userISBN == 2)
                {
                    LibraryStartMenu();
                }
            }
        }

        public static void CheckOut(Materials userCheckOut, List<Materials> allMaterials)
        {
            userCheckOut.statusOfMaterial = Status.CHECKEDOUT;

            string Path = "MaterialsList.txt";
            using (TextWriter tw = new StreamWriter(Path))
            {
                foreach (Materials x in allMaterials)
                {
                    tw.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}", x.typeOfMaterial, x.ISBN, x.nameOfMaterial, x.Creator, x.statusOfMaterial.ToString()));
                }
                tw.Close();
            }
            DueDateTracker(userCheckOut);
        }

        public static void DueDateTracker(Materials userCheckout)
        {
            DateTime checkoutDate = DateTime.Today;
            DateTime dueDate = checkoutDate.AddDays(14);

            DateTime returnDate = DateTime.Now;
            TimeSpan intervalDate = (returnDate - dueDate);
            double t = Math.Round(intervalDate.TotalDays);

            int result = DateTime.Compare(checkoutDate, returnDate);
            Console.WriteLine($@"
Please return {userCheckout.nameOfMaterial} by {dueDate.ToShortDateString()}, to avoid any unwanted curses");
            
            DueDateRecorder(userCheckout, dueDate);
            SecondaryMenu();
        }

        public static void DueDateRecorder(Materials userCheckout, DateTime dueDate)
        {
            using (StreamWriter tw = File.AppendText("DueDateTracker.txt"))
            {
                tw.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}", userCheckout.typeOfMaterial, userCheckout.ISBN, userCheckout.nameOfMaterial, userCheckout.Creator, userCheckout.statusOfMaterial.ToString(), dueDate.ToShortDateString()));
            }
        }

        public static void ReturnSelect()
        {
            List<Materials> allMaterials = TextToList();

            int userISBN = 0;
            do Console.Write(@" 
1 - Show list of all items
2 - Return to Main Menu
Return an Item - Enter the ISBN of the item you would like to return

What do you wish to do next?: ");
            while (!int.TryParse(Console.ReadLine(), out userISBN));
            {
                if (userISBN != 1 && userISBN != 2)
                {
                    var obj = allMaterials.FirstOrDefault(x => x.ISBN == userISBN);
                    if (obj.statusOfMaterial != Status.CHECKEDOUT)
                    {
                        Console.WriteLine(@"
I'm sorry, that item must be checked out to be returned");
                        LibraryStartMenu();
                    }
                    else
                    {
                        Return(obj, allMaterials);
                    }
                }
                else if (userISBN == 1)
                {
                    foreach (Materials x in allMaterials)
                    {
                        Console.WriteLine($"ISBN: {x.ISBN} | TYPE: {x.typeOfMaterial} | NAME: {x.nameOfMaterial} | CREATOR: {x.Creator} | STATUS: {x.statusOfMaterial}");
                    }
                    ReturnSelect();
                }
                else if (userISBN == 2)
                {
                    LibraryStartMenu();
                }
            }
        }

        public static void Return(Materials userReturn, List<Materials> allMaterials)
        {
            userReturn.statusOfMaterial = Status.ONSHELF;

            string Path = "MaterialsList.txt";
            using (TextWriter tw = new StreamWriter(Path))
            {
                foreach (Materials x in allMaterials)
                {
                    tw.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}", x.typeOfMaterial, x.ISBN, x.nameOfMaterial, x.Creator, x.statusOfMaterial.ToString()));
                }
                tw.Close();
            }
            ReturnDateTracker(userReturn);
        }

        public static void ReturnDateTracker(Materials userReturn)
        {
            string line;
            string item = userReturn.nameOfMaterial;

            using (System.IO.StreamReader file = new System.IO.StreamReader("DueDateTracker.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    if (words[2].Trim() == item)
                    {
                        DateTime dueDate = DateTime.Parse(words[5].Trim());
                        DateTime returnDate = DateTime.Now;
                        TimeSpan intervalDate = (returnDate - dueDate);
                        int result = DateTime.Compare(dueDate, returnDate);
                        double t = Math.Round(intervalDate.TotalDays);

                        if (result < 0)
                        {
                            Console.WriteLine($@"
Tsk, tsk {userReturn.nameOfMaterial} is overdue by {t} days!");
                        }
                        else
                        {
                            Console.WriteLine($@"
Thank you! {userReturn.nameOfMaterial} has been returned on time.");
                        }
                    }

                }
            }
            var oldLines = System.IO.File.ReadAllLines("DueDateTracker.txt");
            var newLines = oldLines.Where(line => !line.Contains(item));
            File.WriteAllLines("DueDateTracker.txt", newLines);
            SecondaryMenu();

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
                if (words[0] == "POTIONS SUPPLIES")
                {
                    allMaterials.Add(new potionsSupplies(int.Parse(words[1].Trim().ToUpper()), words[2].Trim().ToUpper(), words[3].Trim().ToUpper(), (Status)Enum.Parse(typeof(Status), words[4].Trim().ToUpper())));
                }
                else if (words[0] == "BOOKS")
                {
                    allMaterials.Add(new Book(int.Parse(words[1].Trim().ToUpper()), words[2].Trim().ToUpper(), words[3].Trim().ToUpper(), (Status)Enum.Parse(typeof(Status), words[4].Trim().ToUpper())));
                }

                else if (words[0] == "MANGA")
                {
                    allMaterials.Add(new Manga(int.Parse(words[1].Trim().ToUpper()), words[2].Trim().ToUpper(), words[3].Trim().ToUpper(), (Status)Enum.Parse(typeof(Status), words[4].Trim().ToUpper())));
                }
            }
            file.Close();
            return allMaterials;
        }

        //public static int userChoiceValidation(string userChoice)
        //{
            //regex stuff goes here
            
        //}
        static void Main(string[] args)
        {
            Console.WriteLine("*~*Welcome to the Bodleian Library!*~*");
            LibraryStartMenu();
        }
    }
}
