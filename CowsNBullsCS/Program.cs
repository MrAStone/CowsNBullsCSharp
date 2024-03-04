namespace CowsNBullsCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(); // initialise random
            int cowBullNum = 0;
            bool validCBNum = false;
            while (!validCBNum) // Loop to create the cows and bulls number
            {
                cowBullNum = rand.Next(1023, 9877); // smallest can be 1023, largest 9876
                string cbNumStrings = Convert.ToString(cowBullNum); //Convert to string to test
                bool repeats = false; // assume no repeats
                for (int i = 0; i < cbNumStrings.Length; i++) // for each digit in the number
                {
                    for (int j = i + 1; j < cbNumStrings.Length; j++) // check all other digits
                    {
                        if (cbNumStrings[j] == cbNumStrings[i]) // if they match
                        {
                            repeats = true; // there is a repeat
                        }
                    }
                }
                validCBNum = !repeats; // if no repeats then number is valid
            }
            Console.WriteLine(cowBullNum); // used to test, don't show in actual game


            int inputNum = 0; //users guess
            int guesses = 0; // number of attempts
            while (inputNum != cowBullNum) // compare input with cows and bulls number
            {
                guesses++; // increment guesses
                int cows = 0; // number of cows
                int bulls = 0; // number of bulls
                string input = "";
                string cbNumStrings = Convert.ToString(cowBullNum); //Convert to string to test
                bool repeats = true; // assume repeats
                while (repeats)
                {

                    repeats = false; // sets no repeats again
                    Console.Write("Enter a number: ");
                    inputNum = Convert.ToInt32(Console.ReadLine()); // take user input
                    input = Convert.ToString(inputNum); // convert users guess to string

                    for (int i = 0; i < input.Length; i++) // for each digit in the number
                    {

                        for (int j = i + 1; j < input.Length; j++) // check all other digits
                        {
                            if (input[j] == input[i]) // if they match
                            {
                                repeats = true; // there is a repeat

                            }
                        }
                    }
                    if (repeats) // not a valid guess
                    {
                        Console.WriteLine("You can't have repeating numbers"); // Tell user!
                    }
                    if (input.Length != 4) // If guess is not 4 digits long
                    {
                        repeats = true; // Not valid instead of repeats
                        Console.WriteLine("Number must be 4 digits long"); //Tell user!
                    }
                }
                string cbNumString = Convert.ToString(cowBullNum); // convert cowbull num to string

                for (int i = 0; i < cbNumString.Length; i++) // for each digit in the cows and bulls number
                {
                    for (int j = 0; j < input.Length; j++) // for every digit in the users guess
                    {
                        if (cbNumString[i] == input[j]) // if the digits match (contains that number)
                        {
                            if (i == j) // if the position matches
                            {
                                bulls++; // its a bull
                            }
                            else
                            {
                                cows++; // otherwise it's a cow
                            }
                        }
                    }
                }
                string cowString = "cows"; // preventing pedants from commenting on output
                string bullString = "bulls";
                if (cows == 1)
                {
                    cowString = "cow"; // 1 cow, multiple cows
                }
                if (bulls == 1)
                {
                    bullString = "bull";
                }
                Console.WriteLine($"your input had {cows} {cowString} and {bulls} {bullString}"); // output number of cows and bulls in guess

            }
            Console.WriteLine($"You guessed the number {cowBullNum} in {guesses} attempts"); // they have done it!
        }
    }
}
