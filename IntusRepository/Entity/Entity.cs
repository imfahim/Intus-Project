using System.ComponentModel.DataAnnotations;


namespace IntusRepository.Entity
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; } //0
        public DateTime CreatedOn { get; set; } //Now DateTime
        public DateTime? UpdatedOn { get; set; }
    }
}
