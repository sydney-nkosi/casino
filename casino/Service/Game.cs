using casino.Models;
using System;

namespace casino.Service
{
    public class Game
    {
        //Multiple play until user decides to stop
        public void Play()
        {
            //Keys meaning
            Console.WriteLine("\nHit(h) - to get dealt card, stand(s) - not to get dealt card.\n");

            while (true)
            {
                DidUserWin();
                Console.Write("Want to play again? y/n. ");
                string userInput = GetInput();

                if (userInput.StartsWith("y"))
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }

        //returns true if user win, false if the dealer wins.
        private bool DidUserWin()
        {
            Deck deck = new Deck();
            Hand userHand = new Hand();
            Hand dealerHand = new Hand();
          
            while (true)
            {
                deck.Shuffle();
              
                //Let the user draw card.
                while (true)
                {
                    //Hit or stand.
                    Console.Write("Hit(h) or stand(s)? ");
                    string userChoice = GetInput();

                    if (userChoice.Equals(""))
                    {
                        continue;
                    }
                    else if ("stand".StartsWith(userChoice))
                    {
                        break;
                    }
                    else if ("hit".StartsWith(userChoice))
                    {
                        userHand.AddCard(deck.Deal());
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Must be 'hit' or 'stand'\n");
                        continue;
                    }

                    //Display user's hand.
                    PrintHand(userHand);

                    //Check value after displaying hand.
                    if (userHand.GetValue() > 21)
                    {
                        Console.WriteLine($"Your hand value is {userHand.GetValue()}, which exceeds 21. You lose.\n");
                        return false;
                    }
                }

                //Draw cards for the dealer.
                while (dealerHand.GetValue() <= 17)
                {
                    dealerHand.AddCard(deck.Deal());
                    if (dealerHand.GetValue() > 21)
                    {
                        Console.WriteLine($"Dealer's hand value is {dealerHand.GetValue()}, which exceeds 21. You win.\n");
                        PrintHand(dealerHand, false);
                        return true;
                    }
                }

                //Display hands, values and who won.
                PrintHand(dealerHand, false);
                PrintHand(userHand);

                int userValue = userHand.GetValue();
                int dealerValue = dealerHand.GetValue();

                PrintHandValues(userValue, dealerValue);
                
                if (userValue == dealerValue)
                {
                    Console.WriteLine($"It's a draw. You play again.\n");
                    //In case of a draw we reset deck, hands and let users play again.
                    deck.ResetDeck();
                    userHand.ResetHand();
                    dealerHand.ResetHand();
                    continue;
                }

                bool userWin = userValue > dealerValue;
                Console.WriteLine($"You {(userWin ? "win" : "lose")}.\n");

                return userWin;
            }
        }

        private void PrintHand(Hand hand, bool isUsersHand = true)
        {
            Console.WriteLine($"{(isUsersHand ? "Your" : "Dealer's")} hand:\n");
            hand.PrintHand();
            Console.WriteLine();
        }

        private void PrintHandValues(int userValue, int dealerValue)
        {
            Console.WriteLine($"Value of dealer's hand: {dealerValue}");
            Console.WriteLine($"Value of your hand: {userValue}\n");
        }

        private string GetInput()
        {
            string input = Console.ReadLine().ToLower();
            Console.WriteLine();
            return input;
        }
    }
}
