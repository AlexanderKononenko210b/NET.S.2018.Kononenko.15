using System;
using NUnit.Framework;
using CustomBinarySearchTree;

namespace BinarySearchTree.Test
{
    /// <summary>
    /// Class test BinarySearchTree with struct Point
    /// </summary>
    [TestFixture]
    public class PointTest
    {
        private Point[] inputArray = new Point[3] { new Point(14.0, 5.0), new Point(22.0, 5.0), new Point(2.0, 5.0) };

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with IComparer
        /// </summary>
        [Test]
        public void Point_Preorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new PointComparator();

            var newTree = new BinarySearchTree<Point>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new Point[3] { inputArray[0], inputArray[2], inputArray[1] };

            var index = 0;

            foreach (Point item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order with IComparer
        /// </summary>
        [Test]
        public void Point_Postorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new PointComparator();

            var newTree = new BinarySearchTree<Point>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new Point[3] { inputArray[2], inputArray[1], inputArray[0] };

            var index = 0;

            foreach (Point item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a invariant order with IComparer
        /// </summary>
        [Test]
        public void Point_Inorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new PointComparator();

            var newTree = new BinarySearchTree<Point>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new Point[3] { inputArray[2], inputArray[0], inputArray[1] };

            var index = 0;

            foreach (Point item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with Comparison
        /// </summary>
        [Test]
        public void Point_Preorder_CustomBinaryTree_With_Comparison()
        {
            var comparer = new PointComparator();

            Comparison<Point> comparison = comparer.Compare;

            var newTree = new BinarySearchTree<Point>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new Point[3] { inputArray[0], inputArray[2], inputArray[1] };

            var index = 0;

            foreach (Point item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index], item);

                index++;
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order with Comparison
        /// </summary>
        [Test]
        public void Point_Postorder_CustomBinaryTree_With_Comparison()
        {
            var comparer = new PointComparator();

            Comparison<Point> comparison = comparer.Compare;

            var newTree = new BinarySearchTree<Point>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new Point[3] { inputArray[2], inputArray[1], inputArray[0] };

            var index = 0;

            foreach (Point item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a invariant order with Comparison
        /// </summary>
        [Test]
        public void Point_Inorder_CustomBinaryTree_With_Comparison()
        {
            var comparer = new PointComparator();

            Comparison<Point> comparison = comparer.Compare;

            var newTree = new BinarySearchTree<Point>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new Point[3] { inputArray[2], inputArray[0], inputArray[1] };

            var index = 0;

            foreach (Point item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test Search item in BinarySearchTree if T is type Point
        /// </summary>
        [Test]
        public void Point_Contains_CustomBinaryTree()
        {
            var comparer = new PointComparator();

            var newTree = new BinarySearchTree<Point>(inputArray, comparer);

            Assert.IsTrue(newTree.Contains(inputArray[0]));

            Assert.IsFalse(newTree.Contains(new Point(12.0, 5.0)));
        }
    }
}
