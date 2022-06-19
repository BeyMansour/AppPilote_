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
    public class DetailsModel : PageModel
    {
        private readonly AppPilote.Data.AppPiloteContext _context;

        public DetailsModel(AppPilote.Data.AppPiloteContext context)
        {
            _context = context;
        }

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
    }
}
