using QueryGenerator.Models;
using QueryGenerator.QueryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator
{
    public class QueryGenerator
    {
        public string GenerateQuery(Table input)
        {
            StringBuilder query = new StringBuilder("select * from ");

            query.Append(input.TableName + " Where ");
            for(int i = 0; i < input.Columns.Count(); i++)
            {
                var queryFilter = input.Columns[i];
                var operatorFactory = new FilterFactory();

                var operatorType = operatorFactory.generateOperator(queryFilter.Operator);
                var generatedQuery = operatorType.GenerateQuery(queryFilter);

                query.Append(generatedQuery);
                if (i < input.Columns.Count - 1)
                    query.Append(" AND ");
               

            }
            return query.ToString();
        }

        public string GenerateJoinQuery(TableJoin input)
        {
            StringBuilder query = new StringBuilder("select * from ");

            query.Append(input.PrimaryTable.TableName);
            for(int j = 0; j < input.Joins.Count(); j++)
            {
                var joinFactory = new JoinFactory();
                var joinType = joinFactory.GenerateJoinQuery(input.Joins[j].Type);
                var joinQuery = joinType.GenerateJoinQuery(input.Joins[j], input.PrimaryTable.TableName);
                query.Append(joinQuery);
            }            
            return query.ToString();
        }
    }
}
