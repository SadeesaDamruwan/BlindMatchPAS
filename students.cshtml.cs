using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace BlindMatchPAS.Pages
{
    public class StudentsModel : PageModel
    {
        // Static list to persist data for this session
        public static List<StudentData> StudentList = new List<StudentData>
        {
            new StudentData { Id = 101, Name = "Alice Johnson", Email = "alice@nsbm.lk", Interest = "AI", GPA = 3.8 },
            new StudentData { Id = 102, Name = "Bob Smith", Email = "bob@nsbm.lk", Interest = "Cyber Security", GPA = 3.5 },
            new StudentData { Id = 103, Name = "Charlie Brown", Email = "charlie@nsbm.lk", Interest = "Data Science", GPA = 3.9 }
        };

        [BindProperty]
        public StudentData CurrentStudent { get; set; } = new();

        public void OnGet() { }

        // Handles both Adding (if ID is 0) and Editing (if ID exists)
        public IActionResult OnPostSaveStudent()
        {
            if (CurrentStudent.Id == 0)
            {
                // ADD NEW
                CurrentStudent.Id = StudentList.Any() ? StudentList.Max(s => s.Id) + 1 : 101;
                StudentList.Add(CurrentStudent);
            }
            else
            {
                // EDIT EXISTING
                var existing = StudentList.FirstOrDefault(s => s.Id == CurrentStudent.Id);
                if (existing != null)
                {
                    existing.Name = CurrentStudent.Name;
                    existing.Email = CurrentStudent.Email;
                    existing.Interest = CurrentStudent.Interest;
                    existing.GPA = CurrentStudent.GPA;
                }
            }
            return RedirectToPage();
        }

        // Handles Removal
        public IActionResult OnPostRemove(int id)
        {
            var student = StudentList.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                StudentList.Remove(student);
            }
            return RedirectToPage();
        }
    }

    public class StudentData
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Interest { get; set; } = "";
        public double GPA { get; set; }
    }
}