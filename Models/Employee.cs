using System.ComponentModel.DataAnnotations;

namespace Learning.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? EmployeeName { get; set; }
        [Required]
        public string? EmployeePhone { get; set; }
        public int? EmployeeAge { get; set; }
        public string? EmployeeEmail { get; set; }
        public decimal? EmployeeSalary { get; set; }
    }
}
