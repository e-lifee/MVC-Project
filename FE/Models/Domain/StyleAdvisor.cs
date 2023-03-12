namespace FE.Models.Domain
{
    public class StyleAdvisor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StyleType { get; set; }
        public int Experience { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }


    }
}
