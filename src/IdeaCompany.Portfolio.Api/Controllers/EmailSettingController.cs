using AutoMapper;
using IdeaCompany.Portfolio.Api.Controllers.Dtos;
using IdeaCompany.Portfolio.Core.EmailSettings.Models;
using IdeaCompany.Portfolio.Core.EmailSettings.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdeaCompany.Portfolio.Api.Controllers;

[ApiController]
[Route("/api/email-settings/{portfolioId}/")]
public class EmailSettingController : Controller
{
    private IEmailSettingsService EmailSettingsService { get; }
    private IMapper Mapper { get; }

    public EmailSettingController(IEmailSettingsService emailSettingsService, IMapper mapper)
    {
        EmailSettingsService = emailSettingsService;
        Mapper = mapper;
    }
    
    [HttpPost]
    [Route("")]
    public async Task<ActionResult<string>> Create(string portfolioId, [FromBody] EmailSettingDto emailSettingDto)
    {
        try
        {
            var emailSetting = Mapper.Map<EmailSetting>(emailSettingDto);
            emailSetting.PortfolioId = Guid.NewGuid();
            await EmailSettingsService.AddEmailSetting(emailSetting);
            
            return Ok("The email settings have been created.");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("send-email")]
    public async Task<ActionResult<string>> SendEmail(string portfolioId, EmailDto emailDto)
    {
        try
        {
            var email = Mapper.Map<Email>(emailDto);
            await EmailSettingsService.SendEmail(email);

            return Ok("Email sent successfully");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}