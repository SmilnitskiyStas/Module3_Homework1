using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList.Models
{
    internal class MList<T> : IEnumerable
    {
        public int Count { get; set; }

        private T[] MArray { get; set; }

        private int _arrayLength = 10;

        private double _loadFactory = 0.7;

        public MList()
        {
        }

        public MList(double loadFactory)
        {
        }

        /// <summary>
        /// Додавання значення.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="value">Значення додавання.</param>
        public void Add(T value)
        {
            AuditOfList();

            T[] temp = new T[_arrayLength];

            if (MArray == null)
            {
                MArray = temp;
            }

            for (int i = 0; i < Count; i++)
            {
                temp[i] = MArray[i];
            }

            temp[Count++] = value;

            MArray = temp;
        }

        /// <summary>
        /// Додавання масиву.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="addValuesToArray">Масив для додавання.</param>
        public void AddRange(T[] addValuesToArray)
        {
            int startIndex = Count;

            Count += addValuesToArray.Length;

            AuditOfList();

            T[] temp = new T[_arrayLength];

            for (int i = 0; i < startIndex; i++)
            {
                temp[i] = MArray[i];
            }

            for (int i = startIndex, y = 0; i < Count; i++, y++)
            {
                temp[i] = addValuesToArray[y];
            }

            MArray = temp;
        }

        /// <summary>
        /// Видалення по значенню.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="value">Значення для видалення.</param>
        public void Remove(T value)
        {
            AuditOfList();

            T[] temp = new T[_arrayLength];

            int indexForNewArray = 0;

            for (int i = 0; i <= Count; i++)
            {
                if (MArray[i].Equals(value))
                {
                    Count--;

                    continue;
                }

                temp[indexForNewArray++] = MArray[i];
            }

            MArray = temp;
        }

        /// <summary>
        /// Видалення із масиву по індексу.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="index">Індекс видалення.</param>
        public void RemoveAt(int index)
        {
            Count--;

            AuditOfList();

            T[] temp = new T[_arrayLength];

            for (int i = 0; i < index; i++)
            {
                temp[i] = MArray[i];
            }

            for (int i = index; i < Count; i++)
            {
                temp[i] = MArray[i + 1];
            }

            MArray = temp;
        }

        /// <summary>
        /// Сортування масиву.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="mList">Клас розширення.</param>
        public void Sort()
        {
            Array.Sort(MArray, 0, Count);
        }

        public IEnumerator GetEnumerator()
        {
            return new MListEnumerator<T>(MArray, Count);
        }

        /// <summary>
        /// Перевірка масиву на те, чи потрібно його збільшувати чи зменшувати.
        /// </summary>
        private void AuditOfList()
        {
            double division = Convert.ToDouble(Count) / Convert.ToDouble(_arrayLength);

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
