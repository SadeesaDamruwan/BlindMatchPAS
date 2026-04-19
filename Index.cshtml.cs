using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace BlindMatchPAS.Pages
{
    public class IndexModel : PageModel
    {
        // 'required' ensures these aren't null for .NET 10/C# 12+
        public required List<Match> Matches { get; set; }

        // We use 'static' so that additions/removals persist while the app is running.
        // This is what the HTML will loop through.
        public static List<string> CurrentTags { get; set; } = ["AI", "Machine Learning", "Data Science", "Frontend", "UI Design"];

        public void OnGet()
        {
            // Load Mock Match Data
            Matches =
            [
                new Match { Student1 = "John Doe", Student2 = "John Doe", Supervisor = "Dr. Smith", Status = "Approved" },
                new Match { Student1 = "Jane Smith", Student2 = "Age Smith", Supervisor = "Dr. Johnson", Status = "Pending" },
                new Match { Student1 = "Jany Vew", Student2 = "Ney Smith", Supervisor = "Dr. Limith", Status = "Approved" }
            ];
        }

        public IActionResult OnPostAddArea(string NewArea)
        {
            if (!string.IsNullOrWhiteSpace(NewArea) && !CurrentTags.Contains(NewArea))
            {
                CurrentTags.Add(NewArea);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostRemoveArea(string areaName)
        {
            if (CurrentTags.Contains(areaName))
            {
                CurrentTags.Remove(areaName);
            }
            return RedirectToPage();
        }

        public IActionResult OnPost()
        {
            TempData["Message"] = "All research areas have been synchronized.";
            return RedirectToPage();
        }
    }

    public class Match
    {
        public required string Student1 { get; set; }
        public required string Student2 { get; set; }
        public required string Supervisor { get; set; }
        public required string Status { get; set; }
    }
}