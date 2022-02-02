namespace Chinook.DataStore.SqlServer
{
    public partial class ToCustomer : Customer 
    {
    }
    public partial class FromCustomer : Customer
    {
    }
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Company { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string Email { get; set; } = null!;
        public int? SupportRepId { get; set; }
        public virtual Employee? SupportRep { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
        public virtual ICollection<CustomerShippingRate> ShippingRates { get; set; } = new HashSet<CustomerShippingRate>();
    }
}
