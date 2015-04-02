using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Enums;
using NUnit.Framework;

namespace Tests.Cells {
    [TestFixture]
    public class CellFactoryTests {
        [Test]
        public void CanCreateAllTypes() {
            var missedCellTypes = new List<CellType>();

            var values = (IList) Enum.GetValues(typeof (CellType));
            for (var i = 0; i < values.Count; i++) {
                var cellType = (CellType) values[i];
                try {
                    CellFactory.Create(cellType, 1, 1);
                }
                catch (Exception e) {
                    missedCellTypes.Add(cellType);
                    Console.WriteLine(cellType.ToString());
                }
            }

            missedCellTypes.ShouldBeEmpty();
        }
    }
}