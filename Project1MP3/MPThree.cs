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
        public string SongTitle { get; set; }
        private string Artist { get; set; }
        private string SongReleaseDate { get; set; }
        private double PlaybackTime { get; set; }
        private Genre Genre { get; set; }
        private decimal DownloadCost { get; set; }
        private string ImagePath { get; set; }
        private double FileSize { get; set; }

        /// <summary>
        /// Default MPThree constructor with all default values.
        /// </summary>
        public MPThree()
        {
            SongTitle = null;
            Artist = null;
            SongReleaseDate = null;
            PlaybackTime = 0.00d;
            Genre = Genre.Other;
            DownloadCost = 0.00m;
            ImagePath = null;
            FileSize = 0.0d;
        }

        /// <summary>
        /// Copy constructor that copies an existing MPThree object.
        /// </summary>
        /// <param name="existingSong">An existing song the user has created.</param>
        public MPThree(MPThree existingSong)
        {
            SongTitle = existingSong.SongTitle;
            Artist = existingSong.Artist;
            SongReleaseDate = existingSong.SongReleaseDate; 
            PlaybackTime = existingSong.PlaybackTime; 
            Genre = existingSong.Genre;
            DownloadCost = existingSong.DownloadCost;
            ImagePath = existingSong.ImagePath;
            FileSize = existingSong.FileSize;
        }

        /// <summary>
        /// Parameterized Constructor that creates a new MPThree object given certain input
        /// values.
        /// </summary>
        /// <param name="SongTitle">MPThree object's song name value</param>
        /// <param name="Artist">MPThree object's artist name value</param>
        /// <param name="SongReleaseDate">MPThree object's release date value</param>
        /// <param name="PlaybackTime">MPThree object's playback time value</param>
        /// <param name="Genre">MPThree object's genre enum value</param>
        /// <param name="DownloadCost">MPThree object's download cost value</param>
        /// <param name="ImagePath">MPThree object's image path value as a string</param>
        /// <param name="FileSize">MPThree object's file size value</param>
        public MPThree(string SongTitle, string Artist, string SongReleaseDate, double PlaybackTime, Genre Genre, decimal DownloadCost, string ImagePath, double FileSize)
        {
            this.SongTitle = SongTitle;
            this.Artist = Artist;
            this.SongReleaseDate = SongReleaseDate;
            this.PlaybackTime = PlaybackTime;
            this.Genre = Genre;
            this.DownloadCost = DownloadCost;
            this.ImagePath = ImagePath;
            this.FileSize = FileSize;
        }

        /// <summary>
        /// MPThree ToString method to display object info to the console.
        /// </summary>
        /// <returns>The MPThree object's values as an organized string.</returns>
        public override string ToString()
        {
            string info = "";
            info += $"MP3 Title:        {SongTitle}";
            info += $"\nArtist:           {Artist}";
            info += $"\nRelease Date:     {SongReleaseDate}       Genre:       {Genre}";
            info += $"\nDownload Cost:    {DownloadCost}             File Size:   {FileSize} MBs";
            info += $"\nSong Playtime:    {PlaybackTime} minutes      Album Photo: {ImagePath}";

            return info;
        }
    }
}
