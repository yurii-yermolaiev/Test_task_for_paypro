using AutoMapper;
using Test.Core.Entities;
using Test.Models;
using Test.Repositories.Interfaces;
using Test.Services.Interfacess;

namespace Test.Services.Business
{
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;

        private readonly IRepository<Question> _questionRepository;

        private readonly IRepository<Comment> _commentRepository;

        private readonly IResponseRepository _responseRepository;

        private readonly IUserService _userService;

        public QuestionService(IMapper mapper,
            IRepository<Question> questionRepository,
            IRepository<Comment> commentRepository,
            IResponseRepository responseRepository,
            IUserService userService)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _commentRepository = commentRepository;
            _responseRepository = responseRepository;
            _userService = userService;
        }

        public async Task CreateCommentAsync(CreateCommentModel model)
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            var comment = _mapper.Map<Comment>(model);

            comment.ApplicationUser = currentUser;

            await _commentRepository.CreateAsync(comment);

            await _commentRepository.SaveAsync();
        }

        public async Task CreateQuestionAsync(CreateQuestionModel model)
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            var question = _mapper.Map<Question>(model);

            question.ApplicationUser = currentUser;

            await _questionRepository.CreateAsync(question);

            await _questionRepository.SaveAsync();
        }

        public async Task CreateResponseAsync(CreateResponseModel model)
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            var response = _mapper.Map<Response>(model);

            response.ApplicationUser = currentUser;

            await _responseRepository.CreateAsync(response);

            await _responseRepository.SaveAsync();
        }

        public async Task<QuestionModel> GetQuestionAsync(long id)
        {
            var qestion = await _questionRepository.GetAsync(id);

            if(qestion == null)
            {
                return null;
            }

            var result = _mapper.Map<QuestionModel>(qestion);

            return result;
        }

        public async Task<IEnumerable<QuestionModel>> GetQuestionsAsync()
        {
            var qestions = await _questionRepository.GetAllAsync();

            var result = _mapper.Map<List<QuestionModel>>(qestions);

            return result;
        }

        public async Task<bool> MarkResponseAsRightAsync(long id)
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            var response = await _responseRepository.GetAsync(id);

            var question = await _questionRepository.GetAsync(response.QuestionId);

            if(question.ApplicationUserId != currentUser.Id)
            {
                return false;
            }

            await _responseRepository.MarkAsRight(id);

            await _questionRepository.SaveAsync();

            return true;
        }
    }
}
