using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectPractice.Models;

namespace ProjectPractice.Controllers
{
    public class ReportsController : Controller
    {
        private readonly PracticeContext _context;

        public ReportsController(PracticeContext context)
        {
            _context = context;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
            var practiceContext = _context.PhotoReports.Include(p => p.Photo).Include(p => p.ReporterNavigation);
            return View(await practiceContext.ToListAsync());
        }

        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhotoReports == null)
            {
                return NotFound();
            }

            var photoReport = await _context.PhotoReports
                .Include(p => p.Photo)
                .Include(p => p.ReporterNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photoReport == null)
            {
                return NotFound();
            }

            return View(photoReport);
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhotoReports == null)
            {
                return NotFound();
            }

            var photoReport = await _context.PhotoReports
                .Include(p => p.Photo)
                .Include(p => p.ReporterNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photoReport == null)
            {
                return NotFound();
            }

            return View(photoReport);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhotoReports == null)
            {
                return Problem("Entity set 'PracticeContext.PhotoReports'  is null.");
            }
            var photoReport = await _context.PhotoReports.FindAsync(id);
            if (photoReport != null)
            {
                _context.PhotoReports.Remove(photoReport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotoReportExists(int id)
        {
          return _context.PhotoReports.Any(e => e.Id == id);
        }
    }
}
