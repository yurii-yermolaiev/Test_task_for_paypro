using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class CreateCommentModel
    {
        [MaxLength(1000)]
        public string Body { get; set; }

        public long QuestionId { get; set; }
    }
}
