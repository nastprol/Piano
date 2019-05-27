using System;
using System.Windows.Forms;

namespace Piano
{
    public class InitialForm : Form
    {
        private readonly Button startButton = new Button();
        private readonly Button settingsButton = new Button();
        private readonly GameForm gameForm;
        private readonly SettingsForm settingsForm;

        public InitialForm(GameConstructor constructor, SettingsForm settingsForm)
        {
            this.settingsForm = settingsForm;
            this.gameForm = constructor.Form;
            InitializeComponent();
        }

        private void ClickStart(object sender, EventArgs e) //После проигрыша не работает
        {
            Hide();
            gameForm.ShowDialog();
            Show();
        }

        private void ClickSettings(object sender, EventArgs e)
        {
            Hide();
            settingsForm.ShowDialog();
            Show();
        }


        private void InitializeComponent()
        {
            this.SuspendLayout();

            startButton.Location = new System.Drawing.Point(300, 50);
            startButton.Size = new System.Drawing.Size(80, 30);
            startButton.Text = "Start";

            settingsButton.Location = new System.Drawing.Point(100, 50);
            settingsButton.Size = new System.Drawing.Size(80, 30);
            settingsButton.Text = "Settings";
            Controls.Add(settingsButton);
            Controls.Add(startButton);

            startButton.Click += ClickStart;
            settingsButton.Click += ClickSettings;

            Location = new System.Drawing.Point(0, 0);
            ClientSize = new System.Drawing.Size(1000, 500);
            Name = "Menu";
            ResumeLayout(false);
        }
    }
}
