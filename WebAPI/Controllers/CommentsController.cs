using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Entites;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly TravixContext _travixContext;

        public CommentsController(TravixContext travixContext)
        {
            _travixContext = travixContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _travixContext.Comments.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _travixContext.Comments.FindAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment Comment)
        {
            await _travixContext.Comments.AddAsync(Comment);
            await _travixContext.SaveChangesAsync();
            return Ok("Ekleme Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Comment Comment)
        {
            _travixContext.Comments.Update(Comment);
            await _travixContext.SaveChangesAsync();
            return Ok("Güncelleme Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _travixContext.Comments.FindAsync(id);
            _travixContext.Comments.Remove(values);
            await _travixContext.SaveChangesAsync();
            return Ok("Silme Başarılı");
        }
        
        [HttpGet("CommentTrue")]
        public async Task<IActionResult> CommentTrue()
        {
            var values = await _travixContext.Comments.Where(x => x.IsStatus == true).ToListAsync();
            return Ok(values);
        }

        [HttpGet("isStatus/{id:int}")]
        public async Task<IActionResult> IsStatus(int id)
        {
            var value = await _travixContext.Comments.FindAsync(id);
            if (value.IsStatus == true)
            {
                value.IsStatus = false;
                await _travixContext.SaveChangesAsync();
            }
            else
            {
                value.IsStatus = true;
                await _travixContext.SaveChangesAsync();
            }

            return Ok("Başarılı");
        }
    }
}
