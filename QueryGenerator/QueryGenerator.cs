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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="columnNameToSelect">Pass Individual Column Name or "*" to select all</param>
        /// <returns></returns>
        public string GenerateQuery(Table input, string columnNameToSelect)
        {
            StringBuilder query = new StringBuilder("select " + columnNameToSelect + " from ");

            query.Append(input.TableName + " Where ");
            for (int i = 0; i < input.Columns.Count(); i++)
            {
                var queryFilter = input.Columns[i];
                var operatorFactory = new FilterFactory();

                var operatorType = operatorFactory.generateOperator(queryFilter.Operator);
                var generatedQuery = operatorType.GenerateQuery(queryFilter);

                query.Append(generatedQuery);
                if (i < input.Columns.Count - 1)
                {
                    var exptoAppend = queryFilter.Logicalexpression != string.Empty ? queryFilter.Logicalexpression : "";
                    query.Append(" " + exptoAppend + " ");
                }

            }
            return query.ToString();
        }

        public string GenerateJoinQuery(TableJoin input)
        {
            StringBuilder query = new StringBuilder("select * from ");

            query.Append(input.PrimaryTable.TableName);
            for (int j = 0; j < input.Joins.Count(); j++)
            {
                var joinFactory = new JoinFactory();
                var joinType = joinFactory.GenerateJoinQuery(input.Joins[j].Type);
                var joinQuery = joinType.GenerateJoinQuery(input.Joins[j], input.PrimaryTable.TableName);
                query.Append(joinQuery);
            }
            return query.ToString();
        }

        public string GenerateSubQueryQuery(Table input)
        {
            StringBuilder query = new StringBuilder("select * from ");

            query.Append(input.TableName + " Where " + input.SubQueryColumnFilterBy
                + " IN (");
            var generatedQuery = this.GenerateQuery(input, input.SubQueryColumnFilterBy);

            query.Append(generatedQuery + ")");
            return query.ToString();
        }
    }
}
