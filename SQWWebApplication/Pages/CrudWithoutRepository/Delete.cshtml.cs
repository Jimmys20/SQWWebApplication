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

    public async Task<IActionResult> OnPostAsync(string areaCode)
    {
      var area = new Area { areaCode = areaCode };
      area.state = SQWEntityState.esDeleted;

      await worker.runAsync(context =>
      {
        context.save(area);
      });

      return RedirectToPage("./Index");
    }
  }
}
