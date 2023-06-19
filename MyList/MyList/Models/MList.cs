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
        public T[] MArray { get; set; }

        public int Count { get; set; }

        public MList()
        {
        }

        public MList(double loadFactory)
        {
        }

        public IEnumerator GetEnumerator()
        {
            return new MListEnumerator<T>(MArray, Count);
        }
    }
}
