////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project1MP3
// File Name: MPThreeDriver.cs
// Description: Displays a welcome message to the user as well as displays the interactable menu.
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Travis Nagle, naglet@etsu.edu, Department of Computing, East Tennessee State University
// Created: 08/30/2022
// Copyright: Travis Nagle, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////

using System.Security.Cryptography;

public class MPThreeDriver
{
    public static void Main()
    { 
        Console.WriteLine("Hello! Welcome to the MP3 Tracker Program! Here you can download, catalog, and play MP3 music files!");

        string playerName;
        do
        {
            Console.Write("Please enter your name: ");
            playerName = Console.ReadLine();

        } while (playerName == "");

        Console.WriteLine($"Welcome {playerName}! Please enjoy MP3 Tracker.");
        Menu();
    }

    public static void Menu()
    {
        Console.WriteLine("Menu for Project 1 - MP3");
        Console.WriteLine("------------------------");
        Console.WriteLine();
        Console.WriteLine("1. Create a new MP3 file");
        Console.WriteLine("2. Display an MP3 file");
        Console.WriteLine("3. End the Program");

        string userChoice = Console.ReadLine();

        while(userChoice != "1" && userChoice != "2" && userChoice != "3");
        {
            Console.WriteLine("Menu for Project 1 - MP3");
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Create a new MP3 file");
            Console.WriteLine("2. Display an MP3 file");
            Console.WriteLine("3. End the Program");

            userChoice = Console.ReadLine();
        }
        
        switch (userChoice)
        {
            case "1":
                Console.WriteLine("One works"); // placeholder line
                break;
            case "2":
                Console.WriteLine("Two works"); // placeholder line
                break;
            case "3":
                Console.WriteLine("Thank you for using MP3 Tracker!");
                break;
        }
    }
}