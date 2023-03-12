using Microsoft.AspNetCore.Mvc;
using FE.Models.Domain;
using System.Globalization;

namespace FE.ViewComponents
{
    public class NewAdvisors:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var advisorList = new List<StyleAdvisor>
            {

                new StyleAdvisor
                {

                    Name="Kendall",
                    LastName="Jenner",
                    Email="kendalljnr@gmail.com",
                    Phone="+1 1234 569823",
                    Age=27,
                    DateOfBirth = DateTime.ParseExact("13-03-1989", "dd-MM-yyyy",CultureInfo.InvariantCulture)
        },
                new StyleAdvisor
                {

                    Name="Bella",
                    LastName="Hadid",
                    Email="bella.hadid@gmail.com",
                    Phone="+1 8964 569823",
                    Age=27,
                    DateOfBirth = DateTime.ParseExact("13-03-1989", "dd-MM-yyyy",CultureInfo.InvariantCulture)
                }
            };

            return View(advisorList);
        }
    }
}
