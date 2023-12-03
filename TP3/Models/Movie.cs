using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public DateTime? MovieAdded { get; set; }

      //  public IFormFile? Photo { get; set; }

        public Guid genre_id { get; set; }
        [ForeignKey(nameof(Genre))]
        public virtual Genre? Genres { get; set; }


        public virtual ICollection<Customer>? Customers { get; set; }

    }
}
