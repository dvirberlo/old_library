using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Dvir_Library.Models;
using System.Collections;
using Dvir_Library.LB;

namespace Dvir_Library.Controllers
{
    public class BooksController : ApiController
    {
        Book[] arrays = LibraryDirector.LoadData();

        public IEnumerable<Book> GetBooks()
        {
            return arrays;
        }
        public Book GetBookById(int id)
        {
            return LibraryDirector.GetBookById(id, arrays);
        }
        public Book GetBookByName(String name)
        {
            return LibraryDirector.GetBookByName(name, arrays);
        }
        public IEnumerable<Book> GetBooksByAva(bool ava)
        {
            return LibraryDirector.GetBooksByAva(ava, arrays);
        }
    }
}
