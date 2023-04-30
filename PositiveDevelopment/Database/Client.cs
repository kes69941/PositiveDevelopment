using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PositiveDevelopment
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Dob { get; set; }

        public int ClientStatusId { get; set; }

        public int ContactInfoId { get; set; }

        [ForeignKey("ContactId")]
        public virtual ContactInfo Contact { get; set; }

        [ForeignKey("StatusId")]
        public virtual ClientStatus Status { get; set; }
    }
}
