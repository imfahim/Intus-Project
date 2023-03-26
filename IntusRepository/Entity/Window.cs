namespace IntusRepository.Entity
{
    public class Window : Entity
    {
        public string Name { get; set; }
        public int OrderId { get; set; }
        public int QuantityOfWindows { get; set; }
        public ICollection<SubElement> SubElements { get; set; }
    }
}
