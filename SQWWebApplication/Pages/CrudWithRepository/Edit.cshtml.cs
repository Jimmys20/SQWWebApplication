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
  public class EditModel : PageModel
  {
    public readonly AreaRepository repository;

    public EditModel(AreaRepository repository)
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
      area.state = SQWEntityState.esModified;

      await repository.updateAsync(area);

      return RedirectToPage("./Index");
    }
  }
}
