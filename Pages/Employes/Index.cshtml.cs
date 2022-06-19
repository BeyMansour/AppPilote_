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
    public class IndexModel : PageModel
    {
        private readonly AppPilote.Data.AppPiloteContext _context;

        public IndexModel(AppPilote.Data.AppPiloteContext context)
        {
            _context = context;
        }

        public IList<Employe> Employe { get;set; }

        public async Task OnGetAsync()
        {
            Employe = await _context.Employe.ToListAsync();
        }
    }
}
