﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formula_One_Game
{
    public partial class DreamTeamOptionWindow : Form
    {
        public DreamTeamOptionWindow(string message)
        {
            InitializeComponent();
            textBoxOptions.Text = message;
        }
    }
}
