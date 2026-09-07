using CodeBuddies.Data;
using CodeBuddies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeBuddies.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly CodeBuddiesContext _context;
        public ProfessoresController(CodeBuddiesContext context) => _context = context;

        public async Task<IActionResult> Index() => View(await _context.Professores.ToListAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var professor = await _context.Professores.FirstOrDefaultAsync(p => p.Id == id);
            return professor == null ? NotFound() : View(professor);
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var professor = await _context.Professores.FindAsync(id);
            return professor == null ? NotFound() : View(professor);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Professor professor)
        {
            if (id != professor.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var professor = await _context.Professores.FirstOrDefaultAsync(p => p.Id == id);
            return professor == null ? NotFound() : View(professor);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            if (professor != null)
            {
                _context.Professores.Remove(professor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
