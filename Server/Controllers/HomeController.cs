using Microsoft.AspNetCore.Mvc;
using MovieManager.Services;

namespace MovieManager.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    private IEmailService _emailService;
    private IEmailTemplateService _templateService;

    public HomeController(IEmailService emailService,IEmailTemplateService templateService)
    {
        _emailService = emailService;
        _templateService = templateService;
    }

    [HttpGet("/")]
    public IActionResult Home()
    {
        return Ok("Hello from movie manager server");
    }

    [HttpGet("/mail")]
    public async Task<IActionResult> SendMail()
    {
        try
        {
            // string body = @"Hello there
            // Heres some stuff
            //     1. Food
            //     2. Playlist
            //     3. Video games
            // Have a great day...
            // ";

            // await _emailService.SendEmail("bookerochieng20@gmail.com","Test Msg",body);
            
            // Generate HTML content
            var appName = "Movie-Manager";
            var userName = "Booker";

            var resetEmailUrl = "http://localhost:5173/reset-password";
            var verifymailUrl = "http://localhost:5173/verify-email?tkn=abcd";

            string htmlBody = false
                    ? await _templateService.GeneratePasswordResetEmail(appName, userName, resetEmailUrl)
                    : await _templateService.GenerateVerificationEmail(appName, userName, verifymailUrl);

            await _emailService.SendEmail("bookerochieng20@gmail.com","Verify email",htmlBody);

            return Ok(new {message = "Email sent successfully."});
        }
        catch(Exception ex)
        {
            return BadRequest(new {message="Error occured",error = ex.Message});
        }
    }
}