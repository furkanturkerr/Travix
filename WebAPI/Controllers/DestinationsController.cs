using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Entites;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly TravixContext _travixContext;

        public DestinationsController(TravixContext travixContext)
        {
            _travixContext = travixContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _travixContext.Destinations.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _travixContext.Destinations.FindAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Destination Destination)
        {
            await _travixContext.Destinations.AddAsync(Destination);
            await _travixContext.SaveChangesAsync();
            return Ok("Ekleme Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Destination Destination)
        {
            _travixContext.Destinations.Update(Destination);
            await _travixContext.SaveChangesAsync();
            return Ok("Güncelleme Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _travixContext.Destinations.FindAsync(id);
            _travixContext.Destinations.Remove(values);
            await _travixContext.SaveChangesAsync();
            return Ok("Silme Başarılı");
        }
    }
}
