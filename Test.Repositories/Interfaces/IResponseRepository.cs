using Test.Core.Entities;

namespace Test.Repositories.Interfaces
{
    public interface IResponseRepository : IRepository<Response>
    {
        public Task MarkAsRight(long id);
    }
}
