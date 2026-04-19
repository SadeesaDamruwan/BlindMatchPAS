using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BlindMatchPAS.Pages
{
    public class SettingsModel : PageModel
    {
        // --- BINDING PROPERTIES ---
        // [BindProperty] allows the form data to be automatically mapped to these variables

        [BindProperty]
        [Display(Name = "System Name")]
        public string SystemName { get; set; } = "NSBM Blind Match System";

        [BindProperty]
        [EmailAddress]
        public string AdminEmail { get; set; } = "admin@nsbm.lk";

        [BindProperty]
        public bool IsMaintenanceMode { get; set; }

        [BindProperty]
        public bool IsDarkMode { get; set; }

        [BindProperty]
        public int SessionTimeout { get; set; } = 30;

        [BindProperty]
        public bool Enable2FA { get; set; } = true;

        // --- NOTIFICATION SETTINGS ---
        [BindProperty]
        public bool EmailOnMatch { get; set; } = true;

        [BindProperty]
        public bool WeeklyReports { get; set; }

        public void OnGet()
        {
            // This runs when the page first loads.
            // In the future, you would fetch these values from your SQL Database here.
        }

        public IActionResult OnPost()
        {
            // 1. Validate the form (e.g., check if the email is valid)
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // 2. Logic to "Save" would go here. 
            // Example: _context.Settings.Update(model); await _context.SaveChangesAsync();

            // 3. Set a success message to display on the frontend
            TempData["SuccessMessage"] = "System configuration has been successfully updated!";

            // 4. Redirect back to the settings page to refresh the view
            return RedirectToPage();
        }

        public IActionResult OnPostReset()
        {
            // Logic for the "Reset to Defaults" button
            SystemName = "NSBM Blind Match System";
            AdminEmail = "admin@nsbm.lk";
            IsMaintenanceMode = false;
            SessionTimeout = 30;

            TempData["InfoMessage"] = "Settings have been reset to system defaults.";
            return RedirectToPage();
        }
    }
}