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
        private List<MPThree> PlaylistSongs { get; set; }
        private string PlaylistName { get; set; }
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
            PlaylistName = "";
            PlaylistCreator = "";
            CreationDate = "";
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
            PlaylistSongs = existingPlaylist.PlaylistSongs;
            PlaylistName = existingPlaylist.PlaylistName;
            PlaylistCreator = existingPlaylist.PlaylistCreator;
            CreationDate = existingPlaylist.CreationDate;
        }

        public List<MPThree> GetPlaylist()
        {
            return PlaylistSongs;
        }

        public void SetSong(MPThree song)
        {
            PlaylistSongs.Add(song);
        }

        public void RemoveSong(MPThree song)
        {
            PlaylistSongs.Remove(song);
        }

        public int PlaylistSize(Playlist playlist)
        {
            int size = playlist.PlaylistSongs.Count;
            return size;
        }

        public MPThree EditSong(MPThree song)
        {
            Console.WriteLine("-------EDIT SONG-------");

            Console.Write("Song Title: ");
            song.SongTitle = Console.ReadLine();
            Console.Write("Artist Name: ");
            song.Artist = Console.ReadLine();
            song.SongReleaseDate = Console.ReadLine();
            song.PlaybackTime = double.Parse(Console.ReadLine());
            song.Genre = (Genre)Enum.Parse(typeof(Genre), Console.ReadLine());
            song.DownloadCost = decimal.Parse(Console.ReadLine());
            song.ImagePath = Console.ReadLine();
            song.FileSize = double.Parse(Console.ReadLine());

            return song;
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
                info += $"\nSong {i + 1} \n{PlaylistSongs[i]}";

            return info;
        }
    }
}
