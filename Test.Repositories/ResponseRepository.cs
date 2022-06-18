using Microsoft.EntityFrameworkCore;
using Test.Core.Entities;
using Test.Infrastructure;
using Test.Repositories.Interfaces;

namespace Test.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly ApplicationDbContext _context;

        public ResponseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Response item)
        {
            await _context.Responses.AddAsync(item);
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

        public async Task<Response?> GetAsync(long id)
        {
            return await _context.Responses
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Response>> GetAllAsync()
        {
            return await _context.Responses.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Response item)
        {
            _context.Update(item);
        }

        public async Task MarkAsRight(long id)
        {
            var response = await _context.Responses
                .FirstOrDefaultAsync(d => d.Id == id);

            var rightResponse = await _context.Responses
                .FirstOrDefaultAsync(r => r.QuestionId == response.QuestionId
                && r.IsRight == true);

            if(rightResponse != null)
            {
                rightResponse.IsRight = false;
            }

            response.IsRight = true;
        }
    }
}
