namespace Shared.Helpers.Extensions
{
    public static class ListExtension
    {
        public static void AddNotNullableItem<T>(this List<T> list, T? item) 
        {
            if (item != null)
            {
                list.Add(item);
            }
        }
    }
}
