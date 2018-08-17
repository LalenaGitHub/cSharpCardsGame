using System;
using System.Windows;
using System.Windows.Threading;
using WpfApp6;

namespace nsKartenSpiel
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        int i = 0;
        private void timer_tick(object sender, EventArgs e)
        {
            lblSeconds.Content = i.ToString();
            lblSeconds.Content = CardList.listAllCardsMix[i].ToString();
            i++;

            if (i >= PersonList.listPerson[0].ListWithCards.Count)
            {
                timer.Stop();

                lblWon.Content = PersonList.listPerson[0].NamePerson + " " +PersonList.listPerson[0].Profit + " \n " +
                    PersonList.listPerson[1].NamePerson + " " + PersonList.listPerson[1].Profit;
            }
            else 
            {
                toMatch(i);
            }
        }



        private void btnSaveRosa_Click(object sender, RoutedEventArgs e)
        {
            var personaName = tbRosaUser.Text;

            lblRosaUser.Content = personaName;
            btnSaveRosa.Visibility = Visibility.Hidden;
            tbRosaUser.Visibility = Visibility.Hidden;


            // Configure the message box to be displayed
            string messageBoxText = personaName + ", bist Du 18 Jahre alt oder älter?";
            string caption = "Alterprüfung";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button
                    // ... 
                    makePersonAndAddToList(personaName);
                    break;
                case MessageBoxResult.No:
                    // User pressed No button
                    // ...
                    MessageBox.Show("Du bist zu jung!");
                    break;

            }

           
        }

        private void makePersonAndAddToList(string personaName)
        {
            //make Object Person 1

            Person playerOne = new Person(
                namePerson: personaName,
                age: "22"
                );

            PersonList.listPerson.Add(playerOne);

            if (tbBlauUser.Visibility == Visibility.Hidden)
            {
                btnStartGame.Visibility = Visibility.Visible;
            }
        }

        private void btnSaveBlau_Click(object sender, RoutedEventArgs e)
        {
            var personaName = tbBlauUser.Text;
            lblBlauUser.Content = personaName;
            btnSaveBlau.Visibility = Visibility.Hidden;
            tbBlauUser.Visibility = Visibility.Hidden;

            //make Object Person 2
            Person playerTwo = new Person(
                namePerson: personaName,
                age: "25"
            );

            PersonList.listPerson.Add(playerTwo);
            if (tbRosaUser.Visibility == Visibility.Hidden)
            {
                btnStartGame.Visibility = Visibility.Visible;
            }

        }


        private void initAndShuffleListWithCards()
        {
            CardList.iniList();
            CardList.shuffle();
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            initAndShuffleListWithCards();
            sliceListCards();
                
            //toMatch
            if ((PersonList.listPerson[0].ListWithCards).Count > 0) 
                {
                timer.Start();
                }
            }
            

        private void addProfit(int player, int sumProfit)
        {
            PersonList.listPerson[player].Profit += (sumProfit);

        }
        

        private void toMatch(int i)
        {
                Card karte_P0 = (PersonList.listPerson[0].ListWithCards[i]);
                Card karte_P1 = (PersonList.listPerson[1].ListWithCards[i]);

                int karteProfit_P0 = karte_P0.Profit;
                int karteProfit_P1 = karte_P1.Profit;

                int nameWon = -1;
                nameWon = karteProfit_P0 > karteProfit_P1 ? 0 : 1;
                addProfit(nameWon, karteProfit_P0 + karteProfit_P1);

                string nameWonString = "";
                nameWonString = nameWon == 0 ? PersonList.listPerson[0].NamePerson : PersonList.listPerson[1].NamePerson;

                lblCardLeft.Content = karte_P0.ToString();
                lblCardRight.Content = karte_P1.ToString();

                lblWon.Content = nameWonString + " is won!";
            
        }

        private void sliceListCards()
        {
            int playerCount = PersonList.listPerson.Count;
            if (PersonList.listPerson.Count < 1)
            {
                // Fehler
            }
            else
            {
                int kartenAnzahl = CardList.listAllCardsMix.Count;
                int firstPart = kartenAnzahl / playerCount; // 4 von 9/2
                int secondPart = kartenAnzahl - firstPart;

                PersonList.listPerson[0].ListWithCards = Util.getList(CardList.listAllCardsMix, 0, firstPart);
                PersonList.listPerson[1].ListWithCards = Util.getList(CardList.listAllCardsMix, firstPart, CardList.listAllCardsMix.Count);
            }
        }






    }
}
