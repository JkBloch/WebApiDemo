using AutoMapper;
using JkBook.Database;
using JkBook.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JkBook.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context,IConfiguration configuration,IMapper mapper )
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }

        public async Task<List<BookModel>> SearchBooksAsync(string title,string author)
        {
            var records = await _context.Books.Where(x=>x.Title.Contains(title)).Where(x=>x.Author.Contains(author)).ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }

        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return _mapper.Map<BookModel>(book);    
        }

        public async Task<int> AddNewBookAsync(BookModel model)
        {
            var newBook = new Books()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,          
            };         
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<int> UpdateBookAsync(int bookId,BookModel model)
        {
            var book = new Books()
            {
                Id=bookId,
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,              
            };
            _context.Books.Update(book);
            var result = await _context.SaveChangesAsync();
            return result;         
        }

        public async Task<int> UpdateBookAsyncPatch(int bookId, JsonPatchDocument model)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book !=null)
            {
                model.ApplyTo(book);
                var result =await _context.SaveChangesAsync();
                return result;
            }
            return 0;

        }


        public async Task<int> DeleteBookAsync(int bookId)
        {
            var book = new Books { Id = bookId };
            _context.Remove(book);
                var result = await _context.SaveChangesAsync();
                return result;
        }

     


     
      
  
    }
}

