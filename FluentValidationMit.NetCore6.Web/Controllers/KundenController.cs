using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FluentValidationMit.NetCore6.Web.Models;
using FluentValidation;

namespace FluentValidationMit.NetCore6.Web.Controllers
{
    public class KundenController : Controller
    {
        private readonly AppDbKontext _context;
        private readonly IValidator<Kunde> _kundeValidator;

        public KundenController(AppDbKontext context, IValidator<Kunde> kundeValidator)
        {
            _context = context;
            _kundeValidator = kundeValidator;
        }


        // GET: Kunden
        public async Task<IActionResult> Index()
        {
              return View(await _context.Kunden.ToListAsync());
        }

        // GET: Kunden/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kunden == null)
            {
                return NotFound();
            }

            var kunde = await _context.Kunden
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kunde == null)
            {
                return NotFound();
            }

            return View(kunde);
        }

        // GET: Kunden/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kunden/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Alter,GeburtsDatum")] Kunde kunde)
        {
            //Ich kann die Validate-Methode verwenden, um eine direkte Validierung der gewünschten Zielklasse durchzuführen.
            //Z.b mit einer Win-anwendung
            var validatorResultat = _kundeValidator.Validate(kunde);

            //Mit ModelState findet eine bidirektionale Validierung statt, d.h.es findet sowohl eine client -
            //als auch eine serverseitige Validierung statt.

            //if(ModelState.IsValid)
            //{
            //    ....
            //}

            //Wenn wir keine Validierung auf der Clientseite wünschen, können wir mit der Validate-Methode validieren.

            if (validatorResultat.IsValid)
            {
                _context.Add(kunde);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kunde);
        }

        // GET: Kunden/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kunden == null)
            {
                return NotFound();
            }

            var kunde = await _context.Kunden.FindAsync(id);
            if (kunde == null)
            {
                return NotFound();
            }
            return View(kunde);
        }

        // POST: Kunden/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Alter")] Kunde kunde)
        {
            if (id != kunde.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kunde);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KundeExists(kunde.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kunde);
        }

        // GET: Kunden/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kunden == null)
            {
                return NotFound();
            }

            var kunde = await _context.Kunden
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kunde == null)
            {
                return NotFound();
            }

            return View(kunde);
        }

        // POST: Kunden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kunden == null)
            {
                return Problem("Entity set 'AppDbKontext.Kunden'  is null.");
            }
            var kunde = await _context.Kunden.FindAsync(id);
            if (kunde != null)
            {
                _context.Kunden.Remove(kunde);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KundeExists(int id)
        {
          return _context.Kunden.Any(e => e.Id == id);
        }
    }
}
