﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fotone
{
    public partial class DataEntry : Form
    {
        public string hashtag;

        public DataEntry()
        {
            InitializeComponent();
            hashtag = "puertoEscondido";
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            hashtag = hashtagEntry.Text;
            this.Close();
        }
    }
}
