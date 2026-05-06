using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Entites;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly TravixContext _travixContext;

        public HeroesController(TravixContext travixContext)
        {
            _travixContext = travixContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _travixContext.Heroes.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _travixContext.Heroes.FindAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Hero Hero)
        {
            await _travixContext.Heroes.AddAsync(Hero);
            await _travixContext.SaveChangesAsync();
            return Ok("Ekleme Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Hero Hero)
        {
            _travixContext.Heroes.Update(Hero);
            await _travixContext.SaveChangesAsync();
            return Ok("Güncelleme Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _travixContext.Heroes.FindAsync(id);
            _travixContext.Heroes.Remove(values);
            await _travixContext.SaveChangesAsync();
            return Ok("Silme Başarılı");
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
