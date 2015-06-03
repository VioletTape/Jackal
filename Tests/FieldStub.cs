using System;
using System.Collections.Generic;
using Core.BaseTypes;

namespace Tests {
    public class FieldStub : Field {
       
        public void InsertCell(Cell cell) {
            field[cell.Position.Column][cell.Position.Row] = cell;
            cell.Field = this;
        }

        
        public FieldStub(IRule rule) : this(rule, 0) {}

        internal FieldStub(IRule rule, int justForTesting) : base(rule, justForTesting) {}


    }
}