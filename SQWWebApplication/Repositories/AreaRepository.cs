using SQW.Interfaces;
using SQWWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQWWebApplication.Repositories
{
  public class AreaRepository
  {
    private readonly ISQWWorker worker;

    public AreaRepository(ISQWWorker worker)
    {
      this.worker = worker;
    }

    public async Task<List<Area>> getAllAsync()
    {
      List<Area> areas = null;

      await worker.runAsync(context =>
      {
        areas = context
          .select<Area>("SELECT * FROM STARCASH.CASINO_AREAS");
      });

      return areas;
    }

    public async Task<Area> getByAreaCodeAsync(string areaCode)
    {
      Area area = null;

      await worker.runAsync(context =>
      {
        area = context
          .createCommand(@"SELECT * FROM STARCASH.CASINO_AREAS WHERE AREA_CODE = :AREA_CODE")
          .addStringInParam("AREA_CODE", areaCode)
          .first<Area>();
      });

      return area;
    }

    public async Task deleteAsync(Area area)
    {
      await worker.runAsync(context =>
      {
        context.delete(area);
      });
    }

    public async Task insertAsync(Area area)
    {
      await worker.runAsync(context =>
      {
        context.save(area);
      });
    }

    public async Task updateAsync(Area area)
    {
      await worker.runAsync(context =>
      {
        context.save(area);
      });
    }
  }
}
