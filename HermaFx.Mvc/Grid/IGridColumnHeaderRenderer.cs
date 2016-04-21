using System.Web;
using HermaFx.Mvc.Grid.Columns;

namespace HermaFx.Mvc.Grid
{
    /// <summary>
    ///     Renderer of the header
    /// </summary>
    public interface IGridColumnHeaderRenderer
    {
        /// <summary>
        ///     Render grid header
        /// </summary>
        /// <param name="column">Column</param>
        /// <returns>HTML</returns>
        IHtmlString Render(IGridColumn column);
    }
}