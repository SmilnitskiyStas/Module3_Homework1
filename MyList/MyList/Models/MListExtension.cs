using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList.Models
{
    internal static class MListExtension
    {
        private static int _count = 0;

        private static int _arrayLength = 10;

        private static double _loadFactory = 0.7;

        /// <summary>
        /// Додавання значення.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="mList">Клас розширення.</param>
        /// <param name="value">Значення додавання.</param>
        public static void Add<T>(this MList<T> mList, T value)
        {
            AuditOfList();

            T[] temp = new T[_arrayLength];

            if (mList.MArray == null)
            {
                mList.MArray = temp;
            }

            for (int i = 0; i < _count; i++)
            {
                temp[i] = mList.MArray[i];
            }

            temp[_count++] = value;

            mList.MArray = temp;
            mList.Count = _count;
        }

        /// <summary>
        /// Додавання масиву.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="mList">Клас розширення.</param>
        /// <param name="addValuesToArray">Масив для додавання.</param>
        public static void AddRange<T>(this MList<T> mList, T[] addValuesToArray)
        {
            int startIndex = _count;

            _count += addValuesToArray.Length;

            AuditOfList();

            T[] temp = new T[_arrayLength];

            for (int i = 0; i < startIndex; i++)
            {
                temp[i] = mList.MArray[i];
            }

            for (int i = startIndex, y = 0; i < _count; i++, y++)
            {
                temp[i] = addValuesToArray[y];
            }

            mList.MArray = temp;
            mList.Count = _count;
        }

        /// <summary>
        /// Видалення по значенню.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="mList">Клас розширення.</param>
        /// <param name="value">Значення для видалення.</param>
        public static void Remove<T>(this MList<T> mList, T value)
        {
            AuditOfList();

            T[] temp = new T[_arrayLength];

            int indexForNewArray = 0;

            for (int i = 0; i <= _count; i++)
            {
                if (mList.MArray[i].Equals(value))
                {
                    _count--;

                    continue;
                }

                temp[indexForNewArray++] = mList.MArray[i];
            }

            mList.MArray = temp;
            mList.Count = _count;
        }

        /// <summary>
        /// Видалення із масиву по індексу.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="mList">Клас розширення.</param>
        /// <param name="index">Індекс видалення.</param>
        public static void RemoveAt<T>(this MList<T> mList, int index)
        {
            _count--;

            AuditOfList();

            T[] temp = new T[_arrayLength];

            for (int i = 0; i < index; i++)
            {
                temp[i] = mList.MArray[i];
            }

            for (int i = index; i < _count; i++)
            {
                temp[i] = mList.MArray[i + 1];
            }

            mList.MArray = temp;
            mList.Count = _count;
        }

        /// <summary>
        /// Сортування масиву.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="mList">Клас розширення.</param>
        public static void Sort<T>(this MList<T> mList)
        {
            Array.Sort(mList.MArray, 0, _count);
        }

        /// <summary>
        /// Перевірка масиву на те, чи потрібно його збільшувати чи зменшувати.
        /// </summary>
        private static void AuditOfList()
        {
            double division = Convert.ToDouble(_count) / Convert.ToDouble(_arrayLength);

            if (division > _loadFactory)
            {
                _arrayLength *= 2;
            }

            if (division * 2 < _loadFactory)
            {
                _arrayLength /= 2;
            }
        }
    }
}
