using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CustomBinarySearchTree
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        #region Field

        private Node<T> root;

        private Comparison<T> comparison;

        #endregion Field

        #region Constructors

        /// <summary>
        /// Constructor with plug-in interface IComparer<T></T>
        /// </summary>
        /// <param name="comparer">instance type IComparer<T></T></param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.root = null;

            if (comparer == null)
            {
                if (typeof(T).GetInterface("IComparable<TSource>") != null || typeof(T).GetInterface("IComparable") != null)
                    comparer = Comparer<T>.Default;
                else
                    throw new GetDefaulCompareException($"Type {nameof(T)} does not contain default sort order comparer");
            }

            this.comparison = comparer.Compare;
        }

        /// <summary>
        /// Constructor with plug-in delegate type Comparison<T></T>
        /// </summary>
        /// <param name="comparison">instance delegate Comparison<T></T></param>
        public BinarySearchTree(Comparison<T> comparison)
        {
            this.root = null;

            if (comparison == null)
            {
                if (typeof(T).GetInterface("IComparable<TSource>") != null || typeof(T).GetInterface("IComparable") != null)
                    comparison = Comparer<T>.Default.Compare;
                else
                    throw new GetDefaulCompareException($"Type {nameof(T)} does not contain default sort order comparer");
            }

            this.comparison = comparison;
        }

        /// <summary>
        /// Default constructor if comparator = null
        /// </summary>
        public BinarySearchTree() : this((Comparison<T>)null) { }

        /// <summary>
        /// Constructor with instance type interface IEnumerable<T>type</T> as parameter<T></T>
        /// </summary>
        /// <param name="enumerable">instance type IEnumerable<T>type</T></param>
        public BinarySearchTree(IEnumerable<T> enumerable) : this((Comparison<T>)null)
        {
            if (enumerable != null)
            {
                foreach (var data in enumerable)
                    root = AddItem(root, data);
            }
        }

        /// <summary>
        /// Constructor with instance type interface IEnumerable<T>type</T> as parameter and instance type IComparer<T></T>
        /// </summary>
        /// <param name="enumerable">instance type IEnumerable<T>type</T></param>
        /// <param name="comparer">instance type IComparer<T>type</T></param>
        public BinarySearchTree(IEnumerable<T> enumerable, IComparer<T> comparer) : this(comparer)
        {
            if (enumerable != null)
            {
                foreach (var data in enumerable)
                    root = AddItem(root, data);
            }
        }

        #endregion Constructors

        #region Public Api

        /// <summary>
        /// Public method for add new item in CustomBinarySearch
        /// </summary>
        /// <param name="data">data</param>
        /// <returns></returns>
        public void Add(T data)
        {
            if (data == null)
                throw new ArgumentNullException($"Argument {nameof(data)} is null");

            root = AddItem(root, data);
        }

        /// <summary>
        /// Public method for add IEnumerable new item in CustomBinarySearch
        /// </summary>
        /// <param name="collection"></param>
        public void Add(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException($"Argument {nameof(collection)} is null");

            foreach (var data in collection)
                Add(data);
        }

        /// <summary>
        /// Check contains item in BinarySearchTree
        /// </summary>
        /// <param name="searchItem">search item</param>
        /// <returns>true if BinarySearchTree contains this Item</returns>
        public bool Contains(T searchItem)
        {
            if(searchItem == null)
                throw new ArgumentNullException($"Argument {nameof(searchItem)} is null");

            return ContainsItem(root, searchItem);
        }

        /// <summary>
        /// Post order CustomBinaryTree using yield
        /// </summary>
        /// <returns>IEnumerable type T</returns>
        public IEnumerable<T> Postorder()
        {
            if (root == null)
                throw new InvalidOperationException($"CustomBinaryTree is empty");

            if (comparison == null)
                throw new InvalidOperationException($"Type {nameof(T)} does not contain default sort order comparer");

            return Postorder(root);
        }

        /// <summary>
        /// Transverse order CustomBinaryTree using yield
        /// </summary>
        /// <returns>IEnumerable type T</returns>
        public IEnumerable<T> Inorder()
        {
            if (root == null)
                throw new InvalidOperationException($"CustomBinaryTree is empty");

            if (comparison == null)
                throw new InvalidOperationException($"Type {nameof(T)} does not contain default sort order comparer");

            return Inorder(root);
        }

        /// <summary>
        /// Generic version method GetEnumarator 
        /// </summary>
        /// <returns>Preorder method round tree as default</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Preorder().GetEnumerator();
        }

        /// <summary>
        /// Explisit inplementation method GetEnumerator interface IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion Public Api

        #region Private methods

        /// <summary>
        /// Method for search item in BinarySearchTree
        /// </summary>
        /// <param name="node">node for check</param>
        /// <param name="data">data for search</param>
        /// <returns>true if the item is find</returns>
        private bool ContainsItem(Node<T> node, T data)
        {
            if (node == null)
                return false;

            var resultComparison = comparison(data, node.Data);

            if (resultComparison == 0)
            {
                var equalityComparer = EqualityComparer<T>.Default;

                return equalityComparer.Equals(data, node.Data) ? true : ContainsItem(node.Left, data);
            }

            if (resultComparison < 0)
                return ContainsItem(node.Left, data);

            if (resultComparison > 0)
                return ContainsItem(node.Right, data);

            return false;
        }

        /// <summary>
        /// Block operator for transverse order CustomBinaryTree
        /// </summary>
        /// <param name="node">current node</param>
        /// <returns>IEnumerable type T</returns>
        private IEnumerable<T> Inorder(Node<T> node)
        {
            if (node.Left != null)
                foreach (var item in Inorder(node.Left))
                    yield return item;

            yield return node.Data;

            if (node.Right != null)
                foreach (var item in Inorder(node.Right))
                    yield return item;
        }

        /// <summary>
        /// Block operator for post order CustomBinaryTree
        /// </summary>
        /// <param name="node">current node</param>
        /// <returns>IEnumerable type T</returns>
        private IEnumerable<T> Postorder(Node<T> node)
        {
            if (node.Left != null)
                foreach (var item in Postorder(node.Left))
                    yield return item;

            if (node.Right != null)
                foreach (var item in Postorder(node.Right))
                    yield return item;

            yield return node.Data;
        }

        /// <summary>
        /// Block operator for straight order CustomBinaryTree
        /// </summary>
        /// <param name="node">current node</param>
        /// <returns>IEnumerable type T</returns>
        private IEnumerable<T> Preorder(Node<T> node)
        {
            yield return node.Data;

            if (node.Left != null)
                foreach (var item in Preorder(node.Left))
                    yield return item;

            if (node.Right != null)
                foreach (var item in Preorder(node.Right))
                    yield return item;
        }

        /// <summary>
        /// Straight order CustomBinaryTree using yield and using as source default Enumerator
        /// </summary>
        /// <returns>IEnumerable type T</returns>
        private IEnumerable<T> Preorder()
        {
            if (root == null)
                throw new InvalidOperationException($"CustomBinaryTree is empty");

            if (comparison == null)
                throw new InvalidOperationException($"Type {nameof(T)} does not contain default sort order comparer");

            return Preorder(root);
        }


        /// <summary>
        /// Private method for add data in CustomBinarySearch
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private Node<T> AddItem(Node<T> node, T data)
        {
            if (node == null)
                return new Node<T>(data);

            var resultComparison = comparison(data, node.Data);

            if (resultComparison <= 0)
                node.Left = AddItem(node.Left, data);

            if (resultComparison > 0)
                node.Right = AddItem(node.Right, data);

            return node;
        }

        #endregion Private methods

        #region Node in CustomBinarySearchTree

        /// <summary>
        /// Custom class Node typeof T representation node in CustomBinarySearchTree
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        public sealed class Node<T>
        {
            public Node(T data)
            {
                this.Data = data;

                this.Left = null;

                this.Right = null;
            }

            public T Data { get; set; }

            public Node<T> Left { get; set; }

            public Node<T> Right { get; set; }
        }

        #endregion Node in CustomBinarySearchTree
    }
}
