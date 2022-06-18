using Microsoft.AspNetCore.Identity;

namespace Test.Core.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public List<Question> Questions { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Response> Responses{ get; set; }
    }
}