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
        public bool SaveNeeded { get; set; } = false;

        /// <summary>
        /// Default constructor for the Playlist class that uses the default MPThree constructor
        /// to create a default song while also displaying empty string values for the other attributes.
        /// </summary>
        public Playlist()
        {
            PlaylistSongs = new List<MPThree>();
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
        /// Sorts the playlist alphabetically by the song titles in the playlist
        /// </summary>
        /// <param name="playlist">the created playlist</param>
        public void SortByTitle(Playlist playlist)
        {
            int numOfElements = playlist.PlaylistSongs.Count;
            MPThree temp = new MPThree();
            for (int i = numOfElements; i > 1; i--)
            {
                int max = FindMaxTitle(playlist, i);
                if (max != i - 1)
                {
                    temp = playlist.PlaylistSongs[max];
                    playlist.PlaylistSongs[max] = playlist.PlaylistSongs[i - 1];
                    playlist.PlaylistSongs[i - 1] = temp;
                }
            }
        }

        /// <summary>
        /// Searches for the highest character value in ASCII and returns the index of the string of that value
        /// as a variable
        /// </summary>
        /// <param name="playlist">created playlist</param>
        /// <param name="count">size of playlist list</param>
        /// <returns>value of the first title alphabetically</returns>
        public int FindMaxTitle(Playlist playlist, int count)
        {
            int max = 0;
            for(int i = 1; i < count; i++)
            {
                int maxLength = 0;
                string songOne = playlist.PlaylistSongs[i].SongTitle;
                string songMax = playlist.PlaylistSongs[max].SongTitle;

                if (songOne.CompareTo(songMax) > songMax.CompareTo(songOne))
                {
                    max = i;
                }
                
            }
            return max;
        }

        /// <summary>
        /// Sorts the playlist by date checking year, month, and day and sorting by ascension
        /// </summary>
        /// <param name="playlist">created playlist</param>
        public void SortByDate(Playlist playlist)
        {
            int numOfElements = playlist.PlaylistSongs.Count;
            MPThree temp = new MPThree();
            for(int i = numOfElements; i > 1; i--)
            {
                int max = FindMaxDate(playlist, i); 
                if(max != i - 1)
                {
                    temp = playlist.PlaylistSongs[max]; 
                    playlist.PlaylistSongs[max] = playlist.PlaylistSongs[i - 1]; 
                    playlist.PlaylistSongs[i - 1] = temp; 
                }
            }
        }

        /// <summary>
        /// Finds the latest date index and stores it in an integer variable 
        /// </summary>
        /// <param name="playlist">created playlist</param>
        /// <param name="count">size of the playlist list</param>
        /// <returns>index of latest date</returns>
        public static int FindMaxDate(Playlist playlist, int count)
        {
            int max = 0;
            for(int i = 1; i < count; i++)
            {
                if (int.Parse(playlist.PlaylistSongs[i].SongReleaseDate.Split('/')[2]) > int.Parse(playlist.PlaylistSongs[max].SongReleaseDate.Split('/')[2]))
                {
                    max = i;
                }
                else if (int.Parse(playlist.PlaylistSongs[i].SongReleaseDate.Split('/')[2]) == int.Parse(playlist.PlaylistSongs[max].SongReleaseDate.Split('/')[2]))
                {
                    if (int.Parse(playlist.PlaylistSongs[i].SongReleaseDate.Split('/')[0]) > int.Parse(playlist.PlaylistSongs[max].SongReleaseDate.Split('/')[0]))
                    {
                        max = i;
                    }
                    else if(int.Parse(playlist.PlaylistSongs[i].SongReleaseDate.Split('/')[0]) == int.Parse(playlist.PlaylistSongs[max].SongReleaseDate.Split('/')[0]))
                    {
                        if (int.Parse(playlist.PlaylistSongs[i].SongReleaseDate.Split('/')[1]) > int.Parse(playlist.PlaylistSongs[max].SongReleaseDate.Split('/')[1]))
                        {
                            max = i;
                        }
                    }
                }
            }
            return max;
        }

        /// <summary>
        /// Looks for a text file to take playlist info from and fills a new playlist with it
        /// </summary>
        /// <param name="filePath">path where file is located</param>
        /// <param name="playlist">user created playlist</param>
        /// <returns>a new playlist with the data from the text file</returns>
        public Playlist FillFromFile(string filePath, Playlist playlist)
        {

            bool valid = false;
            string text = "";
            StreamReader reader = null;
            filePath = $"../../../PlaylistData/{filePath}";

            try
            {
                reader = new StreamReader(filePath);
                valid = true;

                try
                {
                    text = reader.ReadLine();
                    if (text == null)
                    {
                        Console.WriteLine("You're save file is empty");
                    }
                    else
                    {
                        string[] fields = text.Split("|");
                        playlist = new Playlist(playlist.PlaylistSongs, fields[0], fields[1], fields[2]);

                        while (reader.Peek() != -1)
                        {
                            text = reader.ReadLine();
                            fields = text.Split("|");

                            MPThree song = new MPThree(fields[0], fields[1], fields[2], double.Parse(fields[3]), (Genre)Enum.Parse(typeof(Genre), fields[4]),
                                                       decimal.Parse(fields[5]), fields[6], double.Parse(fields[7]));
                            playlist.PlaylistSongs.Add(song);
                        }
                    }
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("This save file is empty");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            SaveNeeded = true;
            return playlist;
        }

        /// <summary>
        /// Checks for a text file to save to and writes all playlist info on it separated by a pipe character
        /// </summary>
        /// <param name="filePath">Path to where the file is located</param>
        /// <param name="playlist">user created playlist</param>
        public void SaveToFile(string filePath, Playlist playlist)
        {
            StreamWriter writer = null;
            filePath = $"../../../PlaylistData/{filePath}";
            try
            {
                writer = new StreamWriter(new FileStream(filePath, FileMode.Create));
                writer.WriteLine(playlist.PlaylistName + "|" + playlist.PlaylistCreator + "|" + playlist.CreationDate);

                for(int i = 0; i < playlist.PlaylistSongs.Count; i++)
                {
                    writer.WriteLine(playlist.PlaylistSongs[i].SongTitle + "|" + playlist.PlaylistSongs[i].Artist + "|" + playlist.PlaylistSongs[i].SongReleaseDate
                                     + "|" + playlist.PlaylistSongs[i].PlaybackTime + "|" + playlist.PlaylistSongs[i].Genre + "|" + playlist.PlaylistSongs[i].DownloadCost
                                     + "|" + playlist.PlaylistSongs[i].ImagePath + "|" + playlist.PlaylistSongs[i].FileSize);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(writer != null)
                    writer.Close();
            }

            SaveNeeded = false;
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
