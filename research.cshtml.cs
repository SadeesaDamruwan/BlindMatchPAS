using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlindMatchPAS.Pages
{
    public class ResearchModel : PageModel
    {
        // Static list ensures data persists while the app is running
        public static List<ResearchEntry> ResearchItems = new List<ResearchEntry>
        {
            new ResearchEntry { Id = 1, Title = "Optimizing AI for Clinical Triage", Field = "AI / Healthcare", SupervisorName = "Dr. Aruna Pathirana", Summary = "ML-based triaging.", Requirements = "Python basics." },
            new ResearchEntry { Id = 2, Title = "Cloud Security in Education", Field = "Cyber Security", SupervisorName = "Prof. Samantha Perera", Summary = "Cloud frameworks.", Requirements = "Networking knowledge." }
        };

        [BindProperty]
        public ResearchEntry NewTopic { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPostCreateTopic()
        {
            if (!ModelState.IsValid) return Page();

            // Simple ID generation logic
            NewTopic.Id = ResearchItems.Any() ? ResearchItems.Max(r => r.Id) + 1 : 1;
            ResearchItems.Add(NewTopic);

            return RedirectToPage();
        }
    }

    public class ResearchEntry
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Field { get; set; } = "";
        public string SupervisorName { get; set; } = "";
        public string Summary { get; set; } = "";
        public string Requirements { get; set; } = "";
    }
}