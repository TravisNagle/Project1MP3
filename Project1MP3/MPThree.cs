////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project1MP3
// File Name: Genre.cs
// Description: Creates the MPThree class to allow the user to add their own songs.
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Travis Nagle, naglet@etsu.edu, Department of Computing, East Tennessee State University
// Created: 08/31/2022
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
    /// Creates the MPThree class with eight main attributes including the 
    /// genre enum.
    /// </summary>
    public class MPThree
    {
        public string songTitle { get; set; }
        private string artist { get; set; }
        private string songReleaseDate { get; set; }
        private double playbackTime { get; set; }
        private Genre genre { get; set; }
        private decimal downloadCost { get; set; }
        private string imagePath { get; set; }
        private double fileSize { get; set; }

        /// <summary>
        /// Default MPThree constructor with all default values.
        /// </summary>
        public MPThree()
        {
            songTitle = null;
            artist = null;
            songReleaseDate = null;
            playbackTime = 0.00d;
            genre = Genre.Other;
            downloadCost = 0.00m;
            imagePath = null;
            fileSize = 0.0d;
        }

        /// <summary>
        /// Copy constructor that copies an existing MPThree object.
        /// </summary>
        /// <param name="existingSong">An existing song the user has created.</param>
        public MPThree(MPThree existingSong)
        {
            songTitle = existingSong.songTitle;
            artist = existingSong.artist;
            songReleaseDate = existingSong.songReleaseDate; 
            playbackTime = existingSong.playbackTime; 
            genre = existingSong.genre;
            downloadCost = existingSong.downloadCost;
            imagePath = existingSong.imagePath;
            fileSize = existingSong.fileSize;
        }

        /// <summary>
        /// Parameterized Constructor that creates a new MPThree object given certain input
        /// values.
        /// </summary>
        /// <param name="songTitle">MPThree object's song name value</param>
        /// <param name="artist">MPThree object's artist name value</param>
        /// <param name="songReleaseDate">MPThree object's release date value</param>
        /// <param name="playbackTime">MPThree object's playback time value</param>
        /// <param name="genre">MPThree object's genre enum value</param>
        /// <param name="downloadCost">MPThree object's download cost value</param>
        /// <param name="imagePath">MPThree object's image path value as a string</param>
        /// <param name="fileSize">MPThree object's file size value</param>
        public MPThree(string songTitle, string artist, string songReleaseDate, double playbackTime, Genre genre, decimal downloadCost, string imagePath, double fileSize)
        {
            this.songTitle = songTitle;
            this.artist = artist;
            this.songReleaseDate = songReleaseDate;
            this.playbackTime = playbackTime;
            this.genre = genre;
            this.downloadCost = downloadCost;
            this.imagePath = imagePath;
            this.fileSize = fileSize;
        }

        /// <summary>
        /// MPThree ToString method to display object info to the console.
        /// </summary>
        /// <returns>The MPThree object's values as an organized string.</returns>
        public override string ToString()
        {
            string info = "";
            info += $"MP3 Title:        {songTitle}";
            info += $"\nArtist:           {artist}";
            info += $"\nRelease Date:     {songReleaseDate}       Genre:       {genre}";
            info += $"\nDownload Cost:    {downloadCost}             File Size:   {fileSize} MBs";
            info += $"\nSong Playtime:    {playbackTime} minutes      Album Photo: {imagePath}";

            return info;
        }
    }
}
