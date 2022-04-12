namespace ShopManagement.Application.Contracts.Address
{
    public class AddressViewModel
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public long AcountId { get; set; }
        public string Acount { get; set; }
        public string CreationDate { get; set; }
    }
}
