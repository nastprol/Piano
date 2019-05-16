using System;
using System.Drawing;
using System.Windows.Forms;
using Piano.Game.State;

namespace Piano
{
    public class GameForm : Form
    {
        private const int ElementSizeHeight = 100;
        private const int ElementSizeWidth = 50;
        private readonly IGame state;
        private Controller controller;

        public GameForm(IGame state)
        {
            this.state = state;
            var map = state.GetMap();
            ClientSize = new Size(map.NumberInWidth * ElementSizeWidth, map.NumberInHigh * ElementSizeHeight);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            var timer = new Timer();
            timer.Tick += TimerTick;
            timer.Interval = 60;
            timer.Start();
        }

        public void AddController(Controller controller)
        {
            this.controller = controller;
            this.controller.gameOver += GameOver;
        }

        private void GameOver()
        {
            MessageBox.Show("Game over :(");
            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var map = state.GetMap();
            for (var i = 0; i < map.NumberInHigh; i++)
            for (var j = 0; j < map.NumberInWidth; j++)
                e.Graphics.FillRectangle(new SolidBrush(map[map.NumberInHigh - i - 1, j].Color), j * ElementSizeWidth, i * ElementSizeHeight,
                    ElementSizeWidth, ElementSizeHeight);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}