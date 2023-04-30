using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace PositiveDevelopment.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private PositiveDevelopmentContext context;

        public CreateModel(ILogger<CreateModel> logger, PositiveDevelopmentContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostAsync()
        {

            if(!ModelState.IsValid)
            {
                return Page();
            }

            ContactInfo contactInfo = getContactInfo();
            context.ContactInfos.Add(contactInfo);
            context.SaveChanges();
            
            Client client = getClientInfo();

            client.Contact = contactInfo;
            client.ContactInfoId = contactInfo.ContactInfoId;
            client.Status = getStatus();

            context.Clients.Add(client);
            context.SaveChanges();

            return RedirectToPage("./Index");
        }

        private ClientStatus getStatus()
        {
            return context.ClientStatuses.FirstOrDefault(t => t.ClientStatusId.Equals(int.Parse(Request.Form["status"])));
        }

        private Client getClientInfo()
        {
            Client client = new Client();
            client.FirstName = Request.Form["firstname"];
            client.LastName = Request.Form["lastname"];
            client.Dob = DateTime.Parse(Request.Form["dob"]);
            return client;


        }

        private ContactInfo getContactInfo()
        {
            ContactInfo contactInfo = new ContactInfo();
            contactInfo.AddressOne = Request.Form["addressone"];
            contactInfo.AddressTwo = Request.Form["addresstwo"];
            contactInfo.City = Request.Form["city"];
            contactInfo.AState = Request.Form["state"];
            contactInfo.Email = Request.Form["email"];
            contactInfo.Zip = int.Parse(Request.Form["zip"]);
            return contactInfo;
        }
        public enum Status
        {
            New = 1,
            Active = 2,
            Inactive = 3
        }
    }
}
