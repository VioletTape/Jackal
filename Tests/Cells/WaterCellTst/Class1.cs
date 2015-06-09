using Core.BaseTypes;
using Core.Enums;
using NUnit.Framework;

namespace Tests.Cells.WaterCellTst {
    [TestFixture]
    public class Class1 {
        [Test]
        public void ShouldBeAwareOfRestricedDirections() {
            //Arrange
            var field = new GreenField();
            var pirate = field.CurrentPirate;
                                                                  //   1 2                               
                                                                  // 5 p <---- так ходить нельзя           
            //Act                                                 // 6s                                    
            field.MovePirateTo(pirate, field.Cells(1, 5));        // 7                                     
                                                                  // 8                                     
            //Assert
            pirate.Position
                .ShouldBeEqual(new Position(0,6));
        }
    }
}