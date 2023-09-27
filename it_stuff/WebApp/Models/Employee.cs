using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Employee
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Address {get; set; }
        public int Phone {get; set;}
    }
}