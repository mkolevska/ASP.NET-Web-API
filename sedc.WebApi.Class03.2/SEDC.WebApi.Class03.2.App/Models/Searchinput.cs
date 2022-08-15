using System.ComponentModel.DataAnnotations;

namespace SEDC.WebApi.Class03._2.App.Models
{
    public class Searchinput
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
