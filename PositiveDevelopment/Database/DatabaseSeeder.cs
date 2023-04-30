using System;
using System.Collections.Generic;
using System.Linq;

namespace PositiveDevelopment.Database
{
    public class DatabaseSeeder
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private List<string> lastNames = new List<string> { "Shaffer", "Buchanan", "Bixler", "Isola", "Peng", "Hendrix"};
        private List<string> firstNames = new List<string> { "Katherine", "Andrew", "Tim", "Dipo", "Zu", "Emily" };
        Random random;

        public DatabaseSeeder ()
        {
            random = new Random();
        }

        private String getRandomString()
        {
            return new string(Enumerable.Repeat(chars, 15).Select(r => r[random.Next(r.Length)]).ToArray());
        }
         private Client getClientInfo()
        {
            int nameIndex = random.Next(0, 6);
            Client client = new Client();
            client.FirstName = lastNames[nameIndex];
            client.LastName = firstNames[nameIndex];
            client.Dob = DateTime.Now;
            return client;
        }

        private ContactInfo getContactInfo()
        {
            ContactInfo contactInfo = new ContactInfo();
            contactInfo.AddressOne = getRandomString();
            contactInfo.AddressTwo = getRandomString();
            contactInfo.City = getRandomString();
            contactInfo.AState = getRandomString();
            contactInfo.Email = getRandomString();
            contactInfo.Zip = 123521;
            return contactInfo;
        }

        private ClientStatus getStatusInfo(PositiveDevelopmentContext context)
        {
            int statusId = random.Next(1, 4);
            ClientStatus status = context.ClientStatuses.AsQueryable().FirstOrDefault(t => t.ClientStatusId.Equals(statusId));
            return status;
        }
 
        public PositiveDevelopmentContext SeedDatabase(PositiveDevelopmentContext context)
        {

            for (int x = 0; x < 100; x++)
            {
                Client client = getClientInfo();
                ContactInfo contactInfo = getContactInfo();
                context.Add(contactInfo);
                context.SaveChanges();
                client.ContactInfoId = contactInfo.ContactInfoId;
                client.Contact = contactInfo;
                client.Status = getStatusInfo(context);
                context.Add(client);
                context.SaveChanges();
            }
            return context;

        }
    }
}
