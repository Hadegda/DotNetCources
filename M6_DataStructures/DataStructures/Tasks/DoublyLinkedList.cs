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
				for (var t = _start; t.next != null; t = t.next)
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
				_start = new Node<T> { data = e };
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
				_start = new Node<T> { data = e };
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

			var n = new Node<T> { data = e, prev = t.prev, next = t };
			t.prev.next = n;
			t.prev = n;
		}

        public T ElementAt(int index)
        {
			if (index < 0 || _start == null || Length <= index)
			{
				throw new IndexOutOfRangeException();
			}

			return GetNodeAt(index).data;
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

			if (item.Equals(_start.data) && _start.next == null)
			{
				_start = null;
				return;
			}

			if (item.Equals(_start.data))
			{
				GetAndRemoveFirst();
				return;
			}

			if (item.Equals(_start.next.data) && _start.next.next == null)
			{
				_start.next.prev = null;
				_start.next = null;
				return;
			}

			var t = _start;
			while (t.next.next != null)
			{
				if (item.Equals(t.data))
				{
					t.prev.next = t.next;
					t.next.prev = t.prev;
					return;
				}
				t = t.next;
			}

			if (item.Equals(t.next.data))
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

			if (index == 0 && _start.next == null)
			{
				var data = _start.data;
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
			t.prev.next = t.next;
			t.next.prev = t.prev;
			
			t.prev = null;
			t.next = null;
			return t.data;
		}

        IEnumerator IEnumerable.GetEnumerator()
        {
			return new Enumerator(this);
		}

		private void AddToStart(T e)
		{
			var n = new Node<T> { data = e, next = _start };
			_start.prev = n;
			_start = n;
		}

		private void AddToEnd(T e)
		{
			var t = _start;
			while (t.next != null)
			{
				t = t.next;
			}
			var n = new Node<T> { data = e, prev = t };
			t.next = n;
		}

		private T GetAndRemoveFirst()
		{
			var t = _start;
			_start = _start.next;
			_start.prev = null;

			t.next = null;
			return t.data;
		}

		private T GetAndRemoveLast()
		{
			var t = _start;
			while (t.next != null)
			{
				t = t.next;
			}
			t.prev.next = null;

			t.prev = null;
			return t.data;
		}

		private Node<T> GetNodeAt(int index)
		{
			var t = _start;
			for (var i = 0; i < index; i++)
			{
				t = t.next;
			}
			return t;
		}

		public class Node<T>
		{
			public T data { get; set; }
			public Node<T>? prev { get; set; } = null;
			public Node<T>? next { get; set; } = null;
		}

		public class Enumerator : IEnumerator<T>
		{
			private Node<T>? _current = null;

			internal Enumerator(DoublyLinkedList<T> list)
			{
				_current = new Node<T> { next = list._start };
			}

			public T Current
			{
				get
				{
					if (_current == null) throw new InvalidOperationException("Enumerator Ended");

					return _current.data;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					if (_current == null) throw new InvalidOperationException("Enumerator Ended");
					return _current.data;
				}
			}

			public void Dispose()
			{
				_current = null;
			}

			public bool MoveNext()
			{
				if (_current == null || _current.next == null)
				{
					return false;
				}
				else
				{
					_current = _current.next;
					return true;
				}
			}

			public void Reset()
			{
				while(_current.prev != null)
				{
					_current = _current.prev;
				}
			}
		}
	}
}
