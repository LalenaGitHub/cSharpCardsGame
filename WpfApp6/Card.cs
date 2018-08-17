

using System;
using System.Collections.Generic;
using WpfApp6;

namespace nsKartenSpiel
{


    enum CardValue
    {
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Qeen = 12,
        King = 13,
        Ase = 14
    };

    enum CardSuits
    {
        Pik = 1, // Pik
        Kreuz = 2, //Kreuz
        Karo = 3, //Karo
        Herz = 4 // Herz
    };


    internal class CardList {
        public static List<Card> listAllCardsMix = new List<Card>();
        //public List<List<int>> listAllCardsInit = new List<List<int>>();


       static int[,] listAllCards;

           public  struct CountGards  {
            public int value;
            public int suit;

            public CountGards(int v, int s)
            {
                value = v;
                suit = s;
            }
        };

 

        public static void iniList()
        {
            listAllCards = new int[4,9] {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            CountGards countGards = new CountGards(9,4);

            for (int cValueIndex = 0; cValueIndex < countGards.value; cValueIndex++)
            {
                for (int cSuitIndex = 0; cSuitIndex < countGards.suit; cSuitIndex++)
                {

                    Card card = new Card(cValueIndex, cSuitIndex);
                    int cValue = card.getCardValue(cValueIndex);
                    int cSuit = card.getCardSuit(cSuitIndex);
                    int cProfit = cValue * cSuit;
                    card.setProfot(cProfit);
                    listAllCardsMix.Add(card);
                }
            }
         }
        

        public static void shuffle()
        {
            listAllCardsMix = Util.ShuffleList(listAllCardsMix);
                       
        }

       }
    
   

    internal class Card
    {
        private CardValue Value;
        private CardSuits Suit;
        private int profit;

        

        public Card(int valueIndex, int suitIndex) {
            this.Value = (CardValue) getCardValue(valueIndex);
            this.Suit = (CardSuits) getCardSuit(suitIndex);
           
        }

        public int Profit { get => profit; set => profit = value; }

        public int getCardValue(int cValueIndex)
        {
        return cValueIndex + 6;
        }

        public int getCardSuit(int cSuitIndex)
        {
        return cSuitIndex + 1;
        }

        public void setProfot(int cProfit)
        {
            profit = cProfit;
        }

        public override string ToString() {
            return this.Suit + " " + this.Value + " (" + this.profit + ")"; 
        }


    }



}
 
