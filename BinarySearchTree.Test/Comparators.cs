using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Test
{
    /// <summary>
    /// Comparator for type int
    /// </summary>
    public sealed class IntComparator : IComparer<int>
    {
        public int Compare(int first, int second)
        {
            if (first == second)
                return 0;
            else if (first < second)
                return -1;
            else return 1;
        }
    }

    /// <summary>
    /// Comparator for type string
    /// </summary>
    public sealed class StringComparator : IComparer<string>
    {
        public int Compare(string first, string second)
        {
            if (first == null && second == null)
                return 0;
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            if (first.Length == second.Length)
                return 0;
            if (first.Length < second.Length)
                return -1;
            return 1;
        }
    }

    /// <summary>
    /// Comparator for type Book
    /// </summary>
    public sealed class BookComparator : IComparer<Book>
    {
        public int Compare(Book first, Book second)
        {
            if (first == null && second == null)
                return 0;

            if (first == null) return -1;

            if (second == null) return 1;

            if (first.GetNumberBook() == second.GetNumberBook())
                return 0;

            if (first.GetNumberBook() < second.GetNumberBook())
                return -1;

            return 1;
        }
    }

    /// <summary>
    /// Comparator for type Point
    /// </summary>
    public sealed class PointComparator : IComparer<Point>
    {
        public int Compare(Point first, Point second)
        {
            if (first.x == second.x)
                return 0;

            if (first.x < second.x)
                return -1;

            return 1;
        }
    }
}
