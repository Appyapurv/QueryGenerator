using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator.Models
{
    public class Column
    {
        public string Operator { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
    }
}
