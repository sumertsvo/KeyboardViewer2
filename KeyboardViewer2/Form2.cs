﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardViewer2
{
    public partial class Form2 : Form
    {
        public bool f_right, f_left, f_up, f_down = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            Hide();
        }

        private void up_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            f_up = false;
            f_down = false;
            f_right = false;
            f_left = false;
            Properties.Settings.Default.X = Owner.Location.X;
            Properties.Settings.Default.Y = Owner.Location.Y;
            Properties.Settings.Default.Save();
        }

        private void up_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
            f_up = true;
            Owner.Location = new Point((Owner.Location.X), (Owner.Location.Y - 5));

        }

        private void left_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
            f_left = true;
            Owner.Location = new Point((Owner.Location.X - 5), (Owner.Location.Y));

        }

        private void down_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
            f_down = true;
            Owner.Location = new Point((Owner.Location.X), (Owner.Location.Y + 5));

        }

        private void right_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
            f_right = true;
            Owner.Location = new Point((Owner.Location.X + 5), (Owner.Location.Y));

        }

        private void big_Click(object sender, EventArgs e)
        {
            Owner.Height = Owner.Height + 2;
            Owner.Width = Owner.Width + 3;

            Properties.Settings.Default.Width = Owner.Width;
            Properties.Settings.Default.Height = Owner.Height;
            Properties.Settings.Default.Save();
        }

        private void little_Click(object sender, EventArgs e)
        {
            Owner.Height = Owner.Height - 2;
            Owner.Width = Owner.Width - 3;

            Properties.Settings.Default.Width = Owner.Width;
            Properties.Settings.Default.Height = Owner.Height;
            Properties.Settings.Default.Save();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Owner.Opacity = Owner.Opacity + 0.05;
            Properties.Settings.Default.Opacity = Owner.Opacity;
            Properties.Settings.Default.Save();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Owner.Opacity = Owner.Opacity - 0.05;
            Properties.Settings.Default.Opacity = Owner.Opacity;
            Properties.Settings.Default.Save();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, (Object)textBox1.Text);
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text = (Convert.ToString(e.KeyValue));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (f_right)
            {
                Owner.Location = new Point((Owner.Location.X + 5), (Owner.Location.Y));
            }
            if (f_left)
            {
                Owner.Location = new Point((Owner.Location.X - 5), (Owner.Location.Y));
            }
            if (f_up)
            {
                Owner.Location = new Point((Owner.Location.X), (Owner.Location.Y - 5));
            }
            if (f_down)
            {
                Owner.Location = new Point((Owner.Location.X), (Owner.Location.Y + 5));
            }
        }
    }
}
