using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator.Models
{
    public class TableJoin
    {
        public Table PrimaryTable { get; set; }
        public List<Join> Joins { get; set; }
    }
}
