using Microsoft.EntityFrameworkCore;
using Test.Core.Entities;
using Test.Infrastructure;
using Test.Repositories.Interfaces;

namespace Test.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Comment item)
        {
            await _context.Comments.AddAsync(item);
        }

        public async Task DeleteAsync(long id)
        {
            var item = await _context.Responses
                .FirstOrDefaultAsync(d => d.Id == id);

            if (item != null)
            {
                _context.Remove(item);
            }
        }

        public async Task<Comment?> GetAsync(long id)
        {
            return await _context.Comments
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment item)
        {
            _context.Comments.Update(item);
        }

    }
}
