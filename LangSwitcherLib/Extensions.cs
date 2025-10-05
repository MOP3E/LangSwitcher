using System;
using System.Collections.Generic;

namespace LangSwitcherLib
{
    public static class Extensions
    {
        /// <summary>
        /// Добавление значения в отсортированный список.
        /// </summary>
        /// <param name="list">Список, к которому добавляется значение.</param>
        /// <param name="item">Значение, добавляемое к списку.</param>
        public static int SortedAdd<T>(this List<T> list, T item)
        {
            //если список пуст, либо добавляемый в него элемент больше, чем последний элемент списка...
            if (list.Count == 0 || ((IComparable)list[list.Count - 1]).CompareTo(item) < 0)
            {
                list.Add(item);
                return list.Count - 1;
            }

            //определить позицию для вставки
            int position = list.BinarySearch(item);
            if (position < 0)
                position = ~position;

            //добавить значение в список
            if (position < list.Count)
                list.Insert(position, item);
            else
                list.Add(item);

            return position;
        }

        /// <summary>
        /// Добавление значения в отсортированный список.
        /// </summary>
        /// <param name="list">Список, к которому добавляется значение.</param>
        /// <param name="item">Значение, добавляемое к списку.</param>
        /// <param name="comparer">Интерфейс, используемый для сравнения элементов списка.</param>
        public static int SortedAdd<T>(this List<T> list, T item, IComparer<T> comparer)
        {
            //если список пуст, либо добавляемый в него элемент больше, чем последний элемент списка...
            if (list.Count == 0 || comparer.Compare(list[list.Count - 1], item) < 0)
            {
                list.Add(item);
                return list.Count - 1;
            }

            //определить позицию для вставки
            int position = list.BinarySearch(item, comparer);
            if (position < 0)
                position = ~position;

            //добавить значение в список
            if (position < list.Count)
                list.Insert(position, item);
            else
                list.Add(item);

            return position;
        }

        /// <summary>
        /// Добавление уникального значения в отсортированный список.
        /// </summary>
        /// <param name="list">Список, к которому добавляется значение.</param>
        /// <param name="item">Значение, добавляемое к списку.</param>
        public static int SortedAddOnce<T>(this List<T> list, T item)
        {
            //если список пуст, либо добавляемый в него элемент больше, чем последний элемент списка...
            if (list.Count == 0 || ((IComparable)list[list.Count - 1]).CompareTo(item) < 0)
            {
                list.Add(item);
                return list.Count - 1;
            }

            //определить позицию для вставки
            int position = list.BinarySearch(item);

            //такое значение уже есть в списке - ничего вставлять не нужно
            if (position >= 0)
                return position;

            //добавить значение в список
            position = ~position;
            if (position < list.Count)
                list.Insert(position, item);
            else
                list.Add(item);

            return position;
        }

        /// <summary>
        /// Добавление уникального значения в отсортированный список.
        /// </summary>
        /// <param name="list">Список, к которому добавляется значение.</param>
        /// <param name="item">Значение, добавляемое к списку.</param>
        /// <param name="comparer">Интерфейс, используемый для сравнения элементов списка.</param>
        public static int SortedAddOnce<T>(this List<T> list, T item, IComparer<T> comparer)
        {
            //если список пуст, либо добавляемый в него элемент больше, чем последний элемент списка...
            if (list.Count == 0 || comparer.Compare(list[list.Count - 1], item) < 0)
            {
                list.Add(item);
                return list.Count - 1;
            }

            //определить позицию для вставки
            int position = list.BinarySearch(item, comparer);

            //такое значение уже есть в списке - ничего вставлять не нужно
            if (position >= 0)
                return position;

            //добавить значение в список
            position = ~position;
            if (position < list.Count)
                list.Insert(position, item);
            else
                list.Add(item);

            return position;
        }
    }
}
