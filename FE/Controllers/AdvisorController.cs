using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FE.Data;
using FE.Models;
using FE.Models.Domain;


namespace FE.Controllers
{
    public class AdvisorController:Controller
    {
        private readonly ApplicationDbContext dbcontext;

        public AdvisorController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var advisors = await dbcontext.Advisor.ToListAsync();
            return View(advisors);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Add(AddAdvisorViewModel sa)
        {
            var advisors = new StyleAdvisor
            {
                Id = Guid.NewGuid(),
                Name = sa.Name,
                LastName= sa.LastName,
                Email = sa.Email,
                Age= sa.Age,
                Experience=sa.Experience,
                StyleType=sa.StyleType, 
                Phone = sa.Phone,
                DateOfBirth = sa.DateOfBirth,
            };

            if(sa.Image != null)
            {
                // Convert image to byte array
                using (var stream = new MemoryStream())
                {
                    await sa.Image.CopyToAsync(stream);
                    advisors.Image = stream.ToArray();
                }
            }



            await dbcontext.Advisor.AddAsync(advisors);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {

            var advisor= await dbcontext.Advisor.FirstOrDefaultAsync(x => x.Id == id);

            if (advisor != null)
            {
                var viewModel = new UpdateAdvisorViewModel()
                {

                    Id = advisor.Id,
                    Name = advisor.Name,
                    LastName = advisor.LastName,
                    Email = advisor.Email,
                    Age= advisor.Age,
                    Experience=advisor.Experience,
                    StyleType=advisor.StyleType,
                    Phone = advisor.Phone,
                    DateOfBirth = advisor.DateOfBirth,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateAdvisorViewModel model)
        {
            
            
            var advisor = await dbcontext.Advisor.FindAsync(model.Id);
            if (advisor != null)
            {
                advisor.Name = model.Name;
                advisor.LastName = model.LastName;    
                advisor.Email = model.Email;
                advisor.Age= model.Age;
                advisor.Experience= model.Experience;
                advisor.StyleType = model.StyleType;
                advisor.Phone = model.Phone;
                advisor.DateOfBirth = model.DateOfBirth;
                advisor.Id= model.Id;
                if (model.Image != null)
                {
                    // Convert image to byte array
                    using (var stream = new MemoryStream())
                    {
                        await model.Image.CopyToAsync(stream);
                        advisor.Image = stream.ToArray();
                    }
                }

                await dbcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]

        public async Task<IActionResult> Delete(UpdateAdvisorViewModel model)
        {
            var advisor = await dbcontext.Advisor.FindAsync(model.Id);

            if (advisor != null)
            {
                dbcontext.Advisor.Remove(advisor);
                await dbcontext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> GetImage(Guid id)
        {
            var advisor = await dbcontext.Advisor.FirstOrDefaultAsync(x => x.Id == id);
            if (advisor == null || advisor.Image == null)
            {
                return NotFound();
            }

            return File(advisor.Image, "image/jpeg");
        }
    }
}
