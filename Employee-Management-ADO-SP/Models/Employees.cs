using System.ComponentModel.DataAnnotations;

namespace Employee_Management_ADO_SP.Models
{
    public class Employees
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Gender { get; set; }

        [Required, StringLength(50)]
        public string Designation { get; set; }

        [Required]
        public int Age { get; set; }

        [Required, StringLength(50)]
        public string City { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }
    }
}
