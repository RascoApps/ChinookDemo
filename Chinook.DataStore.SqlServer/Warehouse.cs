using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinook.DataStore.SqlServer
{
    public class Warehouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
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
        public virtual ICollection<CustomerShippingRate> CustomerShippingRates { get; set; } = new HashSet<CustomerShippingRate>();
        public virtual ICollection<Parcel> Parcels { get; set; } = new HashSet<Parcel>();

    }
}
