using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBook(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title,string author)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(author)).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1,Title="MVC",Author="Ramesh"},
                new BookModel(){Id=2,Title="C#",Author="Ramesh"},
                new BookModel(){Id=3,Title="Java",Author="Rudra"},
                new BookModel(){Id=4,Title="PHP",Author="Ramesh"},
                new BookModel(){Id=5,Title="SQL",Author="Navya"}
            };
        }
    }
}
