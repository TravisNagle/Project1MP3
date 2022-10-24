////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project3MP3Tracker
// File Name: Playlist.cs
// Description: Implements a Playlist class that keeps track of multiple songs the user 
// has created
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Travis Nagle, naglet@etsu.edu, Department of Computing, East Tennessee State University
// Created: 10/12/2022
// Copyright: Travis Nagle, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Project1MP3
{
    /// <summary>
    /// Implementation of the Playlist class that creates a list of MP3 songs and displays
    /// the name, creator, and creation date of the playlist.
    /// </summary>
    public class Playlist
    {
        private List<MPThree> PlaylistSongs { get; set; } = new List<MPThree>();
        public string PlaylistName { get; set; }
        private string PlaylistCreator { get; set; }
        private string CreationDate { get; set; }

        /// <summary>
        /// Default constructor for the Playlist class that uses the default MPThree constructor
        /// to create a default song while also displaying empty string values for the other attributes.
        /// </summary>
        public Playlist()
        {
            PlaylistSongs = new List<MPThree>();
            PlaylistSongs.Add(new MPThree());
            PlaylistName = null;
            PlaylistCreator = null;
            CreationDate = null;
        }

        /// <summary>
        /// Parameterized constructor for the Playlist class that takes an input for
        /// each of the attributes within the Playlist class and creates a new playlist
        /// object.
        /// </summary>
        /// <param name="playlistSongs">List of playlist songs</param>
        /// <param name="playlistName">Name of the created playlist</param>
        /// <param name="playlistCreator">Name of the user that created the playlist</param>
        /// <param name="creationDate">Date the playlist was created</param>
        public Playlist(List<MPThree> playlistSongs, string playlistName, string playlistCreator, string creationDate)
        {
            PlaylistSongs = playlistSongs;
            PlaylistName = playlistName;
            PlaylistCreator = playlistCreator;
            CreationDate = creationDate;
        }

        /// <summary>
        /// Copy constructor for the playlist class that copies an existing playlist
        /// object and copies it to a new object.
        /// </summary>
        /// <param name="existingPlaylist">Previously created playlist</param>
        public Playlist(Playlist existingPlaylist)
        {
            List<MPThree> copiedPlaylistSongs = new List<MPThree>(PlaylistSongs);
            PlaylistName = existingPlaylist.PlaylistName;
            PlaylistCreator = existingPlaylist.PlaylistCreator;
            CreationDate = existingPlaylist.CreationDate;
        }

        /// <summary>
        /// Displays the songs of the playlist
        /// </summary>
        /// <returns>list of MPThree objects in playlist</returns>
        public List<MPThree> GetPlaylist()
        {
            return PlaylistSongs;
        }

        /// <summary>
        /// Adds a MPThree object to an existing playlist
        /// </summary>
        /// <param name="song">MPThree to be added</param>
        public void SetSong(MPThree song)
        {
            PlaylistSongs.Add(song);
        }

        /// <summary>
        /// Displays the size of the playlist as an integer of the number of songs
        /// </summary>
        /// <param name="playlist">the playlist to be counted</param>
        /// <returns>the size as an integer</returns>
        public int PlaylistSize(Playlist playlist)
        {
            int size = playlist.PlaylistSongs.Count;
            return size;
        }

        /// <summary>
        /// Edits a song within a created playlist object
        /// </summary>
        /// <param name="playlist">created playlist object</param>
        /// <returns>the playlist with the user-chosen song edited</returns>
        public Playlist EditSong(Playlist playlist)
        {
            bool isValid = false;
            int userChoice = -1;

            while (!isValid)
            {
                try
                {
                    do
                    {
                        Console.WriteLine(playlist);
                        Console.WriteLine("Select a song to edit: ");
                        userChoice = int.Parse(Console.ReadLine());
                        isValid = true;
                    }
                    while (userChoice <= 0 || userChoice > playlist.PlaylistSongs.Count);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            int featureChoice = 0;
            do
            {
                bool valid = false;
                while(!valid)
                {
                    try
                    {
                        do
                        {
                            Console.WriteLine($"Select a feature to edit:\n1.) Song Title\n2.) Artist Name\n3.) Release Date\n4.) Playback Time\n5.) Genre\n6.) Download Cost\n7.) Image Path\n8.) File Size");
                            featureChoice = int.Parse(Console.ReadLine());
                            if (featureChoice <= 0 || featureChoice > 8)
                            {
                                Console.WriteLine($"{featureChoice} is not one of the valid selections");
                            }                          
                            valid = true;
                        }
                        while (featureChoice <= 0 || featureChoice > 8);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            while (featureChoice <= 0 || featureChoice > 8);

            switch(featureChoice)
            {
                case 1:
                    string titleChoice = "";
                    bool validTitle = false;
                    while(!validTitle)
                    {
                        try
                        {
                            do
                            {
                                Console.Write("Song Title: ");
                                titleChoice = Console.ReadLine();
                                validTitle = true;
                                playlist.PlaylistSongs[userChoice - 1].SongTitle = titleChoice;
                            }
                            while (titleChoice == "");
                        }
                        catch(FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case 2:
                    string artistChoice = "";
                    bool validArtist = false;
                    while (!validArtist)
                    {
                        try
                        {
                            do
                            {
                                Console.Write("Artist Name: ");
                                artistChoice = Console.ReadLine();
                                validArtist = true;
                                playlist.PlaylistSongs[userChoice - 1].Artist = artistChoice;
                            }
                            while (artistChoice == "");
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case 3:
                    string releaseDate = "";
                    bool validDate = false;
                    while (!validDate)
                    {
                        try
                        {
                            do
                            {
                                Console.Write("Release Date: ");
                                releaseDate = Console.ReadLine();
                                validDate = true;
                                playlist.PlaylistSongs[userChoice - 1].Artist = releaseDate;
                            }
                            while (releaseDate == "");
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case 4:
                    double playbackTime = -1;
                    bool validTime = false;
                    while (!validTime)
                    {
                        try
                        {
                            do
                            {
                                Console.Write("Playback Time: ");
                                playbackTime = double.Parse(Console.ReadLine());
                                validTime = true;
                                playlist.PlaylistSongs[userChoice - 1].PlaybackTime = playbackTime;
                            }
                            while (playbackTime == -1);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case 5:
                    Genre userGenre = Genre.Other;
                    string genreChoice = "";
                    bool validGenre = false;
                    while (!validGenre)
                    {
                        try
                        {
                            do
                            {
                                Console.Write("Genre: ");
                                genreChoice = Console.ReadLine();
                                userGenre = (Genre)Enum.Parse(typeof(Genre), genreChoice);
                                validGenre = true;
                                playlist.PlaylistSongs[userChoice - 1].Genre = userGenre;
                            }
                            while (genreChoice == "");
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Your input was not valid, please try again.");
                        }
                    }
                    break;
                case 6:
                    decimal downloadCost = -1;
                    bool validCost = false;
                    while (!validCost)
                    {
                        try
                        {
                            do
                            {
                                Console.Write("Download Cost: ");
                                downloadCost = decimal.Parse(Console.ReadLine());
                                validCost = true;
                                playlist.PlaylistSongs[userChoice - 1].DownloadCost = downloadCost;
                            }
                            while (downloadCost == -1);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case 7:
                    string imagePath = "";
                    bool validPath = false;
                    while (!validPath)
                    {
                        try
                        {
                            do
                            {
                                Console.Write("Image Path: ");
                                imagePath = Console.ReadLine();
                                validPath = true;
                                playlist.PlaylistSongs[userChoice - 1].ImagePath = imagePath;
                            }
                            while (imagePath == "");
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case 8:
                    double fileSize = -1;
                    bool validFile = false;
                    while (!validFile)
                    {
                        try
                        {
                            do
                            {
                                Console.Write("File Size: ");
                                fileSize = double.Parse(Console.ReadLine());
                                validFile = true;
                                playlist.PlaylistSongs[userChoice - 1].FileSize = fileSize;
                            }
                            while (fileSize == -1);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
            }
            return playlist;
        }

        /// <summary>
        /// Removes a song from a created playlist
        /// </summary>
        /// <param name="playlist">user created playlist</param>
        /// <param name="songPos">one past the position of the song to be removed</param>
        /// <returns></returns>
        public Playlist RemoveSong(Playlist playlist, int songPos)
        {
            playlist.PlaylistSongs.RemoveAt(songPos - 1);
            Console.WriteLine($"Song {songPos} has been removed");

            return playlist;
        }

        /// <summary>
        /// Searches for songs in the playlist via the user's entered song name
        /// </summary>
        /// <param name="playlist">the created playlist</param>
        /// <param name="songName">the name of the song the user is searching for</param>
        public void SearchSongName(Playlist playlist, string songName)
        {

            List<MPThree> searchedPlaylist = new List<MPThree>();

            Console.WriteLine("-------SONGS FOUND-------");
            Console.WriteLine();
            for (int i = 0; i < playlist.PlaylistSongs.Count; i++)
            {
                if (playlist.PlaylistSongs[i].SongTitle == songName)
                {
                    searchedPlaylist.Add(playlist.PlaylistSongs[i]);
                }
            }
            for (int i = 0; i < searchedPlaylist.Count; i++)
            {
                Console.WriteLine(searchedPlaylist[i]);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Searches the playlist via the user's entered genre
        /// </summary>
        /// <param name="playlist">the created playlist</param>
        /// <param name="genre">the genre the user is searching for</param>
        public void SearchGenre(Playlist playlist, Genre genre)
        {
            List<MPThree> searchedPlaylist = new List<MPThree>();

            Console.WriteLine("-------SONGS FOUND-------");
            Console.WriteLine();
            for (int i = 0; i < playlist.PlaylistSongs.Count; i++)
            {
                if (playlist.PlaylistSongs[i].Genre == genre)
                {
                    searchedPlaylist.Add(playlist.PlaylistSongs[i]);
                }
            }
            for (int i = 0; i < searchedPlaylist.Count; i++)
            {
                Console.WriteLine(searchedPlaylist[i]);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Searches for songs in the playlist via the user's entered artist name
        /// </summary>
        /// <param name="playlist">the created playlist</param>
        /// <param name="artistName">the artist's name the user is searching for</param>
        public void SearchArtistName(Playlist playlist, string artistName)
        {
            List<MPThree> searchedPlaylist = new List<MPThree>();

            Console.WriteLine("-------SONGS FOUND-------");
            Console.WriteLine();
            for(int i = 0; i < playlist.PlaylistSongs.Count; i++)
            {
                if (playlist.PlaylistSongs[i].Artist == artistName)
                {
                    searchedPlaylist.Add(playlist.PlaylistSongs[i]);
                }
            }
            for(int i = 0; i < searchedPlaylist.Count; i++)
            {
                Console.WriteLine(searchedPlaylist[i]);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Sorts the playlist alphabetically by the song titles in the playlist
        /// </summary>
        /// <param name="playlist">the created playlist</param>
        public void SortByTitle(Playlist playlist)
        {
            playlist.PlaylistSongs.Sort(delegate (MPThree songOne, MPThree songTwo)
            {
                return songOne.SongTitle.CompareTo(songTwo.SongTitle);
            });
        }

        /// <summary>
        /// Sorts the playlist by date checking year, month, and day and sorting by ascension
        /// </summary>
        /// <param name="playlist">created playlist</param>
        public void SortByDate(Playlist playlist)
        {

        }

        public static int FindMax(Playlist playlist, int count)
        {
            int max = 0;
            for(int i = 1; i < count; i++)
            {
                if (int.Parse(playlist.PlaylistSongs[i].SongReleaseDate.Split('/')[2]) > int.Parse(playlist.PlaylistSongs[max].SongReleaseDate.Split('/')[2]))
                {
                    max = i;
                }
            }
            return max;
        }

        /// <summary>
        /// ToString method to display all MP3's in the playlist
        /// </summary>
        /// <returns>The playlist as a string</returns>
        public override string ToString()
        {
            string info = "";
            info += $"\nPlaylist Name: {PlaylistName}";
            info += $"\nPlaylist Creator: {PlaylistCreator}";
            info += $"\nCreation Date: {CreationDate}";

            for (int i = 0; i < PlaylistSongs.Count; i++)
            {
                info += $"\nSong {i + 1} \n{PlaylistSongs[i]}";
            }
            return info;
        }
    }
}
