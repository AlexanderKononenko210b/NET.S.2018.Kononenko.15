using System;
using NUnit.Framework;
using CustomQueue;

namespace Queue.Test
{
    /// <summary>
    /// Class for test class Queue
    /// </summary>
    [TestFixture]
    public class QueueTest
    {
        /// <summary>
        /// Test create Queue element type int
        /// </summary>
        [TestCase]
        public void Create_Queue_Type_Int()
        {
            var Queue = new Queue<int>();
            Assert.AreEqual(4, Queue.Size);
            Assert.AreEqual(0, Queue.Count);
        }

        /// <summary>
        /// Test Enqueue new elements as last in Queue
        /// </summary>
        [TestCase]
        public void Enqueue_Queue_Type_Int()
        {
            var Queue = new Queue<int>();
            Queue.Enqueue(5);
            Queue.Enqueue(6);
            Queue.Enqueue(9);
            Assert.AreEqual(3, Queue.Count);
            Assert.IsTrue(Queue.Contains(5));
            Assert.IsTrue(Queue.Contains(6));
            Assert.IsTrue(Queue.Contains(9));
            Assert.IsFalse(Queue.Contains(10));
            Assert.AreEqual(5, Queue.Peek());
        }

        /// <summary>
        /// Test Dequeue element in Queue
        /// </summary>
        [TestCase]
        public void Dequeue_Queue_Type_Int()
        {
            var Queue = new Queue<int>();
            Queue.Enqueue(5);
            Queue.Enqueue(6);
            Queue.Enqueue(9);
            Assert.AreEqual(5, Queue.Peek());
            var assert1 = Queue.Dequeue();
            Assert.AreEqual(5, assert1);
            Assert.AreEqual(6, Queue.Peek());
        }

        /// <summary>
        /// Test Enqueue new elements as last in Queue and resize size queue
        /// </summary>
        [TestCase]
        public void Enqueue_With_Resize_Queue_Type_Int()
        {
            var Queue = new Queue<int>();
            Queue.Enqueue(5);
            Queue.Enqueue(6);
            Queue.Enqueue(9);
            Assert.AreEqual(4, Queue.Size);
            Queue.Enqueue(10);
            Assert.AreEqual(8, Queue.Size);
            Queue.Enqueue(8);
            Assert.AreEqual(8, Queue.Size);
            Queue.Enqueue(23);
            Assert.AreEqual(8, Queue.Size);
            Queue.Enqueue(34);
            Assert.AreEqual(8, Queue.Size);
            Queue.Enqueue(23);
            Assert.AreEqual(16, Queue.Size);
        }

        /// <summary>
        /// Test Clear all elements in Queue
        /// </summary>
        [TestCase]
        public void Clear_Queue_Type_Int()
        {
            var Queue = new Queue<int>();
            Queue.Enqueue(5);
            Queue.Enqueue(6);
            Queue.Enqueue(9);
            Queue.Enqueue(10);
            Queue.Enqueue(8);
            Queue.Enqueue(23);
            Queue.Enqueue(34);
            Queue.Enqueue(23);
            Assert.AreEqual(8, Queue.Count);
            Assert.AreEqual(16, Queue.Size);
            Queue.Clear();
            Assert.AreEqual(0, Queue.Count);
            Assert.AreEqual(4, Queue.Size);
        }

        /// <summary>
        /// Test Enqueue new elements as last in Queue and resize size queue
        /// </summary>
        [TestCase]
        public void Foreach_Queue_Type_Int()
        {
            var Queue = new Queue<int>();
            Queue.Enqueue(5);
            Queue.Enqueue(6);
            Queue.Enqueue(9);
            Queue.Enqueue(10);
            Queue.Enqueue(8);
            Queue.Enqueue(23);
            Queue.Enqueue(34);
            Queue.Enqueue(23);
            var index = 0;
            foreach (int number in Queue)
            {
                Assert.AreEqual(Queue[index], number);
                index++;
            }
        }
    }
}
