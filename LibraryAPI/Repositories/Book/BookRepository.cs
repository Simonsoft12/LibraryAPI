using Dapper;
using LibraryAPI.Entities.DTOs.Book;
using LibraryAPI.Models.Book;
using System.Data;

namespace LibraryAPI.Repositories.Book
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnection _db;

        public BookRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<BookDTO>> GetAllAsync(BookSearchModel model)
        {
            try
            {
                var sql = @"
                    SELECT * FROM Book
                    WHERE 
                        (@Title IS NULL OR Title LIKE '%' + @Title + '%') AND
                        (@Author IS NULL OR Author LIKE '%' + @Author + '%') AND
                        (@ISBN IS NULL OR ISBN = @ISBN) AND
                        (@StatusId IS NULL OR StatusId = @StatusId)
                    ORDER BY 
                        CASE WHEN @SortBy = 'title' THEN Title END,
                        CASE WHEN @SortBy = 'author' THEN Author END,
                        CASE WHEN @SortBy = 'statusid' THEN StatusId END
                ";

                 if (model.Page.HasValue && model.PageSize.HasValue)
                 {
                     sql += @"OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
                 }

                var offset = model.Page.HasValue && model.PageSize.HasValue
                    ? (model.Page.Value - 1) * model.PageSize.Value
                    : (int?)null;

                var pageSize = model.PageSize;

                var parameters = new
                {
                    Title = model.Title,
                    Author = model.Author,
                    ISBN = model.ISBN,
                    StatusId = model.StatusId,
                    SortBy = model.SortBy,
                    Offset = offset,
                    PageSize = pageSize
                };

                return await _db.QueryAsync<BookDTO>(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Entities.Book> GetByIdAsync(int id)
        {
            try
            {
                const string sql = "SELECT * FROM Book WHERE Id = @Id";
                return await _db.QueryFirstOrDefaultAsync<Entities.Book>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task AddAsync(Entities.Book book)
        {
            try
            {
                const string sql = @"
                    INSERT INTO Book (Title, Author, ISBN, StatusId)
                    VALUES (@Title, @Author, @ISBN, @StatusId)";
                await _db.ExecuteAsync(sql, book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAsync: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAsync(Entities.Book book)
        {
            try
            {
                const string sql = @"
                    UPDATE Book
                    SET Title = @Title, Author = @Author, ISBN = @ISBN, StatusId = @StatusId
                    WHERE Id = @Id";
                await _db.ExecuteAsync(sql, book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateAsync: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                const string sql = "DELETE FROM Book WHERE Id = @Id";
                await _db.ExecuteAsync(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            try
            {
                const string sql = "SELECT COUNT(1) FROM Book WHERE Id = @Id";
                var count = await _db.ExecuteScalarAsync<int>(sql, new { Id = id });
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ExistsAsync: {ex.Message}");
                throw;
            }
        }
    }
}