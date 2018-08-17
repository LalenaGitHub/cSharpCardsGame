using nsKartenSpiel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6
{
    class Util
    {
        public static List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }


        public static List<Card> getList(List<Card> listAll, int forIndex, int bisIndex)
        {
            List<Card> list = new List<Card>();

            int index = 0;
            foreach (Card card in listAll)
            {
                if ((index >= forIndex) && (index < bisIndex))
                {
                    list.Add(card);
                }
                index++;
            }

            return list;
        }
    }
}
