using SQW;
using SQW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQWWebApplication.Models
{
  [SQWTableMap("STARCASH", "CASINO_AREAS", nameof(areaCode), "AREA_CODE", default(string))]
  public class Area : SQWEntity
  {
    [SQWFieldMap("AREA_CODE")]
    public string areaCode { get; set; }
    [SQWFieldMap("DESCRIPTION")]
    public string description { get; set; }
  }
}
