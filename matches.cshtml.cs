using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace BlindMatchPAS.Pages
{
    public class MatchesModel : PageModel
    {
        // Static list ensures matches persist across page navigation
        public static List<ProjectMatch> MatchList = new List<ProjectMatch>();

        public void OnGet()
        {
            // Optional: load existing matches on page load if needed
        }

        // Triggered by the "Generate New Matches" button
        public IActionResult OnPostGenerateMatches()
        {
            // 1. Clear previous results to start fresh
            MatchList.Clear();

            // 2. Sample data sources (simulating your Student and Supervisor lists)
            var students = new[] {
                new { Name = "Alice Johnson", GPA = 3.8, Area = "AI" },
                new { Name = "Bob Smith", GPA = 3.5, Area = "Cyber Security" },
                new { Name = "Charlie Brown", GPA = 3.9, Area = "Data Science" }
            };

            var supervisors = new[] {
                new { Name = "Dr. Aruna Pathirana", Expertise = "AI" },
                new { Name = "Prof. Samantha Perera", Expertise = "Cyber Security" },
                new { Name = "Dr. Nilanthi Silva", Expertise = "Data Science" }
            };

            int matchIdTracker = 1001;

            // 3. Simple Matching Algorithm: Match by Research Area string
            foreach (var student in students)
            {
                var bestSupervisor = supervisors.FirstOrDefault(s => s.Expertise == student.Area);

                if (bestSupervisor != null)
                {
                    MatchList.Add(new ProjectMatch
                    {
                        Id = matchIdTracker++,
                        StudentName = student.Name,
                        GPA = student.GPA,
                        SupervisorName = bestSupervisor.Name,
                        ResearchArea = student.Area
                    });
                }
            }

            // 4. Refresh page to show the new table content
            return RedirectToPage();
        }
    }

    public class ProjectMatch
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public double GPA { get; set; }
        public string SupervisorName { get; set; } = string.Empty;
        public string ResearchArea { get; set; } = string.Empty;
    }
}