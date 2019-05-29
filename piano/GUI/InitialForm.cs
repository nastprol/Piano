using Domain;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace App
{
    public class InitialForm : Form
    {
        private readonly Controller controller;
        private readonly GameForm gameForm;
        private readonly Button settingsButton = new Button();
        private readonly SettingsForm settingsForm;
        private readonly Button startButton = new Button();

        public InitialForm(GameForm form, Controller controller, SettingsForm settingsForm)
        {
            this.settingsForm = settingsForm;
            gameForm = form;
            this.controller = controller;
            InitializeComponent();
        }

        private void ClickStart(object sender, EventArgs e) 
        {
            Hide();
            gameForm.ShowDialog();
            Close();
        }

        private void ClickSettings(object sender, EventArgs e)
        {
            Hide();
            settingsForm.ShowDialog();
            Show();
        }


        private void InitializeComponent()
        {
            SuspendLayout();            

            startButton.Location = new Point(300, 50);
            startButton.Size = new Size(80, 30);
            startButton.Text = "Start";

            settingsButton.Location = new Point(100, 50);
            settingsButton.Size = new Size(80, 30);
            settingsButton.Text = "Settings";
            Controls.Add(settingsButton);
            Controls.Add(startButton);

            startButton.Click += ClickStart;
            settingsButton.Click += ClickSettings;

            Location = new Point(0, 0);
            ClientSize = new Size(1000, 500);
            Name = "Menu";
            ResumeLayout(false);
        }
    }
}