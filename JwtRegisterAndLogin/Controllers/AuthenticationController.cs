using Application.Interfaces;
using Application.RequestHandlers.AuthenticationRequests.Command.Register;
using Application.RequestHandlers.AuthenticationRequests.Command.VerificateEmail;
using Application.RequestHandlers.AuthenticationRequests.Query.CheckIsEmailExist;
using Application.RequestHandlers.AuthenticationRequests.Query.Login;
using Application.RequestHandlers.AuthenticationRequests.Query.SentCodeToVerificationEmail;
using AutoMapper;
using Domain.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtRegisterAndLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        public AuthenticationController(ISender sender, IMapper mapper, IMailService mailService)
        {
            _sender = sender;
            _mapper = mapper;
            _mailService = mailService;
        }
        [HttpGet("login")] 
        public async Task<IActionResult> Login([FromQuery]LoginRequest loginRequest)
        {
            var result = await _sender.Send(_mapper.Map<LoginQuery>(loginRequest));
            return Ok(result);
        }
        [HttpPost("sent-code-to-verification-email")]
        public async Task<IActionResult> SentCodeToVerificationEmail([FromQuery] string email)
        {
            var result = await _sender.Send(new SentCodeToVerificationEmailQuery(email));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }
        [HttpPut("verificate-email")]
        public async Task<IActionResult> VerificateEmail([FromQuery] VerificateEmailRequest verificateEmailRequest)
        {
            var result = await _sender.Send(_mapper.Map<VerificateEmailCommand>(verificateEmailRequest));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromQuery]RegisterRequest registerRequest)
        {
            var result = await _sender.Send(_mapper.Map<RegisterCommand>(registerRequest));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }
        [HttpGet("test-sending-mail")]
        public async Task<IActionResult> TestSentMessage([FromQuery] string email,string subject,string text)
        {
            //var result = await _sender.Send(new CheckIsEmailExistQuery(email));
            await _mailService.SentMailAsync(email,subject,text);
            return Ok();
        }
    }
}
