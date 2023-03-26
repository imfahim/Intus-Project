namespace IntusProject.Shared
{
    public class Window
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public bool IsDeleted { get; set; } //0
        public DateTime CreatedOn { get; set; } //Now DateTime
        public DateTime? UpdatedOn { get; set; }
        public string Name { get; set; }
        public int QuantityOfWindows { get; set; }
        public ICollection<SubElement> SubElements { get; set; }
        public int TotalSubElements
        {
            get
            {
                if (SubElements == null)
                    return 0;
                else
                    return SubElements.Count();
            }
        }
    }
}
