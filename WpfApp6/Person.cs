using System.Collections.Generic;

namespace nsKartenSpiel
{
    internal class Person
    {
        private string namePerson;
        private string Age;
        private List<Card> listWithCards;
        private int profit =0;

        public Person(string namePerson, string age )
        {
            this.namePerson = namePerson;
            this.Age = age;
        }

        public int Profit
        {
            get => profit;
            set => profit = value;
        }

        public string NamePerson
        {
            get => namePerson;
            set => namePerson = value;
        }

        internal List<Card> ListWithCards {
            get => listWithCards;
            set => listWithCards = value;
        }
    }

    internal class PersonList {
        public static List<Person> listPerson = new List<Person>();
    }


  
}