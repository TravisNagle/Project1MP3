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
    public class MPThree
    {
        public string songTitle;
        private string artist;
        private string songReleaseDate;
        private double playbackTime;
        private Genre genre { get; set; }
        private decimal downloadCost;
        private string imagePath;
        private double fileSize;

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


        public override string ToString()
        {
            string info = "";
            info += $"MP3 Title:        {songTitle}";
            info += $"\nArtist:           {artist}";
            info += $"\nRelease Date:     {songReleaseDate}          Genre:       {genre}";
            info += $"\nDownload Cost:    {downloadCost}             File Size:   {fileSize}";
            info += $"\nSong Playtime:    {playbackTime}             Album Photo: {imagePath}";

            return info;
        }


    }
}
