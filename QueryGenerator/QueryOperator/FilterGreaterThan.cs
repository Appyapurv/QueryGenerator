using QueryGenerator.Interfaces;
using QueryGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator.QueryOperator
{
    public class FilterGreaterThan : Filter, IFilter
    {
        public string GenerateQuery(Column queryVariable)
        {
            return $"{queryVariable.FieldName} > {queryVariable.FieldValue}";
        }
    }
}
