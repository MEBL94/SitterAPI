using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SitterAPI.Models;

namespace SitterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BabyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Baby
        [HttpGet]
        public IEnumerable<Baby> GetBabies()
        {
            return _context.Babies;
        }

        // GET: api/Baby/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBaby([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var baby = await _context.Babies.FindAsync(id);

            if (baby == null)
            {
                return NotFound();
            }

            return Ok(baby);
        }

        // PUT: api/Baby/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaby([FromRoute] long id, [FromBody] Baby baby)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != baby.Id)
            {
                return BadRequest();
            }

            _context.Entry(baby).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BabyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Baby
        [HttpPost]
        public async Task<IActionResult> PostBaby([FromBody] Baby baby)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Babies.Add(baby);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaby", new { id = baby.Id }, baby);
        }

        // DELETE: api/Baby/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaby([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var baby = await _context.Babies.FindAsync(id);
            if (baby == null)
            {
                return NotFound();
            }

            _context.Babies.Remove(baby);
            await _context.SaveChangesAsync();

            return Ok(baby);
        }

        private bool BabyExists(long id)
        {
            return _context.Babies.Any(e => e.Id == id);
        }
    }
}