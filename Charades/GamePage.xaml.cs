using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Charades
{
    public partial class GamePage : PhoneApplicationPage
    {
        System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        Random random = new Random();
        int timeLeft, secondInterval = 0;
        string drawThis;
        bool isButtonsVisible;
        
        public GamePage()
        {
            InitializeComponent();
            myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            myDispatcherTimer.Tick += new EventHandler(Each_Tick);         
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {           
            checkPlayersAndScore();
            checkWords();
            checkPlayers();
            checkAssigned();
            //set secondinterval 0

        }
        
        private void btnAssignOrder_Click(object sender, RoutedEventArgs e)
        {
            int numOfPlayers = globalVar.NumOfPlayers;
            //int randomNum;

            addPlayers(numOfPlayers);
            orderPlayers();

            btnAssignOrder.Visibility = Visibility.Collapsed;
            tbNowDrawingPlayer.Text = globalVar.playersListOrdered[globalVar.NumOfPlayersThatDrew].ToString();
            globalVar.isAssigned = true;
            //playersListOrdered.RemoveAt(0);
        }

        private void btnReady_Click(object sender, RoutedEventArgs e)
        {
            if (isButtonsVisible == true)
            {
                MessageBox.Show("Please select who guessed the word.");
            }
            else if(globalVar.isAssigned == true)
            {
                timeLeft = 5;
                tbTimeLeft.Text = "Word showing in: 5";
                myDispatcherTimer.Start();
                btnReady.Visibility = Visibility.Collapsed;
                tbTimeLeft.Visibility = Visibility.Visible;

                whatToDraw();
                tbWhatToDraw.Text = drawThis;
            }
            else
            {
                MessageBox.Show("Please assign order first.");
            }
                      
        }

        public void Each_Tick(object o, EventArgs sender)
        {
            timeLeft--;
            tbTimeLeft.Text = "Word showing in: " + timeLeft.ToString();

            if (secondInterval == 1)
            {
                tbTimeLeft2.Text = "Starting to draw in: " + timeLeft.ToString();
            }         
            if (timeLeft == 0 && secondInterval == 0)
            {
                secondInterval++;
                timeLeft = 6;
                //tbTimeLeft2.Text = "";
                tbTimeLeft.Visibility = Visibility.Collapsed;
                tbTimeLeft2.Visibility = Visibility.Visible;
                tbWhatToDraw.Visibility = Visibility.Visible;
            }
            if (timeLeft == 0 && secondInterval == 1)
            {
                //draw 
                NavigationService.Navigate(
                     new Uri("/Drawing.xaml",
                         UriKind.RelativeOrAbsolute)
                     );
                secondInterval = 0;
                tbTimeLeft.Visibility = Visibility.Collapsed;
                tbTimeLeft2.Visibility = Visibility.Collapsed;
                tbWhatToDraw.Visibility = Visibility.Collapsed;
                btnReady.Visibility = Visibility.Visible;
                myDispatcherTimer.Stop();
            }

        }

        private void checkAssigned()
        {
            if (globalVar.isAssigned == true)
            {
                btnAssignOrder.Visibility = Visibility.Collapsed;
            }
        }

        private void checkPlayers()
        {
            if (globalVar.NumOfPlayers == globalVar.NumOfPlayersThatDrew)
            {
                globalVar.NumOfPlayersThatDrew = 0;
                tbNowDrawingPlayer.Text = globalVar.playersListOrdered[globalVar.NumOfPlayersThatDrew].ToString();
                //playersListOrdered = playersListBackup;
            }
            else if (globalVar.playersListOrdered.Count() != 0)
            {
                tbNowDrawingPlayer.Text = globalVar.playersListOrdered[globalVar.NumOfPlayersThatDrew].ToString();
                //playersListOrdered.RemoveAt(0);
            }
        }

        private void checkPlayersAndScore()
        {
            int numOfPlayers = globalVar.NumOfPlayers;

            if (numOfPlayers == 1)
            {
                tbPlayer1.Visibility = Visibility.Visible;
                tbScorePlayer1.Visibility = Visibility.Visible;

                if (globalVar.isDrawingDone == true)
                {
                    isButtonsVisible = true;
                    btnGuessPlayer1.Visibility = Visibility.Visible;
                }

                tbPlayer1.Text = globalVar.Player1;
                tbScorePlayer1.Text = globalVar.Player1Score.ToString();
            }
            else if (numOfPlayers == 2)
            {
                tbPlayer1.Visibility = Visibility.Visible;
                tbScorePlayer1.Visibility = Visibility.Visible;               
                tbPlayer2.Visibility = Visibility.Visible;
                tbScorePlayer2.Visibility = Visibility.Visible;
                
                if (globalVar.isDrawingDone == true)
                {
                    isButtonsVisible = true;
                    btnGuessPlayer1.Visibility = Visibility.Visible;
                    btnGuessPlayer2.Visibility = Visibility.Visible;
                }

                tbPlayer1.Text = globalVar.Player1;
                tbScorePlayer1.Text = globalVar.Player1Score.ToString();
                tbPlayer2.Text = globalVar.Player2;
                tbScorePlayer2.Text = globalVar.Player2Score.ToString();
            }
            else if (numOfPlayers == 3)
            {
                tbPlayer1.Visibility = Visibility.Visible;
                tbScorePlayer1.Visibility = Visibility.Visible;            
                tbPlayer2.Visibility = Visibility.Visible;
                tbScorePlayer2.Visibility = Visibility.Visible;                
                tbPlayer3.Visibility = Visibility.Visible;
                tbScorePlayer3.Visibility = Visibility.Visible;
                
                if (globalVar.isDrawingDone == true)
                {
                    isButtonsVisible = true;
                    btnGuessPlayer1.Visibility = Visibility.Visible;
                    btnGuessPlayer2.Visibility = Visibility.Visible;
                    btnGuessPlayer3.Visibility = Visibility.Visible;
                }

                tbPlayer1.Text = globalVar.Player1;
                tbScorePlayer1.Text = globalVar.Player1Score.ToString();
                tbPlayer2.Text = globalVar.Player2;
                tbScorePlayer2.Text = globalVar.Player2Score.ToString();
                tbPlayer3.Text = globalVar.Player3;
                tbScorePlayer3.Text = globalVar.Player3Score.ToString();
            }
            else if (numOfPlayers == 4)
            {
                tbPlayer1.Visibility = Visibility.Visible;
                tbScorePlayer1.Visibility = Visibility.Visible;              
                tbPlayer2.Visibility = Visibility.Visible;
                tbScorePlayer2.Visibility = Visibility.Visible;                
                tbPlayer3.Visibility = Visibility.Visible;
                tbScorePlayer3.Visibility = Visibility.Visible;               
                tbPlayer4.Visibility = Visibility.Visible;
                tbScorePlayer4.Visibility = Visibility.Visible;
                
                if (globalVar.isDrawingDone == true)
                {
                    isButtonsVisible = true;
                    btnGuessPlayer1.Visibility = Visibility.Visible;
                    btnGuessPlayer2.Visibility = Visibility.Visible;
                    btnGuessPlayer3.Visibility = Visibility.Visible;
                    btnGuessPlayer4.Visibility = Visibility.Visible;
                }

                tbPlayer1.Text = globalVar.Player1;
                tbScorePlayer1.Text = globalVar.Player1Score.ToString();
                tbPlayer2.Text = globalVar.Player2;
                tbScorePlayer2.Text = globalVar.Player2Score.ToString();
                tbPlayer3.Text = globalVar.Player3;
                tbScorePlayer3.Text = globalVar.Player3Score.ToString();
                tbPlayer4.Text = globalVar.Player4;
                tbScorePlayer4.Text = globalVar.Player4Score.ToString();
            }
            else if (numOfPlayers == 5)
            {
                tbPlayer1.Visibility = Visibility.Visible;
                tbScorePlayer1.Visibility = Visibility.Visible;                
                tbPlayer2.Visibility = Visibility.Visible;
                tbScorePlayer2.Visibility = Visibility.Visible;              
                tbPlayer3.Visibility = Visibility.Visible;
                tbScorePlayer3.Visibility = Visibility.Visible;                
                tbPlayer4.Visibility = Visibility.Visible;
                tbScorePlayer4.Visibility = Visibility.Visible;                
                tbPlayer5.Visibility = Visibility.Visible;
                tbScorePlayer5.Visibility = Visibility.Visible;
                
                if (globalVar.isDrawingDone == true)
                {
                    isButtonsVisible = true;
                    btnGuessPlayer1.Visibility = Visibility.Visible;
                    btnGuessPlayer2.Visibility = Visibility.Visible;
                    btnGuessPlayer3.Visibility = Visibility.Visible;
                    btnGuessPlayer4.Visibility = Visibility.Visible;
                    btnGuessPlayer5.Visibility = Visibility.Visible;
                }

                tbPlayer1.Text = globalVar.Player1;
                tbScorePlayer1.Text = globalVar.Player1Score.ToString();
                tbPlayer2.Text = globalVar.Player2;
                tbScorePlayer2.Text = globalVar.Player2Score.ToString();
                tbPlayer3.Text = globalVar.Player3;
                tbScorePlayer3.Text = globalVar.Player3Score.ToString();
                tbPlayer4.Text = globalVar.Player4;
                tbScorePlayer4.Text = globalVar.Player4Score.ToString();
                tbPlayer5.Text = globalVar.Player5;
                tbScorePlayer5.Text = globalVar.Player5Score.ToString();
            }
            else if (numOfPlayers == 6)
            {
                tbPlayer1.Visibility = Visibility.Visible;
                tbScorePlayer1.Visibility = Visibility.Visible;                
                tbPlayer2.Visibility = Visibility.Visible;
                tbScorePlayer2.Visibility = Visibility.Visible;               
                tbPlayer3.Visibility = Visibility.Visible;
                tbScorePlayer3.Visibility = Visibility.Visible;                
                tbPlayer4.Visibility = Visibility.Visible;
                tbScorePlayer4.Visibility = Visibility.Visible;                
                tbPlayer5.Visibility = Visibility.Visible;
                tbScorePlayer5.Visibility = Visibility.Visible;               
                tbPlayer6.Visibility = Visibility.Visible;
                tbScorePlayer6.Visibility = Visibility.Visible;
                

                if (globalVar.isDrawingDone == true)
                {
                    isButtonsVisible = true;
                    btnGuessPlayer1.Visibility = Visibility.Visible;
                    btnGuessPlayer2.Visibility = Visibility.Visible;
                    btnGuessPlayer3.Visibility = Visibility.Visible;
                    btnGuessPlayer4.Visibility = Visibility.Visible;
                    btnGuessPlayer5.Visibility = Visibility.Visible;
                    btnGuessPlayer6.Visibility = Visibility.Visible;
                }

                tbPlayer1.Text = globalVar.Player1;
                tbScorePlayer1.Text = globalVar.Player1Score.ToString();
                tbPlayer2.Text = globalVar.Player2;
                tbScorePlayer2.Text = globalVar.Player2Score.ToString();
                tbPlayer3.Text = globalVar.Player3;
                tbScorePlayer3.Text = globalVar.Player3Score.ToString();
                tbPlayer4.Text = globalVar.Player4;
                tbScorePlayer4.Text = globalVar.Player4Score.ToString();
                tbPlayer5.Text = globalVar.Player5;
                tbScorePlayer5.Text = globalVar.Player5Score.ToString();
                tbPlayer6.Text = globalVar.Player6;
                tbScorePlayer6.Text = globalVar.Player6Score.ToString();
            }
            else
            {
                tbPlayer1.Visibility = Visibility.Visible;
                tbScorePlayer1.Visibility = Visibility.Visible;              
                tbPlayer2.Visibility = Visibility.Visible;
                tbScorePlayer2.Visibility = Visibility.Visible;                
                tbPlayer3.Visibility = Visibility.Visible;
                tbScorePlayer3.Visibility = Visibility.Visible;                
                tbPlayer4.Visibility = Visibility.Visible;
                tbScorePlayer4.Visibility = Visibility.Visible;                
                tbPlayer5.Visibility = Visibility.Visible;
                tbScorePlayer5.Visibility = Visibility.Visible;                
                tbPlayer6.Visibility = Visibility.Visible;
                tbScorePlayer6.Visibility = Visibility.Visible;                
                tbPlayer7.Visibility = Visibility.Visible;
                tbScorePlayer7.Visibility = Visibility.Visible;
                

                if (globalVar.isDrawingDone == true)
                {
                    isButtonsVisible = true;
                    btnGuessPlayer1.Visibility = Visibility.Visible;
                    btnGuessPlayer2.Visibility = Visibility.Visible;
                    btnGuessPlayer3.Visibility = Visibility.Visible;
                    btnGuessPlayer4.Visibility = Visibility.Visible;
                    btnGuessPlayer5.Visibility = Visibility.Visible;
                    btnGuessPlayer6.Visibility = Visibility.Visible;
                    btnGuessPlayer7.Visibility = Visibility.Visible;
                }

                tbPlayer1.Text = globalVar.Player1;
                tbScorePlayer1.Text = globalVar.Player1Score.ToString();
                tbPlayer2.Text = globalVar.Player2;
                tbScorePlayer2.Text = globalVar.Player2Score.ToString();
                tbPlayer3.Text = globalVar.Player3;
                tbScorePlayer3.Text = globalVar.Player3Score.ToString();
                tbPlayer4.Text = globalVar.Player4;
                tbScorePlayer4.Text = globalVar.Player4Score.ToString();
                tbPlayer5.Text = globalVar.Player5;
                tbScorePlayer5.Text = globalVar.Player5Score.ToString();
                tbPlayer6.Text = globalVar.Player6;
                tbScorePlayer6.Text = globalVar.Player6Score.ToString();
                tbPlayer7.Text = globalVar.Player7;
                tbScorePlayer7.Text = globalVar.Player7Score.ToString();
            }
        }

        private void addPlayers(int players)
        {
            int numOfPlayers = players;

            if (numOfPlayers == 1)
            {
                globalVar.playersList.Add(globalVar.Player1);
            }
            else if (numOfPlayers == 2)
            {
                globalVar.playersList.Add(globalVar.Player1);
                globalVar.playersList.Add(globalVar.Player2);
            }
            else if (numOfPlayers == 3)
            {
                globalVar.playersList.Add(globalVar.Player1);
                globalVar.playersList.Add(globalVar.Player2);
                globalVar.playersList.Add(globalVar.Player3);
            }
            else if (numOfPlayers == 4)
            {
                globalVar.playersList.Add(globalVar.Player1);
                globalVar.playersList.Add(globalVar.Player2);
                globalVar.playersList.Add(globalVar.Player3);
                globalVar.playersList.Add(globalVar.Player4);
            }
            else if (numOfPlayers == 5)
            {
                globalVar.playersList.Add(globalVar.Player1);
                globalVar.playersList.Add(globalVar.Player2);
                globalVar.playersList.Add(globalVar.Player3);
                globalVar.playersList.Add(globalVar.Player4);
                globalVar.playersList.Add(globalVar.Player5);
            }
            else if (numOfPlayers == 6)
            {
                globalVar.playersList.Add(globalVar.Player1);
                globalVar.playersList.Add(globalVar.Player2);
                globalVar.playersList.Add(globalVar.Player3);
                globalVar.playersList.Add(globalVar.Player4);
                globalVar.playersList.Add(globalVar.Player5);
                globalVar.playersList.Add(globalVar.Player6);
            }
            else if (numOfPlayers == 7)
            {
                globalVar.playersList.Add(globalVar.Player1);
                globalVar.playersList.Add(globalVar.Player2);
                globalVar.playersList.Add(globalVar.Player3);
                globalVar.playersList.Add(globalVar.Player4);
                globalVar.playersList.Add(globalVar.Player5);
                globalVar.playersList.Add(globalVar.Player6);
                globalVar.playersList.Add(globalVar.Player7);
            }
            tbNowDrawingPlayer.Text = globalVar.playersList.Count().ToString();
        }

        private void orderPlayers()
        {
            while (globalVar.playersList.Count() > 0)
            {
                int rnd = random.Next(0, globalVar.playersList.Count());
                globalVar.playersListOrdered.Add(globalVar.playersList[rnd]);
                globalVar.playersList.RemoveAt(rnd);
            }

            
            //int randomNum;
            //for (int i = 0; i <= globalVar.playersList.Count()+1; i++)
            //{
            //    if (globalVar.playersList.Count() == 1)
            //    {
            //        globalVar.playersListOrdered.Add(globalVar.playersList[0]);
            //        globalVar.playersList.RemoveAt(0);
            //    }
            //    else
            //    {
            //        randomNum = random.Next(0, globalVar.playersList.Count());
            //        globalVar.playersListOrdered.Add(globalVar.playersList[randomNum]);
            //        globalVar.playersList.RemoveAt(randomNum);

            //    }               
            //}

            //globalVar.playersListBackup = globalVar.playersListOrdered;
        }

        private void whatToDraw()
        {
            int randomNum;

            if (globalVar.Words.Count() == 0)
            {
                globalVar.Words = globalVar.WordsBackup;
            }
            randomNum = random.Next(0, globalVar.Words.Count());
            drawThis = globalVar.Words[randomNum];
            globalVar.Words.RemoveAt(randomNum);
        }

        private void checkWords()
        {
            if (globalVar.Words.Count() == 0)
            {
                globalVar.Words = globalVar.WordsBackup;
            }
        }

        private void hideButtons()
        {
            isButtonsVisible = false;
            btnGuessPlayer1.Visibility = Visibility.Collapsed;
            btnGuessPlayer2.Visibility = Visibility.Collapsed;
            btnGuessPlayer3.Visibility = Visibility.Collapsed;
            btnGuessPlayer4.Visibility = Visibility.Collapsed;
            btnGuessPlayer5.Visibility = Visibility.Collapsed;
            btnGuessPlayer6.Visibility = Visibility.Collapsed;
            btnGuessPlayer7.Visibility = Visibility.Collapsed;
        }

        private void btnGuessPlayer1_Click(object sender, RoutedEventArgs e)
        {
            globalVar.Player1Score += 25;
            tbScorePlayer1.Text = globalVar.Player1Score.ToString();
            tbScorePlayer1.Visibility = Visibility.Visible;
            hideButtons();
        }

        private void btnGuessPlayer2_Click(object sender, RoutedEventArgs e)
        {
            globalVar.Player2Score += 25;
            tbScorePlayer2.Text = globalVar.Player2Score.ToString();
            tbScorePlayer2.Visibility = Visibility.Visible;
            hideButtons();
        }

        private void btnGuessPlayer3_Click(object sender, RoutedEventArgs e)
        {
            globalVar.Player3Score += 25;
            tbScorePlayer3.Text = globalVar.Player3Score.ToString();
            tbScorePlayer3.Visibility = Visibility.Visible;
            hideButtons();
        }

        private void btnGuessPlayer4_Click(object sender, RoutedEventArgs e)
        {
            globalVar.Player4Score += 25;
            tbScorePlayer4.Text = globalVar.Player4Score.ToString();
            tbScorePlayer4.Visibility = Visibility.Visible;
            hideButtons();
        }

        private void btnGuessPlayer5_Click(object sender, RoutedEventArgs e)
        {
            globalVar.Player5Score += 25;
            tbScorePlayer5.Text = globalVar.Player5Score.ToString();
            tbScorePlayer5.Visibility = Visibility.Visible;
            hideButtons();
        }

        private void btnGuessPlayer6_Click(object sender, RoutedEventArgs e)
        {
            globalVar.Player6Score += 25;
            tbScorePlayer6.Text = globalVar.Player6Score.ToString();
            tbScorePlayer6.Visibility = Visibility.Visible;
            hideButtons();
        }

        private void btnGuessPlayer7_Click(object sender, RoutedEventArgs e)
        {
            globalVar.Player7Score += 25;
            tbScorePlayer7.Text = globalVar.Player7Score.ToString();
            tbScorePlayer7.Visibility = Visibility.Visible;
            hideButtons();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to end this game?", "End Game?", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                NavigationService.Navigate(
                                     new Uri("/MainPage.xaml",
                                         UriKind.RelativeOrAbsolute)
                                     );
                myDispatcherTimer.Stop();
            }
            else
            {
                e.Cancel = true;
            }
        }

    }
}