﻿////////////////////////////////////////////////////////////////////////////////////////////////////////
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

using System.Linq.Expressions;
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
        MPThree song = new MPThree();
        Playlist playlist = new Playlist();
        //Playlist playlist = new Playlist();
        string username = "Gamer";
        Menu(username, song, playlist);

        /*
        //Creates a default song to verify the user has created a new song
        MPThree defaultSong = new MPThree();

        Console.WriteLine("Hello! Welcome to the MP3 Tracker Program! Here you can download, catalog, and play MP3 music files!");

        string userName;
        //Checks if the user has entered any string for the username
        do
        {
            Console.Write("Please enter your name: ");
            userName = Console.ReadLine();

        } while (userName == "");

        Console.WriteLine($"Welcome {userName}! Please enjoy MP3 Tracker.");
        //Takes user to the menu
        Menu(userName, defaultSong);
        */
    }

    /// <summary>
    /// Menu method that displays the menu options for the user which gives
    /// the user three possible menu routes.
    /// </summary>
    /// <param name="userName">Takes username value to save it for menu option 3.</param>
    /// <param name="newSong">Takes a new song value to store.</param>
    public static void Menu(string username, MPThree newSong, Playlist playlist)
    {
        string userChoice;
        //Displays the menu options while the user has not entered 1, 2, or 3.
        do
        {
            Console.WriteLine("Menu for Project 3 - MP3 Tracker");
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Create a new playlist"); //done
            Console.WriteLine("2. Create a new MP3"); //done
            Console.WriteLine("3. Edit an MP3");
            Console.WriteLine("4. Remove an MP3");
            Console.WriteLine("5. Display playlist"); //done
            Console.WriteLine("6. Search by song name"); //done
            Console.WriteLine("7. Search by genre");
            Console.WriteLine("8. Search by artist");
            Console.WriteLine("9. Sort songs by title");
            Console.WriteLine("10. Sort by release date");
            Console.WriteLine("11. Exit"); //done


            userChoice = Console.ReadLine();

            //Checks if the user has chosen a one of the provided options
            if (!(int.Parse(userChoice) > 0 && int.Parse(userChoice) < 12))
                Console.WriteLine("That was not one of the valid options. Please try again.");

        } while (!(int.Parse(userChoice) > 0 && int.Parse(userChoice) < 12));
        
        //Checks for which menu option the user has chosen and directs them through that route.
        switch (int.Parse(userChoice))
        {
            case 1:
                playlist = CreatePlaylist(username);
                Menu(username, newSong, playlist);
                break;
            case 2:
                MPThree song = AddSong(username, playlist);
                playlist.SetSong(song);
                Menu(username, newSong, playlist);
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                DisplayPlaylist(username, playlist);
                break;
            case 6:
                SearchName(username, playlist);
                Menu(username, newSong, playlist);
                break;
            case 7:
                break;
            case 8:
                SearchArtist(username, playlist);
                Menu(username, newSong, playlist);
                break;
            case 9:
                break;
            case 10:
                DisplaySong(username, newSong, playlist);
                break;
            case 11:
                Console.WriteLine($"Thank you for using MP3 Tracker, {username}!");
                break;
            default:
                Console.WriteLine("That was not one of the valid options, please try again.");
                break;
        }
    }

    public static Playlist CreatePlaylist(string username)
    {
        string playlistName;
        Console.Write("Playlist Name: ");
        playlistName = Console.ReadLine();

        string creationDate;
        Console.Write("Creation Date: ");
        creationDate = Console.ReadLine();

        List<MPThree> playlistSong = new List<MPThree>();
        Playlist playlist = new Playlist(playlistSong, username, playlistName, creationDate);

        string userChoice = "";
        do
        {
            Console.WriteLine("Press any button to add a song, -1 to quit");
            userChoice = Console.ReadLine();
            if (userChoice == "-1")
                break;

            MPThree song = AddSong(username, playlist);
            playlist.SetSong(song);
        } while (userChoice != "-1");


        Console.WriteLine($"Playlist Created! Press \"ENTER\" to be returned to the main menu.");
        Console.ReadKey();
        return playlist;
    }

    /// <summary>
    /// The method that creates the song. Prompts the user to enter a value for each of the
    /// MPThree objects attributes.
    /// </summary>
    /// <param name="userName">Takes the username value from Main and continues to save it.</param>
    public static MPThree AddSong(string userName, Playlist playlist)
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

        double playbackTimeChoice = 0;
        do
        {
            bool isValid = false;
            while(!isValid)
            {
                try
                {
                    Console.WriteLine("Playback Time: ");
                    playbackTimeChoice = double.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        } while (playbackTimeChoice < 0);

        Genre userGenre = Genre.Other;
        string genreChoice = "";
        bool valid = false;
        while(!valid)
        {
            try
            {
                Console.WriteLine("Please select a genre:\n1. Rock\n2. Pop\n3. Jazz\n4. Country\n5. Classical\n6. Other");
                genreChoice = Console.ReadLine();
                userGenre = (Genre)Enum.Parse(typeof(Genre), genreChoice); // Converts user's string input to enum
                valid = true;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("You have chosen an invalid option, please try again.");
            }
        }


        decimal downloadCostChoice = 0;
        do
        {
            bool isValid = false;
            while(!isValid)
            {
                try
                {
                    Console.WriteLine("Download Cost: ");
                    downloadCostChoice = decimal.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        } while (downloadCostChoice < 0);

        string imagePathChoice;
        do
        {
            Console.WriteLine("Image Path: ");
            imagePathChoice = Console.ReadLine();
        } while (imagePathChoice == "");

        double fileSizeChoice = 0;
        do
        {
            bool isValid = false;
            while(!isValid)
            {
                try
                {
                    Console.WriteLine("File Size: ");
                    fileSizeChoice = double.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        } while (fileSizeChoice < 0);

        //Creates the new song based on user specifications.
        MPThree newSong = new MPThree(nameChoice, artistChoice, releaseDateChoice, playbackTimeChoice, userGenre, downloadCostChoice, imagePathChoice, fileSizeChoice);

        Console.WriteLine($"Song Created and Added!\n");
        return newSong;
    }

    public static void EditSong(string username, Playlist playlist)
    {
        int songChoice = -1;
        Console.Write($"Which song would you like to edit: ");
        songChoice = int.Parse(Console.ReadLine());
    }

    /// <summary>
    /// Displays the playlist to the console
    /// </summary>
    /// <param name="username">user entered name</param>
    /// <param name="playlist">created playlist object</param>
    public static void DisplayPlaylist(string username, Playlist playlist)
    {
        Console.WriteLine("-------DISPLAYING PLAYLIST-------");
        Console.WriteLine(playlist);
    }

    /// <summary>
    /// Searches the playlist for the song that contains the name of the song the user
    /// is searching for
    /// </summary>
    /// <param name="username">user entered name</param>
    /// <param name="playlist">created playlist object</param>
    public static void SearchName(string username, Playlist playlist)
    {
        string searchedSongName = "";
        Console.Write("Enter the song you are looking for: ");
        searchedSongName = Console.ReadLine();

        playlist.SearchSongName(playlist, searchedSongName);
    }

    public static void SearchGenre(string username, Playlist playlist)
    {

    }

    /// <summary>
    /// Searches the playlist for the song that contains the artist name of the song the user
    /// is searching for
    /// </summary>
    /// <param name="username">user entered name</param>
    /// <param name="playlist">created playlist object</param>
    public static void SearchArtist(string username, Playlist playlist)
    {
        string searchedArtistName = "";
        Console.Write("Enter the artist you are looking for: ");
        searchedArtistName = Console.ReadLine();

        playlist.SearchArtistName(playlist, searchedArtistName);
    }

    /// <summary>
    /// Method that displays the user's song if one has been created.
    /// If no song has been created prompts the user to create one and
    /// returns back to menu.
    /// </summary>
    /// <param name="userName">Takes the username and saves it for the menu.</param>
    /// <param name="newSong">Takes the new song and displays it.</param>
    public static void DisplaySong(string userName, MPThree newSong, Playlist playlist)
    {
        // Checks if user has added a song
        if (newSong.SongTitle == null)
        {
            Console.WriteLine($"No menu choice exists. Please use menu choice \"1\" before trying to display an MP3 file.");
            //Returns user to the menu
            Menu(userName, newSong, playlist);
        }
        // Shows user their added song
        else
        {
            Console.WriteLine(newSong);
            Console.WriteLine($"Press \"ENTER\" to return to the menu.");
            Console.ReadKey();
            //Returns user to the menu
            Menu(userName, newSong, playlist);
        }
    }
}