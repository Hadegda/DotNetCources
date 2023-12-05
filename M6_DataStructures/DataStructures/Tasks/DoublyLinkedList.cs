using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> _start;
		private Node<T> _end;

		public int Length
        { 
            get
            {
				if (_start == null)
				{
					return 0;
				}

				var i = 1;
				for (var t = _start; t.Next != null; t = t.Next)
				{
					i++;
				}
                return i;
			}
        }

        public void Add(T e)
        {
            if (_start == null)
            {
				_start = new Node<T> { Data = e };
				_end = _start;
				return;
			}

			AddToEnd(e);

		}

        public void AddAt(int index, T e)
        {
			if (index < 0 || Length < index)
			{
				throw new IndexOutOfRangeException();
			}

			if (_start == null)
			{
				_start = new Node<T> { Data = e };
				return;
			}

			if (index == 0)
			{
				AddToStart(e);
				return;
			}

			if (index == Length)
			{
				AddToEnd(e);
				return;
			}

			var t = GetNodeAt(index);

			var n = new Node<T> { Data = e, Prev = t.Prev, Next = t };
			t.Prev.Next = n;
			t.Prev = n;
		}

        public T ElementAt(int index)
        {
			if (index < 0 || _start == null || Length <= index)
			{
				throw new IndexOutOfRangeException();
			}

			return GetNodeAt(index).Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
			return new Enumerator(this);
		}

        public void Remove(T item)
        {
			if (_start == null)
			{
				throw new NullReferenceException();
			}

			if (item.Equals(_start.Data) && _start.Next == null)
			{
				_start = null;
				return;
			}

			if (item.Equals(_start.Data))
			{
				GetAndRemoveFirst();
				return;
			}

			var t = _start;
			while (t.Next != _end)
			{
				if (item.Equals(t.Data))
				{
					t.Prev.Next = t.Next;
					t.Next.Prev = t.Prev;
					return;
				}
				t = t.Next;
			}

			if (item.Equals(_end.Data))
			{
				GetAndRemoveLast();
				return;
			}
		}

        public T RemoveAt(int index)
        {
			if (index < 0 || _start == null || Length <= index)
			{
				throw new IndexOutOfRangeException();
			}

			if (index == 0 && _start.Next == null)
			{
				var data = _start.Data;
				_start = null;
				return data;
			}

			if (index == 0)
			{
				return GetAndRemoveFirst();
			}

			if (index == Length - 1)
			{
				return GetAndRemoveLast();
			}

			var t = GetNodeAt(index);
			t.Prev.Next = t.Next;
			t.Next.Prev = t.Prev;
		
			return t.Data;
		}

        IEnumerator IEnumerable.GetEnumerator()
        {
			return GetEnumerator();
		}

		private void AddToStart(T e)
		{
			var n = new Node<T> { Data = e, Next = _start };
			_start.Prev = n;
			_start = n;
		}

		private void AddToEnd(T e)
		{
			var n = new Node<T> { Data = e, Prev = _end };
			_end.Next = n;
			_end = n;
		}

		private T GetAndRemoveFirst()
		{
			var data = _start.Data;
			_start = _start.Next;
			_start.Prev = null;

			return data;
		}

		private T GetAndRemoveLast()
		{
			var data = _end.Data;
			_end = _end.Prev;
			_end.Next = null;

			return data;
		}

		private Node<T> GetNodeAt(int index)
		{
			var t = _start;
			for (var i = 0; i < index; i++)
			{
				t = t.Next;
			}
			return t;
		}

		public class Node<T1>
		{
			public T1 Data { get; set; }
			public Node<T1> Prev { get; set; }
			public Node<T1> Next { get; set; }
		}

		public class Enumerator : IEnumerator<T>
		{
			private Node<T> _current;

			public Enumerator(DoublyLinkedList<T> list)
			{
				_current = new Node<T> { Next = list._start };
			}

			public T Current
			{
				get
				{
					if (_current == null)
					{
						throw new InvalidOperationException("Enumerator Ended");
					}

					return _current.Data;
				}
			}

			object IEnumerator.Current => Current;

			public void Dispose()
			{
				_current = null;
			}

			public bool MoveNext()
			{
				if (_current == null || _current.Next == null)
				{
					return false;
				}

				_current = _current.Next;
				return true;
			}

			public void Reset()
			{
				while(_current.Prev != null)
				{
					_current = _current.Prev;
				}
			}
		}
	}
}
