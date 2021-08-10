using QueryGenerator.Interfaces;
using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryGenerator.QueryOperator;

namespace QueryGenerator.QueryFactory
{
    public class FilterFactory
    {
        public IFilter generateOperator(string operatorType)
        {
            if(string.Equals(operatorType, "equal", StringComparison.OrdinalIgnoreCase))
            {
                return new FilterEqual();
            }
            else if(string.Equals(operatorType, "in", StringComparison.OrdinalIgnoreCase))
            {
                return new FilterIN();
            }else if(string.Equals(operatorType, "between", StringComparison.OrdinalIgnoreCase))
            {
                return new FilterBetween();
            }
            return null;
        }
    }
}
