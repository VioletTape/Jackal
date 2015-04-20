using System.Collections.Generic;
using Core.Cells;
using Core.Enums;

namespace Core.BaseTypes {
	public class Ship : IHavePosition {
		private ShipMovementStrategy strategy;

		public TeamType TeamType { get; set; }

		public Position Position {
			get { return Cell.Position; }
		}

		public List<Pirate> Pirates;

		public int Gold { get; private set; }

		public WaterCell Cell { get; set; }

		public Ship(Team team, WaterCell cell, ShipMovement movement = ShipMovement.None) {
			Gold = 0;
			TeamType = team.Type;

			SelectStrategy(movement);
		}

		private void SelectStrategy(ShipMovement movement) {
			switch (movement) {
				case ShipMovement.None:
					strategy = new EmptyShipMovementStrategy(this);
					break;
				case ShipMovement.Horizontal:
					strategy = new HorizontalShipMovementStrategy(this);
					break;
				case ShipMovement.Vertical:
					strategy = new VerticalShipMovementStrategy(this);
					break;
			}
		}

		public void AddGold() {
			Gold = Gold + 1;
		}

		public void MoveTo(WaterCell cell) {
			if (Pirates.Count < 1) {
				return;
			}

			if (strategy.MoveAllowedTo(cell)) {
                // todo: как-то не так должно быть
			    Cell = cell;
			    //				Cell.ShipLeaves();
			    //				cell.ShipComes(this);
			}
		}

		public bool IsMotherShip(Pirate pirate) {
			return true;
		}

		public bool Equals(Ship other) {
			if (ReferenceEquals(null, other)) {
				return false;
			}
			if (ReferenceEquals(this, other)) {
				return true;
			}
			return Equals(other.TeamType, TeamType);
		}

		public override bool Equals(object obj) {
			if (ReferenceEquals(null, obj)) {
				return false;
			}
			if (ReferenceEquals(this, obj)) {
				return true;
			}
			if (obj.GetType() != typeof (Ship)) {
				return false;
			}
			return Equals((Ship) obj);
		}

		public override int GetHashCode() {
			return TeamType.GetHashCode();
		}

		public enum ShipMovement {
			None,
			Vertical,
			Horizontal
		}
	}

	public abstract class ShipMovementStrategy {
		private readonly Ship ship;
		private readonly Movement movement;

		protected ShipMovementStrategy(Ship ship, Movement movement) {
			this.ship = ship;
			this.movement = movement;
		}


		public virtual bool MoveAllowedTo(Cell cell) {
			if (cell.CellType != CellType.Water) {
				return false;
			}
			var directionFrom = cell.Position.GetDirectionFrom(ship.Cell.Position);

			return Foo(directionFrom);
		}

		internal abstract bool Foo(Direction directionFrom);


		public enum Movement {
			Vert,
			Hor
		}
	}

	internal class HorizontalShipMovementStrategy : ShipMovementStrategy {
		public HorizontalShipMovementStrategy(Ship ship) : base(ship, Movement.Hor) {}

		internal override bool Foo(Direction directionFrom) {
			return directionFrom == Direction.E || directionFrom == Direction.W;
		}
	}

	internal class VerticalShipMovementStrategy : ShipMovementStrategy {
		public VerticalShipMovementStrategy(Ship ship) : base(ship, Movement.Vert) {}

		internal override bool Foo(Direction directionFrom) {
			return directionFrom == Direction.S || directionFrom == Direction.N;
		}
	}

	internal class EmptyShipMovementStrategy : ShipMovementStrategy {
		public EmptyShipMovementStrategy(Ship ship) : base(ship, Movement.Vert) {}

		internal override bool Foo(Direction directionFrom) {
			return true;
		}
	}
}