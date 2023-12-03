using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public Guid MembershiptypesId { get; set; }
        [ForeignKey(nameof(Membershiptype))]

        public virtual Membershiptype? Membershiptypes { get; set; }
        
        public virtual ICollection<Movie>? Movies { get; set; }
    
    
 
    
    }
}
