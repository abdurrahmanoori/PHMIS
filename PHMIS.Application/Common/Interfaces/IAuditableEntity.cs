using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHMIS.Application.Common.Interfaces;


public interface IAuditableEntity /*: IEntity*/
{
    string? CreatedBy { get; set; }
    DateTime? CreatedDate { get; set; }
    int? UpdatedBy { get; set; }
    DateTime? UpdatedDate { get; set; }
    //DateTime ExpireDate { get; set; }
}
