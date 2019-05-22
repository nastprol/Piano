using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Piano.Control;
using Piano.Game.State;

namespace Piano
{
    public sealed class GameForm : Form, IKeyInput, IMouseInput
    {
        private const int ElementSizeHeight = 100;
        private const int ElementSizeWidth = 50;
        private readonly IGame state;
        private readonly Timer timer;
        private SoundPlayer player;

        public GameForm(IGame state)
        {
            DoubleBuffered = true;
            this.state = state;
            var map = state.Map;
            ClientSize = new Size(map.Width * ElementSizeWidth, map.Height * ElementSizeHeight);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            timer = new Timer();
            timer.Tick += TimerTick;
            timer.Interval = 60;
            player = new SoundPlayer();
        }

        protected override void OnLoad(EventArgs e)
        {
            timer.Start();
        }

        private void GameOver()
        {
            timer.Stop();
            MessageBox.Show("Game over :(");
            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var map = state.Map;
            for (var i = 0; i < map.Height; i++)
            for (var j = 0; j < map.Width; j++)
                e.Graphics.FillRectangle(new SolidBrush(map[map.Height - i - 1, j].Color), j * ElementSizeWidth,
                    i * ElementSizeHeight,
                    ElementSizeWidth, ElementSizeHeight);

            e.Graphics.DrawString(state.GetPoints.ToString(), new Font("Arial", 16), Brushes.Green, 0, 0);
            e.Graphics.DrawString((state.GetTime / 1000).ToString(), new Font("Arial", 16), Brushes.Red, 0, 25);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            state.Update();
            if (state.IsGameEnd)
                GameOver();
            Invalidate();
        }
    }
}