using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQW.Interfaces;
using SQWWebApplication.Models;

namespace SQWWebApplication.Pages.CrudWithoutRepository
{
  public class CreateModel : PageModel
  {
    public readonly ISQWWorker worker;

    public CreateModel(ISQWWorker worker)
    {
      this.worker = worker;
    }

    [BindProperty]
    public Area area { get; set; }

    public IActionResult OnGet()
    {
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      await worker.runAsync(context =>
      {
        context.insert(area);
      });

      return RedirectToPage("./Index");
    }
  }
}
