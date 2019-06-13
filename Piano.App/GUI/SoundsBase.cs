using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Threading;
using Domain.Infrastructure;
using Piano.Properties;

namespace App
{
    public class SoundsBase
    {
        private readonly Dictionary<Note, SoundPlayer> notes = new Dictionary<Note, SoundPlayer>();
        private SoundPlayer currentPlayer;

        public SoundsBase()
        {
            foreach (var note in (Note[]) Enum.GetValues(typeof(Note)))
            {
                var player = new SoundPlayer();
                player.Play();
                player.Stream = (Stream)Resources.ResourceManager.GetObject(note.ToString());
                player.Load();
                notes[note] = player;
            }
        }

        public void PlayNote(Note note)
        {
            currentPlayer?.Stop();
            currentPlayer = notes[note];
            currentPlayer.Play();
        }

        public void PlayGameOverSound()
        {
            currentPlayer?.Stop();
            var duration = TimeSpan.FromMilliseconds(420);
            PlayNoteWithDuration(Note.DSharp, duration);
            PlayNoteWithDuration(Note.D, duration);
            PlayNoteWithDuration(Note.CSharp, duration);
            PlayNoteWithDuration(Note.C, duration);
        }

        private void PlayNoteWithDuration(Note note, TimeSpan duration)
        {
            var player = notes[note];
            player.Play();
            Thread.Sleep(duration);
        }
    }
}