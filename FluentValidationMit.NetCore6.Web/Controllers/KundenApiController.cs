using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidationMit.NetCore6.Web.Models;
using FluentValidation;

namespace FluentValidationMit.NetCore6.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KundenApiController : ControllerBase
    {
        private readonly AppDbKontext _context;
        private readonly IValidator<Kunde> _kundeValidator;

        public KundenApiController(AppDbKontext context, IValidator<Kunde> kundeValidator)
        {
            _context = context;
            _kundeValidator = kundeValidator;
        }


        // GET: api/KundenApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kunde>>> GetKunden()
        {
            return await _context.Kunden.ToListAsync();
        }

        // GET: api/KundenApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kunde>> GetKunde(int id)
        {
            var kunde = await _context.Kunden.FindAsync(id);

            if (kunde == null)
            {
                return NotFound();
            }

            return kunde;
        }

        // PUT: api/KundenApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKunde(int id, Kunde kunde)
        {
            if (id != kunde.Id)
            {
                return BadRequest();
            }

            _context.Entry(kunde).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KundeExists(id))
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

        // POST: api/KundenApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kunde>> PostKunde(Kunde kunde)
        {
            var resultat = _kundeValidator.Validate(kunde);
            if (!resultat.IsValid)
            {
                return BadRequest(resultat.Errors.Select(x => new
                {
                    eigenschaft = x.PropertyName,
                    fehler = x.ErrorMessage
                }));
            }
            _context.Kunden.Add(kunde);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKunde", new { id = kunde.Id }, kunde);
        }

        // DELETE: api/KundenApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKunde(int id)
        {
            var kunde = await _context.Kunden.FindAsync(id);
            if (kunde == null)
            {
                return NotFound();
            }

            _context.Kunden.Remove(kunde);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KundeExists(int id)
        {
            return _context.Kunden.Any(e => e.Id == id);
        }
    }
}
