using System;
using NUnit.Framework;
using BinarySearchTree;

namespace BinarySearchTree.Test
{
    /// <summary>
    /// Class test CustomBinarySearchTree with System.Int32
    /// </summary>
    [TestFixture]
    public class SystemInt32Test
    {
        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with IComparer
        /// </summary>
        [Test]
        public void Int_Preorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new IntComparator();

            var newTree = new CustomBinarySearchTree<int>(comparer);

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);


            var helperArrayResult = new int[7] { 5, 3, 1, 4, 8, 6, 9 };

            var index = 0;

            foreach (int item in newTree.Preorder())
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

            var newTree = new CustomBinarySearchTree<int>(comparer);

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);

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

            var newTree = new CustomBinarySearchTree<int>(comparer);

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);

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

            var newTree = new CustomBinarySearchTree<int>(comparison);

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);


            var helperArrayResult = new int[7] { 5, 3, 1, 4, 8, 6, 9 };

            var index = 0;

            foreach (int item in newTree.Preorder())
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

            var newTree = new CustomBinarySearchTree<int>(comparison);

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);

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

            var newTree = new CustomBinarySearchTree<int>(comparison);

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);

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

            var newTree = new CustomBinarySearchTree<int>(comparer);

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);

            var helperArrayResult = new int[7] { 5, 3, 1, 4, 8, 6, 9 };

            var index = 0;

            foreach (int item in newTree.Preorder())
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

            var newTree = new CustomBinarySearchTree<int>(comparer);

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);

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

            var newTree = new CustomBinarySearchTree<int>(comparer);

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);

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

            var newTree = new CustomBinarySearchTree<int>(comparison);

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);

            var helperArrayResult = new int[7] { 5, 3, 1, 4, 8, 6, 9 };

            var index = 0;

            foreach (int item in newTree.Preorder())
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

            var newTree = new CustomBinarySearchTree<int>(comparison);

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);

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

            var newTree = new CustomBinarySearchTree<int>(comparison);

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);

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
            var newTree = new CustomBinarySearchTree<int>();

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);


            var helperArrayResult = new int[7] { 5, 3, 1, 4, 8, 6, 9 };

            var index = 0;

            foreach (int item in newTree.Preorder())
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
            var newTree = new CustomBinarySearchTree<int>();

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);

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
            var newTree = new CustomBinarySearchTree<int>();

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);

            var helperArrayResult = new int[7] { 1, 3, 4, 5, 6, 8, 9 };

            var index = 0;

            foreach (int item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test add new item in CustomBinaryTree when expected InvalidOperationException
        /// </summary>
        [Test]
        public void Int_Add_New_Element_With_Duplicates_Expected_InvalidOperationException()
        {
            var newTree = new CustomBinarySearchTree<int>();

            newTree.Add(5);
            newTree.Add(3);
            newTree.Add(8);
            newTree.Add(1);
            newTree.Add(4);
            newTree.Add(6);
            newTree.Add(9);

            Assert.Throws<InvalidOperationException>(() => newTree.Add(9));
        }
    }
}
