using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator.Models
{
    public class Table
    {
        public List<Column> Columns { get; set; }
        public string TableName { get; set; }

        public string SubQueryColumnFilterBy { get; set; }
    }
}
