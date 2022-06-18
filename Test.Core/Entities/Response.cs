using System.ComponentModel.DataAnnotations;

namespace Test.Core.Entities
{
    public class Response
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(1000)]
        public string Body { get; set; }

        public bool IsRight { get; set; }

        public long ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public long QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
