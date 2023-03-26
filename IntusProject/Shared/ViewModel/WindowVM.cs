using System.ComponentModel.DataAnnotations;


namespace IntusProject.Shared.ViewModel
{
    public class WindowVM
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public int QuantityOfWindows { get; set; }
    }
}
