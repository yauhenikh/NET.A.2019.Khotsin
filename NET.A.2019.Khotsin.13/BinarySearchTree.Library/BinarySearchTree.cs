using System;
using System.Collections.Generic;

namespace BinarySearchTreeLibrary
{
    /// <summary>
    /// Represents generic binary search tree
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the binary search tree</typeparam>
    public class BinarySearchTree<T>
    {
        private BinarySearchTreeNode<T> _root;
        private IComparer<T> _comparer;

        /// <summary>
        /// Default constructor
        /// </summary>
        public BinarySearchTree()
        {
            _root = null;
            Count = 0;
            _comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Constructor with IComparer<T> parameter
        /// </summary>
        /// <param name="comparer">Given comparer</param>
        public BinarySearchTree(IComparer<T> comparer) : this()
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Constructor with IEnumerable<T> parameter
        /// </summary>
        /// <param name="collection">Given collection of the elements</param>
        public BinarySearchTree(IEnumerable<T> collection) : this()
        {
            if (collection == null)
            {
                throw new ArgumentNullException(null, "collection cannot be null");
            }

            foreach (T item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Constructor with IEnumerable<T> and IComparer<T> parameters
        /// </summary>
        /// <param name="collection">Given collection of the elements</param>
        /// <param name="comparer">Given comparer</param>
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer) : this(comparer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(null, "collection cannot be null");
            }

            foreach (T item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Number of elements in the tree
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Adds element to the binary search tree
        /// </summary>
        /// <param name="value">Value to add</param>
        /// <returns>True, if tree doesn't contain same value, false otherwise</returns>
        public bool Add(T value)
        {
            if (Contains(value))
            {
                return false;
            }

            if (_root == null)
            {
                _root = new BinarySearchTreeNode<T>(value);
                Count++;

                return true;
            }

            BinarySearchTreeNode<T> current = _root;
            BinarySearchTreeNode<T> parent = null;

            while (current != null)
            {
                parent = current;

                if (_comparer.Compare(value, current.Value) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            current = new BinarySearchTreeNode<T>(value);

            if (_comparer.Compare(value, parent.Value) < 0)
            {
                parent.Left = current;
            }
            else
            {
                parent.Right = current;
            }

            Count++;

            return true;
        }

        /// <summary>
        /// Removes element from the binary search tree
        /// </summary>
        /// <param name="value">Value to remove</param>
        /// <returns>True, if tree doesn't contain same value, false otherwise</returns>
        public bool Remove(T value)
        {
            if (!Contains(value))
            {
                return false;
            }

            BinarySearchTreeNode<T> parent = null;
            BinarySearchTreeNode<T> current = FindWithParent(value, out parent);

            BinarySearchTreeNode<T> replacementNode = null;
            BinarySearchTreeNode<T> replacementNodeParent = null;

            if (current.Right == null)
            {
                replacementNode = current.Left;
            }
            else if (current.Left == null)
            {
                replacementNode = current.Right;
            }
            else
            {
                replacementNodeParent = current;
                replacementNode = current.Left;

                while (replacementNode.Right != null)
                {
                    replacementNodeParent = replacementNode;
                    replacementNode = replacementNode.Right;
                }

                if (replacementNodeParent == current)
                {
                    replacementNode.Right = current.Right;
                }
                else
                {
                    replacementNode.Right = current.Right;
                    replacementNodeParent.Right = replacementNode.Left;
                    replacementNode.Left = replacementNodeParent;
                }
            }

            if (current == _root)
            {
                _root = replacementNode;
            }
            else if (_comparer.Compare(current.Value, parent.Value) < 0)
            {
                parent.Left = replacementNode;
            }
            else
            {
                parent.Right = replacementNode;
            }

            Count--;

            return true;
        }

        /// <summary>
        /// Determines if tree contains value
        /// </summary>
        /// <param name="value">Given value</param>
        /// <returns>True, if tree contains value</returns>
        public bool Contains(T value)
        {
            BinarySearchTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        /// <summary>
        /// Returns tree elements using preorder traversal
        /// </summary>
        /// <returns>Sequence of the elements</returns>
        public IEnumerable<T> PreOrderTraversal()
        {
            return PreOrderTraversal(_root);
        }

        /// <summary>
        /// Returns tree elements using inorder traversal
        /// </summary>
        /// <returns>Sequence of the elements</returns>
        public IEnumerable<T> InOrderTraversal()
        {
            return InOrderTraversal(_root);
        }

        /// <summary>
        /// Returns tree elements using postorder traversal
        /// </summary>
        /// <returns>Sequence of the elements</returns>
        public IEnumerable<T> PostOrderTraversal()
        {
            return PostOrderTraversal(_root);
        }

        /// <summary>
        /// Finds node with given value and its parent
        /// </summary>
        /// <param name="value">Given value</param>
        /// <param name="parent">Parent of the found node</param>
        /// <returns>Node with given value</returns>
        private BinarySearchTreeNode<T> FindWithParent(T value, out BinarySearchTreeNode<T> parent)
        {
            BinarySearchTreeNode<T> current = _root;
            parent = null;

            while (current != null)
            {
                int res = _comparer.Compare(value, current.Value);

                if (res < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (res > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        /// <summary>
        /// Returns tree elements using preorder traversal
        /// </summary>
        /// <param name="root">Node to begin traversal</param>
        /// <returns>Sequence of the elements</returns>
        private IEnumerable<T> PreOrderTraversal(BinarySearchTreeNode<T> root)
        {
            if (root != null)
            {
                yield return root.Value;

                foreach (var element in PreOrderTraversal(root.Left))
                {
                    yield return element;
                }

                foreach (var element in PreOrderTraversal(root.Right))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Returns tree elements using inorder traversal
        /// </summary>
        /// <param name="root">Node to begin traversal</param>
        /// <returns>Sequence of the elements</returns>
        private IEnumerable<T> InOrderTraversal(BinarySearchTreeNode<T> root)
        {
            if (root != null)
            {
                foreach (var element in InOrderTraversal(root.Left))
                {
                    yield return element;
                }

                yield return root.Value;

                foreach (var element in InOrderTraversal(root.Right))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Returns tree elements using postorder traversal
        /// </summary>
        /// <param name="root">Node to begin traversal</param>
        /// <returns>Sequence of the elements</returns>
        private IEnumerable<T> PostOrderTraversal(BinarySearchTreeNode<T> root)
        {
            if (root != null)
            {
                foreach (var element in PostOrderTraversal(root.Left))
                {
                    yield return element;
                }

                foreach (var element in PostOrderTraversal(root.Right))
                {
                    yield return element;
                }

                yield return root.Value;
            }
        }
    }
}
