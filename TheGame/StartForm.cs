﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGame
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void superButton1_Click(object sender, EventArgs e)
        {
            GameForm gf = new GameForm();
            this.Hide();
            gf.ShowDialog(this);
            Close();
        }
    }
}