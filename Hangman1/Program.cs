using System.Text.RegularExpressions;
using System.Reflection;

int tries = 6;
string cheatCode = "zzyzx";
Console.WriteLine("Welcome to Word Guess, the same rules for Wordle apply here (no letters in wrong place (we will not tell you if it is part of it), etc.)");
Console.WriteLine("Made by Natey hecht | Github: N-coder82 | Dev.to: @satoshi");
Thread.Sleep(2000);
Console.Clear();
Console.WriteLine("Ready to play!");
Thread.Sleep(1000);
Console.Clear();
var workingdir = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
var lines = File.ReadAllLines(workingdir + @"\WordGuessWords.txt");
var r = new Random();
var randomLineNumber = r.Next(0, lines.Length - 1);
string answerWord = lines[randomLineNumber];
Random random = new Random();
bool isStillPlaying = true;
while (tries > 0 && isStillPlaying)
{
    string userInput = Console.ReadLine();
    while (userInput.Length != 5 || !Regex.IsMatch(userInput, @"^[a-zA-Z]+$") || !lines.Contains(userInput))
    {
        Console.WriteLine("Your previous input doesn't meet the current criteria: cannot be a number, has to be 5 letters, has to exist.");
        userInput = Console.ReadLine();
    }
    string wordOutput = "";
    if (userInput == cheatCode)
    {
        Console.WriteLine(answerWord);
        GoodChanceShutDown();
    }
    else
    {
      /* foreach (char ch in answerWord)
        {
            if (IsLetterInString(userInput, ch.ToString()))
            {
                wordOutput += ch.ToString();
            }
            else
            {
                wordOutput += "_";
                isStillPlaying = true;
            }
        }*/
        for (int i = 0; i < 5; i++)
        {
            char currentInput = userInput[i];
            char currentAnswer = answerWord[i];
            if(currentInput == currentAnswer)
            {
                wordOutput += currentInput.ToString();
            }
            else
            {
                wordOutput += "_";
                isStillPlaying = true;
            }
        }

        Console.WriteLine(wordOutput);
        if (userInput == answerWord || !isStillPlaying)
        {
            isStillPlaying = false;
            Console.WriteLine("Good Job! You guessed it!");
            Console.WriteLine();
            GoodChanceShutDown();
        }
        else
            tries--;
        if (tries != 0)
        {
            Console.WriteLine("You have " + tries + " tries left");
        }
        if (tries < 1 && userInput != answerWord)
        {
            ShutDown();
        }

    }
}

static void ShutDown()
{
    Console.WriteLine("Press any key to exit, You have run out of chances.");
    Console.ReadKey();
    Environment.Exit(0);
}

static bool IsLetterInString(string word, string letter)
{
    foreach (char ch in word)
    {
        if (letter.Equals(ch.ToString()))
            return true;
    }
    return false;
}


void GoodChanceShutDown()
{
    Console.WriteLine("Press any key to exit, You have guessed the word with " + tries.ToString() + " chances remaining!");
    Console.ReadKey();
    Environment.Exit(0);
}