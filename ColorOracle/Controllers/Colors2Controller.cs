using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColorOracle.Models;

namespace ColorOracle
{
    [Route("api/[controller]")]
    [ApiController]
    public class Colors2Controller : ControllerBase
    {
        private readonly ModelContext _context;

        public Colors2Controller(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Colors
        [HttpGet("BeautifulColors")]
        public async Task<ActionResult<IEnumerable<Color>>> GetColors()
        {
            return await _context.Colors.ToListAsync();
        }
        // GET: api/Colors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColor(decimal? id)
        {
            return await _context.Colors.FindAsync();
        }


        // PUT: api/Colors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(Color color, decimal? id)
        {
            if (id != color.ColorId) 
            {
                return BadRequest();
            }
            _context.Entry(color).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/Colors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Color>> PostColor(Color color)
        {
            _context.Colors.Add(color);
            await _context.SaveChangesAsync();
            return Ok();
        }




        // DELETE: api/Colors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Color>> DeleteColor(decimal? id)
        {
            var color = await _context.Colors.FindAsync(id);
            if (color == null )
            {
                return BadRequest();
            }
            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool ColorExists(decimal? id)
        {
            return _context.Colors.Any(e => e.ColorId == id);
        }
    }
}
