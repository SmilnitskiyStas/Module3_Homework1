using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyList.Models;

namespace MyList
{
    internal class Starter
    {
        public void Run()
        {
            int[] ints = new int[] { 1, 2, 3, 4 };

            MList<int> list = new MList<int>();

            list.Add(3);
            list.AddRange(ints);
            list.Remove(1);
            list.RemoveAt(0);

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
