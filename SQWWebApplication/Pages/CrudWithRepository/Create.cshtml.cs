using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQW.Interfaces;
using SQWWebApplication.Models;
using SQWWebApplication.Repositories;

namespace SQWWebApplication.Pages.CrudWithRepository
{
  public class CreateModel : PageModel
  {
    public readonly AreaRepository repository;

    public CreateModel(AreaRepository repository)
    {
      this.repository = repository;
    }

    [BindProperty]
    public Area area { get; set; }

    public IActionResult OnGet()
    {
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      await repository.insertAsync(area);

      return RedirectToPage("./Index");
    }
  }
}
