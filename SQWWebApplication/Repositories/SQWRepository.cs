using SQW;
using SQW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQWWebApplication.Repositories
{
  public class SQWRepository<T> where T : ISQWEntity
  {
    private readonly ISQWWorker worker;

    public SQWRepository(ISQWWorker worker)
    {
      this.worker = worker;
    }

    public async Task deleteAsync(T t)
    {
      t.state = SQWEntityState.esDeleted;
      await worker.runAsync(context =>
      {
        context.save(t);
      });
    }

    public async Task insertAsync(T t)
    {
      await worker.runAsync(context =>
      {
        context.save(t);
      });
    }

    public async Task updateAsync(T t)
    {
      t.state = SQWEntityState.esModified;
      await worker.runAsync(context =>
      {
        context.save(t);
      });
    }
  }
}
