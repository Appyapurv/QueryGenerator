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
    public class FilterIN : Filter, IFilter
    {
        public string GenerateQuery(Column queryVariable)
        {
            // If multiple values exists.
            var filterValues = this.GetFieldValue(queryVariable).FieldValue;
            return $"{queryVariable.FieldName} IN ({filterValues})";
        }
    }
}
