using QueryGenerator.Models;
using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryGenerator.Interfaces;
using QueryGenerator.QueryOperator;

namespace QueryGenerator
{
    public class FilterEqual : Filter, IFilter
    {
        public string GenerateQuery(Column queryVariable)
        {
            return $"{queryVariable.FieldName} = {queryVariable.FieldValue}";
        }
    }
}
