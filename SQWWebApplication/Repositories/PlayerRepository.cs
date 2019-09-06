using SQW.Interfaces;
using SQWWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQWWebApplication.Repositories
{
  public class PlayerRepository
  {
    private readonly ISQWWorker worker;

    public PlayerRepository(ISQWWorker worker)
    {
      this.worker = worker;
    }

    public async Task<List<Player>> getPlayersAsync()
    {
      List<Player> players = null;

      await worker.runAsync(context =>
      {
        players = context
          .select<Player>(@"SELECT *
                              FROM LOGISMOS.PLAYER_MASTER
                             FETCH FIRST 100 ROWS ONLY");
      });

      return players;
    }

    public async Task<Player> getPlayerByIdAsync(long id)
    {
      Player player = null;

      await worker.runAsync(context =>
      {
        player = context
          .createCommand(@"SELECT *
                             FROM LOGISMOS.PLAYER_MASTER
                            WHERE LINK_ID = :LINK_ID")
          .addNumericInParam("LINK_ID", id)
          .first<Player>();
      });

      return player;
    }

    public async Task createPlayerAsync(Player player)
    {
      await worker.runAsync(context =>
      {
        context.save(player);
      });
    }

    public async Task editPlayerAsync(Player player)
    {
      player.state = SQWEntityState.esModified;

      await worker.runAsync(context =>
      {
        context.save(player);
      });
    }

    public async Task deletePlayerAsync(Player player)
    {
      player.state = SQWEntityState.esDeleted;

      await worker.runAsync(context =>
      {
        context.save(player);
      });
    }
  }

}