using System.Collections.Generic;
using Core.Infrastructure;
using NUnit.Framework;

namespace Tests.Infrastructure {
    [TestFixture]
    public class CurcuitListTests {
        [SetUp]
        public void TestInit() {}

        [Test]
        public void ShouldReturnFirstItemByCurrent() {
            // Assert
            var ints = new List<int> {
                                         10,
                                         20,
                                     };

            var curcuitList = new CurcuitList<int>(ints);

            curcuitList.Current
                       .ShouldBeEqual(10);
        }

        [Test]
        public void ShouldReturnNextItem() {
            // Assert
            var ints = new List<int> {
                                         10,
                                         20,
                                     };

            var curcuitList = new CurcuitList<int>(ints);

            curcuitList.GetNext()
                       .ShouldBeEqual(20);
        }

         [Test]
        public void ShouldReturninCurcuit() {
            // Assert
            var ints = new List<int> {
                                         10,
                                         20,
                                     };

            var curcuitList = new CurcuitList<int>(ints);

            curcuitList.GetNext();
            curcuitList.GetNext()
                       .ShouldBeEqual(10);
        }
    }
}