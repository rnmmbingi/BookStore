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

        public async Task<int> AddNewBook(BookModel bookobj)
        {
            var newBook = new Books()
            {
                Title = bookobj.Title,
                Author = bookobj.Author,
                TotalPages = bookobj.TotalPages.HasValue ? bookobj.TotalPages : 0 ,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                Description = bookobj.Description,
                LanguageId=bookobj.LanguageId
                

            };
            await _bookStoreDbContext.AddAsync(newBook);
            await _bookStoreDbContext.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        { 
            var books = new List<BookModel>();
            var allbooks = await _bookStoreDbContext.Books.ToListAsync();
            if(allbooks?.Any()==true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Id=book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        TotalPages = book.TotalPages.HasValue? book.TotalPages: 0 ,
                        Category=book.Category,
                        LanguageId = book.LanguageId, 
                        
                        Description = book.Description
                    });
                    
                }

            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            return await _bookStoreDbContext.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    TotalPages = book.TotalPages,
                    Category = book.Category,
                    LanguageId = book.LanguageId,
                    Description = book.Description,
                    Language = book.Language.Name,
                }).FirstOrDefaultAsync();              
        }
        public List<BookModel> SearchBook(string title,string author)
        {
            return null;
        }      

    }
}
