using CodeBuddies.Data;
using CodeBuddies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodeBuddies.Controllers
{
    public class AlunosController : Controller
    {
        private readonly CodeBuddiesContext _context;
        public AlunosController(CodeBuddiesContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var alunos = _context.Alunos.Include(a => a.Professor);
            return View(await alunos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var aluno = await _context.Alunos.Include(a => a.Professor)
                .FirstOrDefaultAsync(a => a.Id == id);
            return aluno == null ? NotFound() : View(aluno);
        }

        public IActionResult Create()
        {
            ViewData["ProfessorId"] = new SelectList(_context.Professores, "Id", "Nome");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfessorId"] = new SelectList(_context.Professores, "Id", "Nome", aluno.ProfessorId);
            return View(aluno);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound();
            ViewData["ProfessorId"] = new SelectList(_context.Professores, "Id", "Nome", aluno.ProfessorId);
            return View(aluno);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Aluno aluno)
        {
            if (id != aluno.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfessorId"] = new SelectList(_context.Professores, "Id", "Nome", aluno.ProfessorId);
            return View(aluno);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var aluno = await _context.Alunos.Include(a => a.Professor)
                .FirstOrDefaultAsync(a => a.Id == id);
            return aluno == null ? NotFound() : View(aluno);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
