using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Newtonsoft.Json;

namespace Dvir_Library.Models
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public string availability { get; set; }

        public bool getAvailabailityB()
        {
            if (this.availability == "available ")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void setAvailabilityB(bool ava)
        {
            if (ava == true)
            {
                this.availability = "available ";
            }
            else
            {
                this.availability = "borrowed ";
            }
        }
        public void setBook(Book b)
        {
            this.name = b.name + "";
            this.availability = b.availability + "";
        }

        public static String ListToString(List<Book> arrays, int booksCount)
        {
            String data = "";
            for (int i = 0; i < booksCount; i++)
            {
                data += arrays[i].name;
                data += arrays[i].availability;
                data += "\n";
            }
            return data;
        }

        public String toString()
        {
            return "the book " + this.name + "is " + this.availability + ".";
        }

        public static Book[] ListToArr(List<Book> arrays)
        {
            Book[] arr = new Book[arrays.Count()];
            for (int i = 0; i < arrays.Count(); i++)
            {
                arr[i] = arrays[i];
            }
            return arr;
        }

        public static List<Book> arrToList(Book[] arr)
        {
            List<Book> arrays = new List<Book>();
            for (int i = 0; i < arr.Count(); i++)
            {
                arrays.Add(arr[i]);
            }
            return arrays;
        }
        public Book (int id, String name, String availability)
        {
            this.id = id;
            this.name = name;
            this.availability = availability;
        }
    }
}