using AutoMapper;
using IdeaCompany.Portfolio.Api.Controllers.Dtos;
using IdeaCompany.Portfolio.Core.EmailSettings.Models;

namespace IdeaCompany.Portfolio.Api.Infrastructure.Automappings;

public class EmailProfile : Profile
{
    public EmailProfile()
    {
        CreateMap<Email, EmailDto>().ReverseMap();
        CreateMap<EmailSettingDto, EmailSetting>().ReverseMap();
    }
}