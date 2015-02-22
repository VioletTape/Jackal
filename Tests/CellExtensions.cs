using System.Reflection;
using Core.BaseTypes;

namespace Tests {
    public static class CellExtensions {
        public static object Field(this Cell cell, string fieldName) {
            var type = cell.GetType();
            var fieldInfo = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            return fieldInfo.GetValue(cell);
        }

        public static void SetField(this Cell cell, string fieldName, object val) {
            var type = cell.GetType();
            var fieldInfo = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(cell, val);
        }
    }
}