using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Piano.Control;

namespace Piano
{
    public sealed class GameForm : Form, IKeyInput, IMouseInput
    {
        private const int ElementSizeHeight = 100;
        private const int ElementSizeWidth = 50;
        private readonly GameState state;
        private readonly SoundsBase sounds;
        private readonly Timer timer;
        private readonly Stopwatch sw;

        public GameForm(GameState state, SoundsBase sounds)
        {
            DoubleBuffered = true;
            this.state = state;
            this.sounds = sounds;
            var map = state.Map;
            ClientSize = new Size(map.Width * ElementSizeWidth, map.Height * ElementSizeHeight);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            timer = new Timer();
            timer.Tick += TimerTick;
            timer.Interval = 17;
            sw = new Stopwatch();
            state.NoteClick += PlayNote;
            state.Start += Start;
        }

        private void Start()
        {
            timer.Start();
            sw.Start();
        }

        private void PlayNote(Note note)
        {
            sounds.PlayNote(note);
        }

        protected override void OnLoad(EventArgs e)
        {
            
        }

        private void GameOver()
        {
            timer.Stop();
            sw.Stop();
            sw.Reset();
            MessageBox.Show(@"Game over :(");
            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.White), 0,0, ClientSize.Width, ClientSize.Height);
            e.Graphics.TranslateTransform(0, -state.MapShiftFromBottom);
            var map = state.Map;
            for (var i = 0; i < map.Height; i++)
                for (var j = 0; j < map.Width; j++)
                {
                    var color = map[map.Height - i - 1, j].IsNote ? Color.Black : Color.White;
                    e.Graphics.FillRectangle(new SolidBrush(color), j * ElementSizeWidth,
                    i * ElementSizeHeight,
                    ElementSizeWidth, ElementSizeHeight);
                }
            e.Graphics.ResetTransform();
            e.Graphics.DrawString(state.GetPoints.ToString(), new Font("Arial", 16), Brushes.Green, 0, 0);
            e.Graphics.DrawString((sw.ElapsedMilliseconds / 1000).ToString(), new Font("Arial", 16), Brushes.Red, 0, 25);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (state.IsGameEnd)
            {
                sounds.PlayGameOverSound();
                GameOver();
            }
            state.Update();
            Invalidate();
        }
    }
}