// namespace myproject.Models
// {
//     public class Student
//     {
//         public int Id { get; set; }

//         public string Name { get; set; } = string.Empty;

//         public string Program { get; set; } = string.Empty;
//     }
// }

//Student info add Email and phone
//Course add creditHour
//

using System.ComponentModel.DataAnnotations;

namespace myproject.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student name is required.")]
        [StringLength(100,
            ErrorMessage = "Name cannot exceed 100 characters.")]
        [Display(Name = "Student Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Program is required.")]
        [StringLength(100,
            ErrorMessage = "Program cannot exceed 100 characters.")]
        [Display(Name = "Program Name")]
        public string Program { get; set; } = string.Empty;
    }
}