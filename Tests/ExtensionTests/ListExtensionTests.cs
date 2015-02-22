using System.Collections.Generic;
using Core.Extensions;
using NUnit.Framework;

namespace Tests.ExtensionTests {
    [TestFixture]
    public class ListExtensionTests {
        [Test]
        public void CheckEmptyList() {
            var ints = new List<int>();

            ints.NotEmpty().ShouldBeFalse();

            ints.Add(12);

            ints.NotEmpty().ShouldBeTrue();
        }
    }
}