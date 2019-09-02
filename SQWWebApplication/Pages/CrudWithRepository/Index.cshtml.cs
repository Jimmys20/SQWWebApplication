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
  public class IndexModel : PageModel
  {
    private readonly AreaRepository repository;

    public IndexModel(AreaRepository repository)
    {
      this.repository = repository;
    }

    public List<Area> areas { get; set; }

    public async Task OnGetAsync()
    {
      areas = await repository.getAllAsync();
    }
  }
}
