using System.ComponentModel.DataAnnotations;

namespace IntusProject.Shared.ViewModel
{
    public class OrderVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string State { get; set; }
    }
}
