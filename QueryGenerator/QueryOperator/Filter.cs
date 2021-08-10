using QueryGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator.QueryOperator
{
    public abstract class Filter
    {
        public Column GetFieldValue(Column queryParameter)
        {
            var valuesList = queryParameter.FieldValue.Split(';').ToList();
            StringBuilder value = new StringBuilder();
            string output = string.Empty;

            try
            {
                for(int i=0; i < valuesList.Count(); i++)
                {
                    output = valuesList[i];

                    value.Append(output);
                    if (valuesList.Count > 1 && (i < valuesList.Count - 1))
                        value.Append(',');
                }
                queryParameter.FieldValue = value.ToString();
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return queryParameter;
        }
    }
}
