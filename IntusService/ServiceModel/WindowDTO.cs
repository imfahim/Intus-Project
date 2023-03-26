namespace IntusService.ServiceModel
{
    public class WindowDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public bool IsDeleted { get; set; } //0
        public DateTime CreatedOn { get; set; } //Now DateTime
        public DateTime? UpdatedOn { get; set; }
        public string Name { get; set; }
        public int QuantityOfWindows { get; set; }
        public ICollection<SubElementDTO> SubElements { get; set; }
    }
}
