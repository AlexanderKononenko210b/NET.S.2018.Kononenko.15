using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    /// <summary>
    /// Custom class queue
    /// </summary>
    /// <typeparam name="T">type object for save in queue</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        private const int INITIAL_SIZE = 4;

        private const int GROWTH_FACTOR = 2;

        private int head;

        private int tail;

        private int size;

        private int count;

        private T[] array;

        /// <summary>
        /// Constructor for type Queue
        /// </summary>
        public Queue()
        {
            this.size = INITIAL_SIZE;

            this.array = new T[INITIAL_SIZE];

            this.head = 0;

            this.tail = 0;
        }

        /// <summary>
        /// Property for control version Queue
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Index for the access element Queue
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return this.array[index]; }
        }

        /// <summary>
        /// Method for resize array with copy element
        /// </summary>
        /// <returns>new array</returns>
        private T[] ResizeArray()
        {
            T[] newArray;

            checked
            {
                size = array.Length * GROWTH_FACTOR;
            }

            newArray = new T[size];

            array.CopyTo(newArray, 0);

            return newArray;
        }

        /// <summary>
        /// Method for copy all element array in new array without first element
        /// </summary>
        /// <param name="newArray">arraay for copy with the same Length</param>
        /// <param name="arrayIndex">index for start copy</param>
        private void DelCopyTo(T[] newArray, int arrayIndex)
        {
            for (int i = arrayIndex; i <= tail; i++)
            {
                newArray[i - 1] = this.array[i];
            }
        }

        /// <summary>
        /// Property for return count element in array
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Property for return size of array
        /// </summary>
        public int Size => array.Length;

        /// <summary>
        /// Method for add new element in the end queue
        /// </summary>
        /// <param name="obj">object for add in queue</param>
        public void Enqueue(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException($"Argument {nameof(obj)} is null");

            if (tail == 0)
                array[tail] = obj;

            array[tail++] = obj;

            count++;

            if (tail == array.Length)
                array = ResizeArray();
        }

        /// <summary>
        /// Method for return first element in array without delete this element
        /// </summary>
        /// <returns>last element in queue</returns>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException($"Queue is empty");

            return array[head];
        }

        /// <summary>
        /// Method for return first element in array with delete this element
        /// </summary>
        /// <returns>first element in queue</returns>
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException($"Queue is empty");

            var firstElement = array[head];

            var newArray = new T[size];

            this.DelCopyTo(newArray, 1);

            array = newArray;

            return firstElement;
        }

        /// <summary>
        /// Method for clear queue
        /// </summary>
        public void Clear()
        {
            if (Count == 0)
                throw new InvalidOperationException($"Queue is already clear");

            array = new T[INITIAL_SIZE];

            this.count = 0;

            this.size = 4;
        }

        /// <summary>
        /// Method for determain that queue contain item
        /// </summary>
        /// <param name="item">element for find in queue</param>
        /// <returns>true if queue contain element</returns>
        public bool Contains(T item)
        {
            if (item == null)
                throw new ArgumentNullException($"Argument {nameof(item)} is null");

            if (Count == 0)
                throw new InvalidOperationException($"Queue is Empty");

            var enumerator = GetEnumerator();

            while (enumerator.MoveNext())
                if (enumerator.Current.Equals(item))
                    return true;
            return false;
        }

        /// <summary>
        /// Method for get instance struct CustomEnumerator
        /// </summary>
        /// <returns>instance struct CustomEnumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomEnumerator(this);
        }

        /// <summary>
        /// Explisit call method interface
        /// </summary>
        /// <returns>result method GetEnumerator()</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Custom struct representing object for collection iteration 
        /// </summary>
        private struct CustomEnumerator : IEnumerator<T>
        {
            private Queue<T> Queue;

            private int version;

            private T current;

            private int index;

            /// <summary>
            /// Readonly property representing element in Queue
            /// </summary>
            public T Current
            {
                get
                {
                    if (index == -1)
                        throw new InvalidOperationException($"Enumeration was not started");


                    if (index == Queue.Count)
                        throw new InvalidOperationException($"Enumeration was ended");

                    return Queue[index];
                }
            }

            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Constructor for struct CustomEnumerator
            /// </summary>
            /// <param name="Queue">collection for iteration</param>
            public CustomEnumerator(Queue<T> Queue)
            {
                this.Queue = Queue;

                this.version = Queue.Version;

                this.index = -1;

                this.current = default(T);
            }

            /// <summary>
            /// Method for movement through collection type Queue
            /// </summary>
            /// <returns>true if next element in collection is exist</returns>
            public bool MoveNext()
            {
                if (this.version != Queue.Version)
                    throw new InvalidOperationException($"CustonQueue was changed");

                index++;

                if (index > -1 && index < Queue.Count)
                    return true;
                return false;
            }

            /// <summary>
            /// Method for reset index in a start position
            /// </summary>
            public void Reset()
            {
                if (this.version != Queue.Version)
                    throw new InvalidOperationException($"CustonQueue was changed");

                this.index = -1;

                this.current = default(T);
            }

            void IDisposable.Dispose() { }
        }
    }
}
