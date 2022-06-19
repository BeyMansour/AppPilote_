using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppPilote.Data;
using AppPilote.Models;

namespace AppPilote.Pages.Employes
{
    public class EditModel : PageModel
    {
        private readonly AppPilote.Data.AppPiloteContext _context;

        public EditModel(AppPilote.Data.AppPiloteContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeExists(Employe.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeExists(int id)
        {
            return _context.Employe.Any(e => e.Id == id);
        }
    }
}
