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
            bool userRetry = false;

            Console.WriteLine(@"
1 - Show library contents");
            Console.WriteLine("2 - Search by creator");
            Console.WriteLine("3 - Search by keyword");
            Console.WriteLine("4 - Check out an item");
            Console.WriteLine("5 - Return an item");
            Console.WriteLine("6 - Exit the library");
            Console.WriteLine("7 - Librarian Mode");

            do
            {
                userRetry = false;
                Console.Write(@"
What would you like to do?: ");
                string userMenuChoice = Console.ReadLine();
                int validatedUserChoice = userChoiceValidation(userMenuChoice);
                switch (validatedUserChoice)
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
                    case 7:
                        AddAnItemTotheList();
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
                Console.Write(@"
What would you like to do?: ");

                string userMenuChoice = Console.ReadLine();
                int validatedUserChoice = userChoiceValidation(userMenuChoice);
                switch (validatedUserChoice)
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
            do
            {
                userRetry = false;
                Console.WriteLine(@"
1 - Check out");
                Console.WriteLine(@"2 - Return to main menu");
                Console.Write(@"
What do you wish to do next?: ");
                string userMenuChoice = Console.ReadLine();
                int validatedUserChoice = userChoiceValidation(userMenuChoice);
                switch (validatedUserChoice)
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

            Console.Write(@"
1 - Show list of all items
2 - Return to Main Menu
Checkout an Item - Enter the ISBN of the item you would like to checkout

What do you wish to do next?: ");
            string userMenuChoice = Console.ReadLine();
            int userISBN = userChoiceValidation(userMenuChoice);

            if (userISBN != 1 && userISBN != 2)
            {
                var obj = allMaterials.FirstOrDefault(x => x.ISBN == userISBN);
                {
                    if (obj == null)
                    {
                        Console.WriteLine(@"
Please enter a valid ISBN.");
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
            else
            {
                Console.WriteLine("Please select a valid option.");
                UserSelect();
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

            
            Console.Write(@" 
1 - Show list of all items
2 - Return to Main Menu
Return an Item - Enter the ISBN of the item you would like to return

What do you wish to do next?: ");
            string userMenuChoice = Console.ReadLine();
            int userISBN = userChoiceValidation(userMenuChoice);
            if (userISBN != 1 && userISBN != 2)
                {
                    var obj = allMaterials.FirstOrDefault(x => x.ISBN == userISBN);
                    {
                        if (obj == null)
                        {
                            Console.WriteLine($@"
Please enter a valid ISBN.");
                            UserSelect();
                        }

                        else if (obj.statusOfMaterial != Status.CHECKEDOUT)
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

        public static int userChoiceValidation(string userChoice)
        {
            try
            {
                int userNumber = int.Parse(userChoice);
                return userNumber;
            }
            catch (FormatException)
            {
                return 9;
            }
        }


        public static void AddAnItemTotheList()
        {
            Console.Write("\n1 - Add an item to the Library's contents\n2 - Remove an item from the Library's contents\n\nWhat would you like to do?: ");
            var librarianInput = Console.ReadLine();


            if (librarianInput == "1")
            {
                Console.WriteLine("\nPlease enter the following item information: ");
                Console.Write("Type of material: ");
                string libTypeOfMateral = Console.ReadLine().ToUpper();
                Console.Write("ISBN: ");
                string libISBN = Console.ReadLine().ToUpper();
                Console.Write("Name of material: ");
                string libNameOfMaterial = Console.ReadLine().ToUpper();
                Console.Write("Creator: ");
                string libCreator = Console.ReadLine().ToUpper();
                Console.Write("Status of material (checkedout, onshelf, vanished): ");
                string libStatus = Console.ReadLine().ToUpper();

                using (StreamWriter tw = File.AppendText("MaterialsList.txt"))
                {
                    tw.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}", libTypeOfMateral, libISBN, libNameOfMaterial, libCreator, libStatus));
                }

                Console.WriteLine($"{libNameOfMaterial} has been added to the Library's contents!\n");

                LibrarianMenuAddToList();
            }
            else if (librarianInput == "2")
            {

                Console.Write("Please enter the name of the item you would like to remove: ");
                string libNameOfMaterial = Console.ReadLine().ToUpper();
                string item = libNameOfMaterial;


                var oldLines = System.IO.File.ReadAllLines("MaterialsList.txt");
                var newLines = oldLines.Where(line => !line.Contains(item));
                File.WriteAllLines("MaterialsList.txt", newLines);

                Console.WriteLine($"{libNameOfMaterial} has been removed from the Library's contents!\n");

                LibrarianMenuAddToList();
            }
           

        }

        public static void LibrarianMenuAddToList()
        {
            bool userRetry = false;
            do
            {
                userRetry = false;
                Console.WriteLine("1 - Add/Remove another item");
                Console.WriteLine("2 - Return to main menu");
                Console.WriteLine("3 - Exit");
                Console.Write("\nWhat do you wish to do next?: ");
                string userMenuChoice = Console.ReadLine();
                int validatedUserChoice = userChoiceValidation(userMenuChoice);
                switch (validatedUserChoice)
                {
                    case 1:
                        AddAnItemTotheList();
                        break;
                    case 2:
                        LibraryStartMenu();
                        break;
                    case 3:
                        Console.WriteLine(@"
*~*Mischief Managed! Goodbye!*~*");
                        userRetry = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        userRetry = true;
                        break;
                }
            } while (userRetry);


        }

        static void Main(string[] args)
        {
            Console.WriteLine("*~*Welcome to the Bodleian Library!*~*");
            LibraryStartMenu();
        }
    }
}
