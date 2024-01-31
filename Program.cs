using System;
using System.Data;
using System.Linq;
using System.Net.Quic;
int WinningNumber = 0;
int UserNumber = 0;
int i = 0;
int RoundNumber = 0;
int CurrentRound = 0;
int StillHave = 0;
int RoundInput_correct = 0;
int WinningNumber_correct = 0;
bool playing_infinite = false;
string answer;
int startRange = 0;
int endRange = 0;

Random random = new Random();
Console.Clear();
Console.WriteLine("Randomly generating number or not? y/n");
answer = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
if (answer == "quit")
{
    i++;
    WinningNumber_correct = WinningNumber_correct + 1;
    RoundInput_correct = RoundInput_correct + 1;
}
else if (answer == "y")
{
    Console.Write("Write start of range: ");
    string? startString = Console.ReadLine();
    int.TryParse(startString, out startRange);
    Console.Write("Write end of range: ");
    string? endString = Console.ReadLine();
    int.TryParse(endString, out endRange);
    WinningNumber = random.Next(startRange, endRange);
}

while (WinningNumber_correct == 0 && answer == "n")
{
    Console.Write("Please give number, that you want to find: ");
    string? userInputWinnignCondition = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;

    if (userInputWinnignCondition == "quit")
    {
        i++;
        WinningNumber_correct = WinningNumber_correct + 1;
        RoundInput_correct = RoundInput_correct + 1;
    }
    else if (int.TryParse(userInputWinnignCondition, out WinningNumber))
    {
        Console.Clear();
        Console.WriteLine("Your number is acceptable");
        WinningNumber_correct = WinningNumber_correct + 1;

    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}

while (RoundInput_correct == 0)
{
    Console.Write("Please give numebr of rounds, that you want to play (it could be Infinite): ");
    string? RoundInput = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

    if (RoundInput == "quit")
    {
        i++;
        RoundInput_correct = RoundInput_correct + 1;
    }
    else if (RoundInput == "infinite")
    {
        RoundNumber = -1;
        RoundInput_correct = RoundInput_correct + 1;
        playing_infinite = true;
    }
    else if (int.TryParse(RoundInput, out RoundNumber) && RoundNumber > 0)
    {
        Console.WriteLine("Number of rounds accepted");
        RoundInput_correct = RoundInput_correct + 1;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number of rounds.");
    }
}

int Hot = WinningNumber / 2;
int hotLeft = Hot;
int hotRight = WinningNumber + Hot;
int hotLeftLeft = hotLeft + (Hot / 2);
int hotRightRight = hotRight - (Hot / 2);
int coldLeft = Hot - (Hot / 2);
int coldRight = hotRight + (Hot / 2);

if (WinningNumber == 0)
{
    Hot = 5;
    hotLeft = -1 * Hot;
    hotRight = Hot;
    hotLeftLeft = hotLeft + (Hot / 2);
    hotRightRight = hotRight - (Hot / 2);
    coldLeft = (-1 * Hot) - (Hot / 2);
    coldRight = hotRight + (Hot / 2);
}

while (i == 0)
{
    if (playing_infinite == false)
    {
        CurrentRound = CurrentRound + 1;
        StillHave = RoundNumber - CurrentRound;
        Console.WriteLine($"{CurrentRound} round out of {RoundNumber}");
    }
    Console.Write("Write your guess: ");
    string? userInput = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
    if (userInput == "quit")
    {
        break;
    }
    if (int.TryParse(userInput, out UserNumber))
    {
        Console.WriteLine("You choosed " + UserNumber);
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
    //For winning number+
    if (WinningNumber >= 0)
    {
        if (UserNumber == WinningNumber)
        {
            Console.WriteLine("You won");
            break;
        }
        else if ((UserNumber >= hotLeft && UserNumber <= hotLeftLeft) || (UserNumber <= hotRight && UserNumber >= hotRightRight))
        {
            Console.WriteLine($"Hot, try another, you have {StillHave} more rounds");
        }
        else if (UserNumber >= hotLeftLeft && UserNumber <= hotRightRight)
        {
            Console.WriteLine($"Very hot, try another, you have {StillHave} more rounds");
        }
        else if ((UserNumber >= coldLeft && UserNumber <= hotLeftLeft) || (UserNumber <= coldRight && UserNumber >= hotRightRight))
        {
            Console.WriteLine($"Cold, try another, you have {StillHave} more rounds");
        }
        else
        {
            Console.WriteLine($"Very cold, try another, you have {StillHave} more rounds");
        }
    }

    if (WinningNumber < 0)
    {
        if (UserNumber == WinningNumber)
        {
            Console.WriteLine("You won");
            break;
        }
        else if ((UserNumber <= hotLeft && UserNumber >= hotLeftLeft) || (UserNumber >= hotRight && UserNumber <= hotRightRight))
        {
            Console.WriteLine($"Hot, try another, you have {StillHave} more rounds");
        }
        else if (UserNumber <= hotLeftLeft && UserNumber >= hotRightRight)
        {
            Console.WriteLine($"Very hot, try another, you have {StillHave} more rounds");
        }
        else if ((UserNumber <= coldLeft && UserNumber >= hotLeftLeft) || (UserNumber >= coldRight && UserNumber <= hotRightRight))
        {
            Console.WriteLine($"Cold, try another, you have {StillHave} more rounds");
        }
        else
        {
            Console.WriteLine($"Very cold, try another, you have {StillHave} more rounds");
        }
    }

    if (CurrentRound == RoundNumber )
    {
        Console.WriteLine("You lost");
        break;
    }
}




