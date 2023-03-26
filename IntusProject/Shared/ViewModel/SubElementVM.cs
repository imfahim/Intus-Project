using System.ComponentModel.DataAnnotations;

namespace IntusProject.Shared.ViewModel
{
    public class SubElementVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Element is required")]
        public int Element { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Width is required")]
        public int Width { get; set; }
        [Required(ErrorMessage = "Height is required")]
        public int Height { get; set; }
    }
}
