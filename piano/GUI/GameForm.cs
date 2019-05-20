using System;
using System.Drawing;
using System.Windows.Forms;
using Piano.Game.State;

namespace Piano
{
    public sealed class GameForm : Form
    {
        private const int ElementSizeHeight = 100;
        private const int ElementSizeWidth = 50;
        private readonly IGame state;
        private readonly Controller controller;

        public GameForm(IGame state, Controller controller)
        {
            DoubleBuffered = true;
            this.state = state;
            this.controller = controller;
            this.controller.Subscribe(this);
            this.controller.GameOver += GameOver;
            var map = state.Map;
            ClientSize = new Size(map.NumberInWidth * ElementSizeWidth, map.NumberInHigh * ElementSizeHeight);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            var timer = new Timer();
            timer.Tick += TimerTick;
            timer.Interval = 60;
            timer.Start();
        }

        private void GameOver()
        {
            MessageBox.Show("Game over :(");
            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var map = state.Map;
            for (var i = 0; i < map.NumberInHigh; i++)
            for (var j = 0; j < map.NumberInWidth; j++)
                e.Graphics.FillRectangle(new SolidBrush(map[map.NumberInHigh - i - 1, j].Color), j * ElementSizeWidth, i * ElementSizeHeight,
                    ElementSizeWidth, ElementSizeHeight);

            e.Graphics.DrawString(state.GetPoints.ToString(), new Font("Arial", 16), Brushes.Green, 0, 0);
            e.Graphics.DrawString((state.GetTime / 1000).ToString(), new Font("Arial", 16), Brushes.Red, 0, 25);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}