using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System; // Ensure System namespace is included for DateTime
using System.Collections.Generic; // Ensure this namespace is included for List

namespace Project_1._0.Pages
{
    public class updatesModel : PageModel // Ensure it derives from PageModel
    {
        public List<Update> RecentUpdates { get; set; }

        public updatesModel()
        {
            // Initialization of RecentUpdates list
            RecentUpdates = new List<Update>()
            {
                new Update { Date = DateTime.Now, Description = "Added new privacy policy details." },
                new Update { Date = DateTime.Now.AddDays(-1), Description = "Updated the homepage layout." },
                new Update { Date = DateTime.Now.AddDays(-1), Description = "Added Site Logo To Appbar as well as icons to Menu Navigation"}
            };
        }
    }

    public class Update
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
