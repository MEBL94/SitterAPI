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
    public class SitterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SitterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sitter
        [HttpGet]
        public IEnumerable<Sitter> GetSitters()
        {
            return _context.Sitters;
        }

        // GET: api/Sitter/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSitter([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sitter = await _context.Sitters.FindAsync(id);

            if (sitter == null)
            {
                return NotFound();
            }

            return Ok(sitter);
        }

        // PUT: api/Sitter/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSitter([FromRoute] long id, [FromBody] Sitter sitter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sitter.Id)
            {
                return BadRequest();
            }

            _context.Entry(sitter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SitterExists(id))
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

        // POST: api/Sitter
        [HttpPost]
        public async Task<IActionResult> PostSitter([FromBody] Sitter sitter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sitters.Add(sitter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSitter", new { id = sitter.Id }, sitter);
        }

        // DELETE: api/Sitter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSitter([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sitter = await _context.Sitters.FindAsync(id);
            if (sitter == null)
            {
                return NotFound();
            }

            _context.Sitters.Remove(sitter);
            await _context.SaveChangesAsync();

            return Ok(sitter);
        }

        private bool SitterExists(long id)
        {
            return _context.Sitters.Any(e => e.Id == id);
        }
    }
}