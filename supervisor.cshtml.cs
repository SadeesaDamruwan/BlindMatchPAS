using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace BlindMatchPAS.Pages
{
    public class SupervisorsModel : PageModel
    {
        // This list holds the supervisors displayed on the grid
        public List<SupervisorEntry> SupervisorList { get; set; } = new();

        // This property binds the data from the "Add New" Modal form
        [BindProperty]
        public SupervisorEntry NewSupervisor { get; set; } = new();

        public void OnGet()
        {
            LoadSupervisors();
        }

        private void LoadSupervisors()
        {
            // Note: Added 'Id' property so "View Profile" knows which one to open
            SupervisorList = new List<SupervisorEntry>
            {
                new SupervisorEntry {
                    Id = 1,
                    Name = "Dr. Aruna Pathirana",
                    Department = "Faculty of Computing",
                    Expertise = new List<string> { "AI", "Machine Learning" },
                    CurrentCount = 4,
                    MaxCapacity = 5
                },
                new SupervisorEntry {
                    Id = 2,
                    Name = "Prof. Samantha Perera",
                    Department = "Software Engineering",
                    Expertise = new List<string> { "Cyber Security", "Cloud" },
                    CurrentCount = 5,
                    MaxCapacity = 5
                },
                new SupervisorEntry {
                    Id = 3,
                    Name = "Dr. Nilanthi Silva",
                    Department = "Information Systems",
                    Expertise = new List<string> { "Data Science", "BI" },
                    CurrentCount = 2,
                    MaxCapacity = 6
                }
            };
        }

        // Action called when "Save Supervisor" is clicked in the modal
        public IActionResult OnPostAddSupervisor()
        {
            if (!ModelState.IsValid)
            {
                LoadSupervisors();
                return Page();
            }

            // Here you would normally save 'NewSupervisor' to your database
            return RedirectToPage();
        }
    }

    public class SupervisorEntry
    {
        public int Id { get; set; } // Required for the Profile link
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public List<string> Expertise { get; set; } = new();
        public int CurrentCount { get; set; }
        public int MaxCapacity { get; set; }
    }
}