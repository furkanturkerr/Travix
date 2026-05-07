using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Entites;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly TravixContext _travixContext;

        public BlogsController(TravixContext travixContext)
        {
            _travixContext = travixContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _travixContext.Blogs.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _travixContext.Blogs.FindAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog Blog)
        {
            Blog.CreateTime = DateTime.Now;
            await _travixContext.Blogs.AddAsync(Blog);
            await _travixContext.SaveChangesAsync();
            return Ok("Ekleme Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Blog Blog)
        {
            _travixContext.Blogs.Update(Blog);
            await _travixContext.SaveChangesAsync();
            return Ok("Güncelleme Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _travixContext.Blogs.FindAsync(id);
            _travixContext.Blogs.Remove(values);
            await _travixContext.SaveChangesAsync();
            return Ok("Silme Başarılı");
        }

        [HttpGet("BlogTrue")]
        public async Task<IActionResult> BlogTrue()
        {
            var values = await _travixContext.Blogs.Where(x => x.IsStatus == true).ToListAsync();
            return Ok(values);
        }

        [HttpGet("isStatus/{id:int}")]
        public async Task<IActionResult> IsStatus(int id)
        {
            var value = await _travixContext.Blogs.FindAsync(id);
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
