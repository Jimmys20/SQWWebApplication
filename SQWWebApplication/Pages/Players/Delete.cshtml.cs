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
  public class DeleteModel : PageModel
  {
    public readonly PlayerRepository repository;

    public DeleteModel(PlayerRepository repository)
    {
      this.repository = repository;
    }

    public Player player { get; set; }

    public async Task<IActionResult> OnGetAsync(long id)
    {
      player = await repository.getPlayerByIdAsync(id);

      return Page();
    }

    public async Task<IActionResult> OnPostAsync(long id)
    {
      var player = await repository.getPlayerByIdAsync(id);

      if (player == null)
        return NotFound();

      await repository.deletePlayerAsync(player);

      return RedirectToPage("./Index");
    }
  }
}
