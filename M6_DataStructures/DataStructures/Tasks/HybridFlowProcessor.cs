using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private readonly DoublyLinkedList<T> _values = new DoublyLinkedList<T>();

		public T Dequeue()
        {
            if (_values.Length == 0)
            {
				throw new InvalidOperationException();
			}
			return _values.RemoveAt(0);
		}

        public void Enqueue(T item)
        {
			_values.Add(item);
		}

        public T Pop()
		{
			if (_values.Length == 0)
			{
				throw new InvalidOperationException();
			}
			return _values.RemoveAt(_values.Length - 1);
        }

        public void Push(T item)
        {
            _values.Add(item);
        }
    }
}
