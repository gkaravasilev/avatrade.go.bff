namespace AvaTrade.Go.BFF.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<TSource> WhereWhen<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, bool condition)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }
        public static IEnumerable<TSource> TakeWhen<TSource>(this IEnumerable<TSource> source, int count, bool condition)
        {
            if (condition)
                return source.Take(count);
            else
                return source;
        }

        public static char[] TextToCharArray(this string source)
        {
            return source.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .SelectMany(x => x.Trim().ToCharArray())
                .Where(x => (x >= '0' && x <= '9') || (x >= 'a' && x <= 'z'))
                .ToArray();
        }

    }
}
