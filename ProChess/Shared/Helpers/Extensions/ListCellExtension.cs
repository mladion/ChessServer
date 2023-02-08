using Shared.Data;

namespace Shared.Helpers.Extensions
{
    public static class ListCellExtension
    {
        public static void AddCell<T>(this List<Cell> list, T item) 
        {
            if (item != null)
            {
                list.Add(item as Cell);
            }
        }
    }
}
