using System;
using System.Drawing;
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
            ClientSize = new Size(state.GetMap.GetLength(0) * ElementSize, state.GetMap.GetLength(1) * ElementSize);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            var timer = new Timer();
            timer.Tick += TimerTick;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var map = state.GetMap;
            for (var i = 0; i < map.GetLength(0); i++)
            for (var j = 0; j < map.GetLength(1); j++)
                e.Graphics.FillRectangle(new SolidBrush(map[i, j].Color), i * ElementSize, j * ElementSize,
                    ElementSize, ElementSize);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}