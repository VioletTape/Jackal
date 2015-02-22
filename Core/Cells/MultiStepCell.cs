using System.Collections.Generic;
using Core.BaseTypes;

namespace Core.Cells {
    public class MultiStepCell : Cell {
        private readonly int stepsNumber;
        private readonly Dictionary<int, List<Pirate>> steps = new Dictionary<int, List<Pirate>>();

        protected MultiStepCell(int stepsNumber, int col, int row) : base(col, row) {
            MultiStep = true;
            this.stepsNumber = stepsNumber - 1;

            for (var i = 0; i < stepsNumber; i++) {
                steps[i] = new List<Pirate>();
            }
        }

        protected override bool PirateComes(Pirate pirate) {
            if (!Pirates.Contains(pirate)) {
                KillFoesFor(steps[0], pirate);
            }
            steps[0].Add(pirate);

            return true;

        }

        public override bool PirateWent(Pirate pirate) {
            if (steps[stepsNumber].Contains(pirate)) {
                return base.PirateWent(pirate);
            }

            for (var i = stepsNumber; i > 0; i--) {
                if (steps[i - 1].Contains(pirate)) {
                    steps[i - 1].Remove(pirate);

                    KillFoesFor(steps[i], pirate);
                    steps[i].Add(pirate);
                }
            }

            return false;
        }
    }
}