using QueryGenerator.Models;

namespace QueryGenerator.Interfaces
{
    public interface IFilter
    {
        string GenerateQuery(Column queryVariable);
    }
}