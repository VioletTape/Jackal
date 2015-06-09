using Core.BaseTypes;
using Tests.RulesForTesting;

namespace Tests {
    public class FieldStub : Field {
        public void InsertCell(Cell cell) {
            field[cell.Position.Column][cell.Position.Row] = cell;
            cell.Field = this;
        }


        public FieldStub(IRule rule) : this(rule, 0) {}

        internal FieldStub(IRule rule, int justForTesting) : base(rule, justForTesting) {}
    }

    public class GreenField : FieldStub {
        public GreenField() : base(new TestEmptyRules()) {
            GeneratePlayers(new TestEmptyRules());
            
            GenerateGrass();
            LinkAllCellsToField();
        }

        public Pirate CurrentPirate {
            get {
                var currentPirate = CurrentPlayer.CurrentTeam.Pirates.Current;
                currentPirate.StartTurn();
                return currentPirate;
            }
        }


        internal GreenField(IRule rule, int justForTesting) : base(rule, justForTesting) {}
    }
}