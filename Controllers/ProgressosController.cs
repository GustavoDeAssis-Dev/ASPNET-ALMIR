using CodeBuddies.Data;
using CodeBuddies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodeBuddies.Controllers
{
    public class ProgressosController : Controller
    {
        private readonly CodeBuddiesContext _context;
        public ProgressosController(CodeBuddiesContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var progressos = _context.Progressos
                .Include(p => p.Aluno)
                .Include(p => p.FaseJogo);
            return View(await progressos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var progresso = await _context.Progressos
                .Include(p => p.Aluno)
                .Include(p => p.FaseJogo)
                .FirstOrDefaultAsync(p => p.Id == id);
            return progresso == null ? NotFound() : View(progresso);
        }

        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome");
            ViewData["FaseJogoId"] = new SelectList(_context.FasesJogo, "Id", "TituloFase");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Progresso progresso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(progresso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", progresso.AlunoId);
            ViewData["FaseJogoId"] = new SelectList(_context.FasesJogo, "Id", "TituloFase", progresso.FaseJogoId);
            return View(progresso);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var progresso = await _context.Progressos.FindAsync(id);
            if (progresso == null) return NotFound();
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", progresso.AlunoId);
            ViewData["FaseJogoId"] = new SelectList(_context.FasesJogo, "Id", "TituloFase", progresso.FaseJogoId);
            return View(progresso);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Progresso progresso)
        {
            if (id != progresso.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(progresso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", progresso.AlunoId);
            ViewData["FaseJogoId"] = new SelectList(_context.FasesJogo, "Id", "TituloFase", progresso.FaseJogoId);
            return View(progresso);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var progresso = await _context.Progressos
                .Include(p => p.Aluno)
                .Include(p => p.FaseJogo)
                .FirstOrDefaultAsync(p => p.Id == id);
            return progresso == null ? NotFound() : View(progresso);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var progresso = await _context.Progressos.FindAsync(id);
            if (progresso != null)
            {
                _context.Progressos.Remove(progresso);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
