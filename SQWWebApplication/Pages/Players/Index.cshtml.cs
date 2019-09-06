using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQW.Interfaces;
using SQWWebApplication.Models;
using SQWWebApplication.Repositories;

namespace SQWWebApplication.Pages.Players
{
  public class IndexModel : PageModel
  {
    private readonly PlayerRepository repository;

    public IndexModel(PlayerRepository repository)
    {
      this.repository = repository;
    }

    public List<Player> players { get; set; }

    public async Task OnGetAsync()
    {
      players = await repository.getPlayersAsync();
    }
  }
}
