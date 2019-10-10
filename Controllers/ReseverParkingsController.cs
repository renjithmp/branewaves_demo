using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReseverParkingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReseverParkingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReseverParkings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReseverParking>>> GetReseverParking()
        {
            return await _context.ReseverParking.ToListAsync();
        }

        // GET: api/ReseverParkings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReseverParking>> GetReseverParking(int id)
        {
            var reseverParking = await _context.ReseverParking.FindAsync(id);

            if (reseverParking == null)
            {
                return NotFound();
            }

            return reseverParking;
        }

        // PUT: api/ReseverParkings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReseverParking(int id, ReseverParking reseverParking)
        {
            if (id != reseverParking.Id)
            {
                return BadRequest();
            }

            _context.Entry(reseverParking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReseverParkingExists(id))
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

        // POST: api/ReseverParkings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ReseverParking>> PostReseverParking(ReseverParking reseverParking)
        {
            _context.ReseverParking.Add(reseverParking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReseverParking", new { id = reseverParking.Id }, reseverParking);
        }

        // DELETE: api/ReseverParkings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReseverParking>> DeleteReseverParking(int id)
        {
            var reseverParking = await _context.ReseverParking.FindAsync(id);
            if (reseverParking == null)
            {
                return NotFound();
            }

            _context.ReseverParking.Remove(reseverParking);
            await _context.SaveChangesAsync();

            return reseverParking;
        }

        private bool ReseverParkingExists(int id)
        {
            return _context.ReseverParking.Any(e => e.Id == id);
        }
    }
}
