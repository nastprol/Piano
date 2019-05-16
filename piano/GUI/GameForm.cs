using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using Piano;
using Piano.Game.State;

namespace Piano
{
    public class GameForm : Form
    {
        private const int ElementSize = 50;
        private readonly IGame state;

        public GameForm(IGame state)
        {
            this.state = state;
            var map = state.GetMap();
            ClientSize = new Size(map.NumberInWidth * ElementSize, map.NumberInHigh * ElementSize);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            var timer = new Timer();
            timer.Tick += TimerTick;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var map = state.GetMap();
            for (var i = 0; i < map.NumberInHigh; i++)
            for (var j = 0; j < map.NumberInWidth; j++)
                e.Graphics.FillRectangle(new SolidBrush(map[i, j].Color), i * ElementSize, j * ElementSize,
                    ElementSize, ElementSize);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}