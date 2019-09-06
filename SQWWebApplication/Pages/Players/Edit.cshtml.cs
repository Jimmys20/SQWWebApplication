using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQW.Interfaces;
using SQWWebApplication.Models;
using SQWWebApplication.Repositories;
using SQWWebApplication.ViewModels;

namespace SQWWebApplication.Pages.Players
{
  public class EditModel : PageModel
  {
    private readonly PlayerRepository repository;
    private readonly IMapper mapper;

    public EditModel(PlayerRepository repository, IMapper mapper)
    {
      this.repository = repository;
      this.mapper = mapper;
    }

    [BindProperty]
    public PlayerVm playerVm { get; set; }

    public async Task<IActionResult> OnGetAsync(long id)
    {
      var player = await repository.getPlayerByIdAsync(id);
      playerVm = mapper.Map<PlayerVm>(player);

      return Page();
    }

    public async Task<IActionResult> OnPostAsync(long id)
    {
      var player = await repository.getPlayerByIdAsync(id);

      if (player == null)
        return NotFound();

      mapper.Map(playerVm, player);
      await repository.editPlayerAsync(player);

      return RedirectToPage("./Index");
    }
  }
}
