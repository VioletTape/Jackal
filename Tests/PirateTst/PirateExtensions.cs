using System.Reflection;
using Core.BaseTypes;

namespace Tests.PirateTst {
    public static class PirateExtensions {
        public static bool IsWithGold(this Pirate pirate) {
            var type = pirate.GetType();
            var fieldInfo = type.GetField("isWithGold", BindingFlags.Instance | BindingFlags.NonPublic);
            return (bool) fieldInfo.GetValue(pirate);
        }

        public static void SetWithGold(this Pirate pirate) {
            var type = pirate.GetType();
            var fieldInfo = type.GetField("isWithGold", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldInfo.SetValue(pirate, true);
        }
    }
}