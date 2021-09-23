using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;


namespace Sid_Stephanie_Gabi_Midterm_OOP
{

    public enum Status
    {
        checkedOut,
        onShelf,
        vanished

    }
    public abstract class Materials
    {
        public abstract string typeOfMaterial { get; set; }
        public abstract string nameOfMaterial { get; set; }

        public abstract string Creator { get; set; }

        public abstract Status statusOfMaterial { get; set; }

        public abstract string dueDate { get; set; }

    }
    public class potionsSupplies : Materials
    {
        private string _typeofmaterial = "Potions Supplies";
        public override string typeOfMaterial { get { return _typeofmaterial; } set { _typeofmaterial = value; } }

        public override string nameOfMaterial { get; set; }
        public override string Creator { get; set; }

        public override Status statusOfMaterial { get; set; }

        public override string dueDate { get; set; }

        public potionsSupplies(string nameOfMaterial, string Creator, Status itemStatus)
        {

            this.nameOfMaterial = nameOfMaterial;
            this.Creator = Creator;
            this.statusOfMaterial = itemStatus;
        }

    }
    public class Book : Materials
    {
        private string _typeofmaterial = "Books";
        public override string typeOfMaterial { get { return _typeofmaterial; } set { _typeofmaterial = value; } }

        public override string nameOfMaterial { get; set; }
        public override string Creator { get; set; }

        public override Status statusOfMaterial { get; set; }

        public override string dueDate { get; set; }

        public Book(string Title, string Author, Status itemStatus)
        {

            this.nameOfMaterial = Title;
            this.Creator = Author;
            this.statusOfMaterial = itemStatus;
        }
    }
    public class Manga : Materials
    {
        private string _typeofmaterial = "Manga";
        public override string typeOfMaterial { get { return _typeofmaterial; } set { _typeofmaterial = value; } }

        public override string nameOfMaterial { get; set; }
        public override string Creator { get; set; }

        public override Status statusOfMaterial { get; set; }

        public override string dueDate { get; set; }

        public Manga(string Title, string Author, Status itemStatus)
        {

            this.nameOfMaterial = Title;
            this.Creator = Author;
            this.statusOfMaterial = itemStatus;
        }

    }
}
