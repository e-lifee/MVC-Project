using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FE.Data;
using FE.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.ViewComponents
{
    public class AdvisorListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext dbcontext;

        public AdvisorListViewComponent(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var advisors = await dbcontext.Advisor
                .ToListAsync();

            return View(advisors);
        }
    }
}