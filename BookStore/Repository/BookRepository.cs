using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext=null;
        public BookRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;

        }

        public async Task<int> AddNewBook(Books bookobj)
        {
            var newBook = new Books()
            {
                Title = bookobj.Title,
                Author = bookobj.Author,
                TotalPages = bookobj.TotalPages.HasValue ? bookobj.TotalPages : 0 ,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                Description = bookobj.Description
            };
            await _bookStoreDbContext.AddAsync(newBook);
            await _bookStoreDbContext.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<Books>> GetAllBooks()
        { 
            var books = new List<Books>();
            var allbooks = await _bookStoreDbContext.Books.ToListAsync();
            if(allbooks?.Any()==true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new Books()
                    {
                        Id=book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        TotalPages = book.TotalPages,
                        Category=book.Category,
                        Language=book.Language,                    
                        Description = book.Description
                    });
                    
                }

            }
            return books;
        }
        public async Task<Books> GetBook(int id)
        {
            var book = await _bookStoreDbContext.Books.FindAsync(id);
            if (book!=null)
            {
                var bookDetails = new Books()
                {
                    Id=book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    TotalPages = book.TotalPages,
                    Category = book.Category,
                    Language = book.Language,
                    Description = book.Description
                };
                return bookDetails;
            }
            return null;
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
