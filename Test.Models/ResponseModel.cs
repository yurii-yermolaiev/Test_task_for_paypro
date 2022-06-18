namespace Test.Models
{
    public class ResponseModel
    {
        public long Id { get; set; }

        public string Body { get; set; }

        public bool IsRight { get; set; }

        public long ApplicationUserId { get; set; }

        public long QuestionId { get; set; }

    }
}
