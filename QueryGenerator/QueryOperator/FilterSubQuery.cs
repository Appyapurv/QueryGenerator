using QueryGenerator.Interfaces;
using QueryGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator.QueryOperator
{
    public class FilterSubQuery : Filter, IFilter
    {
        public string GenerateQuery(Column queryVariable)
        {
            return "True";
        }
    }
}
