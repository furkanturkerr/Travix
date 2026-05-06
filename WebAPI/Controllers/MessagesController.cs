using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Entites;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly TravixContext _travixContext;
        private readonly IOpenAIService _openAIService;

        public MessagesController(TravixContext travixContext, IOpenAIService openAıService)
        {
            _travixContext = travixContext;
            _openAIService = openAıService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _travixContext.Messages.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _travixContext.Messages.FindAsync(id);
            value.IsRead = true;
            await _travixContext.SaveChangesAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Message message)
        {
            var aiResponse = await _openAIService
                .CreateMessageWithOpenAIAsync(message.Messages);

            message.MessageAI = aiResponse;

            await _travixContext.Messages.AddAsync(message);
            await _travixContext.SaveChangesAsync();

            return Ok("Ekleme Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _travixContext.Messages.FindAsync(id);
            _travixContext.Messages.Remove(values);
            await _travixContext.SaveChangesAsync();
            return Ok("Silme Başarılı");
        }

        [HttpGet("MessagesTrue")]
        public async Task<IActionResult> MessagesTrue()
        {
            var values = await _travixContext.Messages.Where(x => x.IsRead == true).ToListAsync();
            return Ok(values);
        }

        [HttpGet("isStatus/{id:int}")]
        public async Task<IActionResult> IsStatus(int id)
        {
            var value = await _travixContext.Messages.FindAsync(id);
            if (value.IsRead == true)
            {
                value.IsRead = false;
                await _travixContext.SaveChangesAsync();
            }
            else
            {
                value.IsRead = true;
                await _travixContext.SaveChangesAsync();
            }

            return Ok("Başarılı");
        }
    }
}
