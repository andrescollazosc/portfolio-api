using Microsoft.AspNetCore.Mvc;

namespace IdeaCompany.Portfolio.Api.Controllers;

[ApiController]
[Route("/api/email-settings/")]
public class EmailSettingController : Controller
{
    [HttpPost]
    [Route("")]
    public async Task<ActionResult<string>> Create(string portfolioId)
    {
        // TODO: implement logic to add email settings here
        
        throw new System.NotImplementedException();
    }
}