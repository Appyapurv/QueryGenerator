using QueryGenerator.Interfaces;
using QueryGenerator.JoinOperator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator.QueryFactory
{
    public class JoinFactory
    {
        public IJoinFilter GenerateJoinQuery(string operatorType)
        {
            if (string.Equals(operatorType, "LEFT", StringComparison.OrdinalIgnoreCase))
            {
                return new LeftJoin();
            }
            else if(string.Equals(operatorType, "RIGHT", StringComparison.OrdinalIgnoreCase))
            {
                return new RightJoin();
            }
            return null;
        }
    }
}
