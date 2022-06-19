using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppPilote.Data;
using AppPilote.Models;

namespace AppPilote.Pages.Employes
{
    public class DeleteModel : PageModel
    {
        private readonly AppPilote.Data.AppPiloteContext _context;

        public DeleteModel(AppPilote.Data.AppPiloteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employe Employe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employe = await _context.Employe.FirstOrDefaultAsync(m => m.Id == id);

            if (Employe == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employe = await _context.Employe.FindAsync(id);

            if (Employe != null)
            {
                _context.Employe.Remove(Employe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
