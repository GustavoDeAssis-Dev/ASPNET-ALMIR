using CodeBuddies.Data;
using CodeBuddies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodeBuddies.Controllers
{
    public class RankingsController : Controller
    {
        private readonly CodeBuddiesContext _context;
        public RankingsController(CodeBuddiesContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var rankings = _context.Rankings.Include(r => r.Aluno);
            return View(await rankings.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var ranking = await _context.Rankings.Include(r => r.Aluno)
                .FirstOrDefaultAsync(r => r.Id == id);
            return ranking == null ? NotFound() : View(ranking);
        }

        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ranking ranking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ranking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", ranking.AlunoId);
            return View(ranking);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var ranking = await _context.Rankings.FindAsync(id);
            if (ranking == null) return NotFound();
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", ranking.AlunoId);
            return View(ranking);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ranking ranking)
        {
            if (id != ranking.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(ranking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", ranking.AlunoId);
            return View(ranking);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var ranking = await _context.Rankings.Include(r => r.Aluno)
                .FirstOrDefaultAsync(r => r.Id == id);
            return ranking == null ? NotFound() : View(ranking);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ranking = await _context.Rankings.FindAsync(id);
            if (ranking != null)
            {
                _context.Rankings.Remove(ranking);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
