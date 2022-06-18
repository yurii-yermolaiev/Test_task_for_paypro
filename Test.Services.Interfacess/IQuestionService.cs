using Test.Models;

namespace Test.Services.Interfacess
{
    public interface IQuestionService
    {
        public Task CreateQuestionAsync(CreateQuestionModel model);

        public Task CreateCommentAsync(CreateCommentModel model);

        public Task CreateResponseAsync(CreateResponseModel model);

        public Task<QuestionModel> GetQuestionAsync(long id);

        public Task<IEnumerable<QuestionModel>> GetQuestionsAsync();

        public Task<bool> MarkResponseAsRightAsync(long id);
    }
}
