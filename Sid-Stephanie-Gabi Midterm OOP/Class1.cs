using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;


namespace Sid_Stephanie_Gabi_Midterm_OOP
{

    public enum Status
    {
        CHECKEDOUT,
        ONSHELF,
        VANISHED

    }
    public abstract class Materials
    {
        public abstract string typeOfMaterial { get; set; }
        public abstract string nameOfMaterial { get; set; }

        public abstract string Creator { get; set; }

        public abstract Status statusOfMaterial { get; set; }

        public abstract string dueDate { get; set; }

        public abstract int ISBN { get; set; }

    }
    public class potionsSupplies : Materials
    {
        private string _typeofmaterial = "POTIONS SUPPLIES";
        public override string typeOfMaterial { get { return _typeofmaterial; } set { _typeofmaterial = value; } }

        public override string nameOfMaterial { get; set; }
        public override string Creator { get; set; }

        public override Status statusOfMaterial { get; set; }

        public override string dueDate { get; set; }

        public override int ISBN { get; set; }

        public potionsSupplies(int ISBN, string nameOfMaterial, string Creator, Status itemStatus)
        {

            this.nameOfMaterial = nameOfMaterial;
            this.Creator = Creator;
            this.statusOfMaterial = itemStatus;
            this.ISBN = ISBN;
        }

    }
    public class Book : Materials
    {
        private string _typeofmaterial = "BOOKS";
        public override string typeOfMaterial { get { return _typeofmaterial; } set { _typeofmaterial = value; } }

        public override string nameOfMaterial { get; set; }
        public override string Creator { get; set; }

        public override Status statusOfMaterial { get; set; }

        public override string dueDate { get; set; }

        public override int ISBN { get; set; }

        public Book(int ISBN, string Title, string Author, Status itemStatus)
        {

            this.nameOfMaterial = Title;
            this.Creator = Author;
            this.statusOfMaterial = itemStatus;
            this.ISBN = ISBN;
        }
    }
    public class Manga : Materials
    {
        private string _typeofmaterial = "MANGA";
        public override string typeOfMaterial { get { return _typeofmaterial; } set { _typeofmaterial = value; } }

        public override string nameOfMaterial { get; set; }
        public override string Creator { get; set; }

        public override Status statusOfMaterial { get; set; }

        public override string dueDate { get; set; }

        public override int ISBN { get; set; }

        public Manga(int ISBN, string Title, string Author, Status itemStatus)
        {

            this.nameOfMaterial = Title;
            this.Creator = Author;
            this.statusOfMaterial = itemStatus;
            this.ISBN = ISBN;
        }

    }
}
