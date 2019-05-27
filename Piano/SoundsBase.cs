﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Threading;
using Piano.Properties;

namespace Piano
{
    public class SoundsBase
    {
        private readonly Dictionary<Note, SoundPlayer> notes = new Dictionary<Note, SoundPlayer>();
        private SoundPlayer currentPlayer;

        public SoundsBase()
        {
            foreach (var note in (Note[]) Enum.GetValues(typeof(Note)))
            {
                var stream = (Stream) Resources.ResourceManager.GetObject(note.ToString());
                var player = new SoundPlayer(stream);
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
            var duration = TimeSpan.FromMilliseconds(300);
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