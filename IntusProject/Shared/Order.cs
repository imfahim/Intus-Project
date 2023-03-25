using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntusProject.Shared
{
    public class Order
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } //0
        public DateTime CreatedOn { get; set; } //Now DateTime
        public DateTime? UpdatedOn { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public ICollection<Window> Windows { get; set; }
    }
}
