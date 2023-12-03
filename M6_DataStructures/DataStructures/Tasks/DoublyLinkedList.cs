using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        protected Node<T>? _start = null;

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

			if (item.Equals(_start.Next.Data) && _start.Next.Data == null)
			{
				_start.Next.Prev = null;
				_start.Next = null;
				return;
			}

			var t = _start;
			while (t.Next.Next != null)
			{
				if (item.Equals(t.Data))
				{
					t.Prev.Next = t.Next;
					t.Next.Prev = t.Prev;
					return;
				}
				t = t.Next;
			}

			if (item.Equals(t.Next.Data))
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
			
			t.Prev = null;
			t.Next = null;
			return t.Data;
		}

        IEnumerator IEnumerable.GetEnumerator()
        {
			return new Enumerator(this);
		}

		private void AddToStart(T e)
		{
			var n = new Node<T> { Data = e, Next = _start };
			_start.Prev = n;
			_start = n;
		}

		private void AddToEnd(T e)
		{
			var t = _start;
			while (t.Next != null)
			{
				t = t.Next;
			}
			var n = new Node<T> { Data = e, Prev = t };
			t.Next = n;
		}

		private T GetAndRemoveFirst()
		{
			var t = _start;
			_start = _start.Next;
			_start.Prev = null;

			t.Next = null;
			return t.Data;
		}

		private T GetAndRemoveLast()
		{
			var t = _start;
			while (t.Next != null)
			{
				t = t.Next;
			}
			t.Prev.Next = null;

			t.Prev = null;
			return t.Data;
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

		public class Node<T>
		{
			public T Data { get; set; }
			public Node<T>? Prev { get; set; } = null;
			public Node<T>? Next { get; set; } = null;
		}

		public class Enumerator : IEnumerator<T>
		{
			private Node<T>? _current = null;

			internal Enumerator(DoublyLinkedList<T> list)
			{
				_current = new Node<T> { Next = list._start };
			}

			public T Current
			{
				get
				{
					if (_current == null) throw new InvalidOperationException("Enumerator Ended");

					return _current.Data;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					if (_current == null) throw new InvalidOperationException("Enumerator Ended");
					return _current.Data;
				}
			}

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
				else
				{
					_current = _current.Next;
					return true;
				}
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
