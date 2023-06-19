using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList.Models
{
    internal class MListEnumerator<T> : IEnumerator<T>
    {
        private T[] _array;

        private int _count;

        private int _position = -1;

        public MListEnumerator(T[] array, int count)
        {
            _array = array;
            _count = count;
        }

        public T Current
        {
            get
            {
                if (_position == -1 && _position >= _array.Length)
                {
                    throw new InvalidOperationException();
                }

                return _array[_position];
            }
        }

        object IEnumerator.Current => _array[_position];

        public void Dispose()
        {
            _count = 0;
        }

        /// <summary>
        /// Бере значення із масиву для відображення на консолі.
        /// </summary>
        /// <returns>Логічний оператор.</returns>
        public bool MoveNext()
        {
            if (_position < _count - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Оновлення для того щоб почати відображення з початку.
        /// </summary>
        public void Reset()
        {
            _position = -1;
        }
    }
}
