using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test.Models;
using Test.Services.Interfacess;

namespace Test.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        private readonly ILogger<QuestionController> _logger;

        public QuestionController(IQuestionService questionService,
            ILogger<QuestionController> logger)
        {
            _questionService = questionService;
            _logger = logger;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("question")]
        public async Task<ActionResult> PostQuestionAsync([FromBody] CreateQuestionModel model)
        {
            _logger.LogInformation($"method: {nameof(PostQuestionAsync)}, body : {JsonConvert.SerializeObject(model)}");

            await _questionService.CreateQuestionAsync(model);

            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("comment")]
        public async Task<ActionResult> PostCommentAsync([FromBody] CreateCommentModel model)
        {
            _logger.LogInformation($"method: {nameof(PostCommentAsync)}, body : {JsonConvert.SerializeObject(model)}");

            await _questionService.CreateCommentAsync(model);

            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("response")]
        public async Task<ActionResult> PostResponseAsync([FromBody] CreateResponseModel model)
        {
            _logger.LogInformation($"method: {nameof(PostCommentAsync)}, body : {JsonConvert.SerializeObject(model)}");

            await _questionService.CreateResponseAsync(model);

            return Ok();
        }

        [HttpGet("questions")]
        public async Task<ActionResult<IEnumerable<QuestionModel>>> GetQuestionsAsync()
        {
            var result = await _questionService.GetQuestionsAsync();

            return Ok(result);
        }

        [HttpGet("questions/{id}")]
        public async Task<ActionResult<QuestionModel>> GetQuestionAsync([FromRoute] long id)
        {
            _logger.LogInformation($"method: {nameof(GetQuestionAsync)}, id : {id}");

            var result = await _questionService.GetQuestionAsync(id);

            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("responses/{id}/status-is-right")]
        public async Task<ActionResult> PatchMarkStatusIsRightAsync([FromRoute] long id)
        {
            _logger.LogInformation($"method: {nameof(PatchMarkStatusIsRightAsync)}, id : {id}");

            var result = await _questionService.MarkResponseAsRightAsync(id);

            if(!result)
            {
                return StatusCode(403);
            }

            return Ok();
        }
    }
}
