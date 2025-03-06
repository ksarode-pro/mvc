using System.ComponentModel.DataAnnotations;

public class Employee
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    [MaxLength(15, ErrorMessage = "Max lengthe is 15 characters")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    [MaxLength(15, ErrorMessage = "Max lengthe is 15 characters")]
    public string LastName { get; set; }

    [Required]
    [RegularExpression(@"([a-zA-Z0-9.-_])+@[a-zA-Z0-9-]+.[a-zA-Z0-9]\w+", ErrorMessage = "Invalid email address")]
    public string Email { get; set; }
}