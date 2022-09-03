using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1MP3
{
    internal class MPThree
    {
        private string songTitle;
        private string artist;
        private string songReleaseDate;
        private double playbackTime;
        public Genre genre { get; set; }
        private decimal downloadCost;
        private string imagePath;
        private double fileSize;

        public MPThree()
        {
            songTitle = "(Don't Fear) The Reaper";
            artist = "Blue Oyster Cult";
            songReleaseDate = "05/21/1976";
            playbackTime = 5.09d;
            genre = Genre.Rock;
            downloadCost = 1.29m;
            imagePath = $"photos/AgentsOfFortune.jpg";
            fileSize = 5.4d;
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
            info += $"\nArtist:           {Artist}";
            info += $"\nRelease Date:     {songReleaseDate}       Genre:       {genre}";
            info += $"\nDownload Cost:    {downloadCost}             File Size:   {fileSize}";
            info += $"\nSong Playtime:    {playbackTime}             Album Photo: {imagePath}";

            return info;
        }


    }
}
