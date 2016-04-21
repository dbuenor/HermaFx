using System.Collections.Generic;
using System.Linq;

namespace HermaFx.Mvc.Grid
{
    public class TestGrid : Grid<TestModel>
    {
        public TestGrid(IEnumerable<TestModel> items)
            : base(items)
        {
        }
    }
}