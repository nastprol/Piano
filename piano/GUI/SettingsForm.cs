﻿using Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App
{
    public class SettingsForm : Form, IInputControlChanger, ILoaderChanger, ILocationChanger, IModeChanger
    {
        private readonly ComboBox inputControlBox = new ComboBox();
        private readonly IReadOnlyDictionary<string, Type> inputControls;
        private readonly ComboBox loadBox = new ComboBox();
        private readonly IReadOnlyDictionary<string, Type> loaders;
        private readonly ComboBox modeBox = new ComboBox();

        private readonly IReadOnlyDictionary<string, Type> modes;
        private readonly Button okButton = new Button();
        private readonly TextBox pathBox = new TextBox();

        private readonly GameSettings settings;

        public event EventHandler InputTypeChange;
        public event EventHandler LoaderChange;
        public event EventHandler LocationChange;
        public event EventHandler ModeChange;

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
            if (modeBox.SelectedIndex > -1
                && loadBox.SelectedIndex > -1
                && inputControlBox.SelectedIndex > -1
                && pathBox.Text.Length > 0)
                okButton.Enabled = true;
        }

        private void ModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.ModeTypeName = modes[modeBox.SelectedItem.ToString()].Name;
            ModeChange?.Invoke(sender, e);
        }

        private void LoadBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.LoaderTypeName = loaders[loadBox.SelectedItem.ToString()].Name;
            LoaderChange?.Invoke(sender, e);
        }

        private void InputControlBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.InputTypeName = inputControls[inputControlBox.SelectedItem.ToString()].Name;
            InputTypeChange?.Invoke(sender, e);
        }

        private void pathBox_TextChanged(object sender, EventArgs e)
        {
            settings.MelodyLocation = pathBox.Text;
            LocationChange?.Invoke(sender, e);
        }

        private void OkClick(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeComponent(object[] modes, object[] loaders, object[] controls)
        {
            SuspendLayout();

            modeBox.Items.AddRange(modes);
            loadBox.Items.AddRange(loaders);
            inputControlBox.Items.AddRange(controls);


            modeBox.Location = new Point(10, 10);
            modeBox.Size = new Size(200, 60);

            loadBox.Location = new Point(10, 70);
            loadBox.Size = new Size(200, 60);

            inputControlBox.Location = new Point(10, 40);
            inputControlBox.Size = new Size(200, 60);

            pathBox.Location = new Point(10, 100);
            pathBox.Size = new Size(200, 60);

            okButton.Location = new Point(300, 50);
            okButton.Size = new Size(60, 30);
            okButton.Text = "OK";
            okButton.Enabled = false;

            modeBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            modeBox.SelectedIndexChanged += ModeBox_SelectedIndexChanged;
            loadBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            loadBox.SelectedIndexChanged += LoadBox_SelectedIndexChanged;
            inputControlBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            inputControlBox.SelectedIndexChanged += InputControlBox_SelectedIndexChanged;
            okButton.Click += OkClick;
            pathBox.TextChanged += pathBox_TextChanged;
            pathBox.TextChanged += ComboBox_SelectedIndexChanged;
            inputControlBox.TextChanged += ComboBox_SelectedIndexChanged;


            Controls.Add(loadBox);
            Controls.Add(modeBox);
            Controls.Add(okButton);
            Controls.Add(inputControlBox);
            Controls.Add(pathBox);

            Location = new Point(0, 0);
            ClientSize = new Size(1000, 500);
            Name = "Game settings";
            ResumeLayout(false);
        }
    }
}