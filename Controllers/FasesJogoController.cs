using CodeBuddies.Data;
using CodeBuddies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeBuddies.Controllers
{
    public class FasesJogoController : Controller
    {
        private readonly CodeBuddiesContext _context;
        public FasesJogoController(CodeBuddiesContext context) => _context = context;

        public async Task<IActionResult> Index() => View(await _context.FasesJogo.ToListAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var fase = await _context.FasesJogo.FirstOrDefaultAsync(f => f.Id == id);
            return fase == null ? NotFound() : View(fase);
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FaseJogo fase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fase);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var fase = await _context.FasesJogo.FindAsync(id);
            return fase == null ? NotFound() : View(fase);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FaseJogo fase)
        {
            if (id != fase.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(fase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fase);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var fase = await _context.FasesJogo.FirstOrDefaultAsync(f => f.Id == id);
            return fase == null ? NotFound() : View(fase);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fase = await _context.FasesJogo.FindAsync(id);
            if (fase != null)
            {
                _context.FasesJogo.Remove(fase);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
