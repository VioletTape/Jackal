using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.BaseTypes;
using Core.Cells;
using Core.Infrastructure;

namespace Core.Enums {
    public class Team {
        public TeamType Type { get; private set; }

        public CurcuitList<Pirate> Pirates { get; private set; }

        public Ship Ship { get; private set; }

        public Team(TeamType type, IRule rule) {
            Type = type;
            Ship = CreateShip(type, rule.Size);
            Pirates = new CurcuitList<Pirate>(new [] {
                                                         new Pirate(this), 
                                                         new Pirate(this), 
                                                         new Pirate(this), 
                                                     });
        }

        private Ship CreateShip(TeamType type, int size) {
            var constraints = new List<Ship.ShipMovement> {
                                                              Ship.ShipMovement.Vertical,
                                                              Ship.ShipMovement.Horizontal,
                                                              Ship.ShipMovement.Vertical,
                                                              Ship.ShipMovement.Horizontal
                                                          };

            var positions = new List<Position>(4) {
                                                      new Position(size/2, 0),
                                                      new Position(0, size/2),
                                                      new Position(size/2, size - 1),
                                                      new Position(size - 1, size/2)
                                                  };

            return new Ship(this, new WaterCell(positions[(int) type]), constraints[(int) type]);
        }

        public void EndTurn() {
            foreach (var p in Pirates) {
                p.EndTurn();
            }
        }
    }
}