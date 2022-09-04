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
using Project1MP3;

public class MPThreeDriver
{
    public static void Main()
    {
        MPThree defaultSong = new MPThree();

        Console.WriteLine("Hello! Welcome to the MP3 Tracker Program! Here you can download, catalog, and play MP3 music files!");

        string userName;
        do
        {
            Console.Write("Please enter your name: ");
            userName = Console.ReadLine();

        } while (userName == "");

        Console.WriteLine($"Welcome {userName}! Please enjoy MP3 Tracker.");
        Menu(userName, defaultSong);
    }

    public static void Menu(string userName, MPThree newSong)
    {
        string userChoice;
        do
        {
            Console.WriteLine("Menu for Project 1 - MP3");
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Create a new MP3 file");
            Console.WriteLine("2. Display an MP3 file");
            Console.WriteLine("3. End the Program");

            userChoice = Console.ReadLine();

            if (int.Parse(userChoice) != 1 && int.Parse(userChoice) != 2 && int.Parse(userChoice) != 3)
                Console.WriteLine("That was not one of the valid options. Please try again.");

        } while (int.Parse(userChoice) != 1 && int.Parse(userChoice) != 2 && int.Parse(userChoice) != 3);
        
        switch (int.Parse(userChoice))
        {
            case 1:
                AddSong(userName);
                break;
            case 2:
                ShowSong(userName, newSong);
                break;
            case 3:
                Console.WriteLine($"Thank you for using MP3 Tracker, {userName}!");
                break;
        }
    }

    public static void AddSong(string userName)
    {
        Console.WriteLine("Song Name: ");
        string nameChoice = Console.ReadLine();

        Console.WriteLine("Artist Name: ");
        string artistChoice = Console.ReadLine();

        Console.WriteLine("Release Date: ");
        string releaseDateChoice = Console.ReadLine();

        Console.WriteLine("Playback Time: ");
        double playbackTimeChoice = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Please select a genre:\n1. Rock\n2. Pop\n3. Jazz\n4. Country\n5. Classical\n6. Other");
        string numberSelect = Console.ReadLine();
        Genre genreChoice = Genre.Other;
        switch (numberSelect)
        {
            case "1":
                genreChoice = Genre.Rock;
                break;
            case "2":
                genreChoice = Genre.Pop;
                break;
            case "3":
                genreChoice = Genre.Jazz;
                break;
            case "4":
                genreChoice = Genre.Country;
                break;
            case "5":
                genreChoice = Genre.Classical;
                break;
            case "6":
                genreChoice = Genre.Other;
                break;
        }

        Console.WriteLine("Download Cost: ");
        decimal downloadCostChoice = Convert.ToDecimal(Console.ReadLine()); // Placeholder value

        Console.WriteLine("Image Path: ");
        string imagePathChoice = Console.ReadLine();

        Console.WriteLine("File Size: ");
        double fileSizeChoice = Convert.ToDouble(Console.ReadLine());

        MPThree newSong = new MPThree(nameChoice, artistChoice, releaseDateChoice, playbackTimeChoice, genreChoice, downloadCostChoice, imagePathChoice, fileSizeChoice);

        Console.WriteLine("Song Added! Press \"ENTER\" to return to the menu: ");
        Console.ReadKey();
        Menu(userName, newSong);
    }

    public static void ShowSong(string userName, MPThree newSong)
    {
        // Checks if user has added a song
        if (newSong.songTitle == null)
        {
            Console.WriteLine($"No menu choice exists. Please use menu choice \"1\" before trying to display an MP3 file.");
            Menu(userName, newSong);
        }
        // Shows user their added song
        else
        {
            Console.WriteLine(newSong);
            Console.WriteLine($"Press \"ENTER\" to return to the menu.");
            Console.ReadKey();
            Menu(userName, newSong);
        }
    }
}