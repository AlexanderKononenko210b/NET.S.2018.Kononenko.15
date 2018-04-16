using System;
using NUnit.Framework;
using BinarySearchTree;

namespace BinarySearchTree.Test
{
    /// <summary>
    /// Class test CustomBinarySearchTree with string
    /// </summary>
    [TestFixture]
    public class SystemStringTest
    {
        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with IComparer
        /// </summary>
        [Test]
        public void String_Preorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new StringComparator();

            var newTree = new CustomBinarySearchTree<string>(comparer);

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

            var helperArrayResult = new string[7] { "three", "two", "s", "note", "midnight", "second", "cigarette" };

            var index = 0;

            foreach (string item in newTree.Preorder())
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

            var newTree = new CustomBinarySearchTree<string>(comparer);

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

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

            var newTree = new CustomBinarySearchTree<string>(comparer);

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

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

            var newTree = new CustomBinarySearchTree<string>(comparison);

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");


            var helperArrayResult = new string[7] { "three", "two", "s", "note", "midnight", "second", "cigarette" };

            var index = 0;

            foreach (string item in newTree.Preorder())
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

            var newTree = new CustomBinarySearchTree<string>(comparison);

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

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

            var newTree = new CustomBinarySearchTree<string>(comparison);

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

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

            var newTree = new CustomBinarySearchTree<string>(comparer);

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");


            var helperArrayResult = new string[7] { "three", "two", "s", "note", "midnight", "second", "cigarette" };

            var index = 0;

            foreach (string item in newTree.Preorder())
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

            var newTree = new CustomBinarySearchTree<string>(comparer);

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

            var helperArrayResult = new string[7] { "s", "note", "two", "second", "cigarette", "midnight", "three" };

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

            var newTree = new CustomBinarySearchTree<string>(comparer);

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

            var helperArrayResult = new string[7] { "s", "two", "note", "three", "second", "midnight", "cigarette" };

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

            var newTree = new CustomBinarySearchTree<string>(comparison);

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

            var helperArrayResult = new string[7] { "three", "two", "s", "note", "midnight", "second", "cigarette" };

            var index = 0;

            foreach (string item in newTree.Preorder())
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

            var newTree = new CustomBinarySearchTree<string>(comparison);

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

            var helperArrayResult = new string[7] { "s", "note", "two", "second", "cigarette", "midnight", "three" };

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

            var newTree = new CustomBinarySearchTree<string>(comparison);

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

            var helperArrayResult = new string[7] { "s", "two", "note", "three", "second", "midnight", "cigarette" };

            var index = 0;

            foreach (string item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with default Comparer
        /// </summary>
        [Test]
        public void String_Preorder_CustomBinaryTree_With_Default_Comparer()
        {
            var newTree = new CustomBinarySearchTree<string>();

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

            var helperArrayResult = new string[7] { "three", "two", "s", "note", "midnight", "second", "cigarette" };

            var index = 0;

            foreach (string item in newTree.Preorder())
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
            var newTree = new CustomBinarySearchTree<string>();

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

            var helperArrayResult = new string[7] { "s", "note", "two", "second", "cigarette", "midnight", "three" };

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
            var newTree = new CustomBinarySearchTree<string>();

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

            var helperArrayResult = new string[7] { "s", "two", "note", "three", "second", "midnight", "cigarette" };

            var index = 0;

            foreach (string item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test add new item in CustomBinaryTree when expected InvalidOperationException
        /// </summary>
        [Test]
        public void String_Add_New_Element_With_Duplicates_Expected_InvalidOperationException()
        {
            var newTree = new CustomBinarySearchTree<string>();

            newTree.Add("three");
            newTree.Add("two");
            newTree.Add("midnight");
            newTree.Add("s");
            newTree.Add("note");
            newTree.Add("second");
            newTree.Add("cigarette");

            Assert.Throws<InvalidOperationException>(() => newTree.Add("file"));
        }
    }
}
