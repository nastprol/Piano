using Domain;
using Domain.Infrastructure;
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
        private readonly OpenFileDialog fileDialog = new OpenFileDialog();
        private readonly ComboBox standardMelodiesBox = new ComboBox();
        private readonly Label label = new Label();

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

            Name = "Game settings";

            InitializeComponent(modes.Keys.ToArray(), loaders.Keys.ToArray(), inputControls.Keys.ToArray());
        }

        private void ModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.ModeTypeName = modes[modeBox.SelectedItem.ToString()].Name;
            ModeChange?.Invoke(sender, e);
        }

        private void LoadBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var loader = loaders[loadBox.SelectedItem.ToString()];
            settings.LoaderTypeName = loader.Name;
            LoaderChange?.Invoke(sender, e);

            pathBox.Hide();
            standardMelodiesBox.Hide();

            if (loader == typeof(MelodyFileLoader))            
                fileDialog.ShowDialog();            
            else if (loader == typeof(StandardMelodyLoader))
                standardMelodiesBox.Show();
            else
                pathBox.Show();            
        }

        private void InputControlBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.InputTypeName = inputControls[inputControlBox.SelectedItem.ToString()].Name;
            InputTypeChange?.Invoke(sender, e);
        }

        private void PathBox_TextChanged(object sender, EventArgs e)
        {
            settings.MelodyLocation = pathBox.Text;
            LocationChange?.Invoke(sender, e);
        }

        private void StandardMelodiesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.MelodyLocation = String.Join(" ", standardMelodiesBox.Text.Split().Skip(1));
            LocationChange?.Invoke(sender, e);
        }

        private void FileDialog_PathChanged(object sender, EventArgs e)
        {
            settings.MelodyLocation = fileDialog.FileName;
            LocationChange?.Invoke(sender, e);
            
            label.Text = fileDialog.SafeFileName;
            label.Location = new Point(10, 100);
            label.Size = new Size(200, 60);
            label.Show();
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
            standardMelodiesBox.Items.AddRange(StandardMelodyLoader.StandardMelodies
                .Keys.Select(s => "Мелодия " + s).ToArray());

            modeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            loadBox.DropDownStyle = ComboBoxStyle.DropDownList;
            inputControlBox.DropDownStyle = ComboBoxStyle.DropDownList;        
            standardMelodiesBox.DropDownStyle = ComboBoxStyle.DropDownList;

            modeBox.Location = new Point(10, 10);
            modeBox.Size = new Size(200, 60);

            loadBox.Location = new Point(10, 70);
            loadBox.Size = new Size(200, 60);

            inputControlBox.Location = new Point(10, 40);
            inputControlBox.Size = new Size(200, 60);

            pathBox.Location = new Point(10, 100);
            pathBox.Size = new Size(200, 60);
            standardMelodiesBox.Location = new Point(10, 100);
            standardMelodiesBox.Size = new Size(200, 60);

            okButton.Location = new Point(300, 50);
            okButton.Size = new Size(60, 30);
            okButton.Text = "OK";

            modeBox.SelectedIndexChanged += ModeBox_SelectedIndexChanged;
            loadBox.SelectedIndexChanged += LoadBox_SelectedIndexChanged;
            inputControlBox.SelectedIndexChanged += InputControlBox_SelectedIndexChanged;
            okButton.Click += OkClick;

            pathBox.TextChanged += PathBox_TextChanged;
            standardMelodiesBox.SelectedIndexChanged += StandardMelodiesBox_SelectedIndexChanged;
            fileDialog.FileOk += FileDialog_PathChanged;

            SelectDefaultValues();

            pathBox.Hide();
            standardMelodiesBox.Show();

            AddToControls();
           
            ResumeLayout(false);
        }

        private void SelectDefaultValues()
        {
            loadBox.SelectedIndex = 1;
            modeBox.SelectedIndex = 1;
            inputControlBox.SelectedIndex = 1;
            standardMelodiesBox.SelectedIndex = 0;
        }

        private void AddToControls()
        {
            Controls.Add(loadBox);
            Controls.Add(modeBox);
            Controls.Add(okButton);
            Controls.Add(inputControlBox);
            Controls.Add(pathBox);
            Controls.Add(standardMelodiesBox);
            Controls.Add(label);
        }
    }
}