using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.BaseTypes;
using Core.Cells;

namespace Core.Enums {
    public class Team {
        private readonly List<Pirate> pirates = new List<Pirate>(3);
        public TeamType Type { get; private set; }

        public ReadOnlyCollection<Pirate> Pirates {
            get { return pirates.AsReadOnly(); }
        }

        public Ship Ship { get; private set; }

        public Team(TeamType type, IRule rule) {
            Type = type;

            Ship = CreateShip(type, rule.Size);

            for (var i = 0; i < 3; i++) {
                pirates.Add(new Pirate(Ship));
            }
        }

        private static Ship CreateShip(TeamType type, int size) {
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

            return new Ship(type, new WaterCell(positions[(int) type]), constraints[(int) type]);
        }
    }
}