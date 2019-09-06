using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQW.Interfaces;
using SQWWebApplication.Models;
using SQWWebApplication.Extensions;

namespace SQWWebApplication.Pages.CrudWithoutRepository
{
  public class DeleteModel : PageModel
  {
    public readonly ISQWWorker worker;

    public DeleteModel(ISQWWorker worker)
    {
      this.worker = worker;
    }

    [BindProperty]
    public Area area { get; set; }

    public async Task<IActionResult> OnGetAsync(string areaCode)
    {
      await worker.runAsync(context =>
      {
        area = context
          .createCommand(@"SELECT * FROM STARCASH.CASINO_AREAS WHERE AREA_CODE = :AREA_CODE")
          .addStringInParam("AREA_CODE", areaCode)
          .first<Area>();
      });

      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      await worker.runAsync(context =>
      {
        context.delete<Area>(area.areaCode);
      });

      return RedirectToPage("./Index");
    }
  }
}
