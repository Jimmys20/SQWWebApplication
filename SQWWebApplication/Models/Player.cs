using SQW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQWWebApplication.Models
{
  [SQWTableMap("LOGISMOS", "PLAYER_MASTER", nameof(linkId), "LINK_ID", default(long))]
  public class Player : SQWEntity
  {
    [SQWFieldMap("LINK_ID")]
    public long linkId { get; set; }

    [SQWFieldMap("FIRST_NAME")]
    public string firstName { get; set; }

    [SQWFieldMap("LAST_NAME")]
    public string lastName { get; set; }

    [SQWFieldMap("BIRTH_DATE")]
    public DateTime birthDate { get; set; }

    [SQWFieldMap("LAST_VISIT")]
    public DateTime? lastVisit { get; set; }
  }
}
