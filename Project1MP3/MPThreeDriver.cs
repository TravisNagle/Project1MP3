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

/// <summary>
/// Implementation of the MPThree driver class that introduces
/// the user to the program, lets them choose from an options menu,
/// and performs the operations that each menu item describes.
/// </summary>
public class MPThreeDriver
{
    /// <summary>
    /// Main method that takes the username of the user and saves it.
    /// </summary>
    public static void Main()
    {
        Playlist playlist = new Playlist();
        Console.WriteLine(playlist);
    }

    /// <summary>
    /// Menu method that displays the menu options for the user which gives
    /// the user three possible menu routes.
    /// </summary>
    /// <param name="userName">Takes username value to save it for menu option 3.</param>
    /// <param name="newSong">Takes a new song value to store.</param>
    public static void Menu(string userName, MPThree newSong)
    {
        string userChoice;
        //Displays the menu options while the user has not entered 1, 2, or 3.
        do
        {
            Console.WriteLine("Menu for Project 1 - MP3");
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Create a new MP3 file");
            Console.WriteLine("2. Display an MP3 file");
            Console.WriteLine("3. End the Program");

            userChoice = Console.ReadLine();

            //Checks if the user has chosen a one of the provided options
            if (int.Parse(userChoice) != 1 && int.Parse(userChoice) != 2 && int.Parse(userChoice) != 3)
                Console.WriteLine("That was not one of the valid options. Please try again.");

        } while (int.Parse(userChoice) != 1 && int.Parse(userChoice) != 2 && int.Parse(userChoice) != 3);
        
        //Checks for which menu option the user has chosen and directs them through that route.
        switch (int.Parse(userChoice))
        {
            case 1:
                AddSong(userName);
                break;
            case 2:
                DisplaySong(userName, newSong);
                break;
            case 3:
                Console.WriteLine($"Thank you for using MP3 Tracker, {userName}!");
                break;
        }
    }

    /// <summary>
    /// The method that creates the song. Prompts the user to enter a value for each of the
    /// MPThree objects attributes.
    /// </summary>
    /// <param name="userName">Takes the username value from Main and continues to save it.</param>
    public static void AddSong(string userName)
    {
        string nameChoice;
        do
        {
            Console.WriteLine("Song Name: ");
            nameChoice = Console.ReadLine();
        } while (nameChoice == "");

        string artistChoice;
        do
        {
            Console.WriteLine("Artist Name: ");
            artistChoice = Console.ReadLine();
        } while (artistChoice == "");

        string releaseDateChoice;
        do
        {
            Console.WriteLine("Release Date: ");
            releaseDateChoice = Console.ReadLine();
        } while (releaseDateChoice == "");

        double playbackTimeChoice;
        do
        {
            Console.WriteLine("Playback Time: ");
            playbackTimeChoice = double.Parse(Console.ReadLine());
        } while (playbackTimeChoice < 0);

        Genre userGenre;
        Console.WriteLine("Please select a genre:\n1. Rock\n2. Pop\n3. Jazz\n4. Country\n5. Classical\n6. Other");
        string genreChoice = Console.ReadLine();
        userGenre = (Genre)Enum.Parse(typeof(Genre), genreChoice); // Converts user's string input to enum

        decimal downloadCostChoice;
        do
        {
            Console.WriteLine("Download Cost: ");
            downloadCostChoice = decimal.Parse(Console.ReadLine());
        } while (downloadCostChoice < 0);

        string imagePathChoice;
        do
        {
            Console.WriteLine("Image Path: ");
            imagePathChoice = Console.ReadLine();
        } while (imagePathChoice == "");

        double fileSizeChoice;
        do
        {
            Console.WriteLine("File Size: ");
            fileSizeChoice = double.Parse(Console.ReadLine());
        } while (fileSizeChoice < 0);

        //Creates the new song based on user specifications.
        MPThree newSong = new MPThree(nameChoice, artistChoice, releaseDateChoice, playbackTimeChoice, userGenre, downloadCostChoice, imagePathChoice, fileSizeChoice);

        Console.WriteLine("Song Added! Press \"ENTER\" to return to the menu: ");
        Console.ReadKey();
        //Returns the user to the main menu.
        Menu(userName, newSong);
    }

    /// <summary>
    /// Method that displays the user's song if one has been created.
    /// If no song has been created prompts the user to create one and
    /// returns back to menu.
    /// </summary>
    /// <param name="userName">Takes the username and saves it for the menu.</param>
    /// <param name="newSong">Takes the new song and displays it.</param>
    public static void DisplaySong(string userName, MPThree newSong)
    {
        // Checks if user has added a song
        if (newSong.SongTitle == null)
        {
            Console.WriteLine($"No menu choice exists. Please use menu choice \"1\" before trying to display an MP3 file.");
            //Returns user to the menu
            Menu(userName, newSong);
        }
        // Shows user their added song
        else
        {
            Console.WriteLine(newSong);
            Console.WriteLine($"Press \"ENTER\" to return to the menu.");
            Console.ReadKey();
            //Returns user to the menu
            Menu(userName, newSong);
        }
    }
}