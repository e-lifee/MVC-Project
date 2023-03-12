namespace FE.Models
{
    public class AddAdvisorViewModel
    {
       
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StyleType { get; set; }
        public int Experience { get; set; }
        public IFormFile Image { get; set; }
        public string Email { get; set; }

    }
}
