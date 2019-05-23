﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Piano
{
    public class SettingsForm : Form
    {
        private readonly ComboBox modeBox = new ComboBox();
        private readonly ComboBox loadBox = new ComboBox();
        private readonly ComboBox inputControlBox = new ComboBox();
        private readonly Button okButton = new Button();
        private readonly GameSettings settings;

        private readonly Dictionary<string, Type> modes;
        private readonly Dictionary<string, Type> loaders;
        private readonly Dictionary<string, Type> inputControls;

        public SettingsForm(GameSettings settings, LoadConfig config)
        {
            this.settings = settings;
            modes = config.Modes;
            loaders = config.Loaders;
            inputControls = config.InputControls;

            InitializeComponent(modes.Keys.ToArray(), loaders.Keys.ToArray(), inputControls.Keys.ToArray());
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((modeBox.SelectedIndex > -1) && (loadBox.SelectedIndex > -1))
                okButton.Enabled = true;
        }

        private void ModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.ModeTypeName = modes[modeBox.SelectedItem.ToString()].Name;
        }

        private void LoadBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.LoaderTypeName = loaders[loadBox.SelectedItem.ToString()].Name;
        }

        private void InputControlBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.InputTypeName = inputControls[inputControlBox.SelectedItem.ToString()].Name;
        }

        private void OkClick(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeComponent(object[] modes, object[] loaders, object[] controls)
        {
            this.SuspendLayout();

            modeBox.Items.AddRange(modes);
            loadBox.Items.AddRange(loaders);
            inputControlBox.Items.AddRange(controls);


            modeBox.Location = new System.Drawing.Point(10, 10);
            modeBox.Size = new System.Drawing.Size(200, 60);

            loadBox.Location = new System.Drawing.Point(10, 70);
            loadBox.Size = new System.Drawing.Size(200, 60);

            inputControlBox.Location = new System.Drawing.Point(10, 40);
            inputControlBox.Size = new System.Drawing.Size(200, 60);

            okButton.Location = new System.Drawing.Point(300, 50);
            okButton.Size = new System.Drawing.Size(60, 30);
            okButton.Text = "OK";
            okButton.Enabled = false;

            modeBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            modeBox.SelectedIndexChanged += ModeBox_SelectedIndexChanged;
            loadBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            loadBox.SelectedIndexChanged += LoadBox_SelectedIndexChanged;
            inputControlBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            inputControlBox.SelectedIndexChanged += InputControlBox_SelectedIndexChanged;
            okButton.Click += OkClick;

            //var melodyBox;

            Controls.Add(loadBox);
            Controls.Add(modeBox);
            Controls.Add(okButton);
            Controls.Add(inputControlBox);

            Location = new System.Drawing.Point(0, 0);
            ClientSize = new System.Drawing.Size(1000, 500);
            Name = "Game settings";
            ResumeLayout(false);
        }
    }
}
