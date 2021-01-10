using System.Linq;

namespace IbDataTool.Queries
{
    /// <summary>
    /// StocksTotalQuery
    /// </summary>
    public class StocksTotalQuery : DataContext
    {
        public int Run()
        {
            return (from stock in Stocks
                    select stock).Count();
        }
    }
}