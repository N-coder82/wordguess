﻿using System.Text.RegularExpressions;
using System.Reflection;
Console.WriteLine("        _=====_                               _=====_\r\n       / _____ \\                             / _____ \\\r\n     +.-'_____'-.---------------------------.-'_____'-.+\r\n    /   |     |  '.        S O N Y        .'  |  _  |   \\\r\n   / ___| /|\\ |___ \\                     / ___| /_\\ |___ \\\r\n  / |      |      | ;  __           _   ; | _         _ | ;\r\n  | | <---   ---> | | |__|         |_:> | ||_|       (_)| |\r\n  | |___   |   ___| ;SELECT       START ; |___       ___| ;\r\n  |\\    | \\|/ |    /  _     ___      _   \\    | (X) |    /|\r\n  | \\   |_____|  .','\" \"', |___|  ,'\" \"', '.  |_____|  .' |\r\n  |  '-.______.-' /       \\ANALOG/       \\  '-._____.-'   |\r\n  |               |       |------|       |                |\r\n  |              /\\       /      \\       /\\               |\r\n  |             /  '.___.'        '.___.'  \\              |\r\n  |            /                            \\             |\r\n   \\          /                              \\           /\r\n    \\________/                                \\_________/\r\n                      PS2 CONTROLLER\r\n\r\n------------------------------------------------\r\n");
int tries = 6;
string cheatCode = "zzyzx";
Console.WriteLine("Welcome to Word Guess, the same rules for Wordle apply here (no letters in wrong place (we will not tell you if it is part of it), etc.)");
Console.WriteLine("Press any key to start...");
Console.ReadKey();
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

void ShutDown()
{
    Console.WriteLine("Press any key to exit, You have run out of chances.");
    Console.WriteLine($"Thanks for playing, the word was {answerWord}!");
    Console.ReadKey();
    Environment.Exit(0);
}

bool IsLetterInString(string word, string letter)
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
