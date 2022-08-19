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
            //OrderByDescending(x => x.Plaats).ToListAsync();

        }

        [HttpGet("filter", Name = "GetAdresgegevensByFilter")]
        // GET: AdresgegevensByFilter
        public async Task<ActionResult<IEnumerable<Adresgegeven>>> GetAdresgegevensByFilter(string? straatFilter, long? huisnummerFilter)
        {
            var adresgegevens = _context.Adresgegevens;

            if (adresgegevens == null)
            {
                return NotFound();
            }

            var filtered = adresgegevens;

            /*if (straatFilter != null)
            {
                filtered.Where(item => item.Straat.Equals(straatFilter));
            }

            if(huisnummerFilter != null)
            {
                filtered.Where(item => item.Huisnummer.Equals(huisnummerFilter.ToString()));
            }*/

            return await filtered
                .Where(item => item.Straat.Equals(straatFilter) && item.Huisnummer.Equals(huisnummerFilter.ToString()))                
                .ToListAsync();
        }

        [HttpGet("sort", Name = "GetAdresgegevensBySorting")]
        // GET: AdresgegevensBySorting
        public async Task<ActionResult<IEnumerable<Adresgegeven>>> GetAdresgegevensBySorting(string sorting)
        {
            var adresgegevens = _context.Adresgegevens;

            if (adresgegevens == null)
            {
                return NotFound();
            }

            var sorted = adresgegevens;

            if (sorting.ToLower().Equals("straat"))
            {
                return await sorted
                 .OrderBy(x => x.Straat).ToListAsync();
            }
            else if (sorting.ToLower().Equals("huisnummer"))
            {
               return await sorted
                .OrderBy(x => x.Huisnummer).ToListAsync();
            }          
            else if (sorting.ToLower().Equals("postcode"))
            {
                return await sorted
                 .OrderBy(x => x.Postcode).ToListAsync();
            }
            else if (sorting.ToLower().Equals("plaats"))
            {
                return await sorted
                 .OrderBy(x => x.Plaats).ToListAsync();
            }
            else if (sorting.ToLower().Equals("land"))
            {
                return await sorted
                 .OrderBy(x => x.Land).ToListAsync();
            }

            return BadRequest();

        }
        [HttpGet("{id}", Name = "GetAdresgegevensById")]
        // GET: AdresgegevensById
        public async Task<ActionResult<Adresgegeven>> GetAdresgegevenById(long id)
        {
            if(_context.Adresgegevens == null)
            {
                return NotFound();
            }
            var adresgegevens = await _context.Adresgegevens.FindAsync(id);

            if(adresgegevens == null)
            {
                return NotFound();
            }
            return adresgegevens;
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
