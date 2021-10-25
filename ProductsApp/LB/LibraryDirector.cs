using Dvir_Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Dvir_Library.LB
{
    public class LibraryDirector
    {
        public static Book[] LoadData()
        {
            List<Book> arrays = new List<Book>();
            try {
                    using (StreamReader r = new StreamReader(@"C:\Users\Berlowitz\source\repos\ProductsApp\ProductsApp\books_list.txt"))
                    {
                        string json = r.ReadToEnd();
                        arrays = JsonConvert.DeserializeObject<List<Book>>(json);
                    }
            }
            catch (IOException e)
            {
                e.ToString();
            }
            return ListToArr(arrays);
        }


        public static void SaveData(Book[] arrays)
        {
            try
            {
                string json = JsonConvert.SerializeObject(arrays.ToArray());

                //write string to file
                System.IO.File.WriteAllText(@"C:\Users\Berlowitz\source\repos\ProductsApp\ProductsApp\books_list.txt", json);
            }catch(IOException ex)
            {
                ex.ToString();
            }
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


        public static Book GetBookById(int id, Book[] arrays)
        {
            Book theB = null;
            for(int i = 0; i < arrays.Length; i++)
            {
                if(arrays[i].id == id)
                {
                    theB = arrays[i];
                }
            }
            return theB;
        }


        public static Book GetBookByName(String name, Book[] arrays)
        {
            Book theB = null;
            String name1 = name.Replace(" ", string.Empty).ToUpper();
            for (int i = 0; i < arrays.Length; i++)
            {
                if (arrays[i].name.Replace(" ", string.Empty).ToUpper() == name1)
                {
                    theB = arrays[i];
                    return theB;
                }
            }
                return null;
        }


        public static List<Book> GetBooksByAva(bool ava, Book[] arrays)
        {
            List<Book> theBs = new List<Book>();
            String ava1 = "";
            if (ava) { ava1 = "available "; } else { ava1 = "borrowed "; }
            for(int i = 0; i < arrays.Length; i++)
            {
                if (arrays[i].availability == ava1)
                {
                    theBs.Add(arrays[i]);
                }
            }
            return theBs;
        }
    }
}