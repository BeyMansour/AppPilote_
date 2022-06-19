using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppPilote.Data;
using AppPilote.Models;

namespace AppPilote.Pages.Employes
{
    public class CreateModel : PageModel
    {
        private readonly AppPilote.Data.AppPiloteContext _context;

        public CreateModel(AppPilote.Data.AppPiloteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employe Employe { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employe.Add(Employe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
