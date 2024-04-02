namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (!UI());
        }
        #region UI
        static bool UI()
        {
            switch(CMD.GetInput("Would you like to print:\n1) A single item\n2) Multiple items"))
            {
                case "1":
                    switch(CMD.GetInput("Enter the type that you want to try printing:\n1) String\n2) Number\n3) Boolean"))
                    {
                        case "1":
                            CMD.GetInput("Enter the string:").Print();
                            break;

                        case "2":
                            CMD.GetNumber("Enter the number:").Print();
                            break;

                        case "3":
                            CMD.GetBool("Enter your boolean:").Print();
                            break;
                        default:
                            return CMD.DefaultMessage();
                    }break;

                case "2":
                    switch (CMD.GetInput("Enter the type of collection that you want to try printing:\n1) String\n2) Number\n3) Boolean"))
                    {
                        case "1":
                            CMD.GetStrings("Enter a string:").PrintCollection();
                            break;

                        case "2":
                            CMD.GetNumbers("Enter a number:").PrintCollection();
                            break;

                        case "3":
                            CMD.GetBools("Enter a boolean:").PrintCollection();
                            break;

                        default:
                            return CMD.DefaultMessage();
                    }break;

                default:
                    return CMD.DefaultMessage();
            }
            switch(CMD.GetInput("Would you like to print again? (Y N)").ToUpper())
            {
                case "Y":
                    Console.Clear();
                    Console.WriteLine("Returning to the beginning...");
                    return false;
                case "N":
                default:
                    Console.Clear();
                    Console.WriteLine("Thanks for using our printing service!");
                    return true;

            }
        }
        #endregion

    }
}
