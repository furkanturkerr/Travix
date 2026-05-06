using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Entites;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly TravixContext _travixContext;

        public AboutsController(TravixContext travixContext)
        {
            _travixContext = travixContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _travixContext.Abouts.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _travixContext.Abouts.FindAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(About about)
        {
            await _travixContext.Abouts.AddAsync(about);
            await _travixContext.SaveChangesAsync();
            return Ok("Ekleme Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> Update(About about)
        {
            _travixContext.Abouts.Update(about);
            await _travixContext.SaveChangesAsync();
            return Ok("Güncelleme Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _travixContext.Abouts.FindAsync(id);
            _travixContext.Abouts.Remove(values);
            await _travixContext.SaveChangesAsync();
            return Ok("Silme Başarılı");
        }
    }
    
}
