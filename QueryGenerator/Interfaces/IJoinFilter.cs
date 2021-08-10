using QueryGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator.Interfaces
{
    public interface IJoinFilter
    {
        string GenerateJoinQuery(Join joinParams, string primaryTable);
    }
}
