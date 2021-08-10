using QueryGenerator.Interfaces;
using QueryGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator.QueryOperator
{
    public class JoinQuery : IJoinFilter
    {      
        public string GenerateJoinQuery(Join joinParams, string primaryTable)
        {
            return $" {joinParams.Type} JOIN {joinParams.SecondaryTableName} ON " +
                $"{joinParams.SecondaryTableName}.{joinParams.JoinByColumn} = " +
                $"{primaryTable}.{joinParams.JoinByColumn}";

        }
    }
}
