using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Infrastructure {
    public class CurcuitList<T> : IEnumerable<T> {
        private readonly List<T> items;
        private int index;
        private readonly int count;

        public CurcuitList(IEnumerable<T> list) {
            items = new List<T>(list);
            count = items.Count;
        }

        public int Count {
            get { return items.Count; }
        }

        public T Current {
            get { return items[index]; }
        }

        public T GetNext() {
            index = (index + 1) % count;
            return Current;
        }

        public IEnumerator<T> GetEnumerator() {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

    }
}