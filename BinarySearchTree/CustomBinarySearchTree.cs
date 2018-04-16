using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BinarySearchTree
{
    public class CustomBinarySearchTree<T>
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
        public CustomBinarySearchTree(IComparer<T> comparer)
        {
            this.root = null;

            if (comparer == null)
            {
                this.comparison = Comparer<T>.Default.Compare;

                if (this.comparison == null)
                    throw new InvalidOperationException($"Type {nameof(T)} does not contain default sort order comparer");
            }
            else
                this.comparison = comparer.Compare;
        }

        /// <summary>
        /// Constructor with delegate type Comparison<T></T>
        /// </summary>
        /// <param name="comparison">instance delegate Comparison<T></T></param>
        public CustomBinarySearchTree(Comparison<T> comparison)
        {
            this.root = null;

            if (comparison == null)
            {
                this.comparison = Comparer<T>.Default.Compare;

                if (this.comparison == null)
                    throw new InvalidOperationException($"Type {nameof(T)} does not contain default sort order comparer");
            }
            else
                this.comparison = comparison;
        }

        /// <summary>
        /// Default constructor if comparator = null
        /// </summary>
        public CustomBinarySearchTree()
        {
            this.root = null;

            this.comparison = Comparer<T>.Default.Compare;

            if(this.comparison == null)
                throw new InvalidOperationException($"Type {nameof(T)} does not contain default sort order comparer");
        }

        #endregion Constructors

        #region Private methods

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

            if(resultComparison == 0)
                throw new InvalidOperationException($"{nameof(data)} already contains in CustomBinarySearch");

            if (resultComparison < 0)
                node.Left = AddItem(node.Left, data);

            if (resultComparison > 0)
                node.Right = AddItem(node.Right, data);

            return node;
        }

        #endregion Private methods

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
        /// Straight order CustomBinaryTree using yield
        /// </summary>
        /// <returns>IEnumerable type T</returns>
        public IEnumerable<T> Preorder()
        {
            if(root == null)
                throw new InvalidOperationException($"CustomBinaryTree is empty");

            if(comparison == null)
                throw new InvalidOperationException($"Type {nameof(T)} does not contain default sort order comparer");

            return Preorder(root);
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

        #endregion Public Api

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
