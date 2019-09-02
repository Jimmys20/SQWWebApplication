using SQW.Interfaces;
using SQWWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQWWebApplication.Repositories
{
  public class AreaRepository : SQWRepository<Area>
  {
    private readonly ISQWWorker worker;

    public AreaRepository(ISQWWorker worker) : base(worker)
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
  }
}
