using System.ComponentModel.DataAnnotations;

namespace Test.Core.Entities
{
    public class Question
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Body { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Response> Responses { get; set; }

        public long ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
