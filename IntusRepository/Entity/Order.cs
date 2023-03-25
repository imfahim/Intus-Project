namespace IntusRepository.Entity
{
    public class Order : Entity
    {
        public string Name { get; set; }
        public string State { get; set; }
        public ICollection<Window> Windows { get; set; }
    }
}
