using QueryGenerator.Models;
using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryGenerator.Interfaces;

namespace QueryGenerator.QueryOperator
{
    public class FilterBetween : Filter, IFilter
    {
        public string GenerateQuery(Column queryVariable)
        {
            var valueList = queryVariable.FieldValue.Split(';').ToList();
            return $"{queryVariable.FieldName} BETWEEN {valueList.FirstOrDefault()} AND {(valueList.LastOrDefault())}";
        }
    }
}
