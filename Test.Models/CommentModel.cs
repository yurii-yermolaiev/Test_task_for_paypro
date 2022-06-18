namespace Test.Models
{
    public class CommentModel
    {
        public long Id { get; set; }
       
        public string Body { get; set; }

        public long ApplicationUserId { get; set; }

        public long QuestionId { get; set; }
    }
}
