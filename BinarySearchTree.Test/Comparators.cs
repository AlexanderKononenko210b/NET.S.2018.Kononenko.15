using System;
using System.Collections.Generic;
using System.Configuration;
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
            return first - second;
        }
    }

    /// <summary>
    /// Comparator for type string
    /// </summary>
    public sealed class StringComparator : IComparer<string>
    {
        public int Compare(string first, string second)
        {
            if (first == null && second == null) return 0;

            if (first == null) return -1;

            if (second == null) return 1;

            return first.Length - second.Length;
        }
    }

    /// <summary>
    /// Comparator for type Book
    /// </summary>
    public sealed class BookComparator : IComparer<Book>
    {
        public int Compare(Book first, Book second)
        {
            if (first == null && second == null) return 0;

            if (first == null) return -1;

            if (second == null) return 1;

            return first.GetNumberBook() - second.GetNumberBook();
        }
    }

    /// <summary>
    /// Comparator for type Point
    /// </summary>
    public sealed class PointComparator : IComparer<Point>
    {
        public int Compare(Point first, Point second)
        {
            try
            {
                var appSettingsReader = new AppSettingsReader();

                var accuracy = (double)appSettingsReader.GetValue("accuracy", typeof(double));

                if (Math.Abs(first.x - second.x) < accuracy)
                    return 0;

                if (first.x < second.y)
                    return -1;

                return 1;
            }
            catch
            {
                throw new InvalidOperationException($"Invalide operation get accuracy");
            }
        }
    }
}
