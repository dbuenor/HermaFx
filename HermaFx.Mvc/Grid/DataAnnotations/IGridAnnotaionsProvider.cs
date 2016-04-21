using System.Reflection;

namespace HermaFx.Mvc.Grid.DataAnnotations
{
    internal interface IGridAnnotaionsProvider
    {
        GridColumnAttribute GetAnnotationForColumn<T>(PropertyInfo pi);
        GridHiddenColumnAttribute GetAnnotationForHiddenColumn<T>(PropertyInfo pi);

        bool IsColumnMapped(PropertyInfo pi);

        GridTableAttribute GetAnnotationForTable<T>();
    }
}