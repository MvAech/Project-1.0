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
                new Update { Date = new DateTime(2024, 7, 28), Description = "Added new privacy policy details." },
                new Update { Date = new DateTime(2024, 7, 28), Description = "Updated the homepage layout." },
                new Update { Date = new DateTime(2024, 7, 30), Description = "Added Site Logo To Appbar as well as icons to Menu Navigation"},
                new Update { Date = new DateTime(2024, 8, 6), Description = "Integrated live weather updates on the news page."},
                new Update { Date = new DateTime(2024, 8, 7), Description = "Completed integration of Font Awesome for enhanced iconography."},
            };
        }
    }

    public class Update
    {
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
