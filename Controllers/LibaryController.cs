using Libary.Data;
using Libary.Models;
using LibaryApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Libary.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LibaryController : ControllerBase
    {
        [HttpGet]
        [Route("libary")]
        public async Task<IActionResult> GetAsync(
            [FromServices] LibaryDbContext context
        )
        {
            var libary = await context.Libary.AsNoTracking().ToListAsync();
            return Ok(libary);
        }

        [HttpGet]
        [Route("libary/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] LibaryDbContext context,
            [FromRoute] int id)
        {
            var libary = await context.Libary.AsNoTracking().FirstOrDefaultAsync(book => book.Id == id);
            return libary == null ? NotFound() : Ok(libary);
        }

        [HttpPost("libary")]
        public async Task<IActionResult> GetPostAsync(
            [FromServices] LibaryDbContext context,
            [FromBody] LibaryViewModels models)
        {
            if (!ModelState.IsValid) return BadRequest();

            var libary = new LibaryModel
            {
                Name = models.Name,
                Author = models.Author,
                Description = models.Description,
                ImageUrl = models.ImageUrl,
                DateRegister = DateTime.Now,
            };

            try
            {
                await context.Libary.AddAsync(libary);
                await context.SaveChangesAsync();
                return Created($"v1/libary/{libary.Id}", libary);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("libary/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] LibaryDbContext context,
            [FromBody] LibaryViewModels models,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var libary = await context.Libary.FirstOrDefaultAsync(book => book.Id == id);

            if (libary == null) return NotFound();

            try
            {
                libary.Name = models.Name;
                libary.Author = models.Author;
                libary.Description = models.Description;
                libary.ImageUrl = models.ImageUrl;
                libary.DateUpdatedDb = DateTime.Now;

                context.Libary.Update(libary);
                await context.SaveChangesAsync();
                return Ok(libary);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("libary/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] LibaryDbContext context,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var libary = await context.Libary.FirstOrDefaultAsync(book => book.Id == id);

            if (libary == null) return NotFound();

            try
            {
                context.Libary.Remove(libary);
                await context.SaveChangesAsync();
                return Ok("Obra excluída com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
