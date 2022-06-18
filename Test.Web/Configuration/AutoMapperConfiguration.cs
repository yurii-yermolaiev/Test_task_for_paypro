using AutoMapper;
using Test.Core.Entities;
using Test.Models;

namespace Test.Web.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthModel, ApplicationUser>();

            CreateMap<CreateQuestionModel, Question>();
            CreateMap<Question, QuestionModel>();

            CreateMap<CreateCommentModel, Comment>();
            CreateMap<Comment, CommentModel>();

            CreateMap<CreateResponseModel, Response>();
            CreateMap<Response, ResponseModel>();
        }
    }
}
