using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Adresgegevens.Data;
using Adresgegevens.Models;

namespace AdresgegevensAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdresgegevensController : Controller
    {
        private readonly AdresgegevensContext _context;

        public AdresgegevensController(AdresgegevensContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetAdresgegevens")]
        // GET: Adresgegevens
        public async Task<ActionResult<IEnumerable<Adresgegeven>>> GetAdresgegevens()
        {
            if(_context.Adresgegevens == null)
            {
                return NotFound();
            }
            return await _context.Adresgegevens.ToListAsync();

        }
        [HttpPost(Name = "PostAdresgegevens")]
        //Post: Adresgegevens
        public async Task<ActionResult<Adresgegeven>> PostAdresgegeven(Adresgegeven adresgegeven)
        {
            _context.Adresgegevens.Add(adresgegeven);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdresgegevens), new { id = adresgegeven.Id }, adresgegeven);
        }

        [HttpPut("{id}", Name = "PutAdresgegevens")]
        //Put: Adresgegevens
        public async Task<ActionResult<Adresgegeven>> PutAdresgegeven(long id, Adresgegeven adresgegeven)
        {
            if(id != adresgegeven.Id)
            {
                return BadRequest();
            }
            _context.Entry(adresgegeven).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresgegevenExists(id)){
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}", Name = "PutAdresgegevens")]
        //Put: Adresgegevens

        public async Task<ActionResult> DeleteAdresgegeven(long id)
        {
            if(_context.Adresgegevens == null)
            {
                return NotFound();
            }

            var adresgegeven = await _context.Adresgegevens.FindAsync(id);
            if(adresgegeven == null)
            {
                return NotFound();
            }
            _context.Adresgegevens.Remove(adresgegeven);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdresgegevenExists(long id)
        {
            return (_context.Adresgegevens?.Any(adresgegeven => adresgegeven.Id == id)).GetValueOrDefault();
        }
    }
}
