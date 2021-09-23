using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using Sid_Stephanie_Gabi_Midterm_OOP;

namespace the_Bodleian_Library
{
    class Program
    {
        static void Main(string[] args)
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

            using (StreamReader reader = new StreamReader(Path))
            {
                var line = string.Empty;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }
        }
    }
}
              
