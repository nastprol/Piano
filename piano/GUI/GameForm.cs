﻿using System;
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
        private readonly Timer timer;
        private readonly Stopwatch sw;
        private SoundPlayer player;

        public GameForm(GameState state)
        {
            DoubleBuffered = true;
            this.state = state;
            var map = state.Map;
            ClientSize = new Size(map.Width * ElementSizeWidth, map.Height * ElementSizeHeight);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            timer = new Timer();
            timer.Tick += TimerTick;
            timer.Interval = 6000;
            sw = new Stopwatch();
            player = new SoundPlayer();
        }

        protected override void OnLoad(EventArgs e)
        {
            timer.Start();
            sw.Start();
        }

        private void GameOver()
        {
            timer.Stop();
            sw.Stop();
            MessageBox.Show("Game over :(");
            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var map = state.Map;
            for (var i = 0; i < map.Height; i++)
                for (var j = 0; j < map.Width; j++)
                {
                    Color color = map[map.Height - i - 1, j].IsNote ? Color.Black : Color.White;
                    e.Graphics.FillRectangle(new SolidBrush(color), j * ElementSizeWidth,
                    i * ElementSizeHeight,
                    ElementSizeWidth, ElementSizeHeight);
                }

            e.Graphics.DrawString(state.GetPoints.ToString(), new Font("Arial", 16), Brushes.Green, 0, 0);
            e.Graphics.DrawString((sw.ElapsedMilliseconds / 1000).ToString(), new Font("Arial", 16), Brushes.Red, 0, 25);
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