using System.Collections.Generic;

#nullable disable

namespace PositiveDevelopment
{
    public partial class ContactInfo
    {
        public ContactInfo()
        {
            Clients = new HashSet<Client>();
        }

        public int ContactInfoId { get; set; }
        public string Email { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }
        public string AState { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
