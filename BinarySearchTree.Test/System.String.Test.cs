using System;
using NUnit.Framework;
using CustomBinarySearchTree;

namespace BinarySearchTree.Test
{
    /// <summary>
    /// Class test BinarySearchTree with string
    /// </summary>
    [TestFixture]
    public class SystemStringTest
    {
        private string[] inputArray = new String[7] {"three", "two", "midnight", "s", "note", "second", "cigarette"};

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with IComparer
        /// </summary>
        [Test]
        public void String_Preorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new StringComparator();

            var newTree = new BinarySearchTree<string>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "three", "two", "s", "note", "midnight", "second", "cigarette" };

            var index = 0;

            foreach (string item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order with IComparer
        /// </summary>
        [Test]
        public void String_Postorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new StringComparator();

            var newTree = new BinarySearchTree<string>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "s", "note", "two", "second", "cigarette", "midnight", "three" };

            var index = 0;

            foreach (string item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a invariant order with IComparer
        /// </summary>
        [Test]
        public void String_Inorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new StringComparator();

            var newTree = new BinarySearchTree<string>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "s", "two", "note", "three", "second", "midnight", "cigarette" };

            var index = 0;

            foreach (string item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with Comparison
        /// </summary>
        [Test]
        public void String_Preorder_CustomBinaryTree_With_Comparison()
        {
            var comparer = new StringComparator();

            Comparison<string> comparison = comparer.Compare;

            var newTree = new BinarySearchTree<string>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "three", "two", "s", "note", "midnight", "second", "cigarette" };

            var index = 0;

            foreach (string item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order with Comparison
        /// </summary>
        [Test]
        public void String_Postorder_CustomBinaryTree_With_Comparison()
        {
            var comparer = new StringComparator();

            Comparison<string> comparison = comparer.Compare;

            var newTree = new BinarySearchTree<string>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "s", "note", "two", "second", "cigarette", "midnight", "three" };

            var index = 0;

            foreach (string item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a invariant order with Comparison
        /// </summary>
        [Test]
        public void String_Inorder_CustomBinaryTree_With_Comparison()
        {
            var comparer = new StringComparator();

            Comparison<string> comparison = comparer.Compare;

            var newTree = new BinarySearchTree<string>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "s", "two", "note", "three", "second", "midnight", "cigarette" };

            var index = 0;

            foreach (string item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order if IComparer is null
        /// </summary>
        [Test]
        public void String_Preorder_CustomBinaryTree_With_IComparer_Null()
        {
            var comparer = new StringComparator();

            comparer = null;

            var newTree = new BinarySearchTree<string>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "three", "midnight", "cigarette", "s", "note", "second", "two" };

            var index = 0;

            foreach (string item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order if IComparer is null
        /// </summary>
        [Test]
        public void String_Postorder_CustomBinaryTree_With_IComparer_Null()
        {
            var comparer = new StringComparator();

            comparer = null;

            var newTree = new BinarySearchTree<string>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "cigarette", "note", "second", "s", "midnight", "two", "three" };

            var index = 0;

            foreach (string item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in an invariant order if IComparer is null
        /// </summary>
        [Test]
        public void String_Inorder_CustomBinaryTree_With_IComparer_Null()
        {
            var comparer = new StringComparator();

            comparer = null;

            var newTree = new BinarySearchTree<string>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "cigarette", "midnight", "note", "s", "second", "three", "two" };

            var index = 0;
            
            foreach (string item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order if Comparison is null
        /// </summary>
        [Test]
        public void String_Preorder_CustomBinaryTree_With_Comparison_Null()
        {
            var comparer = new StringComparator();

            Comparison<string> comparison = null;

            var newTree = new BinarySearchTree<string>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "three", "midnight", "cigarette", "s", "note", "second", "two" };

            var index = 0;

            foreach (string item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order if Comparison is null
        /// </summary>
        [Test]
        public void String_Postorder_CustomBinaryTree_With_Comparison_Null()
        {
            var comparer = new StringComparator();

            Comparison<string> comparison = null;

            var newTree = new BinarySearchTree<string>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "cigarette", "note", "second", "s", "midnight", "two", "three" };

            var index = 0;

            foreach (string item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a invariant order if Comparison is null
        /// </summary>
        [Test]
        public void String_Inorder_CustomBinaryTree_With_Comparison_Null()
        {
            var comparer = new StringComparator();

            Comparison<string> comparison = null;

            var newTree = new BinarySearchTree<string>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "cigarette", "midnight", "note", "s", "second", "three", "two" };

            var index = 0;

            foreach (string item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with default Comparer
        /// </summary>
        [Test]
        public void String_Preorder_CustomBinaryTree_With_Default_Comparer()
        {
            var newTree = new BinarySearchTree<string>();

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "three", "midnight", "cigarette", "s", "note", "second", "two" };

            var index = 0;

            foreach (string item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order with default Comparer
        /// </summary>
        [Test]
        public void String_Postorder_CustomBinaryTree_With_Default_Comparer()
        {
            var newTree = new BinarySearchTree<string>();

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "cigarette", "note", "second", "s", "midnight", "two", "three" };

            var index = 0;

            foreach (string item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in an invariant order with default Comparer
        /// </summary>
        [Test]
        public void String_Inorder_CustomBinaryTree_With_Default_Comparer()
        {
            var newTree = new BinarySearchTree<string>();

            newTree.Add(inputArray);

            var helperArrayResult = new string[7] { "cigarette", "midnight", "note", "s", "second", "three", "two" };

            var index = 0;

            foreach (string item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test Search item in BinarySearchTree if T is type string
        /// </summary>
        [Test]
        public void String_Contains_CustomBinaryTree()
        {
            var newTree = new BinarySearchTree<string>(inputArray);

            Assert.IsTrue(newTree.Contains("note"));

            Assert.IsFalse(newTree.Contains("flour"));
        }
    }
}
