using System;
using NUnit.Framework;
using CustomBinarySearchTree;

namespace BinarySearchTree.Test
{
    /// <summary>
    /// Class test BinarySearchTree with System.Int32
    /// </summary>
    [TestFixture]
    public class SystemInt32Test
    {
        private int[] inputArray = new int[7] {5, 3, 8, 1, 4, 6, 9};
        
        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with IComparer
        /// </summary>
        [Test]
        public void Int_Preorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new IntComparator();

            var newTree = new BinarySearchTree<int>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 5, 3, 1, 4, 8, 6, 9 };

            var index = 0;

            foreach (int item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order with IComparer
        /// </summary>
        [Test]
        public void Int_Postorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new IntComparator();

            var newTree = new BinarySearchTree<int>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 1, 4, 3, 6, 9, 8, 5 };

            var index = 0;

            foreach (int item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a invariant order with IComparer
        /// </summary>
        [Test]
        public void Int_Inorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new IntComparator();

            var newTree = new BinarySearchTree<int>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 1, 3, 4, 5, 6, 8, 9 };

            var index = 0;

            foreach (int item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with Comparison
        /// </summary>
        [Test]
        public void Int_Preorder_CustomBinaryTree_With_Comparison()
        {
            var comparer = new IntComparator();

            Comparison<int> comparison = comparer.Compare;

            var newTree = new BinarySearchTree<int>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 5, 3, 1, 4, 8, 6, 9 };

            var index = 0;

            foreach (int item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order with Comparison
        /// </summary>
        [Test]
        public void Int_Postorder_CustomBinaryTree_With_Comparison()
        {
            var comparer = new IntComparator();

            Comparison<int> comparison = comparer.Compare;

            var newTree = new BinarySearchTree<int>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 1, 4, 3, 6, 9, 8, 5 };

            var index = 0;

            foreach (int item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a invariant order with Comparison
        /// </summary>
        [Test]
        public void Int_Inorder_CustomBinaryTree_With_Comparison()
        {
            var comparer = new IntComparator();

            Comparison<int> comparison = comparer.Compare;

            var newTree = new BinarySearchTree<int>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 1, 3, 4, 5, 6, 8, 9 };

            var index = 0;

            foreach (int item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order if IComparer is null
        /// </summary>
        [Test]
        public void Int_Preorder_CustomBinaryTree_With_IComparer_Null()
        {
            var comparer = new IntComparator();

            comparer = null;

            var newTree = new BinarySearchTree<int>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 5, 3, 1, 4, 8, 6, 9 };

            var index = 0;

            foreach (int item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order if IComparer is null
        /// </summary>
        [Test]
        public void Int_Postorder_CustomBinaryTree_With_IComparer_Null()
        {
            var comparer = new IntComparator();

            comparer = null;

            var newTree = new BinarySearchTree<int>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 1, 4, 3, 6, 9, 8, 5 };

            var index = 0;

            foreach (int item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in an invariant order if IComparer is null
        /// </summary>
        [Test]
        public void Int_Inorder_CustomBinaryTree_With_IComparer_Null()
        {
            var comparer = new IntComparator();

            comparer = null;

            var newTree = new BinarySearchTree<int>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 1, 3, 4, 5, 6, 8, 9 };

            var index = 0;

            foreach (int item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order if Comparison is null
        /// </summary>
        [Test]
        public void Int_Preorder_CustomBinaryTree_With_Comparison_Null()
        {
            var comparer = new IntComparator();

            Comparison<int> comparison = null;

            var newTree = new BinarySearchTree<int>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 5, 3, 1, 4, 8, 6, 9 };

            var index = 0;

            foreach (int item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order if Comparison is null
        /// </summary>
        [Test]
        public void Int_Postorder_CustomBinaryTree_With_Comparison_Null()
        {
            var comparer = new IntComparator();

            Comparison<int> comparison = null;

            var newTree = new BinarySearchTree<int>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 1, 4, 3, 6, 9, 8, 5 };

            var index = 0;

            foreach (int item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a invariant order if Comparison is null
        /// </summary>
        [Test]
        public void Int_Inorder_CustomBinaryTree_With_Comparison_Null()
        {
            var comparer = new IntComparator();

            Comparison<int> comparison = null;

            var newTree = new BinarySearchTree<int>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 1, 3, 4, 5, 6, 8, 9 };

            var index = 0;

            foreach (int item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with default Comparer
        /// </summary>
        [Test]
        public void Int_Preorder_CustomBinaryTree_With_Default_Comparer()
        {
            var newTree = new BinarySearchTree<int>();

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 5, 3, 1, 4, 8, 6, 9 };

            var index = 0;

            foreach (int item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order with default Comparer
        /// </summary>
        [Test]
        public void Int_Postorder_CustomBinaryTree_With_Default_Comparer()
        {
            var newTree = new BinarySearchTree<int>();

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 1, 4, 3, 6, 9, 8, 5 };

            var index = 0;

            foreach (int item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in an invariant order with default Comparer
        /// </summary>
        [Test]
        public void Int_Inorder_CustomBinaryTree_With_Default_Comparer()
        {
            var newTree = new BinarySearchTree<int>();

            newTree.Add(inputArray);

            var helperArrayResult = new int[7] { 1, 3, 4, 5, 6, 8, 9 };

            var index = 0;

            foreach (int item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test Search item in BinarySearchTree if T is type int
        /// </summary>
        [Test]
        public void Int_Contains_CustomBinaryTree()
        {
            var newTree = new BinarySearchTree<int>(inputArray);

            Assert.IsTrue(newTree.Contains(4));

            Assert.IsFalse(newTree.Contains(20));
        }
    }
}
