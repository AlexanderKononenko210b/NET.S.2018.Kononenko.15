using System;
using NUnit.Framework;

namespace BinarySearchTree.Test
{
    /// <summary>
    /// Class test CustomBinarySearchTree with struct Point
    /// </summary>
    [TestFixture]
    public class PointTest
    {
        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with IComparer
        /// </summary>
        [Test]
        public void Point_Preorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new PointComparator();

            var newTree = new CustomBinarySearchTree<Point>(comparer);

            var point1 = new Point(14.0, 5.0);

            newTree.Add(point1);

            var point2 = new Point(22.0, 5.0);

            newTree.Add(point2);

            var point3 = new Point(2.0, 5.0);

            newTree.Add(point3);

            var helperArrayResult = new Point[3] { point1, point3, point2 };

            var index = 0;

            foreach (Point item in newTree.Preorder())
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

            var newTree = new CustomBinarySearchTree<Point>(comparer);

            var point1 = new Point(14.0, 5.0);

            newTree.Add(point1);

            var point2 = new Point(22.0, 5.0);

            newTree.Add(point2);

            var point3 = new Point(2.0, 5.0);

            newTree.Add(point3);

            var helperArrayResult = new Point[3] { point3, point2, point1 };

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

            var newTree = new CustomBinarySearchTree<Point>(comparer);

            var point1 = new Point(14.0, 5.0);

            newTree.Add(point1);

            var point2 = new Point(22.0, 5.0);

            newTree.Add(point2);

            var point3 = new Point(2.0, 5.0);

            newTree.Add(point3);

            var helperArrayResult = new Point[3] { point3, point1, point2 };

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

            var newTree = new CustomBinarySearchTree<Point>(comparison);

            var point1 = new Point(14.0, 5.0);

            newTree.Add(point1);

            var point2 = new Point(22.0, 5.0);

            newTree.Add(point2);

            var point3 = new Point(2.0, 5.0);

            newTree.Add(point3);

            var helperArrayResult = new Point[3] { point1, point3, point2 };

            var index = 0;

            foreach (Point item in newTree.Preorder())
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

            var newTree = new CustomBinarySearchTree<Point>(comparison);

            var point1 = new Point(14.0, 5.0);

            newTree.Add(point1);

            var point2 = new Point(22.0, 5.0);

            newTree.Add(point2);

            var point3 = new Point(2.0, 5.0);

            newTree.Add(point3);

            var helperArrayResult = new Point[3] { point3, point2, point1 };

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

            var newTree = new CustomBinarySearchTree<Point>(comparison);

            var point1 = new Point(14.0, 5.0);

            newTree.Add(point1);

            var point2 = new Point(22.0, 5.0);

            newTree.Add(point2);

            var point3 = new Point(2.0, 5.0);

            newTree.Add(point3);

            var helperArrayResult = new Point[3] { point3, point1, point2 };

            var index = 0;

            foreach (Point item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }
    }
}
