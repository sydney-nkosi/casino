using casino.Models;
using System;

namespace casino.Service
{
    public class Game
    {
        //Single play
        //public void Play()
        //{
        //    DidUserWin();
        //}

        //Multiple play until user decides to stop
        public void Play()
        {
            bool continuePlaying = true;

            while (continuePlaying)
            {
                DidUserWin();
                Console.WriteLine("Want to play again? y/n.");
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
            deck.Shuffle();

            Hand userHand = new Hand();
            Hand dealerHand = new Hand();

            //Keys meaning
            Console.WriteLine("\nHit(h) - to get dealt card, stand(s) - not to get dealt card.\n");

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
            bool userWin = userValue > dealerValue;

            Console.WriteLine($"Value of dealer's hand: {dealerValue}\n");
            Console.WriteLine($"Value of your hand: {userValue}\n");
            Console.WriteLine($"You {(userWin ? "win" : "lose")}.\n");
            
            return userWin;
        }

        private void PrintHand(Hand hand, bool isUsersHand = true)
        {
            if (isUsersHand)
            {
                Console.WriteLine("Your hand:\n");
            }
            else
            {
                Console.WriteLine("Dealer's hand:\n");
            }
            hand.PrintHand();
            Console.WriteLine();
        }

        private string GetInput()
        {
            string input = Console.ReadLine().ToLower();
            Console.WriteLine();
            return input;
        }
    }
}
