using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wingslompson.Data;
using Wingslompson.Models;

namespace Wingslompson.TodoController
{
    [ApiController]
    [Route(template: "v1")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        [Route(template: "Wingsons")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            var Wingsonso = await context.Wings.AsNoTracking().ToListAsync();
            return Ok(Wingsonso);
        }

        [HttpGet]
        [Route(template: "Wingsons/{id}")]
        public async Task<IActionResult> GetByAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var Wingsonso = await context.Wings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Wingsonso == null ? NotFound() : Ok(Wingsonso);
        }

        [HttpPost("Wingsons")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateTodoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Wings = new Wings
            {
                Date = DateTime.Now,
                Done = false,
                Title = model.Title
            };

            try
            {
                await context.Wings.AddAsync(Wings);
                await context.SaveChangesAsync();
                return Created($"v1/Wingson/{Wings.Id}", Wings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Wingsons/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateTodoViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Wing = await context.Wings.FirstOrDefaultAsync(x => x.Id == id);

            if (Wing == null)
                return NotFound();

            try
            {
                Wing.Title = model.Title;

                context.Wings.Update(Wing);
                await context.SaveChangesAsync();

                return Ok(Wing);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpDelete("Wingsons/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var Wing = await context.Wings.FirstOrDefaultAsync(x => x.Id == id);
            
            try
            {
            context.Wings.Remove(Wing);
            await context.SaveChangesAsync();
            return Ok(Wing);
            }
            catch (Exception e)
            {
                return BadRequest();
            }     
        }
    }
}
