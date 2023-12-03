namespace TP3.Models
{
    public class Membershiptype
    {
        public Guid Id { get; set; }
        public int SignUpFee { get; set; }
         public int DurationInMonth { get; set; }
        public int DiscountRate { get; set; }

        public ICollection< Customer>? Customers { get; set; }
    }
}
