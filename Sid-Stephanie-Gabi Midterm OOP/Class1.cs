using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace Sid_Stephanie_Gabi_Midterm_OOP
{

    public enum Status
    {
        [Description("Checked Out")] checkedOut = 1,
        [Description("On Shelf")] onShelf = 2,
        [Description("Paging")] paging = 3,
    }
    public abstract class Materials
    {
        public abstract string nameOfMaterial { get; set; }

        public abstract string Creator { get; set; }

        public abstract Status getStatus();

        public abstract string dueDate { get; set; }

    }

    public class potionsSupplies: Materials
    {
        public override string nameOfMaterial { get; set; }
        public override string Creator { get; set; }

        public override Status getStatus()
        {
            throw new NotImplementedException(); 
        }

        public override string dueDate { get; set; }

        public potionsSupplies(string nameOfMaterial, string Creator, Status itemStatus)
        {
            nameOfMaterial = this.nameOfMaterial;
            Creator = this.Creator;
            itemStatus = getStatus();
        }

        public List<potionsSupplies> potionsSuppliesList()
        {
            List<potionsSupplies> potionsSuppliesList = new List<potionsSupplies>();

            potionsSupplies pewterCauldron = new potionsSupplies("Pewter Cauldron", "Ancient Potion Maker", getStatus());
            potionsSupplies glassPhial = new potionsSupplies("Glass Phial", "Diagon Alley Apothecary", getStatus());
            potionsSupplies crystalPhial = new potionsSupplies("Crystal Phial", "Potions Lady", getStatus());
            potionsSupplies brassScales = new potionsSupplies("Brass Scales", "Ancient Potion Maker", getStatus());
            potionsSupplies juicingBoard = new potionsSupplies("Juicing Board", "Diagon Alley Apothecary", getStatus());
            potionsSupplies mortarAndPestle = new potionsSupplies("Mortar and Pestle", "Ancient Potion Maker", getStatus());

            potionsSuppliesList.Add(pewterCauldron);
            potionsSuppliesList.Add(glassPhial);
            potionsSuppliesList.Add(crystalPhial);
            potionsSuppliesList.Add(brassScales);
            potionsSuppliesList.Add(juicingBoard);
            potionsSuppliesList.Add(mortarAndPestle);

            return potionsSuppliesList;
        }

    }



    public class Book : Materials
    {

        public override string nameOfMaterial { get; set; }

        public override string Creator { get; set; }

        public override string dueDate { get; set; }

        public override Status getStatus()
        {
            throw new NotImplementedException();
        }

        public Book(string NameofMaterial, string Creator)
        {
            var Title = this.nameOfMaterial;
            var Author = this.Creator;

        }

    }






}
