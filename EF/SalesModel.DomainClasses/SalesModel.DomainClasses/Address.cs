using SalesModel.DomainClasses.Enums;
namespace SalesModel.DomainClasses
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public AddressType AddressType { get; set; }
        public OrderSource OrderSource { get; set; }

        public virtual Customer customer { get; set; }
    }
}
