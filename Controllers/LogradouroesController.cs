using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApiDesafio.Models;

namespace WebApiDesafio.Controllers
{
    public class LogradouroesController : Controller
    {
        private readonly Contexto _context;

        public LogradouroesController(Contexto context)
        {
            _context = context;
        }

        // GET: Logradouroes
        public async Task<IActionResult> Index()
        {
              return _context.Logradouros != null ? 
                          View(await _context.Logradouros.ToListAsync()) :
                          Problem("Entity set 'Contexto.Logradouros'  is null.");
        }

        // GET: Logradouroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Logradouros == null)
            {
                return NotFound();
            }

            var logradouro = await _context.Logradouros
                .FirstOrDefaultAsync(m => m.LogradouroID == id);
            if (logradouro == null)
            {
                return NotFound();
            }

            return View(logradouro);
        }

        // GET: Logradouroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logradouroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogradouroID,Endereco,Cidade,Estado,ClienteID")] Logradouro logradouro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logradouro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logradouro);
        }

        // GET: Logradouroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Logradouros == null)
            {
                return NotFound();
            }

            var logradouro = await _context.Logradouros.FindAsync(id);
            if (logradouro == null)
            {
                return NotFound();
            }
            return View(logradouro);
        }

        // POST: Logradouroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogradouroID,Endereco,Cidade,Estado,ClienteID")] Logradouro logradouro)
        {
            if (id != logradouro.LogradouroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logradouro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogradouroExists(logradouro.LogradouroID))
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
            return View(logradouro);
        }

        // GET: Logradouroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Logradouros == null)
            {
                return NotFound();
            }

            var logradouro = await _context.Logradouros
                .FirstOrDefaultAsync(m => m.LogradouroID == id);
            if (logradouro == null)
            {
                return NotFound();
            }

            return View(logradouro);
        }

        // POST: Logradouroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Logradouros == null)
            {
                return Problem("Entity set 'Contexto.Logradouros'  is null.");
            }
            var logradouro = await _context.Logradouros.FindAsync(id);
            if (logradouro != null)
            {
                _context.Logradouros.Remove(logradouro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogradouroExists(int id)
        {
          return (_context.Logradouros?.Any(e => e.LogradouroID == id)).GetValueOrDefault();
        }
    }
}
