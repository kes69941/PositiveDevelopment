using System.Collections.Generic;

#nullable disable

namespace PositiveDevelopment
{
    public partial class ClientStatus
    {
        public ClientStatus()
        {
            Clients = new HashSet<Client>();
        }

        public int ClientStatusId { get; set; }

        public string Status { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
