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
                new BookModel(){Id=1,Title="MVC",Author="Ramesh",Description="This description is for MVC book.",Category="Framework",Language="English",TotalPages=214},
                new BookModel(){Id=2,Title="C#",Author="Ramesh",Description="This description is for C# book.",Category="Programming",Language="English",TotalPages=500},
                new BookModel(){Id=3,Title="Java",Author="Rudra",Description="This description is for Java book.",Category="Concepts",Language="English",TotalPages=250},
                new BookModel(){Id=4,Title="PHP",Author="Mahanvitha",Description="This description is for PHP book.",Category="Programming",Language="Hindi",TotalPages=321},
                new BookModel(){Id=5,Title="SQL",Author="Navya",Description="This description is for SQL book.",Category="DataSource",Language="English",TotalPages=300},
                new BookModel(){Id=6,Title="Azure Devops",Author="Ramesh",Description="This description is for Azure Devops book.",Category="Devops",Language="English",TotalPages=250}
            };
        }
    }
}
