using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Core.BaseTypes;
using Core.Enums;
using NUnit.Framework;

namespace Tests {
    public static class AssertExtension {
        public static void ShouldBeTrue(this bool boolean) {
            Assert.IsTrue(boolean);
        }

        public static void ShouldBeFalse(this bool boolean) {
            Assert.IsFalse(boolean);
        }


        public static void ShouldBeGreaterThanZero(this int size) {
            Assert.That(size, Is.GreaterThan(0));
        }


        public static void ShouldBeEmpty(this IEnumerable enumerable) {
            Assert.That(enumerable, Is.Empty);
        }

        public static CollectionAssertCases<T> ShouldContain<T>(this IEnumerable<T> enumerable) {
            return new CollectionAssertCases<T>(enumerable);
        }

        public static void Exact<T>(this CollectionAssertCases<T> collection, T element) {
            Assert.That(collection.AsList, Is.EquivalentTo(new List<T> {element}));
        }

        public static void Only<T>(this CollectionAssertCases<T> collection, Func<T,bool> selection) {
            Assert.IsTrue(collection.AsList.All(selection));
        }

         public static void OnlyCellsOf(this CollectionAssertCases<Cell> collection, CellType cellType) {
            Assert.IsTrue(collection.AsList.All(c => c.CellType == cellType));
        }

         public static IEnumerable<Cell> CellsOf(this CollectionAssertCases<Cell> collection, CellType cellType) {
             return collection.AsList.Where(c => c.CellType == cellType);
         }


        public static void ShouldBeNotNull(this object obj) {
            Assert.IsNotNull(obj);
        }

        public static void ShouldBeNull(this object obj) {
            Assert.IsNull(obj);
        }



        public static void ShouldBeReadonly(this PropertyInfo info) {
            var isPrivate = info.GetAccessors(true)[1].IsPrivate;
            Assert.IsTrue(isPrivate);
        }

        public static void ShouldBeReadonlyCollection<T>(this T enumerable) {
            var genericTypeDefinition = typeof (T).GetGenericTypeDefinition();
            Assert.That(genericTypeDefinition, Is.EqualTo(typeof (ReadOnlyCollection<>)));
        }


        public static void ShouldBeEqual<T>(this T actual, T expected) {
            Assert.That(actual, Is.EqualTo(expected));
        }



        public static object StaticField(this object obj, string fieldName) {
            var type = obj.GetType();
            var fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Static);
            return fieldInfo.GetValue(obj);
        }


        public static PropertyInfo Property(this object obj, string propName) {
            var type = obj.GetType();
            
            return type.GetProperty(propName, BindingFlags.Instance | BindingFlags.Public);
        }


        public static void ExpectException<T>(this Action action) where T : Exception{
            var testDelegate = new TestDelegate(action);
            Assert.Throws(typeof(T), testDelegate);
        }
    }


    public class CollectionAssertCases<T> {
        private readonly IEnumerable<T> enumerable;

        public List<T> AsList {
            get { return new List<T>(enumerable); }
        }

        public CollectionAssertCases(IEnumerable<T> enumerable) {
            this.enumerable = enumerable;
        }

        public void Elements<T>(params T[] elements) {
            Assert.That(enumerable, Is.EquivalentTo(elements));
        }

        public void None() {
            enumerable.ShouldBeEmpty();
        }
    }
}