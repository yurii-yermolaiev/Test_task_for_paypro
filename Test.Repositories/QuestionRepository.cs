using Microsoft.EntityFrameworkCore;
using Test.Core.Entities;
using Test.Infrastructure;
using Test.Repositories.Interfaces;

namespace Test.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Question item)
        {
            await _context.Questions.AddAsync(item);
        }

        public async Task DeleteAsync(long id)
        {
            var item = await _context.Questions
                .Include(d => d.Comments)
                .Include(d => d.Responses)
                .FirstOrDefaultAsync(d => d.Id == id);
            
            if (item != null)
            {
                _context.Comments.RemoveRange(item.Comments);

                _context.Responses.RemoveRange(item.Responses);
            
                _context.Remove(item);
            }
        }

        public async Task<Question?> GetAsync(long id)
        {
            return await _context.Questions
                .Include(d => d.Comments)
                .Include(d => d.Responses)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Question item)
        {
            _context.Update(item);
        }
    }
}
