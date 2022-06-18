using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class CreateQuestionModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Body { get; set; }
    }
}
