using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1MP3
{
    public class Playlist
    {
        private List<MPThree> PlaylistSongs { get; set; }
        private string PlaylistName { get; set; }
        private string PlaylistCreator { get; set; }
        private string CreationDate { get; set; }

        public Playlist()
        {
            PlaylistSongs = new List<MPThree>();
            PlaylistSongs.Add(new MPThree());
            PlaylistName = "";
            PlaylistCreator = "";
            CreationDate = "";
        }

        public Playlist(List<MPThree> playlistSongs, string playlistName, string playlistCreator, string creationDate)
        {
            PlaylistSongs = playlistSongs;
            PlaylistName = playlistName;
            PlaylistCreator = playlistCreator;
            CreationDate = creationDate;
        }

        public Playlist(Playlist existingPlaylist)
        {

        }

        public List<MPThree> GetPlaylist()
        {
            return PlaylistSongs;
        }

        public void SetPlaylist(List<MPThree> playlist)
        {
            PlaylistSongs = playlist;
        }

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
