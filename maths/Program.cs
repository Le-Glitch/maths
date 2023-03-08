using System.Collections.Generic;

bool isInt = false;
int startValue = 0;
int endValue = 0;
List<int> numbers = new List<int>();
List<string> primeTwins = new List<string>();
List<string> primeTriplets = new List<string>();

//Gets a start value from the user and makes sure it's an integer
Console.WriteLine("Enter start value:");
while (!isInt)
{
    isInt = int.TryParse(Console.ReadLine(), out startValue);
}

isInt = false;

//Gets an end value from the user and makes sure it's an integer
Console.WriteLine("Enter end value:");
while (!isInt || endValue <= startValue)
{
    isInt = int.TryParse(Console.ReadLine(), out endValue);
}

bool isPrime;

//Goes through every number between the interval and checks if it can be divided by any positive number except 1 or itself
for (int i = startValue; i < endValue; i++)
{
    isPrime = true;
    for (int j = 2; j < i; j++)
    {
        if (i % j == 0)
        {
            isPrime = false;
            break;
        }
    }
    if (isPrime)
    {
        numbers.Add(i);
    }
}

//Checks the list of prime numbers to see if there is a prime number that is 2 larger than the one being checked
foreach (int number in numbers)
{
    if (numbers.Contains(number + 2))
    {
        primeTwins.Add($"({number}, {number + 2})");
    }
}

//Checks the list of prime numbers to see if there are prime numbers where the smallest and largest differ by 6
foreach (int number in numbers)
{
    if (numbers.Contains(number + 2) && numbers.Contains(number + 6) && number >= 3)
    {
        primeTriplets.Add($"({number}, {number + 2}, {number + 6})");
    }
    if (numbers.Contains(number + 4) && numbers.Contains(number + 6) && number >= 3)
    {
        primeTriplets.Add($"({number}, {number + 4}, {number + 6})");
    }
}

//Writes out all of the numbers and sets of numbers
Console.Clear();
Console.WriteLine("Prime numbers:");
foreach (int number in numbers)
{
    Console.WriteLine(number);
}

Console.WriteLine();
Console.WriteLine("Twin primes:");
foreach (string primeTwin in primeTwins)
{
    Console.WriteLine(primeTwin);
}

Console.WriteLine();
Console.WriteLine("Triplet primes:");
foreach (string primeTriplet in primeTriplets)
{
    Console.WriteLine(primeTriplet);
}
Console.ReadLine();