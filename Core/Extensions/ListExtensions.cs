using System.Collections.Generic;

namespace Core.Extensions {
    public static class ListExtensions {
        public static bool NotEmpty<T>(this List<T> list) {
            return list.Count > 0;
        }
    }
}