namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int computerWins = 0;
            int playerWins = 0;
            int games = 0;
            while (true)
            {
                string playerChoice = GetPlayerChoice();
                string computerChoice = GetComputerChoice();
                if ((playerChoice == "rock" && computerChoice == "rock") ||
                    (playerChoice == "paper" && computerChoice == "paper") ||
                    (playerChoice == "scissors" && computerChoice == "scissors")) {
                    Console.WriteLine("It's a tie");
                }
                if (playerChoice == "rock" && computerChoice == "paper") computerWins = ComputerWon(computerWins, playerChoice, computerChoice);
                if (playerChoice == "paper" && computerChoice == "scissors") computerWins = ComputerWon(computerWins, playerChoice, computerChoice);
                if (playerChoice == "scissors" && computerChoice == "rock") computerWins = ComputerWon(computerWins, playerChoice, computerChoice);
                if (playerChoice == "paper" && computerChoice == "rock") playerWins = PlayerWon(playerWins, playerChoice, computerChoice);
                if (playerChoice == "scissors" && computerChoice == "paper") playerWins = PlayerWon(playerWins, playerChoice, computerChoice);
                if (playerChoice == "rock" && computerChoice == "scissors") playerWins = PlayerWon(playerWins, playerChoice, computerChoice);

                games++;

                switch (GetInput("Would you like to\n1) See stats\n2) Play again\n3) Exit\n\t"))
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"Computer wins: {computerWins}\nPlayer wins: {playerWins}");
                        decimal playerWinRate = Math.Round(playerWins / (decimal)games * 100);
                        decimal computerWinRate = Math.Round(computerWins / (decimal)games * 100);
                        Console.WriteLine($"You have a {playerWinRate}% win rate\nThe computer has a {computerWinRate}% win rate ");
                        switch(GetInput("Would you like to play again (Y X): ").ToUpper())
                        {
                            case "Y":
                            Console.Clear();
                            continue;

                            case "X":
                            default:
                                break;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        continue;
                    case "3":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You didn't enter a valid input!");
                        continue;

                }
                break;
            }
        }
        static int PlayerWon(int input, string player, string computer)
        {
            Console.WriteLine($"You chose {player} and the computer chose {computer}");
            Console.WriteLine("You won!");
            return ++input;
        }
        static int ComputerWon(int input, string player, string computer)
        {
            Console.WriteLine($"You chose {player} and the computer chose {computer}");
            Console.WriteLine("You lost!");
            return ++input;
        }
        static string GetComputerChoice()
        {
            Random rand = new Random();
            int choice = rand.Next(1, 4);
            switch(choice)
            {
                case 1: return "rock";
                case 2: return "paper";
                case 3: return "scissors";
                default: return "";
            }
        }
        static string GetPlayerChoice ()
        {
            while (true)
            {
                switch (GetInput("Choose one of the three:\n1) Rock\n2) Paper\n3) Scissors\n\t"))
                {
                    case "1":
                        return "rock";
                    case "2":
                        return "paper";
                    case "3":
                        return "scissors";
                    default:
                        Console.WriteLine("Please choose from one of the numbers");
                        continue;
                }
            }
        }
        static string GetInput(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                string input = Console.ReadLine();
                if (input != "") return input;
                Console.WriteLine("Input is invalid, please try again.(don't leave empty fields!)");
                continue;
            }
        }
    }
}
