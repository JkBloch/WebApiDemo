using System.Collections.Generic;
using System.Threading.Tasks;
using JkBook.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace JkBook.Repository
{
    public interface IBookRepository
    {
         Task<List<BookModel>> GetAllBooksAsync();
         Task<List<BookModel>> SearchBooksAsync(string title, string author);
        Task<BookModel> GetBookByIdAsync(int id);

        Task<int> AddNewBookAsync(BookModel model);
        Task<int> UpdateBookAsync(int bookId, BookModel model);

        Task<int> UpdateBookAsyncPatch(int bookId, JsonPatchDocument model);
        Task<int> DeleteBookAsync(int bookId);




    }
}