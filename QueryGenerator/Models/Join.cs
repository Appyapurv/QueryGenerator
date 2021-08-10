using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenerator.Models
{
    public class Join
    {
        public string Type { get; set; }
        public string PrimaryColumnName { get; set; }
        public string SecondaryTableName { get; set; }
        public string JoinByColumn { get; set; }
    }
}
