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
  public class CreateModel : PageModel
  {
    public readonly PlayerRepository repository;
    public readonly IMapper mapper;

    public CreateModel(PlayerRepository repository, IMapper mapper)
    {
      this.repository = repository;
      this.mapper = mapper;
    }

    [BindProperty]
    public PlayerVm playerVm { get; set; }

    public IActionResult OnGet()
    {
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      var player = mapper.Map<Player>(playerVm);
      await repository.createPlayerAsync(player);

      return RedirectToPage("./Index");
    }
  }
}
