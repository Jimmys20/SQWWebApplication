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
  public class DeleteModel : PageModel
  {
    public readonly AreaRepository repository;

    public DeleteModel(AreaRepository repository)
    {
      this.repository = repository;
    }

    [BindProperty]
    public Area area { get; set; }

    public async Task<IActionResult> OnGetAsync(string areaCode)
    {
      area = await repository.getByAreaCodeAsync(areaCode);

      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      await repository.deleteAsync(area);

      return RedirectToPage("./Index");
    }
  }
}
