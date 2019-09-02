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
  public class IndexModel : PageModel
  {
    private readonly ISQWWorker worker;

    public IndexModel(ISQWWorker worker)
    {
      this.worker = worker;
    }

    public List<Area> areas { get; set; }

    public async Task OnGetAsync()
    {
      await worker.runAsync(context =>
      {
        areas = context.select<Area>("SELECT * FROM STARCASH.CASINO_AREAS");
      });
    }
  }
}
