using HermaFx.Mvc.Grid.Filtering;
using HermaFx.Mvc.Grid.Sorting;

namespace HermaFx.Mvc.Grid
{
    /// <summary>
    ///     Setting for grid
    /// </summary>
    public interface IGridSettingsProvider
    {
        IGridSortSettings SortSettings { get; }
        IGridFilterSettings FilterSettings { get; }
        IGridColumnHeaderRenderer GetHeaderRenderer();
    }
}