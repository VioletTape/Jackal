using Core.BaseTypes;

namespace Core.Extensions {
    public static class ObjectExtension {
        public static bool IsNull(this object obj) {
            return obj == null;
        }

         public static bool IsNotNull(this object obj) {
            return obj != null;
        }

        public static bool IsHere(this Ship obj) {
            return obj != null;
        }
    }
}