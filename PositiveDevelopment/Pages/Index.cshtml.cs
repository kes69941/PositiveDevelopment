using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PositiveDevelopment.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PositiveDevelopment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private PositiveDevelopmentContext context;
        private DatabaseSeeder seeder;

        public PaginatedList<Client> Clients;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel(ILogger<IndexModel> logger, PositiveDevelopmentContext context)
        {
            _logger = logger;
            this.context = context;
            IQueryable<Client> clients = this.context.Clients.AsQueryable();
            Clients = new PaginatedList<Client>(clients.ToList(), 1, 1, 1);
            this.seeder = new DatabaseSeeder();
        }

        public IActionResult OnPost()
        {
            context = seeder.SeedDatabase(this.context);
            IQueryable<Client> clients = this.context.Clients.Include(t=> t.Status).Include(r=> r.Contact).AsQueryable();
            Clients = PaginatedList<Client>.Create(clients, 1, 10);
            return Page();
        }

        public IActionResult OnGet(string searchString, int? pageIndex)
        {
            IQueryable<Client> clients;

            if (searchString != null)
            {
                pageIndex = 1;
            } else
            {
                this.SearchString = searchString;
            }

            if (!string.IsNullOrEmpty(this.SearchString))
            {
                clients = this.context.Clients.AsQueryable().Include(t => t.Status).Include(r => r.Contact).Where(t => t.Status.Status.Contains(this.SearchString));
            } else {

                clients = this.context.Clients.Include(t => t.Status).Include(r => r.Contact).AsQueryable();
            }

            Clients = PaginatedList<Client>.Create(clients, pageIndex ?? 1, 10);
            return Page();
        }
    }
}
