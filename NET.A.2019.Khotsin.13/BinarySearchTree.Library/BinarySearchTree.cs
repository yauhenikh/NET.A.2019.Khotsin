using System;
using System.Collections.Generic;

namespace BinarySearchTreeLibrary
{
    public class BinarySearchTree<T>
    {
        private BinarySearchTreeNode<T> _root;
        private IComparer<T> _comparer;

        public BinarySearchTree()
        {
            _root = null;
            Count = 0;
            _comparer = Comparer<T>.Default;
        }

        public BinarySearchTree(IComparer<T> comparer) : this()
        {
            _comparer = comparer;
        }

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

        public int Count { get; private set; }

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

        public bool Contains(T value)
        {
            BinarySearchTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        public IEnumerable<T> PreOrderTraversal()
        {
            return PreOrderTraversal(_root);
        }

        public IEnumerable<T> InOrderTraversal()
        {
            return InOrderTraversal(_root);
        }

        public IEnumerable<T> PostOrderTraversal()
        {
            return PostOrderTraversal(_root);
        }

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
