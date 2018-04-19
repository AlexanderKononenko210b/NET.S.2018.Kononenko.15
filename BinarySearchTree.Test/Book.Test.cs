using System;
using NUnit.Framework;
using CustomBinarySearchTree;

namespace BinarySearchTree.Test
{
    /// <summary>
    /// Class test BinarySearchTree with class Book
    /// </summary>
    [TestFixture]
    public class BookTest
    {
        private Book[] inputArray = new Book[3];

        [SetUp]
        public void Initialize()
        {
            var book1 = new Book("978-0-7356-6745-4", "Jeffrey Richter",
                "CLR via C#", "Microsoft Press", 2012, 826, new decimal(59.99));

            inputArray[0] = book1;

            var book2 = new Book("978-0-7356-6745-8", "Astakhov Mihail",
                "Axperimental study of the strength",
                "Bauman MSTU", 2006, 593, new decimal(10.30));

            inputArray[1] = book2;

            var book3 = new Book("978-0-7356-6745-1", "Timoshenko Sergey",
                "Bibration problems in engineering",
                "Mashinostroenie Publ", 1985, 472, new decimal(30.45));

            inputArray[2] = book3;
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with IComparer
        /// </summary>
        [Test]
        public void Book_Preorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new BookComparator();

            var newTree = new BinarySearchTree<Book>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[0], inputArray[2], inputArray[1] };

            var index = 0;

            foreach (Book item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order with IComparer
        /// </summary>
        [Test]
        public void Book_Postorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new BookComparator();

            var newTree = new BinarySearchTree<Book>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[2], inputArray[1], inputArray[0] };

            var index = 0;

            foreach (Book item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a invariant order with IComparer
        /// </summary>
        [Test]
        public void Book_Inorder_CustomBinaryTree_With_IComparer()
        {
            var comparer = new BookComparator();

            var newTree = new BinarySearchTree<Book>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[2], inputArray[0], inputArray[1] };

            var index = 0;

            foreach (Book item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with Comparison
        /// </summary>
        [Test]
        public void Book_Preorder_CustomBinaryTree_With_Comparison()
        {
            var comparer = new BookComparator();

            Comparison<Book> comparison = comparer.Compare;

            var newTree = new BinarySearchTree<Book>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[0], inputArray[2], inputArray[1] };

            var index = 0;

            foreach (Book item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order with Comparison
        /// </summary>
        [Test]
        public void Book_Postorder_CustomBinaryTree_With_Comparison()
        {
            var comparer = new BookComparator();

            Comparison<Book> comparison = comparer.Compare;

            var newTree = new BinarySearchTree<Book>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[2], inputArray[1], inputArray[0] };

            var index = 0;

            foreach (Book item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a invariant order with Comparison
        /// </summary>
        [Test]
        public void Book_Inorder_CustomBinaryTree_With_Comparison()
        {
            var comparer = new BookComparator();

            Comparison<Book> comparison = comparer.Compare;

            var newTree = new BinarySearchTree<Book>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[2], inputArray[0], inputArray[1] };

            var index = 0;

            foreach (Book item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order if IComparer is null
        /// </summary>
        [Test]
        public void Book_Preorder_CustomBinaryTree_With_IComparer_Null()
        {
            var comparer = new BookComparator();

            comparer = null;

            var newTree = new BinarySearchTree<Book>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[0], inputArray[2], inputArray[1] };

            var index = 0;

            foreach (Book item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order if IComparer is null
        /// </summary>
        [Test]
        public void Book_Postorder_CustomBinaryTree_With_IComparer_Null()
        {
            var comparer = new BookComparator();

            comparer = null;

            var newTree = new BinarySearchTree<Book>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[2], inputArray[1], inputArray[0] };

            var index = 0;

            foreach (Book item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in an invariant order if IComparer is null
        /// </summary>
        [Test]
        public void Book_Inorder_CustomBinaryTree_With_IComparer_Null()
        {
            var comparer = new BookComparator();

            comparer = null;

            var newTree = new BinarySearchTree<Book>(comparer);

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[2], inputArray[0], inputArray[1] };

            var index = 0;

            foreach (Book item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order if Comparison is null
        /// </summary>
        [Test]
        public void Book_Preorder_CustomBinaryTree_With_Comparison_Null()
        {
            var comparer = new BookComparator();

            Comparison<Book> comparison = null;

            var newTree = new BinarySearchTree<Book>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[0], inputArray[2], inputArray[1] };

            var index = 0;

            foreach (Book item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order if Comparison is null
        /// </summary>
        [Test]
        public void Book_Postorder_CustomBinaryTree_With_Comparison_Null()
        {
            var comparer = new BookComparator();

            Comparison<Book> comparison = null;

            var newTree = new BinarySearchTree<Book>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[2], inputArray[1], inputArray[0] };

            var index = 0;

            foreach (Book item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a invariant order if Comparison is null
        /// </summary>
        [Test]
        public void Book_Inorder_CustomBinaryTree_With_Comparison_Null()
        {
            var comparer = new BookComparator();

            Comparison<Book> comparison = null;

            var newTree = new BinarySearchTree<Book>(comparison);

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[2], inputArray[0], inputArray[1] };

            var index = 0;

            foreach (Book item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a direct order with default Comparer
        /// </summary>
        [Test]
        public void Book_Preorder_CustomBinaryTree_With_Default_Comparer()
        {
            var newTree = new BinarySearchTree<Book>();

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[0], inputArray[2], inputArray[1] };

            var index = 0;

            foreach (Book item in newTree)
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in a post order with default Comparer
        /// </summary>
        [Test]
        public void Book_Postorder_CustomBinaryTree_With_Default_Comparer()
        {
            var newTree = new BinarySearchTree<Book>();

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[2], inputArray[1], inputArray[0] };

            var index = 0;

            foreach (Book item in newTree.Postorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test bypass CustomBinarySearch in an invariant order with default Comparer
        /// </summary>
        [Test]
        public void Book_Inorder_CustomBinaryTree_With_Default_Comparer()
        {
            var newTree = new BinarySearchTree<Book>();

            newTree.Add(inputArray);

            var helperArrayResult = new Book[3] { inputArray[2], inputArray[0], inputArray[1] };

            var index = 0;

            foreach (Book item in newTree.Inorder())
            {
                Assert.AreEqual(helperArrayResult[index++], item);
            }
        }

        /// <summary>
        /// Test Search item in BinarySearchTree if T is type Book
        /// </summary>
        [Test]
        public void Book_Contains_CustomBinaryTree()
        {
            var newTree = new BinarySearchTree<Book>(inputArray);

            Assert.IsTrue(newTree.Contains(inputArray[0]));

            Assert.IsFalse(newTree.Contains(new Book("978-0-7356-6745-2", "Timoshenko Sergey",
                "Bibration problems in engineering",
                "Mashinostroenie Publ", 1985, 472, new decimal(30.45))));
        }
    }
}
