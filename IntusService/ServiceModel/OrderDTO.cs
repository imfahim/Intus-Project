namespace IntusService.ServiceModel
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } //0
        public DateTime CreatedOn { get; set; } //Now DateTime
        public DateTime? UpdatedOn { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public ICollection<WindowDTO> Windows { get; set; }
    }
}
