using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SQWWebApplication.Models;
using SQWWebApplication.Repositories;
using SQWWebApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQWWebApplication.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlayerController : Controller
  {
    private readonly PlayerRepository repository;
    private readonly IMapper mapper;

    public PlayerController(PlayerRepository repository, IMapper mapper)
    {
      this.repository = repository;
      this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> getAllPlayersAsync()
    {
      return Json(await repository.getPlayersAsync());
    }

    [HttpGet]
    public async Task<IActionResult> getPlayerByIdAsync(long id)
    {
      return Json(await repository.getPlayerByIdAsync(id));
    }

    [HttpPost]
    public IActionResult createPlayer(PlayerVm playerVm)
    {
      var player = mapper.Map<Player>(playerVm);
      repository.createPlayerAsync(player);
      return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> editPlayerAsync(PlayerVm playerVm)
    {
      var player = await repository.getPlayerByIdAsync(playerVm.linkId);

      if (player == null)
        return NotFound();

      mapper.Map(playerVm, player);

      repository.editPlayerAsync(player);

      return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> deletePlayerAsync(long id)
    {
      var player = await repository.getPlayerByIdAsync(id);

      if (player == null)
        return NotFound();

      repository.deletePlayerAsync(player);

      return Ok();
    }
  }
}
