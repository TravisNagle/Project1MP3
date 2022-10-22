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
        string testDate = "12/25/2022";
        string testDate2 = "12/25/2021";

        int month = int.Parse(testDate.Split('/')[0]);
        int year = int.Parse(testDate.Split('/')[2]);
        Console.WriteLine(month);
        Console.WriteLine(year);

        MPThree song = new MPThree();
        Playlist playlist = new Playlist();

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
        Menu(userName, song, playlist);
        
    }

    /// <summary>
    /// Menu method that displays the menu options for the user which gives
    /// the user eleven possible menu routes.
    /// </summary>
    /// <param name="userName">Takes username value to save it</param>
    /// <param name="newSong">Takes a new song value to store</param>
    /// <param name="playlist">Takes a playlist value to store</param>
    public static void Menu(string username, MPThree newSong, Playlist playlist)
    {
        int userChoice = -1;
        bool isValid = false;
        while(!isValid)
        {
            try
            {
                //Displays the menu options while the user has not entered any of the valid options.
                do
                {
                    Console.WriteLine("Menu for Project 3 - MP3 Tracker");
                    Console.WriteLine("------------------------");
                    Console.WriteLine();
                    Console.WriteLine("1. Create a new playlist"); //done
                    Console.WriteLine("2. Create a new MP3"); //done
                    Console.WriteLine("3. Edit an MP3"); //done
                    Console.WriteLine("4. Remove an MP3"); //done
                    Console.WriteLine("5. Display playlist"); //done
                    Console.WriteLine("6. Search by song name"); //done
                    Console.WriteLine("7. Search by genre"); //done
                    Console.WriteLine("8. Search by artist"); //done
                    Console.WriteLine("9. Sort songs by title"); //done
                    Console.WriteLine("10. Sort by release date");
                    Console.WriteLine("11. Exit"); //done

                    userChoice = int.Parse(Console.ReadLine());
                    isValid = true;

                    //Checks if the user has chosen a one of the provided options
                    if (userChoice <= 0 || userChoice > 11)
                        Console.WriteLine("That was not one of the valid options. Please try again.");

                } 
                while (userChoice <= 0 || userChoice > 11);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
       
        //Checks for which menu option the user has chosen and directs them through that route.
        switch (userChoice)
        {
            case 1:
                playlist = CreatePlaylist(username);
                playlist.GetPlaylist();
                Menu(username, newSong, playlist);
                break;
            case 2:
                if(playlist.PlaylistName == null)
                {
                    Console.WriteLine("There is no playlist created, please create a playlist to add a song.");
                    Menu(username, newSong, playlist);
                }
                else
                {
                    MPThree song = AddSong(username, playlist);
                    playlist.SetSong(song);
                    Menu(username, newSong, playlist);
                }
                break;
            case 3:
                EditSong(username, playlist);
                Menu(username, newSong, playlist);
                break;
            case 4:
                playlist = RemoveSong(username, playlist);
                Menu(username, newSong, playlist);
                break;
            case 5:
                DisplayPlaylist(username, playlist);
                Menu(username, newSong, playlist);
                break;
            case 6:
                SearchName(username, playlist);
                Menu(username, newSong, playlist);
                break;
            case 7:
                SearchGenre(username, playlist);
                Menu(username, newSong, playlist);
                break;
            case 8:
                SearchArtist(username, playlist);
                Menu(username, newSong, playlist);
                break;
            case 9:
                playlist = SortByTitle(playlist);
                Menu(username, newSong, playlist);
                break;
            case 10:
                playlist = SortByReleaseDate(playlist);
                Menu(username, newSong, playlist);
                break;
            case 11:
                Console.WriteLine($"Thank you for using MP3 Tracker, {username}!");
                break;
            default:
                Console.WriteLine("That was not one of the valid options, please try again.");
                break;
        }
    }

    /// <summary>
    /// Creates a new playlist with a user defined number of songs added
    /// </summary>
    /// <param name="username">user entered name</param>
    /// <returns>a created playlist object with all songs user enters</returns>
    public static Playlist CreatePlaylist(string username)
    {
        string playlistName = "";
        do
        {
            Console.Write("Playlist Name: ");
            playlistName = Console.ReadLine();
        }
        while (playlistName == "");

        string creationDate = "";
        do
        {
            Console.Write("Creation Date: ");
            creationDate = Console.ReadLine();
        }
        while (creationDate == "");

        List<MPThree> playlistSong = new List<MPThree>();
        Playlist playlist = new Playlist(playlistSong, username, playlistName, creationDate);

        string userChoice = "";
        do
        {
            Console.WriteLine("Press any button to add a song, -1 to quit");
            userChoice = Console.ReadLine();
            if (userChoice == "-1") break;

            MPThree song = AddSong(username, playlist);
            playlist.SetSong(song);
        } while (userChoice != "-1");

        Console.WriteLine("Playlist Created!");
        Console.WriteLine($"Press \"ENTER\" to return to the main menu.");
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

        string releaseDateChoice = "";
        do
        {
            int month = 0;
            int day = 0;
            int year = 0;
            
            while(month <= 0 || month > 12)
            {
                Console.Write("Release Date Month: ");
                month = int.Parse(Console.ReadLine());
            }

            if(month == 2)
            {
                while(day <= 0 || day > 28)
                {
                    Console.Write("Release Date Day: ");
                    day = int.Parse(Console.ReadLine());
                }
            }
            else
            {
                while (day <= 0 || day > 31)
                {
                    Console.Write("Release Date Day: ");
                    day = int.Parse(Console.ReadLine());
                }
            }

            while(year <= 0 || year > 2022)
            {
                Console.Write("Release Date Year: ");
                year = int.Parse(Console.ReadLine());
            }

            releaseDateChoice = $"{month}/{day}/{year}";
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

    /// <summary>
    /// Edits a song from the playlist
    /// </summary>
    /// <param name="username">user created name</param>
    /// <param name="playlist">created playlist object</param>
    /// <returns>Edited playlist</returns>
    public static Playlist EditSong(string username, Playlist playlist)
    {
        Console.WriteLine("-------EDIT SONG-------");
        playlist = playlist.EditSong(playlist);
        Console.WriteLine($"Press \"ENTER\" to return to the main menu.");
        Console.ReadKey();

        return playlist;
    }

    /// <summary>
    /// Removes a song from the position the user chooses from the playlist
    /// </summary>
    /// <param name="username">user created name</param>
    /// <param name="playlist">created playlist</param>
    /// <returns>playlist with song removed</returns>
    public static Playlist RemoveSong(string username, Playlist playlist)
    {
        Console.WriteLine("-------REMOVE SONG-------");
        Console.WriteLine(playlist);
        int userChoice = 0;

        bool isValid = false;
        while(!isValid)
        {
            try
            {
                Console.Write("Please select the song number of the song you would like to remove: ");
                userChoice = int.Parse(Console.ReadLine());
                isValid = true;
            }
        catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        playlist.RemoveSong(playlist, userChoice);
        Console.WriteLine($"Press \"ENTER\" to return to the main menu.");
        Console.ReadKey();
        return playlist;
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
        Console.WriteLine($"Press \"ENTER\" to return to the main menu");
        Console.ReadKey();
    }

    /// <summary>
    /// Searches the playlist for the song that contains the name of the song the user
    /// is searching for
    /// </summary>
    /// <param name="username">user entered name</param>
    /// <param name="playlist">created playlist object</param>
    public static void SearchName(string username, Playlist playlist)
    {
        Console.WriteLine("-------SEARCHING BY SONG NAME-------");
        string searchedSongName = "";
        Console.Write("Enter the song you are looking for: ");
        searchedSongName = Console.ReadLine();

        playlist.SearchSongName(playlist, searchedSongName);
    }

    /// <summary>
    /// Searches the playlist for the song that contains the name of the genre the user
    /// is searching for
    /// </summary>
    /// <param name="username">user entered name</param>
    /// <param name="playlist">created playlist object</param>
    public static void SearchGenre(string username, Playlist playlist)
    {
        Console.WriteLine("-------SEARCHING BY GENRE-------");
        string searchedGenre = "";
        Genre userGenre = Genre.Other;
        searchedGenre = Console.ReadLine();
        bool valid = false;
        while (!valid)
        {
            try
            {
                Console.Write("Enter the genre you are looking for: ");
                searchedGenre = Console.ReadLine();
                userGenre = (Genre)Enum.Parse(typeof(Genre), searchedGenre);
                valid = true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("You have chosen an invalid option, please try again.");
            }
        }
        playlist.SearchGenre(playlist, userGenre);
    }

    /// <summary>
    /// Searches the playlist for the song that contains the artist name of the song the user
    /// is searching for
    /// </summary>
    /// <param name="username">user entered name</param>
    /// <param name="playlist">created playlist object</param>
    public static void SearchArtist(string username, Playlist playlist)
    {
        Console.WriteLine("-------SEARCHING BY ARTIST-------");
        string searchedArtistName = "";
        Console.Write("Enter the artist you are looking for: ");
        searchedArtistName = Console.ReadLine();

        playlist.SearchArtistName(playlist, searchedArtistName);
    }

    /// <summary>
    /// Sorts the playlist by the song titles aphabetically
    /// </summary>
    /// <param name="playlist">the created playlist</param>
    /// <returns>the playlist sorted by song title</returns>
    public static Playlist SortByTitle(Playlist playlist)
    {
        Console.WriteLine("-------SORTED BY TITLE-------");
        playlist.SortByTitle(playlist);

        return playlist;
    }

    public static Playlist SortByReleaseDate(Playlist playlist)
    {
        Console.WriteLine("-------SORTED BY RELEASE DATE-------");
        playlist.SortByDate(playlist);

        return playlist;
    }
}