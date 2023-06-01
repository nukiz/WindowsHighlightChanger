using HighlightColorChanger.util;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// author - nuk @ 1/6/2023
/// clock - 23:41 GMT+2
///</summary>

namespace HighlightColorChanger
{
    public partial class Main : Form
    {
        public Color NewHighlightColor = Color.FromArgb(0, 120, 255);
        public Color NewBoxColor = Color.FromArgb(0, 120, 215);

        bool mouseDown;
        Point lastLocation;

        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1: Press either one of the boxes filled with color. " +
                            "\n2: Select a custom color or one of the presets shown in the pop-up menu." +
                            "\n3: After selecting a color (preferrably the SAME color for BOTH of the boxes) press APPLY!" +
                            "\n4: The changes will come to effect after RESTARTING your PC." +
                            "\n" +
                            "\nPlease note that this software is pretty experimental, and that messing around MIGHT cause damage" +
                            " to your color settings. With this in mind, remember that the author of this software is not responsible" +
                            " for any damage caused by this software (highly unlikely there will be any but still...)", 
                            "How to Use - github.com/nukiz", MessageBoxButtons.OK);
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
             RegistryUtil.SetColorFromRegistry(NewHighlightColor, NewBoxColor);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            ColorDialog.ShowDialog();
            NewHighlightColor = ColorDialog.Color;
            panel1.BackColor = ColorDialog.Color;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            ColorDialog.ShowDialog();
            NewBoxColor = ColorDialog.Color;
            panel2.BackColor = ColorDialog.Color;
        }

        /// <summary>
        /// Not a very smart way of doing this but I don't mind as I'm tired...
        /// Lmao!
        /// </summary>

        private void SyncButton_Click(object sender, EventArgs e)
        {
            NewBoxColor = NewHighlightColor = ColorDialog2.Color = ColorDialog.Color;
            panel1.BackColor = panel2.BackColor = ColorDialog2.Color = ColorDialog.Color;
        }

        private void GithubButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/nukiz/");
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                (Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
            }
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
