using SQW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SQW;

namespace SQWWebApplication.Extensions
{
  public static class ISQWWorkerExtensions
  {
    public static async Task runAsync2(this ISQWWorker worker, Action<ISQWContext> action)
    {
      try
      {
        await worker.runAsync(action);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    public static void delete<T>(this ISQWContext context, object id) where T : ISQWEntity
    {
      var type = typeof(T);

      var tableMapAttribute = (SQWTableMapAttribute)Attribute.GetCustomAttribute(type, typeof(SQWTableMapAttribute));

      var pkPropertyName = tableMapAttribute.pkPropertyName;

      var entity = (T)Activator.CreateInstance(type);

      var pkProperty = type.GetProperty(pkPropertyName);

      pkProperty.SetValue(entity, id, null);

      context.delete(entity);
    }
  }
}
