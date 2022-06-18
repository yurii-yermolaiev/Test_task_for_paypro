namespace Test.Models
{
    public class QuestionModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public long ApplicationUserId { get; set; }

        public List<CommentModel> Comments { get; set; }

        public List<ResponseModel> Responses { get; set; }
    }
}
