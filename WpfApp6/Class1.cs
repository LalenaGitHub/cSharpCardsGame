using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6
{
    class Unit
    {
        static Random rand = new Random();
        public static void Shuffle<T>(T[] array)
        {
            int randvar = rand.Next(array.Length);
            T v;

            for (int count = array.Length; count > 1; count--, randvar = rand.Next(count))
            {
                v = array[randvar];
                array[randvar] = array[count - 1];
                array[count - 1] = v;
            }
        }
    }
}
