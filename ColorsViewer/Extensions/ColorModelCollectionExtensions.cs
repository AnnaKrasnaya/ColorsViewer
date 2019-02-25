using ColorsViewer.Models;
using System.Collections.Generic;
using System.Linq;

namespace ColorsViewer.Extensions
{
    public static class ColorModelCollectionExtensions
    {
        public static IEnumerable<ColorModel> SortByItemId(this IEnumerable<ColorModel> collection, bool descendingOrder)
        {
            var result = descendingOrder ? collection.OrderByDescending(arg => arg.Id) : collection.OrderBy(arg => arg.Id);
            return result;
        }
    }
}